Imports Microsoft.Data.SqlClient

Public Class F_BanHang
    Private tenDN As String
    Private dtChiTiet As DataTable

    Public Sub New(ByVal userTenDN As String)
        InitializeComponent()
        Me.tenDN = userTenDN
    End Sub

    Private Sub F_BanHang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Tạo DataTable toàn cục
        dtChiTiet = New DataTable()
        dtChiTiet.Columns.Add("MaMH", GetType(Integer))
        dtChiTiet.Columns.Add("TenMH", GetType(String))
        dtChiTiet.Columns.Add("SoLuong", GetType(Integer))
        dtChiTiet.Columns.Add("Gia", GetType(Decimal))
        dtChiTiet.Columns.Add("ThanhTien", GetType(Decimal))

        ' Gán DataTable làm nguồn dữ liệu cho DataGridView
        DataGridView1.DataSource = dtChiTiet

        ' Đổi tiêu đề cột cho dễ nhìn
        With DataGridView1
            .Columns("MaMH").HeaderText = "Mã mặt hàng"
            .Columns("TenMH").HeaderText = "Tên mặt hàng"
            .Columns("SoLuong").HeaderText = "Số lượng"
            .Columns("Gia").HeaderText = "Giá"
            .Columns("ThanhTien").HeaderText = "Thành tiền"
        End With

        LoadComboBoxes()
    End Sub

    Private Sub LoadComboBoxes()
        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            ' Load KhachHang
            Dim daKH As New SqlDataAdapter("SELECT MaKH, TenKH FROM tblKhachHang", conn)
            Dim dtKH As New DataTable()
            daKH.Fill(dtKH)
            CmbKhachHang.DataSource = dtKH
            CmbKhachHang.DisplayMember = "TenKH"
            CmbKhachHang.ValueMember = "MaKH"
            CmbKhachHang.SelectedIndex = -1

            ' Load MatHang
            Dim daMH As New SqlDataAdapter("SELECT MaMH, TenMH FROM tblMatHang", conn)
            Dim dtMH As New DataTable()
            daMH.Fill(dtMH)
            CmbMatHang.DataSource = dtMH
            CmbMatHang.DisplayMember = "TenMH"
            CmbMatHang.ValueMember = "MaMH"
            CmbMatHang.SelectedIndex = -1

            conn.Close()
        Catch ex As Exception
            MsgBox("Lỗi tải dữ liệu: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub BtThemVaoHD_Click(sender As Object, e As EventArgs) Handles BtThemVaoHD.Click
        If CmbKhachHang.SelectedIndex = -1 Or CmbMatHang.SelectedIndex = -1 Or TxtSoLuong.Text.Trim() = "" Then
            MsgBox("Vui lòng chọn khách hàng, mặt hàng và nhập số lượng!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        Try
            Dim soLuong As Integer = CInt(TxtSoLuong.Text)
            If soLuong <= 0 Then
                MsgBox("Số lượng phải lớn hơn 0!", vbExclamation, "Lỗi")
                Exit Sub
            End If

            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            ' Kiểm tra số lượng tồn kho
            Dim cmdCheck As New SqlCommand("SELECT SoLuong, Gia FROM tblMatHang WHERE MaMH=@MaMH", conn)
            cmdCheck.Parameters.AddWithValue("@MaMH", CInt(CmbMatHang.SelectedValue))
            Dim reader As SqlDataReader = cmdCheck.ExecuteReader()
            If reader.Read() Then
                Dim soLuongTon As Integer = CInt(reader("SoLuong"))
                Dim gia As Decimal = CDec(reader("Gia"))
                reader.Close()

                If soLuong > soLuongTon Then
                    MsgBox("Số lượng tồn kho không đủ!", vbExclamation, "Lỗi")
                    conn.Close()
                    Exit Sub
                End If

                ' Thêm vào DataTable
                Dim row As DataRow = dtChiTiet.NewRow()
                row("MaMH") = CInt(CmbMatHang.SelectedValue)
                row("TenMH") = CmbMatHang.Text
                row("SoLuong") = soLuong
                row("Gia") = gia
                row("ThanhTien") = soLuong * gia
                dtChiTiet.Rows.Add(row)

                DataGridView1.DataSource = dtChiTiet
                conn.Close()
            Else
                MsgBox("Mặt hàng không tồn tại!", vbExclamation, "Lỗi")
                conn.Close()
            End If
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.Message & vbCrLf & "StackTrace: " & ex.StackTrace, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub BtThanhToan_Click(sender As Object, e As EventArgs) Handles BtThanhToan.Click
        If CmbKhachHang.SelectedIndex = -1 Then
            MsgBox("Vui lòng chọn khách hàng!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        If dtChiTiet.Rows.Count = 0 Then
            MsgBox("Hóa đơn trống!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        ' Nhập thủ công SoHieuHD
        Dim soHieuHD As String = InputBox("Nhập số hiệu hóa đơn:", "Số hiệu hóa đơn")
        If soHieuHD = "" Or Not IsNumeric(soHieuHD) Then
            MsgBox("Số hiệu hóa đơn không hợp lệ!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            ' Kiểm tra trùng SoHieuHD
            Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM tblBanHang WHERE SoHieuHD=@SoHieuHD", conn)
            checkCmd.Parameters.AddWithValue("@SoHieuHD", CInt(soHieuHD))
            If CInt(checkCmd.ExecuteScalar()) > 0 Then
                MsgBox("Số hiệu hóa đơn đã tồn tại!", vbExclamation, "Lỗi")
                conn.Close()
                Exit Sub
            End If

            ' Lấy MaNV từ TenDN
            Dim cmdNV As New SqlCommand("SELECT MaNV FROM tblNhanVien WHERE TenDN=@TenDN", conn)
            cmdNV.Parameters.AddWithValue("@TenDN", tenDN)
            Dim maNV As Integer
            Dim reader As SqlDataReader = cmdNV.ExecuteReader()
            If reader.Read() Then
                maNV = CInt(reader("MaNV"))
            Else
                MsgBox("Không tìm thấy nhân viên!", vbCritical, "Lỗi")
                conn.Close()
                Exit Sub
            End If
            reader.Close()

            ' Thêm vào tblBanHang
            Dim cmdHD As New SqlCommand("INSERT INTO tblBanHang (SoHieuHD, MaKH, MaNV, NgayBan) VALUES (@SoHieuHD, @MaKH, @MaNV, @NgayBan)", conn)
            cmdHD.Parameters.AddWithValue("@SoHieuHD", CInt(soHieuHD))
            cmdHD.Parameters.AddWithValue("@MaKH", CInt(CmbKhachHang.SelectedValue))
            cmdHD.Parameters.AddWithValue("@MaNV", maNV)
            cmdHD.Parameters.AddWithValue("@NgayBan", Date.Now)
            cmdHD.ExecuteNonQuery()

            ' Thêm chi tiết hóa đơn và cập nhật tồn kho
            For Each row As DataRow In dtChiTiet.Rows
                Dim cmdCT As New SqlCommand("INSERT INTO tblChiTietHoaDon (SoHieuHD, MaMH, SoLuong, ThanhTien) VALUES (@SoHieuHD, @MaMH, @SoLuong, @ThanhTien)", conn)
                cmdCT.Parameters.AddWithValue("@SoHieuHD", CInt(soHieuHD))
                cmdCT.Parameters.AddWithValue("@MaMH", CInt(row("MaMH")))
                cmdCT.Parameters.AddWithValue("@SoLuong", CInt(row("SoLuong")))
                cmdCT.Parameters.AddWithValue("@ThanhTien", CDec(row("ThanhTien")))
                cmdCT.ExecuteNonQuery()

                ' Cập nhật số lượng tồn kho
                Dim cmdUpdate As New SqlCommand("UPDATE tblMatHang SET SoLuong=SoLuong-@SoLuong WHERE MaMH=@MaMH", conn)
                cmdUpdate.Parameters.AddWithValue("@MaMH", CInt(row("MaMH")))
                cmdUpdate.Parameters.AddWithValue("@SoLuong", CInt(row("SoLuong")))
                cmdUpdate.ExecuteNonQuery()
            Next

            MsgBox("Thanh toán thành công! Số hiệu hóa đơn: " & soHieuHD, vbInformation, "Thành công")
            conn.Close()

            ' Reset form
            dtChiTiet.Clear()
            CmbKhachHang.SelectedIndex = -1
            CmbMatHang.SelectedIndex = -1
            TxtSoLuong.Clear()
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.Message & vbCrLf & "StackTrace: " & ex.StackTrace, vbCritical, "Lỗi")
        End Try
    End Sub
End Class
