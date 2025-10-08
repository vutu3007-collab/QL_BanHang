Imports Microsoft.Data.SqlClient

Public Class F_MatHang
    Private viTriHienTai As Integer = 0

    Private Sub F_MatHang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()
            Dim da As New SqlDataAdapter("SELECT * FROM tblMatHang", conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            DataGridView1.DataSource = dt
            conn.Close()

            ' Đặt tên cột tiếng Việt
            If DataGridView1.Columns.Count > 0 Then
                DataGridView1.Columns("MaMH").HeaderText = "Mã MH"
                DataGridView1.Columns("TenMH").HeaderText = "Tên MH"
                DataGridView1.Columns("Gia").HeaderText = "Giá"
                DataGridView1.Columns("SoLuong").HeaderText = "Số lượng"
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
            TxtMaMH.Text = row.Cells("MaMH").Value.ToString()
            TxtTenMH.Text = row.Cells("TenMH").Value.ToString()
            TxtGia.Text = row.Cells("Gia").Value.ToString()
            TxtSoLuong.Text = row.Cells("SoLuong").Value.ToString()
        End If
    End Sub

    Private Sub BtThem_Click(sender As Object, e As EventArgs) Handles BtThem.Click
        If TxtMaMH.Text.Trim() = "" Or TxtTenMH.Text.Trim() = "" Or TxtGia.Text.Trim() = "" Or TxtSoLuong.Text.Trim() = "" Then
            MsgBox("Vui lòng điền đầy đủ thông tin!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            ' Kiểm tra trùng MaMH
            Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM tblMatHang WHERE MaMH=@MaMH", conn)
            checkCmd.Parameters.AddWithValue("@MaMH", CInt(TxtMaMH.Text))
            If CInt(checkCmd.ExecuteScalar()) > 0 Then
                MsgBox("Mã mặt hàng đã tồn tại!", vbExclamation, "Lỗi")
                conn.Close()
                Exit Sub
            End If

            Dim cmd As New SqlCommand("INSERT INTO tblMatHang (MaMH, TenMH, Gia, SoLuong) VALUES (@MaMH, @TenMH, @Gia, @SoLuong)", conn)
            cmd.Parameters.AddWithValue("@MaMH", CInt(TxtMaMH.Text))
            cmd.Parameters.AddWithValue("@TenMH", TxtTenMH.Text.Trim())
            cmd.Parameters.AddWithValue("@Gia", CDec(TxtGia.Text))
            cmd.Parameters.AddWithValue("@SoLuong", CInt(TxtSoLuong.Text))

            cmd.ExecuteNonQuery()
            MsgBox("Thêm thành công!", vbInformation, "Thành công")
            conn.Close()
            LoadData()

            TxtMaMH.Clear()
            TxtTenMH.Clear()
            TxtGia.Clear()
            TxtSoLuong.Clear()
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub BtSua_Click(sender As Object, e As EventArgs) Handles BtSua.Click
        If TxtMaMH.Text.Trim() = "" Then
            MsgBox("Vui lòng chọn mặt hàng để sửa!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            Dim cmd As New SqlCommand("UPDATE tblMatHang SET TenMH=@TenMH, Gia=@Gia, SoLuong=@SoLuong WHERE MaMH=@MaMH", conn)
            cmd.Parameters.AddWithValue("@MaMH", CInt(TxtMaMH.Text))
            cmd.Parameters.AddWithValue("@TenMH", TxtTenMH.Text.Trim())
            cmd.Parameters.AddWithValue("@Gia", CDec(TxtGia.Text))
            cmd.Parameters.AddWithValue("@SoLuong", CInt(TxtSoLuong.Text))

            Dim result As Integer = cmd.ExecuteNonQuery()
            If result > 0 Then
                MsgBox("Cập nhật thành công!", vbInformation, "Thành công")
                LoadData()
            Else
                MsgBox("Mã mặt hàng không tồn tại!", vbExclamation, "Lỗi")
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub BtXoa_Click(sender As Object, e As EventArgs) Handles BtXoa.Click
        If TxtMaMH.Text.Trim() = "" Then
            MsgBox("Vui lòng chọn mặt hàng để xóa!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        If MsgBox("Bạn có chắc muốn xóa mặt hàng này?", vbQuestion + vbYesNo, "Xác nhận") = vbYes Then
            Try
                Dim conn As SqlConnection = DBConnection.GetConnection()
                conn.Open()

                Dim cmd As New SqlCommand("DELETE FROM tblMatHang WHERE MaMH=@MaMH", conn)
                cmd.Parameters.AddWithValue("@MaMH", CInt(TxtMaMH.Text))

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    MsgBox("Xóa thành công!", vbInformation, "Thành công")
                    LoadData()
                Else
                    MsgBox("Mã mặt hàng không tồn tại!", vbExclamation, "Lỗi")
                End If
                conn.Close()
            Catch ex As Exception
                MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
            End Try
        End If
    End Sub

    Private Sub BtTimKiem_Click(sender As Object, e As EventArgs) Handles BtTimKiem.Click
        Dim maMH As String = InputBox("Nhập mã mặt hàng cần tìm:", "Tìm kiếm")
        If maMH = "" Then Exit Sub

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            Dim cmd As New SqlCommand("SELECT * FROM tblMatHang WHERE MaMH=@MaMH", conn)
            cmd.Parameters.AddWithValue("@MaMH", CInt(maMH))
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                TxtMaMH.Text = dt.Rows(0)("MaMH").ToString()
                TxtTenMH.Text = dt.Rows(0)("TenMH").ToString()
                TxtGia.Text = dt.Rows(0)("Gia").ToString()
                TxtSoLuong.Text = dt.Rows(0)("SoLuong").ToString()
                DataGridView1.DataSource = dt
            Else
                MsgBox("Không tìm thấy mặt hàng!", vbExclamation, "Lỗi")
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
