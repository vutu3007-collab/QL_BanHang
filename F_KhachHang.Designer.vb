<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_KhachHang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_KhachHang))
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        TxtTenKH = New TextBox()
        TxtDiaChi = New TextBox()
        TxtSoDT = New TextBox()
        DataGridView1 = New DataGridView()
        BtThem = New Button()
        BtSua = New Button()
        BtXoa = New Button()
        BtTimKiem = New Button()
        BtDau = New Button()
        BtTruoc = New Button()
        BtSau = New Button()
        BtCuoi = New Button()
        BtThoat = New Button()
        Label5 = New Label()
        TxtMaKH = New TextBox()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.White
        Label1.Font = New Font("Segoe UI Black", 15F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(288, 29)
        Label1.Name = "Label1"
        Label1.Size = New Size(373, 41)
        Label1.TabIndex = 0
        Label1.Text = "QUẢN LÝ KHÁCH HÀNG"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(219, 152)
        Label2.Name = "Label2"
        Label2.Size = New Size(66, 25)
        Label2.TabIndex = 1
        Label2.Text = "Tên KH"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(219, 256)
        Label3.Name = "Label3"
        Label3.Size = New Size(60, 25)
        Label3.TabIndex = 2
        Label3.Text = "Số ĐT"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(219, 203)
        Label4.Name = "Label4"
        Label4.Size = New Size(68, 25)
        Label4.TabIndex = 3
        Label4.Text = "Địa Chỉ"
        ' 
        ' TxtTenKH
        ' 
        TxtTenKH.Location = New Point(301, 151)
        TxtTenKH.Name = "TxtTenKH"
        TxtTenKH.Size = New Size(372, 31)
        TxtTenKH.TabIndex = 4
        ' 
        ' TxtDiaChi
        ' 
        TxtDiaChi.Location = New Point(301, 201)
        TxtDiaChi.Name = "TxtDiaChi"
        TxtDiaChi.Size = New Size(372, 31)
        TxtDiaChi.TabIndex = 5
        ' 
        ' TxtSoDT
        ' 
        TxtSoDT.Location = New Point(301, 252)
        TxtSoDT.Name = "TxtSoDT"
        TxtSoDT.Size = New Size(372, 31)
        TxtSoDT.TabIndex = 6
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(97, 348)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 62
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(776, 225)
        DataGridView1.TabIndex = 7
        ' 
        ' BtThem
        ' 
        BtThem.BackColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        BtThem.Location = New Point(250, 299)
        BtThem.Name = "BtThem"
        BtThem.Size = New Size(112, 34)
        BtThem.TabIndex = 8
        BtThem.Text = "Thêm"
        BtThem.UseVisualStyleBackColor = False
        ' 
        ' BtSua
        ' 
        BtSua.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(128))
        BtSua.Location = New Point(368, 299)
        BtSua.Name = "BtSua"
        BtSua.Size = New Size(112, 34)
        BtSua.TabIndex = 9
        BtSua.Text = "Sửa"
        BtSua.UseVisualStyleBackColor = False
        ' 
        ' BtXoa
        ' 
        BtXoa.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(128))
        BtXoa.Location = New Point(486, 299)
        BtXoa.Name = "BtXoa"
        BtXoa.Size = New Size(112, 34)
        BtXoa.TabIndex = 10
        BtXoa.Text = "Xóa"
        BtXoa.UseVisualStyleBackColor = False
        ' 
        ' BtTimKiem
        ' 
        BtTimKiem.BackColor = Color.FromArgb(CByte(128), CByte(128), CByte(255))
        BtTimKiem.Location = New Point(604, 299)
        BtTimKiem.Name = "BtTimKiem"
        BtTimKiem.Size = New Size(112, 34)
        BtTimKiem.TabIndex = 12
        BtTimKiem.Text = "Tìm Kiếm"
        BtTimKiem.UseVisualStyleBackColor = False
        ' 
        ' BtDau
        ' 
        BtDau.Location = New Point(250, 579)
        BtDau.Name = "BtDau"
        BtDau.Size = New Size(112, 34)
        BtDau.TabIndex = 13
        BtDau.Text = "Đầu"
        BtDau.UseVisualStyleBackColor = True
        ' 
        ' BtTruoc
        ' 
        BtTruoc.Location = New Point(368, 579)
        BtTruoc.Name = "BtTruoc"
        BtTruoc.Size = New Size(112, 34)
        BtTruoc.TabIndex = 14
        BtTruoc.Text = "Trước"
        BtTruoc.UseVisualStyleBackColor = True
        ' 
        ' BtSau
        ' 
        BtSau.Location = New Point(486, 579)
        BtSau.Name = "BtSau"
        BtSau.Size = New Size(112, 34)
        BtSau.TabIndex = 15
        BtSau.Text = "Sau"
        BtSau.UseVisualStyleBackColor = True
        ' 
        ' BtCuoi
        ' 
        BtCuoi.Location = New Point(604, 579)
        BtCuoi.Name = "BtCuoi"
        BtCuoi.Size = New Size(112, 34)
        BtCuoi.TabIndex = 16
        BtCuoi.Text = "Cuối"
        BtCuoi.UseVisualStyleBackColor = True
        ' 
        ' BtThoat
        ' 
        BtThoat.BackColor = Color.IndianRed
        BtThoat.Location = New Point(799, 29)
        BtThoat.Name = "BtThoat"
        BtThoat.Size = New Size(112, 34)
        BtThoat.TabIndex = 17
        BtThoat.Text = "Thoát"
        BtThoat.UseVisualStyleBackColor = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(219, 105)
        Label5.Name = "Label5"
        Label5.Size = New Size(65, 25)
        Label5.TabIndex = 18
        Label5.Text = "Mã KH"
        ' 
        ' TxtMaKH
        ' 
        TxtMaKH.Location = New Point(301, 105)
        TxtMaKH.Name = "TxtMaKH"
        TxtMaKH.Size = New Size(372, 31)
        TxtMaKH.TabIndex = 19
        ' 
        ' F_KhachHang
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(936, 638)
        Controls.Add(TxtMaKH)
        Controls.Add(Label5)
        Controls.Add(BtThoat)
        Controls.Add(BtCuoi)
        Controls.Add(BtSau)
        Controls.Add(BtTruoc)
        Controls.Add(BtDau)
        Controls.Add(BtTimKiem)
        Controls.Add(BtXoa)
        Controls.Add(BtSua)
        Controls.Add(BtThem)
        Controls.Add(DataGridView1)
        Controls.Add(TxtSoDT)
        Controls.Add(TxtDiaChi)
        Controls.Add(TxtTenKH)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "F_KhachHang"
        Text = "F_KhachHang"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtTenKH As TextBox
    Friend WithEvents TxtDiaChi As TextBox
    Friend WithEvents TxtSoDT As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents BtThem As Button
    Friend WithEvents BtSua As Button
    Friend WithEvents BtXoa As Button
    Friend WithEvents BtTimKiem As Button
    Friend WithEvents BtDau As Button
    Friend WithEvents BtTruoc As Button
    Friend WithEvents BtSau As Button
    Friend WithEvents BtCuoi As Button
    Friend WithEvents BtThoat As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtMaKH As TextBox
End Class
