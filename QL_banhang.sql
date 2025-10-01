-- Tạo Database
CREATE DATABASE QuanLyBanHang;
GO

USE QuanLyBanHang;
GO

-- Tạo bảng Khách Hàng
CREATE TABLE tblKhachHang (
    MaKH INT PRIMARY KEY, -- Không có IDENTITY để nhập thủ công
    TenKH NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(255),
    SoDienThoai NVARCHAR(15)
);

-- Tạo bảng Mặt Hàng
CREATE TABLE tblMatHang (
    MaMH INT PRIMARY KEY, -- Không có IDENTITY để nhập thủ công
    TenMH NVARCHAR(100) NOT NULL,
    Gia DECIMAL(18,2) NOT NULL,
    SoLuong INT NOT NULL
);

-- Tạo bảng Bán Hàng (Hóa Đơn)
CREATE TABLE tblBanHang (
    SoHieuHD INT PRIMARY KEY, -- Không có IDENTITY để nhập thủ công
    NgayBan DATE NOT NULL,
    MaKH INT NOT NULL,
    CONSTRAINT FK_BanHang_KhachHang FOREIGN KEY (MaKH)
    REFERENCES tblKhachHang (MaKH) ON DELETE CASCADE
);

-- Tạo bảng Chi Tiết Hóa Đơn
CREATE TABLE tblChiTietHoaDon (
    SoHieuHD INT NOT NULL,
    MaMH INT NOT NULL,
    SoLuong INT NOT NULL,
    ThanhTien DECIMAL(18,2) NOT NULL,
    PRIMARY KEY (SoHieuHD, MaMH),
    CONSTRAINT FK_ChiTietHoaDon_BanHang FOREIGN KEY (SoHieuHD)
    REFERENCES tblBanHang (SoHieuHD) ON DELETE CASCADE,
    CONSTRAINT FK_ChiTietHoaDon_MatHang FOREIGN KEY (MaMH)
    REFERENCES tblMatHang (MaMH) ON DELETE CASCADE
);


-- Thêm bảng Tài khoản (với quyền)
CREATE TABLE tblTaikhoan (
    TenDN NVARCHAR(50) PRIMARY KEY,
    Matkhau NVARCHAR(50) NOT NULL,
    Quyen NVARCHAR(20) NOT NULL -- 'Admin' hoặc 'NhanVien'
);

-- Thêm bảng Nhân viên
CREATE TABLE tblNhanVien (
    MaNV INT PRIMARY KEY, -- Không IDENTITY
    TenNV NVARCHAR(100) NOT NULL,
    ChucVu NVARCHAR(50),
    TenDN NVARCHAR(50) NOT NULL,
    CONSTRAINT FK_NhanVien_Taikhoan FOREIGN KEY (TenDN)
    REFERENCES tblTaikhoan (TenDN) ON DELETE CASCADE
);

-- Thêm cột MaNV vào tblBanHang
ALTER TABLE tblBanHang
ADD MaNV INT NOT NULL;

ALTER TABLE tblBanHang
ADD CONSTRAINT FK_BanHang_NhanVien FOREIGN KEY (MaNV)
REFERENCES tblNhanVien (MaNV) ON DELETE CASCADE;

-- Dữ liệu mẫu (thêm để test)
INSERT INTO tblTaikhoan (TenDN, Matkhau, Quyen) VALUES ('admin', 'admin123', 'Admin');
INSERT INTO tblTaikhoan (TenDN, Matkhau, Quyen) VALUES ('nhanvien1', 'nv123', 'NhanVien');

INSERT INTO tblNhanVien (MaNV, TenNV, ChucVu, TenDN) VALUES (1, 'Admin User', 'Quan Ly', 'admin');
INSERT INTO tblNhanVien (MaNV, TenNV, ChucVu, TenDN) VALUES (2, 'Nhan Vien Ban Hang', 'Ban Hang', 'nhanvien1');


select * from tblChiTietHoaDon;