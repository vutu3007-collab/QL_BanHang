Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient

Public Class F_KhachHang
    Private viTriHienTai As Integer = 0

    Private Sub F_KhachHang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()
            Dim da As New SqlDataAdapter("SELECT * FROM tblKhachHang", conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            DataGridView1.DataSource = dt
            conn.Close()

            ' Đặt tên cột tiếng Việt
            If DataGridView1.Columns.Count > 0 Then
                DataGridView1.Columns("MaKH").HeaderText = "Mã KH"
                DataGridView1.Columns("TenKH").HeaderText = "Tên KH"
                DataGridView1.Columns("DiaChi").HeaderText = "Địa Chỉ"
                DataGridView1.Columns("SoDienThoai").HeaderText = "Số ĐT"
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
            TxtMaKH.Text = row.Cells("MaKH").Value.ToString()
            TxtTenKH.Text = row.Cells("TenKH").Value.ToString()
            TxtDiaChi.Text = row.Cells("DiaChi").Value.ToString()
            TxtSoDT.Text = row.Cells("SoDienThoai").Value.ToString()
        End If
    End Sub

    Private Sub BtThem_Click(sender As Object, e As EventArgs) Handles BtThem.Click
        If TxtMaKH.Text.Trim() = "" Or TxtTenKH.Text.Trim() = "" Then
            MsgBox("Mã KH và Tên KH không được để trống!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            ' Kiểm tra trùng MaKH
            Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM tblKhachHang WHERE MaKH=@MaKH", conn)
            checkCmd.Parameters.AddWithValue("@MaKH", CInt(TxtMaKH.Text))
            If CInt(checkCmd.ExecuteScalar()) > 0 Then
                MsgBox("Mã khách hàng đã tồn tại!", vbExclamation, "Lỗi")
                conn.Close()
                Exit Sub
            End If

            Dim cmd As New SqlCommand("INSERT INTO tblKhachHang (MaKH, TenKH, DiaChi, SoDienThoai) VALUES (@MaKH, @TenKH, @DiaChi, @SoDT)", conn)
            cmd.Parameters.AddWithValue("@MaKH", CInt(TxtMaKH.Text))
            cmd.Parameters.AddWithValue("@TenKH", TxtTenKH.Text.Trim())
            cmd.Parameters.AddWithValue("@DiaChi", TxtDiaChi.Text.Trim())
            cmd.Parameters.AddWithValue("@SoDT", TxtSoDT.Text.Trim())

            cmd.ExecuteNonQuery()
            MsgBox("Thêm thành công!", vbInformation, "Thành công")
            conn.Close()
            LoadData()

            TxtMaKH.Clear()
            TxtTenKH.Clear()
            TxtDiaChi.Clear()
            TxtSoDT.Clear()
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub BtSua_Click(sender As Object, e As EventArgs) Handles BtSua.Click
        If TxtMaKH.Text.Trim() = "" Then
            MsgBox("Vui lòng chọn khách hàng để sửa!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            Dim cmd As New SqlCommand("UPDATE tblKhachHang SET TenKH=@TenKH, DiaChi=@DiaChi, SoDienThoai=@SoDT WHERE MaKH=@MaKH", conn)
            cmd.Parameters.AddWithValue("@MaKH", CInt(TxtMaKH.Text))
            cmd.Parameters.AddWithValue("@TenKH", TxtTenKH.Text.Trim())
            cmd.Parameters.AddWithValue("@DiaChi", TxtDiaChi.Text.Trim())
            cmd.Parameters.AddWithValue("@SoDT", TxtSoDT.Text.Trim())

            Dim result As Integer = cmd.ExecuteNonQuery()
            If result > 0 Then
                MsgBox("Cập nhật thành công!", vbInformation, "Thành công")
                LoadData()
            Else
                MsgBox("Mã khách hàng không tồn tại!", vbExclamation, "Lỗi")
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub BtXoa_Click(sender As Object, e As EventArgs) Handles BtXoa.Click
        If TxtMaKH.Text.Trim() = "" Then
            MsgBox("Vui lòng chọn khách hàng để xóa!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        If MsgBox("Bạn có chắc muốn xóa khách hàng này?", vbQuestion + vbYesNo, "Xác nhận") = vbYes Then
            Try
                Dim conn As SqlConnection = DBConnection.GetConnection()
                conn.Open()

                Dim cmd As New SqlCommand("DELETE FROM tblKhachHang WHERE MaKH=@MaKH", conn)
                cmd.Parameters.AddWithValue("@MaKH", CInt(TxtMaKH.Text))

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    MsgBox("Xóa thành công!", vbInformation, "Thành công")
                    LoadData()
                Else
                    MsgBox("Mã khách hàng không tồn tại!", vbExclamation, "Lỗi")
                End If
                conn.Close()
            Catch ex As Exception
                MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
            End Try
        End If
    End Sub

    Private Sub BtTimKiem_Click(sender As Object, e As EventArgs) Handles BtTimKiem.Click
        Dim maKH As String = InputBox("Nhập mã khách hàng cần tìm:", "Tìm kiếm")
        If maKH = "" Then Exit Sub

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            Dim cmd As New SqlCommand("SELECT * FROM tblKhachHang WHERE MaKH=@MaKH", conn)
            cmd.Parameters.AddWithValue("@MaKH", CInt(maKH))
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                TxtMaKH.Text = dt.Rows(0)("MaKH").ToString()
                TxtTenKH.Text = dt.Rows(0)("TenKH").ToString()
                TxtDiaChi.Text = dt.Rows(0)("DiaChi").ToString()
                TxtSoDT.Text = dt.Rows(0)("SoDienThoai").ToString()
                DataGridView1.DataSource = dt
            Else
                MsgBox("Không tìm thấy khách hàng!", vbExclamation, "Lỗi")
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