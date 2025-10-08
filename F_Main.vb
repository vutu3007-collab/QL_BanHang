Public Class F_Main
    Private quyen As String
    Private tenDN As String

    Public Sub New(ByVal userQuyen As String, ByVal userTenDN As String)
        InitializeComponent()
        Me.quyen = userQuyen
        Me.tenDN = userTenDN
    End Sub

    Private Sub F_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If quyen = "NhanVien" Then
            MenuNhanVien.Visible = False
            MenuKhachHang.Visible = False
            MenuMatHang.Visible = False
        End If
    End Sub

    Private Sub MenuKhachHang_Click(sender As Object, e As EventArgs) Handles MenuKhachHang.Click
        Dim f As New F_KhachHang()
        f.ShowDialog()
    End Sub

    Private Sub MenuMatHang_Click(sender As Object, e As EventArgs) Handles MenuMatHang.Click
        Dim f As New F_MatHang()
        f.ShowDialog()
    End Sub

    Private Sub MenuNhanVien_Click(sender As Object, e As EventArgs) Handles MenuNhanVien.Click
        Dim f As New F_NhanVien()
        f.ShowDialog()
    End Sub

    Private Sub MenuBanHang_Click(sender As Object, e As EventArgs) Handles MenuBanHang.Click
        Dim f As New F_BanHang(tenDN) ' Truyền tenDN vào constructor
        f.ShowDialog()
    End Sub

    'Private Sub MenuBaoCao_Click(sender As Object, e As EventArgs) Handles MenuBaoCao.Click
    '    Dim f As New F_BaoCao()
    '    f.ShowDialog()
    'End Sub

    Private Sub MenuDangKy_Click(sender As Object, e As EventArgs) Handles MenuDangKy.Click
        If quyen <> "Admin" Then
            MsgBox("Chỉ quản lý có quyền đăng ký tài khoản mới!", vbExclamation, "Lỗi")
            Exit Sub
        End If
        Dim f As New F_DangKy()
        f.ShowDialog()
    End Sub

    Private Sub MenuDangXuat_Click(sender As Object, e As EventArgs) Handles MenuDangXuat.Click
        Me.Close()
        Dim login As New F_DangNhap()
        login.Show()
    End Sub

    Private Sub MenuQuanLyDonHang_Click(sender As Object, e As EventArgs) Handles MenuQuanLyDonHang.Click
        Dim f As New F_BaoCao()
        f.ShowDialog()
    End Sub
End Class