<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_BanHang
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_BanHang))
        BtThemVaoHD = New Button()
        CmbKhachHang = New ComboBox()
        Label4 = New Label()
        Label1 = New Label()
        CmbMatHang = New ComboBox()
        Label2 = New Label()
        Label3 = New Label()
        TxtSoLuong = New TextBox()
        BtThanhToan = New Button()
        DataGridView1 = New DataGridView()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BtThemVaoHD
        ' 
        BtThemVaoHD.BackColor = Color.Lime
        BtThemVaoHD.Location = New Point(315, 233)
        BtThemVaoHD.Name = "BtThemVaoHD"
        BtThemVaoHD.Size = New Size(184, 34)
        BtThemVaoHD.TabIndex = 11
        BtThemVaoHD.Text = "Thêm vào hóa đơn"
        BtThemVaoHD.UseVisualStyleBackColor = False
        ' 
        ' CmbKhachHang
        ' 
        CmbKhachHang.FormattingEnabled = True
        CmbKhachHang.Location = New Point(315, 93)
        CmbKhachHang.Name = "CmbKhachHang"
        CmbKhachHang.Size = New Size(380, 33)
        CmbKhachHang.TabIndex = 10
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(205, 93)
        Label4.Name = "Label4"
        Label4.Size = New Size(104, 25)
        Label4.TabIndex = 9
        Label4.Text = "Khách hàng"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI Black", 15F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(401, 27)
        Label1.Name = "Label1"
        Label1.Size = New Size(187, 41)
        Label1.TabIndex = 13
        Label1.Text = "BÁN HÀNG"
        ' 
        ' CmbMatHang
        ' 
        CmbMatHang.FormattingEnabled = True
        CmbMatHang.Location = New Point(315, 137)
        CmbMatHang.Name = "CmbMatHang"
        CmbMatHang.Size = New Size(380, 33)
        CmbMatHang.TabIndex = 14
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(205, 137)
        Label2.Name = "Label2"
        Label2.Size = New Size(88, 25)
        Label2.TabIndex = 15
        Label2.Text = "Mặt hàng"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(205, 187)
        Label3.Name = "Label3"
        Label3.Size = New Size(85, 25)
        Label3.TabIndex = 16
        Label3.Text = "Số lượng"
        ' 
        ' TxtSoLuong
        ' 
        TxtSoLuong.Location = New Point(315, 184)
        TxtSoLuong.Name = "TxtSoLuong"
        TxtSoLuong.Size = New Size(380, 31)
        TxtSoLuong.TabIndex = 17
        ' 
        ' BtThanhToan
        ' 
        BtThanhToan.BackColor = Color.Fuchsia
        BtThanhToan.Location = New Point(511, 233)
        BtThanhToan.Name = "BtThanhToan"
        BtThanhToan.Size = New Size(184, 34)
        BtThanhToan.TabIndex = 18
        BtThanhToan.Text = "Thanh toán"
        BtThanhToan.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(55, 273)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 62
        DataGridView1.Size = New Size(846, 361)
        DataGridView1.TabIndex = 19
        ' 
        ' F_BanHang
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(953, 698)
        Controls.Add(DataGridView1)
        Controls.Add(BtThanhToan)
        Controls.Add(TxtSoLuong)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(CmbMatHang)
        Controls.Add(Label1)
        Controls.Add(BtThemVaoHD)
        Controls.Add(CmbKhachHang)
        Controls.Add(Label4)
        Name = "F_BanHang"
        Text = "F_BanHang"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents BtThemVaoHD As Button
    Friend WithEvents CmbKhachHang As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CmbMatHang As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtSoLuong As TextBox
    Friend WithEvents BtThanhToan As Button
    Friend WithEvents DataGridView1 As DataGridView
End Class
