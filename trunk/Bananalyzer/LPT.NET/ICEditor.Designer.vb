<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ICEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ICEditor))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.mnuNewChip = New System.Windows.Forms.ToolStripDropDownButton
        Me.mnuAdd8Pin = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAdd14Pin = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAdd16Pin = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAdd18Pin = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAdd20Pin = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAdd24Pin = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAdd28Pin = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAdd32Pin = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAdd40Pin = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.mnuSaveChip = New System.Windows.Forms.ToolStripButton
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.CutToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.CopyToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PasteToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.cboFamily = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.cboIC = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.HelpToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.pg = New System.Windows.Forms.PropertyGrid
        Me.ChipPic = New System.Windows.Forms.PictureBox
        Me.OpenProject = New System.Windows.Forms.OpenFileDialog
        Me.SaveFile = New System.Windows.Forms.SaveFileDialog
        Me.imgRowIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.pbTrace = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ToolStrip1.SuspendLayout()
        CType(Me.ChipPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbTrace, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNewChip, Me.OpenToolStripButton, Me.mnuSaveChip, Me.PrintToolStripButton, Me.toolStripSeparator, Me.CutToolStripButton, Me.CopyToolStripButton, Me.PasteToolStripButton, Me.toolStripSeparator1, Me.ToolStripLabel1, Me.cboFamily, Me.ToolStripLabel2, Me.cboIC, Me.ToolStripSeparator2, Me.HelpToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(732, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'mnuNewChip
        '
        Me.mnuNewChip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.mnuNewChip.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAdd8Pin, Me.mnuAdd14Pin, Me.mnuAdd16Pin, Me.mnuAdd18Pin, Me.mnuAdd20Pin, Me.mnuAdd24Pin, Me.mnuAdd28Pin, Me.mnuAdd32Pin, Me.mnuAdd40Pin})
        Me.mnuNewChip.Image = Global.BananaSerial.My.Resources.Resources.IC8_Pin
        Me.mnuNewChip.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuNewChip.Name = "mnuNewChip"
        Me.mnuNewChip.Size = New System.Drawing.Size(29, 22)
        Me.mnuNewChip.Text = "C&ut"
        '
        'mnuAdd8Pin
        '
        Me.mnuAdd8Pin.Name = "mnuAdd8Pin"
        Me.mnuAdd8Pin.Size = New System.Drawing.Size(114, 22)
        Me.mnuAdd8Pin.Text = "8 Pin"
        '
        'mnuAdd14Pin
        '
        Me.mnuAdd14Pin.Name = "mnuAdd14Pin"
        Me.mnuAdd14Pin.Size = New System.Drawing.Size(114, 22)
        Me.mnuAdd14Pin.Text = "14 Pin"
        '
        'mnuAdd16Pin
        '
        Me.mnuAdd16Pin.Name = "mnuAdd16Pin"
        Me.mnuAdd16Pin.Size = New System.Drawing.Size(114, 22)
        Me.mnuAdd16Pin.Text = "16 Pin"
        '
        'mnuAdd18Pin
        '
        Me.mnuAdd18Pin.Name = "mnuAdd18Pin"
        Me.mnuAdd18Pin.Size = New System.Drawing.Size(114, 22)
        Me.mnuAdd18Pin.Text = "18 Pin"
        '
        'mnuAdd20Pin
        '
        Me.mnuAdd20Pin.Name = "mnuAdd20Pin"
        Me.mnuAdd20Pin.Size = New System.Drawing.Size(114, 22)
        Me.mnuAdd20Pin.Text = "20 Pin"
        '
        'mnuAdd24Pin
        '
        Me.mnuAdd24Pin.Name = "mnuAdd24Pin"
        Me.mnuAdd24Pin.Size = New System.Drawing.Size(114, 22)
        Me.mnuAdd24Pin.Text = "24 Pin"
        '
        'mnuAdd28Pin
        '
        Me.mnuAdd28Pin.Name = "mnuAdd28Pin"
        Me.mnuAdd28Pin.Size = New System.Drawing.Size(114, 22)
        Me.mnuAdd28Pin.Text = "28 Pin"
        '
        'mnuAdd32Pin
        '
        Me.mnuAdd32Pin.Name = "mnuAdd32Pin"
        Me.mnuAdd32Pin.Size = New System.Drawing.Size(114, 22)
        Me.mnuAdd32Pin.Text = "32 Pin"
        '
        'mnuAdd40Pin
        '
        Me.mnuAdd40Pin.Name = "mnuAdd40Pin"
        Me.mnuAdd40Pin.Size = New System.Drawing.Size(114, 22)
        Me.mnuAdd40Pin.Text = "40 Pin"
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "&Open"
        '
        'mnuSaveChip
        '
        Me.mnuSaveChip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.mnuSaveChip.Image = CType(resources.GetObject("mnuSaveChip.Image"), System.Drawing.Image)
        Me.mnuSaveChip.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuSaveChip.Name = "mnuSaveChip"
        Me.mnuSaveChip.Size = New System.Drawing.Size(23, 22)
        Me.mnuSaveChip.Text = "&Save"
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'CutToolStripButton
        '
        Me.CutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CutToolStripButton.Image = CType(resources.GetObject("CutToolStripButton.Image"), System.Drawing.Image)
        Me.CutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripButton.Name = "CutToolStripButton"
        Me.CutToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CutToolStripButton.Text = "C&ut"
        '
        'CopyToolStripButton
        '
        Me.CopyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyToolStripButton.Image = CType(resources.GetObject("CopyToolStripButton.Image"), System.Drawing.Image)
        Me.CopyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripButton.Name = "CopyToolStripButton"
        Me.CopyToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CopyToolStripButton.Text = "&Copy"
        '
        'PasteToolStripButton
        '
        Me.PasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PasteToolStripButton.Image = CType(resources.GetObject("PasteToolStripButton.Image"), System.Drawing.Image)
        Me.PasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteToolStripButton.Name = "PasteToolStripButton"
        Me.PasteToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PasteToolStripButton.Text = "&Paste"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel1.Text = "Family"
        '
        'cboFamily
        '
        Me.cboFamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFamily.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFamily.Items.AddRange(New Object() {"CMOS", "TTL", "INTERFACE", "MEMORY", "LINEAR"})
        Me.cboFamily.Name = "cboFamily"
        Me.cboFamily.Size = New System.Drawing.Size(90, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(18, 22)
        Me.ToolStripLabel2.Text = "IC"
        '
        'cboIC
        '
        Me.cboIC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboIC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboIC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboIC.MaxDropDownItems = 20
        Me.cboIC.Name = "cboIC"
        Me.cboIC.Size = New System.Drawing.Size(321, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'HelpToolStripButton
        '
        Me.HelpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.HelpToolStripButton.Image = CType(resources.GetObject("HelpToolStripButton.Image"), System.Drawing.Image)
        Me.HelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.HelpToolStripButton.Name = "HelpToolStripButton"
        Me.HelpToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.HelpToolStripButton.Text = "He&lp"
        '
        'pg
        '
        Me.pg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pg.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.pg.HelpBackColor = System.Drawing.Color.White
        Me.pg.HelpForeColor = System.Drawing.Color.DarkRed
        Me.pg.LineColor = System.Drawing.Color.DimGray
        Me.pg.Location = New System.Drawing.Point(245, 25)
        Me.pg.Name = "pg"
        Me.pg.Size = New System.Drawing.Size(487, 428)
        Me.pg.TabIndex = 29
        Me.pg.ViewBackColor = System.Drawing.Color.White
        Me.pg.ViewForeColor = System.Drawing.Color.Blue
        '
        'ChipPic
        '
        Me.ChipPic.BackColor = System.Drawing.Color.Transparent
        Me.ChipPic.Location = New System.Drawing.Point(0, 25)
        Me.ChipPic.Name = "ChipPic"
        Me.ChipPic.Size = New System.Drawing.Size(145, 335)
        Me.ChipPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ChipPic.TabIndex = 28
        Me.ChipPic.TabStop = False
        Me.ChipPic.Visible = False
        '
        'OpenProject
        '
        Me.OpenProject.DefaultExt = "bcp"
        Me.OpenProject.Filter = "BananaChips|*.bcp"
        Me.OpenProject.InitialDirectory = "f:\code\pport\lpt\LPT.NET\bin"
        '
        'SaveFile
        '
        Me.SaveFile.DefaultExt = "bcp"
        Me.SaveFile.Filter = "BananaChips|*.bcp"
        '
        'imgRowIcons
        '
        Me.imgRowIcons.ImageStream = CType(resources.GetObject("imgRowIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgRowIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.imgRowIcons.Images.SetKeyName(0, "Input.bmp")
        Me.imgRowIcons.Images.SetKeyName(1, "Output.bmp")
        Me.imgRowIcons.Images.SetKeyName(2, "Clock.bmp")
        Me.imgRowIcons.Images.SetKeyName(3, "Inverted Clock.bmp")
        Me.imgRowIcons.Images.SetKeyName(4, "Scripted Bits.bmp")
        Me.imgRowIcons.Images.SetKeyName(5, "Output High.bmp")
        Me.imgRowIcons.Images.SetKeyName(6, "VCC.bmp")
        Me.imgRowIcons.Images.SetKeyName(7, "GND.bmp")
        Me.imgRowIcons.Images.SetKeyName(8, "NC.bmp")
        Me.imgRowIcons.Images.SetKeyName(9, "Analog.bmp")
        Me.imgRowIcons.Images.SetKeyName(10, "Input Grey.bmp")
        Me.imgRowIcons.Images.SetKeyName(11, "Output Grey.bmp")
        Me.imgRowIcons.Images.SetKeyName(12, "Clock Grey.bmp")
        Me.imgRowIcons.Images.SetKeyName(13, "Inverted Clock Grey.bmp")
        Me.imgRowIcons.Images.SetKeyName(14, "Scripted Bits Grey.bmp")
        '
        'pbTrace
        '
        Me.pbTrace.BackColor = System.Drawing.Color.White
        Me.pbTrace.Location = New System.Drawing.Point(0, 0)
        Me.pbTrace.Name = "pbTrace"
        Me.pbTrace.Size = New System.Drawing.Size(5120, 52)
        Me.pbTrace.TabIndex = 30
        Me.pbTrace.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.pbTrace)
        Me.Panel1.Location = New System.Drawing.Point(0, 455)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(734, 70)
        Me.Panel1.TabIndex = 31
        '
        'ICEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(732, 523)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ChipPic)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.pg)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ICEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BananaChip"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.ChipPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbTrace, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuSaveChip As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CopyToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PasteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ChipPic As System.Windows.Forms.PictureBox
    Friend WithEvents mnuNewChip As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuAdd8Pin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAdd14Pin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAdd16Pin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAdd18Pin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAdd20Pin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAdd28Pin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAdd32Pin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAdd40Pin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pg As System.Windows.Forms.PropertyGrid
    Friend WithEvents OpenProject As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cboFamily As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboIC As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents imgRowIcons As System.Windows.Forms.ImageList
    Friend WithEvents pbTrace As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents mnuAdd24Pin As System.Windows.Forms.ToolStripMenuItem
End Class
