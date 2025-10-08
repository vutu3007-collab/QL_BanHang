Imports Microsoft.Data.SqlClient

Imports System.Data.SqlClient

Public Class F_NhanVien
    Private viTriHienTai As Integer = 0

    Private Sub F_NhanVien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()
            Dim da As New SqlDataAdapter("SELECT * FROM tblNhanVien", conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            DataGridView1.DataSource = dt
            conn.Close()

            ' Đặt tên cột tiếng Việt
            If DataGridView1.Columns.Count > 0 Then
                DataGridView1.Columns("MaNV").HeaderText = "Mã NV"
                DataGridView1.Columns("TenNV").HeaderText = "Tên NV"
                DataGridView1.Columns("ChucVu").HeaderText = "Chức vụ"
                DataGridView1.Columns("TenDN").HeaderText = "Tên DN"
            End If

            If DataGridView1.Rows.Count > 0 Then
                viTriHienTai = 0
                UpdateDataGridView()
            End If
        Catch ex As Exception
            MsgBox("Lỗi tải dữ liệu: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub UpdateDataGridView()
        If DataGridView1.Rows.Count > 0 AndAlso viTriHienTai >= 0 AndAlso viTriHienTai < DataGridView1.Rows.Count Then
            DataGridView1.Rows(viTriHienTai).Selected = True
            DataGridView1.CurrentCell = DataGridView1.Rows(viTriHienTai).Cells(0)
            Dim row As DataGridViewRow = DataGridView1.Rows(viTriHienTai)
            TxtMaNV.Text = row.Cells("MaNV").Value.ToString()
            TxtTenNV.Text = row.Cells("TenNV").Value.ToString()
            TxtChucVu.Text = row.Cells("ChucVu").Value.ToString()
            TxtTenDN.Text = row.Cells("TenDN").Value.ToString()
        End If
    End Sub

    Private Sub BtThem_Click(sender As Object, e As EventArgs) Handles BtThem.Click
        If TxtMaNV.Text.Trim() = "" Or TxtTenNV.Text.Trim() = "" Or TxtChucVu.Text.Trim() = "" Or TxtTenDN.Text.Trim() = "" Then
            MsgBox("Vui lòng điền đầy đủ thông tin!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            ' Kiểm tra trùng MaNV
            Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM tblNhanVien WHERE MaNV=@MaNV", conn)
            checkCmd.Parameters.AddWithValue("@MaNV", CInt(TxtMaNV.Text))
            If CInt(checkCmd.ExecuteScalar()) > 0 Then
                MsgBox("Mã nhân viên đã tồn tại!", vbExclamation, "Lỗi")
                conn.Close()
                Exit Sub
            End If

            ' Kiểm tra TenDN có tồn tại trong tblTaikhoan
            Dim checkDN As New SqlCommand("SELECT COUNT(*) FROM tblTaikhoan WHERE TenDN=@TenDN", conn)
            checkDN.Parameters.AddWithValue("@TenDN", TxtTenDN.Text.Trim())
            If CInt(checkDN.ExecuteScalar()) = 0 Then
                MsgBox("Tên đăng nhập không tồn tại!", vbExclamation, "Lỗi")
                conn.Close()
                Exit Sub
            End If

            Dim cmd As New SqlCommand("INSERT INTO tblNhanVien (MaNV, TenNV, ChucVu, TenDN) VALUES (@MaNV, @TenNV, @ChucVu, @TenDN)", conn)
            cmd.Parameters.AddWithValue("@MaNV", CInt(TxtMaNV.Text))
            cmd.Parameters.AddWithValue("@TenNV", TxtTenNV.Text.Trim())
            cmd.Parameters.AddWithValue("@ChucVu", TxtChucVu.Text.Trim())
            cmd.Parameters.AddWithValue("@TenDN", TxtTenDN.Text.Trim())

            cmd.ExecuteNonQuery()
            MsgBox("Thêm thành công!", vbInformation, "Thành công")
            conn.Close()
            LoadData()

            TxtMaNV.Clear()
            TxtTenNV.Clear()
            TxtChucVu.Clear()
            TxtTenDN.Clear()
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub BtSua_Click(sender As Object, e As EventArgs) Handles BtSua.Click
        If TxtMaNV.Text.Trim() = "" Then
            MsgBox("Vui lòng chọn nhân viên để sửa!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            ' Kiểm tra TenDN có tồn tại trong tblTaikhoan
            Dim checkDN As New SqlCommand("SELECT COUNT(*) FROM tblTaikhoan WHERE TenDN=@TenDN", conn)
            checkDN.Parameters.AddWithValue("@TenDN", TxtTenDN.Text.Trim())
            If CInt(checkDN.ExecuteScalar()) = 0 Then
                MsgBox("Tên đăng nhập không tồn tại!", vbExclamation, "Lỗi")
                conn.Close()
                Exit Sub
            End If

            Dim cmd As New SqlCommand("UPDATE tblNhanVien SET TenNV=@TenNV, ChucVu=@ChucVu, TenDN=@TenDN WHERE MaNV=@MaNV", conn)
            cmd.Parameters.AddWithValue("@MaNV", CInt(TxtMaNV.Text))
            cmd.Parameters.AddWithValue("@TenNV", TxtTenNV.Text.Trim())
            cmd.Parameters.AddWithValue("@ChucVu", TxtChucVu.Text.Trim())
            cmd.Parameters.AddWithValue("@TenDN", TxtTenDN.Text.Trim())

            Dim result As Integer = cmd.ExecuteNonQuery()
            If result > 0 Then
                MsgBox("Cập nhật thành công!", vbInformation, "Thành công")
                LoadData()
            Else
                MsgBox("Mã nhân viên không tồn tại!", vbExclamation, "Lỗi")
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub BtXoa_Click(sender As Object, e As EventArgs) Handles BtXoa.Click
        If TxtMaNV.Text.Trim() = "" Then
            MsgBox("Vui lòng chọn nhân viên để xóa!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        If MsgBox("Bạn có chắc muốn xóa nhân viên này?", vbQuestion + vbYesNo, "Xác nhận") = vbYes Then
            Try
                Dim conn As SqlConnection = DBConnection.GetConnection()
                conn.Open()

                Dim cmd As New SqlCommand("DELETE FROM tblNhanVien WHERE MaNV=@MaNV", conn)
                cmd.Parameters.AddWithValue("@MaNV", CInt(TxtMaNV.Text))

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    MsgBox("Xóa thành công!", vbInformation, "Thành công")
                    LoadData()
                Else
                    MsgBox("Mã nhân viên không tồn tại!", vbExclamation, "Lỗi")
                End If
                conn.Close()
            Catch ex As Exception
                MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
            End Try
        End If
    End Sub

    Private Sub BtTimKiem_Click(sender As Object, e As EventArgs) Handles BtTimKiem.Click
        Dim maNV As String = InputBox("Nhập mã nhân viên cần tìm:", "Tìm kiếm")
        If maNV = "" Then Exit Sub

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            Dim cmd As New SqlCommand("SELECT * FROM tblNhanVien WHERE MaNV=@MaNV", conn)
            cmd.Parameters.AddWithValue("@MaNV", CInt(maNV))
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                TxtMaNV.Text = dt.Rows(0)("MaNV").ToString()
                TxtTenNV.Text = dt.Rows(0)("TenNV").ToString()
                TxtChucVu.Text = dt.Rows(0)("ChucVu").ToString()
                TxtTenDN.Text = dt.Rows(0)("TenDN").ToString()
                DataGridView1.DataSource = dt
            Else
                MsgBox("Không tìm thấy nhân viên!", vbExclamation, "Lỗi")
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub BtDau_Click(sender As Object, e As EventArgs) Handles BtDau.Click
        viTriHienTai = 0
        UpdateDataGridView()
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
        viTriHienTai = DataGridView1.Rows.Count - 1
        UpdateDataGridView()
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