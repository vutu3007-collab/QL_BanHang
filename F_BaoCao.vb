Imports System.IO
Imports Microsoft.Data.SqlClient


Public Class F_BaoCao
    Private viTriHienTai As Integer = 0

    Private Sub F_BaoCao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Gán hình nền
        Try
            Dim imagePath As String = Path.Combine(Application.StartupPath, "background.jpg")
            If File.Exists(imagePath) Then
                Me.BackgroundImage = Image.FromFile(imagePath)
                Me.BackgroundImageLayout = ImageLayout.Zoom
            Else
                MsgBox("Không tìm thấy file hình nền: " & imagePath, vbExclamation, "Lỗi")
            End If
        Catch ex As Exception
            MsgBox("Lỗi tải hình nền: " & ex.Message, vbExclamation, "Lỗi")
        End Try

        ' Khởi tạo DateTimePicker
        dtpTuNgay.Value = Date.Now.AddDays(-30) ' Mặc định 30 ngày trước
        dtpDenNgay.Value = Date.Now
        TxtTongDoanhThu.ReadOnly = True

        ' Tải dữ liệu
        LoadData()
    End Sub

    Private Sub LoadData(Optional maKH As String = "", Optional tuNgay As Date? = Nothing, Optional denNgay As Date? = Nothing)
        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            ' Truy vấn báo cáo: Join tblBanHang, tblKhachHang, tblNhanVien, và tính tổng tiền từ tblChiTietHoaDon
            Dim query As String = "
                SELECT 
                    bh.SoHieuHD AS [Số Hiệu HD], 
                    bh.NgayBan AS [Ngày Bán], 
                    kh.TenKH AS [Tên KH], 
                    nv.TenNV AS [Tên NV], 
                    SUM(ct.ThanhTien) AS [Tổng Tiền]
                FROM tblBanHang bh
                INNER JOIN tblKhachHang kh ON bh.MaKH = kh.MaKH
                INNER JOIN tblNhanVien nv ON bh.MaNV = nv.MaNV
                INNER JOIN tblChiTietHoaDon ct ON bh.SoHieuHD = ct.SoHieuHD
                WHERE 1=1"

            If maKH <> "" Then
                query &= " AND bh.MaKH = @MaKH"
            End If
            If tuNgay.HasValue Then
                query &= " AND bh.NgayBan >= @TuNgay"
            End If
            If denNgay.HasValue Then
                query &= " AND bh.NgayBan <= @DenNgay"
            End If
            query &= " GROUP BY bh.SoHieuHD, bh.NgayBan, kh.TenKH, nv.TenNV"

            Dim cmd As New SqlCommand(query, conn)
            If maKH <> "" Then
                cmd.Parameters.AddWithValue("@MaKH", CInt(maKH))
            End If
            If tuNgay.HasValue Then
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay.Value)
            End If
            If denNgay.HasValue Then
                cmd.Parameters.AddWithValue("@DenNgay", denNgay.Value)
            End If

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            DataGridView1.DataSource = dt

            ' Đặt tên cột tiếng Việt
            If DataGridView1.Columns.Count > 0 Then
                DataGridView1.Columns("Số Hiệu HD").HeaderText = "Số Hiệu HD"
                DataGridView1.Columns("Ngày Bán").HeaderText = "Ngày Bán"
                DataGridView1.Columns("Tên KH").HeaderText = "Tên KH"
                DataGridView1.Columns("Tên NV").HeaderText = "Tên NV"
                DataGridView1.Columns("Tổng Tiền").HeaderText = "Tổng Tiền"
            End If

            ' Tính tổng doanh thu
            Dim tongDoanhThu As Decimal = 0
            For Each row As DataRow In dt.Rows
                tongDoanhThu += CDec(row("Tổng Tiền"))
            Next
            TxtTongDoanhThu.Text = tongDoanhThu.ToString("N2") & " VND"

            ' Cập nhật vị trí hiện tại
            If DataGridView1.Rows.Count > 0 Then
                viTriHienTai = 0
                UpdateDataGridView()
            Else
                viTriHienTai = -1
            End If

            conn.Close()
        Catch ex As Exception
            MsgBox("Lỗi tải dữ liệu: " & ex.Message & vbCrLf & "StackTrace: " & ex.StackTrace, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub UpdateDataGridView()
        If DataGridView1.Rows.Count > 0 AndAlso viTriHienTai >= 0 AndAlso viTriHienTai < DataGridView1.Rows.Count Then
            DataGridView1.Rows(viTriHienTai).Selected = True
            DataGridView1.CurrentCell = DataGridView1.Rows(viTriHienTai).Cells(0)
        End If
    End Sub

    Private Sub BtDau_Click(sender As Object, e As EventArgs) Handles BtDau.Click
        If DataGridView1.Rows.Count > 0 Then
            viTriHienTai = 0
            UpdateDataGridView()
        Else
            MsgBox("Không có dữ liệu!", vbInformation, "Thông báo")
        End If
    End Sub

    Private Sub BtTruoc_Click(sender As Object, e As EventArgs) Handles BtTruoc.Click
        If viTriHienTai > 0 Then
            viTriHienTai -= 1
            UpdateDataGridView()
        Else
            MsgBox("Đã ở dòng đầu tiên!", vbInformation, "Thông báo")
        End If
    End Sub

    Private Sub BtSau_Click(sender As Object, e As EventArgs) Handles BtSau.Click
        If viTriHienTai < DataGridView1.Rows.Count - 1 Then
            viTriHienTai += 1
            UpdateDataGridView()
        Else
            MsgBox("Đã ở dòng cuối cùng!", vbInformation, "Thông báo")
        End If
    End Sub

    Private Sub BtCuoi_Click(sender As Object, e As EventArgs) Handles BtCuoi.Click
        If DataGridView1.Rows.Count > 0 Then
            viTriHienTai = DataGridView1.Rows.Count - 1
            UpdateDataGridView()
        Else
            MsgBox("Không có dữ liệu!", vbInformation, "Thông báo")
        End If
    End Sub

    Private Sub BtLoc_Click(sender As Object, e As EventArgs) Handles BtLoc.Click
        Dim maKH As String = TxtMaKH.Text.Trim()
        Dim tuNgay As Date? = dtpTuNgay.Value
        Dim denNgay As Date? = dtpDenNgay.Value

        ' Kiểm tra dữ liệu đầu vào
        If maKH <> "" AndAlso Not IsNumeric(maKH) Then
            MsgBox("Mã khách hàng phải là số!", vbExclamation, "Lỗi")
            TxtMaKH.Focus()
            Exit Sub
        End If

        If tuNgay > denNgay Then
            MsgBox("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        ' Tải dữ liệu với bộ lọc
        LoadData(maKH, tuNgay, denNgay)
    End Sub

    Private Sub BtLamMoi_Click(sender As Object, e As EventArgs) Handles BtLamMoi.Click
        ' Làm mới bộ lọc
        TxtMaKH.Clear()
        dtpTuNgay.Value = Date.Now.AddDays(-30)
        dtpDenNgay.Value = Date.Now
        LoadData()
    End Sub

    Private Sub BtThoat_Click(sender As Object, e As EventArgs) Handles BtThoat.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            viTriHienTai = e.RowIndex
            UpdateDataGridView()
        End If
    End Sub
End Class
