<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_BaoCao
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_BaoCao))
        Label1 = New Label()
        Label4 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        dtpTuNgay = New DateTimePicker()
        dtpDenNgay = New DateTimePicker()
        TxtMaKH = New TextBox()
        BtLoc = New Button()
        BtLamMoi = New Button()
        DataGridView1 = New DataGridView()
        BtThoat = New Button()
        Label5 = New Label()
        TxtTongDoanhThu = New TextBox()
        BtCuoi = New Button()
        BtSau = New Button()
        BtTruoc = New Button()
        BtDau = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI Black", 15F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(312, 23)
        Label1.Name = "Label1"
        Label1.Size = New Size(310, 41)
        Label1.TabIndex = 1
        Label1.Text = "QUẢN LÝ HÓA ĐƠN"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(45, 140)
        Label4.Name = "Label4"
        Label4.Size = New Size(133, 25)
        Label4.TabIndex = 9
        Label4.Text = "Mã khách hàng"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(45, 86)
        Label2.Name = "Label2"
        Label2.Size = New Size(76, 25)
        Label2.TabIndex = 7
        Label2.Text = "Từ ngày"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(452, 86)
        Label3.Name = "Label3"
        Label3.Size = New Size(88, 25)
        Label3.TabIndex = 13
        Label3.Text = "Đến ngày"
        ' 
        ' dtpTuNgay
        ' 
        dtpTuNgay.Location = New Point(127, 84)
        dtpTuNgay.Name = "dtpTuNgay"
        dtpTuNgay.Size = New Size(319, 31)
        dtpTuNgay.TabIndex = 14
        ' 
        ' dtpDenNgay
        ' 
        dtpDenNgay.Location = New Point(546, 84)
        dtpDenNgay.Name = "dtpDenNgay"
        dtpDenNgay.Size = New Size(319, 31)
        dtpDenNgay.TabIndex = 15
        ' 
        ' TxtMaKH
        ' 
        TxtMaKH.Location = New Point(193, 142)
        TxtMaKH.Name = "TxtMaKH"
        TxtMaKH.Size = New Size(253, 31)
        TxtMaKH.TabIndex = 16
        ' 
        ' BtLoc
        ' 
        BtLoc.BackColor = Color.FromArgb(CByte(128), CByte(128), CByte(255))
        BtLoc.Location = New Point(546, 142)
        BtLoc.Name = "BtLoc"
        BtLoc.Size = New Size(158, 34)
        BtLoc.TabIndex = 17
        BtLoc.Text = "TÌm kiếm"
        BtLoc.UseVisualStyleBackColor = False
        ' 
        ' BtLamMoi
        ' 
        BtLamMoi.BackColor = Color.Silver
        BtLamMoi.Location = New Point(707, 142)
        BtLamMoi.Name = "BtLamMoi"
        BtLamMoi.Size = New Size(158, 34)
        BtLamMoi.TabIndex = 18
        BtLamMoi.Text = "Làm mới"
        BtLamMoi.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(48, 241)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersWidth = 62
        DataGridView1.Size = New Size(817, 396)
        DataGridView1.TabIndex = 19
        ' 
        ' BtThoat
        ' 
        BtThoat.BackColor = Color.IndianRed
        BtThoat.Location = New Point(806, 23)
        BtThoat.Name = "BtThoat"
        BtThoat.Size = New Size(112, 34)
        BtThoat.TabIndex = 20
        BtThoat.Text = "Thoát"
        BtThoat.UseVisualStyleBackColor = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(394, 204)
        Label5.Name = "Label5"
        Label5.Size = New Size(159, 25)
        Label5.TabIndex = 21
        Label5.Text = "Tổng doanh thu: "
        ' 
        ' TxtTongDoanhThu
        ' 
        TxtTongDoanhThu.Enabled = False
        TxtTongDoanhThu.Location = New Point(546, 202)
        TxtTongDoanhThu.Name = "TxtTongDoanhThu"
        TxtTongDoanhThu.ReadOnly = True
        TxtTongDoanhThu.Size = New Size(319, 31)
        TxtTongDoanhThu.TabIndex = 22
        TxtTongDoanhThu.TextAlign = HorizontalAlignment.Right
        ' 
        ' BtCuoi
        ' 
        BtCuoi.Location = New Point(570, 645)
        BtCuoi.Name = "BtCuoi"
        BtCuoi.Size = New Size(112, 34)
        BtCuoi.TabIndex = 26
        BtCuoi.Text = "Cuối"
        BtCuoi.UseVisualStyleBackColor = True
        ' 
        ' BtSau
        ' 
        BtSau.Location = New Point(452, 645)
        BtSau.Name = "BtSau"
        BtSau.Size = New Size(112, 34)
        BtSau.TabIndex = 25
        BtSau.Text = "Sau"
        BtSau.UseVisualStyleBackColor = True
        ' 
        ' BtTruoc
        ' 
        BtTruoc.Location = New Point(334, 645)
        BtTruoc.Name = "BtTruoc"
        BtTruoc.Size = New Size(112, 34)
        BtTruoc.TabIndex = 24
        BtTruoc.Text = "Trước"
        BtTruoc.UseVisualStyleBackColor = True
        ' 
        ' BtDau
        ' 
        BtDau.Location = New Point(216, 645)
        BtDau.Name = "BtDau"
        BtDau.Size = New Size(112, 34)
        BtDau.TabIndex = 23
        BtDau.Text = "Đầu"
        BtDau.UseVisualStyleBackColor = True
        ' 
        ' F_BaoCao
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(930, 691)
        Controls.Add(BtCuoi)
        Controls.Add(BtSau)
        Controls.Add(BtTruoc)
        Controls.Add(BtDau)
        Controls.Add(TxtTongDoanhThu)
        Controls.Add(Label5)
        Controls.Add(BtThoat)
        Controls.Add(DataGridView1)
        Controls.Add(BtLamMoi)
        Controls.Add(BtLoc)
        Controls.Add(TxtMaKH)
        Controls.Add(dtpDenNgay)
        Controls.Add(dtpTuNgay)
        Controls.Add(Label3)
        Controls.Add(Label4)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "F_BaoCao"
        Text = "F_BaoCao"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpTuNgay As DateTimePicker
    Friend WithEvents dtpDenNgay As DateTimePicker
    Friend WithEvents TxtMaKH As TextBox
    Friend WithEvents BtLoc As Button
    Friend WithEvents BtLamMoi As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents BtThoat As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtTongDoanhThu As TextBox
    Friend WithEvents BtCuoi As Button
    Friend WithEvents BtSau As Button
    Friend WithEvents BtTruoc As Button
    Friend WithEvents BtDau As Button
End Class
