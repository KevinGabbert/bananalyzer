<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrace
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTrace))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lesson 1 - Digital Gates")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lessons", New System.Windows.Forms.TreeNode() {TreeNode1})
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Binary Logic", 3, 3)
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("References", 1, 1, New System.Windows.Forms.TreeNode() {TreeNode3})
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Datasheets", 2, 2)
        Me.txtOut = New System.Windows.Forms.TextBox
        Me.tmrPlot = New System.Windows.Forms.Timer(Me.components)
        Me.hsbFrequency = New System.Windows.Forms.HScrollBar
        Me.lblAddress = New System.Windows.Forms.Label
        Me.imgLEDs = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.mnuNewProject = New System.Windows.Forms.ToolStripButton
        Me.mnuOpen = New System.Windows.Forms.ToolStripButton
        Me.mnuSave = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.cmdRun = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.CutToolStripButton = New System.Windows.Forms.ToolStripDropDownButton
        Me.mnuManageChips = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSeperator1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuCMOS = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTTL = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuInterface = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuMemory = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLinear = New System.Windows.Forms.ToolStripMenuItem
        Me.CopyToolStripButton = New System.Windows.Forms.ToolStripDropDownButton
        Me.mnuSendRowConfig = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSendRowBits = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuReadRowConfig = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuReadSamples = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuWriteMatrix = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuPrintTrace = New System.Windows.Forms.ToolStripMenuItem
        Me.PasteToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.txtClockDelay = New System.Windows.Forms.ToolStripTextBox
        Me.PanelTrace = New System.Windows.Forms.Panel
        Me.pbSelected = New System.Windows.Forms.PictureBox
        Me.PanelDigits = New System.Windows.Forms.Panel
        Me.pg = New System.Windows.Forms.PropertyGrid
        Me.PanelLCD = New System.Windows.Forms.Panel
        Me.lblDigits = New System.Windows.Forms.Label
        Me.lblLCD = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblClock = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PanelADC = New System.Windows.Forms.Panel
        Me.ADC7 = New BananaBoard.BananaADC
        Me.ADC6 = New BananaBoard.BananaADC
        Me.ADC5 = New BananaBoard.BananaADC
        Me.ADC4 = New BananaBoard.BananaADC
        Me.ADC3 = New BananaBoard.BananaADC
        Me.ADC2 = New BananaBoard.BananaADC
        Me.ADC1 = New BananaBoard.BananaADC
        Me.ADC0 = New BananaBoard.BananaADC
        Me.imgIC = New System.Windows.Forms.ImageList(Me.components)
        Me.OpenProject = New System.Windows.Forms.OpenFileDialog
        Me.SaveFile = New System.Windows.Forms.SaveFileDialog
        Me.PanelTimer = New System.Windows.Forms.Panel
        Me.COMPort = New System.IO.Ports.SerialPort(Me.components)
        Me.tabs = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.SplitDocs = New System.Windows.Forms.SplitContainer
        Me.tvwDocs = New System.Windows.Forms.TreeView
        Me.imgDocs = New System.Windows.Forms.ImageList(Me.components)
        Me.wb = New System.Windows.Forms.WebBrowser
        Me.panelBreadboard = New System.Windows.Forms.Panel
        Me.BreadBoard = New System.Windows.Forms.PictureBox
        Me.splitBreadBoard = New System.Windows.Forms.SplitContainer
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.DAC1 = New BananaBoard.BananaDAC
        Me.Pot1 = New BananaBoard.BananaPot
        Me.DAC0 = New BananaBoard.BananaDAC
        Me.Pot0 = New BananaBoard.BananaPot
        Me.panelBitEditor = New System.Windows.Forms.Panel
        Me.pbTrace = New System.Windows.Forms.PictureBox
        Me.IC24 = New System.Windows.Forms.PictureBox
        Me.IC40 = New System.Windows.Forms.PictureBox
        Me.IC8 = New System.Windows.Forms.PictureBox
        Me.IC18 = New System.Windows.Forms.PictureBox
        Me.IC28 = New System.Windows.Forms.PictureBox
        Me.IC32 = New System.Windows.Forms.PictureBox
        Me.IC20 = New System.Windows.Forms.PictureBox
        Me.IC14 = New System.Windows.Forms.PictureBox
        Me.IC16 = New System.Windows.Forms.PictureBox
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.ToolStrip1.SuspendLayout()
        Me.PanelTrace.SuspendLayout()
        CType(Me.pbSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelLCD.SuspendLayout()
        Me.PanelADC.SuspendLayout()
        Me.PanelTimer.SuspendLayout()
        Me.tabs.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SplitDocs.Panel1.SuspendLayout()
        Me.SplitDocs.Panel2.SuspendLayout()
        Me.SplitDocs.SuspendLayout()
        Me.panelBreadboard.SuspendLayout()
        CType(Me.BreadBoard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitBreadBoard.Panel1.SuspendLayout()
        Me.splitBreadBoard.Panel2.SuspendLayout()
        Me.splitBreadBoard.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.panelBitEditor.SuspendLayout()
        CType(Me.pbTrace, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IC24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IC40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IC8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IC18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IC28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IC32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IC20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IC14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IC16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtOut
        '
        Me.txtOut.BackColor = System.Drawing.Color.Blue
        Me.txtOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOut.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOut.ForeColor = System.Drawing.Color.Silver
        Me.txtOut.Location = New System.Drawing.Point(2, 2)
        Me.txtOut.Margin = New System.Windows.Forms.Padding(2)
        Me.txtOut.Multiline = True
        Me.txtOut.Name = "txtOut"
        Me.txtOut.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOut.Size = New System.Drawing.Size(640, 548)
        Me.txtOut.TabIndex = 2
        Me.txtOut.UseSystemPasswordChar = True
        '
        'tmrPlot
        '
        Me.tmrPlot.Interval = 10
        '
        'hsbFrequency
        '
        Me.hsbFrequency.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.hsbFrequency.LargeChange = 50
        Me.hsbFrequency.Location = New System.Drawing.Point(1355, 4)
        Me.hsbFrequency.Maximum = 1000
        Me.hsbFrequency.Name = "hsbFrequency"
        Me.hsbFrequency.Size = New System.Drawing.Size(199, 16)
        Me.hsbFrequency.TabIndex = 5
        '
        'lblAddress
        '
        Me.lblAddress.BackColor = System.Drawing.Color.Black
        Me.lblAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAddress.Font = New System.Drawing.Font("LED Real", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress.ForeColor = System.Drawing.Color.White
        Me.lblAddress.Location = New System.Drawing.Point(1, 22)
        Me.lblAddress.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAddress.Size = New System.Drawing.Size(153, 24)
        Me.lblAddress.TabIndex = 6
        Me.lblAddress.Text = "0"
        Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imgLEDs
        '
        Me.imgLEDs.ImageStream = CType(resources.GetObject("imgLEDs.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLEDs.TransparentColor = System.Drawing.Color.Transparent
        Me.imgLEDs.Images.SetKeyName(0, "LED0.bmp")
        Me.imgLEDs.Images.SetKeyName(1, "LED1.bmp")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNewProject, Me.mnuOpen, Me.mnuSave, Me.toolStripSeparator, Me.cmdRun, Me.toolStripSeparator1, Me.CutToolStripButton, Me.CopyToolStripButton, Me.PasteToolStripButton, Me.txtClockDelay})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1444, 25)
        Me.ToolStrip1.TabIndex = 16
        Me.ToolStrip1.Text = "ts"
        '
        'mnuNewProject
        '
        Me.mnuNewProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.mnuNewProject.Image = CType(resources.GetObject("mnuNewProject.Image"), System.Drawing.Image)
        Me.mnuNewProject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuNewProject.Name = "mnuNewProject"
        Me.mnuNewProject.Size = New System.Drawing.Size(23, 22)
        Me.mnuNewProject.Text = "&New"
        '
        'mnuOpen
        '
        Me.mnuOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.mnuOpen.Image = CType(resources.GetObject("mnuOpen.Image"), System.Drawing.Image)
        Me.mnuOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuOpen.Name = "mnuOpen"
        Me.mnuOpen.Size = New System.Drawing.Size(23, 22)
        Me.mnuOpen.Text = "&Open"
        '
        'mnuSave
        '
        Me.mnuSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.mnuSave.Image = CType(resources.GetObject("mnuSave.Image"), System.Drawing.Image)
        Me.mnuSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuSave.Name = "mnuSave"
        Me.mnuSave.Size = New System.Drawing.Size(23, 22)
        Me.mnuSave.Text = "&Save"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'cmdRun
        '
        Me.cmdRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdRun.Image = Global.BananaSerial.My.Resources.Resources.Run
        Me.cmdRun.ImageTransparentColor = System.Drawing.Color.White
        Me.cmdRun.Name = "cmdRun"
        Me.cmdRun.Size = New System.Drawing.Size(23, 22)
        Me.cmdRun.Text = "&Run"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'CutToolStripButton
        '
        Me.CutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CutToolStripButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuManageChips, Me.mnuSeperator1, Me.mnuCMOS, Me.mnuTTL, Me.mnuInterface, Me.mnuMemory, Me.mnuLinear})
        Me.CutToolStripButton.Image = Global.BananaSerial.My.Resources.Resources.IC8_Pin
        Me.CutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripButton.Name = "CutToolStripButton"
        Me.CutToolStripButton.Size = New System.Drawing.Size(29, 22)
        Me.CutToolStripButton.Text = "C&ut"
        '
        'mnuManageChips
        '
        Me.mnuManageChips.Name = "mnuManageChips"
        Me.mnuManageChips.Size = New System.Drawing.Size(183, 22)
        Me.mnuManageChips.Text = "&Manage Chip Library"
        '
        'mnuSeperator1
        '
        Me.mnuSeperator1.Name = "mnuSeperator1"
        Me.mnuSeperator1.Size = New System.Drawing.Size(180, 6)
        '
        'mnuCMOS
        '
        Me.mnuCMOS.Name = "mnuCMOS"
        Me.mnuCMOS.Size = New System.Drawing.Size(183, 22)
        Me.mnuCMOS.Text = "CMOS"
        '
        'mnuTTL
        '
        Me.mnuTTL.Name = "mnuTTL"
        Me.mnuTTL.Size = New System.Drawing.Size(183, 22)
        Me.mnuTTL.Text = "TTL"
        '
        'mnuInterface
        '
        Me.mnuInterface.Name = "mnuInterface"
        Me.mnuInterface.Size = New System.Drawing.Size(183, 22)
        Me.mnuInterface.Text = "Interface"
        '
        'mnuMemory
        '
        Me.mnuMemory.Name = "mnuMemory"
        Me.mnuMemory.Size = New System.Drawing.Size(183, 22)
        Me.mnuMemory.Text = "Memory"
        '
        'mnuLinear
        '
        Me.mnuLinear.Name = "mnuLinear"
        Me.mnuLinear.Size = New System.Drawing.Size(183, 22)
        Me.mnuLinear.Text = "Linear"
        '
        'CopyToolStripButton
        '
        Me.CopyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyToolStripButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSendRowConfig, Me.mnuSendRowBits, Me.mnuReadRowConfig, Me.mnuReadSamples, Me.mnuWriteMatrix, Me.ToolStripMenuItem1, Me.mnuPrintTrace})
        Me.CopyToolStripButton.Image = Global.BananaSerial.My.Resources.Resources.LED1
        Me.CopyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripButton.Name = "CopyToolStripButton"
        Me.CopyToolStripButton.Size = New System.Drawing.Size(29, 22)
        Me.CopyToolStripButton.Text = "&Copy"
        '
        'mnuSendRowConfig
        '
        Me.mnuSendRowConfig.Name = "mnuSendRowConfig"
        Me.mnuSendRowConfig.Size = New System.Drawing.Size(237, 22)
        Me.mnuSendRowConfig.Text = "Send Row Config To ATMega"
        '
        'mnuSendRowBits
        '
        Me.mnuSendRowBits.Name = "mnuSendRowBits"
        Me.mnuSendRowBits.Size = New System.Drawing.Size(237, 22)
        Me.mnuSendRowBits.Text = "Send Row Bits to ATMega"
        '
        'mnuReadRowConfig
        '
        Me.mnuReadRowConfig.Name = "mnuReadRowConfig"
        Me.mnuReadRowConfig.Size = New System.Drawing.Size(237, 22)
        Me.mnuReadRowConfig.Text = "Read Row Config From ATMega"
        '
        'mnuReadSamples
        '
        Me.mnuReadSamples.Name = "mnuReadSamples"
        Me.mnuReadSamples.Size = New System.Drawing.Size(237, 22)
        Me.mnuReadSamples.Text = "Read Samples From ATMega"
        '
        'mnuWriteMatrix
        '
        Me.mnuWriteMatrix.Name = "mnuWriteMatrix"
        Me.mnuWriteMatrix.Size = New System.Drawing.Size(237, 22)
        Me.mnuWriteMatrix.Text = "Write LED Matrix"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(234, 6)
        '
        'mnuPrintTrace
        '
        Me.mnuPrintTrace.Name = "mnuPrintTrace"
        Me.mnuPrintTrace.Size = New System.Drawing.Size(237, 22)
        Me.mnuPrintTrace.Text = "&Print Trace"
        '
        'PasteToolStripButton
        '
        Me.PasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PasteToolStripButton.Image = CType(resources.GetObject("PasteToolStripButton.Image"), System.Drawing.Image)
        Me.PasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteToolStripButton.Name = "PasteToolStripButton"
        Me.PasteToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PasteToolStripButton.Text = "&Paste"
        Me.PasteToolStripButton.Visible = False
        '
        'txtClockDelay
        '
        Me.txtClockDelay.Name = "txtClockDelay"
        Me.txtClockDelay.Size = New System.Drawing.Size(84, 25)
        Me.txtClockDelay.Text = "100"
        Me.txtClockDelay.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtClockDelay.Visible = False
        '
        'PanelTrace
        '
        Me.PanelTrace.AutoScroll = True
        Me.PanelTrace.BackColor = System.Drawing.Color.White
        Me.PanelTrace.Controls.Add(Me.pbSelected)
        Me.PanelTrace.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelTrace.Location = New System.Drawing.Point(2, 2)
        Me.PanelTrace.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelTrace.Name = "PanelTrace"
        Me.PanelTrace.Size = New System.Drawing.Size(640, 548)
        Me.PanelTrace.TabIndex = 22
        '
        'pbSelected
        '
        Me.pbSelected.BackColor = System.Drawing.Color.White
        Me.pbSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbSelected.Location = New System.Drawing.Point(0, 0)
        Me.pbSelected.Margin = New System.Windows.Forms.Padding(2)
        Me.pbSelected.Name = "pbSelected"
        Me.pbSelected.Size = New System.Drawing.Size(136, 70)
        Me.pbSelected.TabIndex = 18
        Me.pbSelected.TabStop = False
        '
        'PanelDigits
        '
        Me.PanelDigits.BackColor = System.Drawing.Color.Black
        Me.PanelDigits.Location = New System.Drawing.Point(1, 742)
        Me.PanelDigits.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelDigits.Name = "PanelDigits"
        Me.PanelDigits.Size = New System.Drawing.Size(899, 205)
        Me.PanelDigits.TabIndex = 23
        '
        'pg
        '
        Me.pg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pg.HelpBackColor = System.Drawing.Color.White
        Me.pg.HelpForeColor = System.Drawing.Color.DarkRed
        Me.pg.Location = New System.Drawing.Point(0, 0)
        Me.pg.Margin = New System.Windows.Forms.Padding(2)
        Me.pg.Name = "pg"
        Me.pg.Size = New System.Drawing.Size(468, 241)
        Me.pg.TabIndex = 10
        Me.pg.ToolbarVisible = False
        Me.pg.ViewBackColor = System.Drawing.Color.White
        Me.pg.ViewForeColor = System.Drawing.Color.Blue
        '
        'PanelLCD
        '
        Me.PanelLCD.BackColor = System.Drawing.Color.Silver
        Me.PanelLCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelLCD.Controls.Add(Me.lblDigits)
        Me.PanelLCD.Controls.Add(Me.lblLCD)
        Me.PanelLCD.Location = New System.Drawing.Point(769, 649)
        Me.PanelLCD.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelLCD.Name = "PanelLCD"
        Me.PanelLCD.Size = New System.Drawing.Size(428, 91)
        Me.PanelLCD.TabIndex = 15
        Me.PanelLCD.Visible = False
        '
        'lblDigits
        '
        Me.lblDigits.BackColor = System.Drawing.Color.Black
        Me.lblDigits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDigits.Font = New System.Drawing.Font("LED Real", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDigits.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblDigits.Location = New System.Drawing.Point(343, 30)
        Me.lblDigits.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDigits.Name = "lblDigits"
        Me.lblDigits.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDigits.Size = New System.Drawing.Size(82, 58)
        Me.lblDigits.TabIndex = 0
        Me.lblDigits.Text = "00000 0x0000"
        Me.lblDigits.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLCD
        '
        Me.lblLCD.BackColor = System.Drawing.Color.White
        Me.lblLCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLCD.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblLCD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLCD.ForeColor = System.Drawing.Color.Navy
        Me.lblLCD.Location = New System.Drawing.Point(343, 0)
        Me.lblLCD.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblLCD.Name = "lblLCD"
        Me.lblLCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLCD.Size = New System.Drawing.Size(82, 32)
        Me.lblLCD.TabIndex = 9
        Me.lblLCD.Text = "Virtual LED Display"
        Me.lblLCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(0, 44)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(153, 21)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Clock Cycle"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblClock
        '
        Me.lblClock.BackColor = System.Drawing.Color.Black
        Me.lblClock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblClock.Font = New System.Drawing.Font("LED Real", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClock.ForeColor = System.Drawing.Color.White
        Me.lblClock.Location = New System.Drawing.Point(0, 66)
        Me.lblClock.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblClock.Name = "lblClock"
        Me.lblClock.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblClock.Size = New System.Drawing.Size(153, 25)
        Me.lblClock.TabIndex = 16
        Me.lblClock.Text = "0"
        Me.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(0, 1)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(153, 21)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Run Cycle"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelADC
        '
        Me.PanelADC.BackColor = System.Drawing.Color.DimGray
        Me.PanelADC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelADC.Controls.Add(Me.ADC7)
        Me.PanelADC.Controls.Add(Me.ADC6)
        Me.PanelADC.Controls.Add(Me.ADC5)
        Me.PanelADC.Controls.Add(Me.ADC4)
        Me.PanelADC.Controls.Add(Me.ADC3)
        Me.PanelADC.Controls.Add(Me.ADC2)
        Me.PanelADC.Controls.Add(Me.ADC1)
        Me.PanelADC.Controls.Add(Me.ADC0)
        Me.PanelADC.Location = New System.Drawing.Point(179, 21)
        Me.PanelADC.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelADC.Name = "PanelADC"
        Me.PanelADC.Size = New System.Drawing.Size(232, 184)
        Me.PanelADC.TabIndex = 19
        '
        'ADC7
        '
        Me.ADC7.Active = False
        Me.ADC7.Location = New System.Drawing.Point(114, 134)
        Me.ADC7.Margin = New System.Windows.Forms.Padding(2)
        Me.ADC7.Name = "ADC7"
        Me.ADC7.Size = New System.Drawing.Size(114, 46)
        Me.ADC7.TabIndex = 36
        '
        'ADC6
        '
        Me.ADC6.Active = False
        Me.ADC6.Location = New System.Drawing.Point(0, 134)
        Me.ADC6.Margin = New System.Windows.Forms.Padding(2)
        Me.ADC6.Name = "ADC6"
        Me.ADC6.Size = New System.Drawing.Size(114, 46)
        Me.ADC6.TabIndex = 35
        '
        'ADC5
        '
        Me.ADC5.Active = False
        Me.ADC5.Location = New System.Drawing.Point(114, 89)
        Me.ADC5.Margin = New System.Windows.Forms.Padding(2)
        Me.ADC5.Name = "ADC5"
        Me.ADC5.Size = New System.Drawing.Size(114, 46)
        Me.ADC5.TabIndex = 34
        '
        'ADC4
        '
        Me.ADC4.Active = False
        Me.ADC4.Location = New System.Drawing.Point(0, 89)
        Me.ADC4.Margin = New System.Windows.Forms.Padding(2)
        Me.ADC4.Name = "ADC4"
        Me.ADC4.Size = New System.Drawing.Size(114, 46)
        Me.ADC4.TabIndex = 33
        '
        'ADC3
        '
        Me.ADC3.Active = False
        Me.ADC3.Location = New System.Drawing.Point(114, 45)
        Me.ADC3.Margin = New System.Windows.Forms.Padding(2)
        Me.ADC3.Name = "ADC3"
        Me.ADC3.Size = New System.Drawing.Size(114, 46)
        Me.ADC3.TabIndex = 32
        '
        'ADC2
        '
        Me.ADC2.Active = False
        Me.ADC2.Location = New System.Drawing.Point(0, 45)
        Me.ADC2.Margin = New System.Windows.Forms.Padding(2)
        Me.ADC2.Name = "ADC2"
        Me.ADC2.Size = New System.Drawing.Size(114, 46)
        Me.ADC2.TabIndex = 31
        '
        'ADC1
        '
        Me.ADC1.Active = False
        Me.ADC1.Location = New System.Drawing.Point(114, 0)
        Me.ADC1.Margin = New System.Windows.Forms.Padding(2)
        Me.ADC1.Name = "ADC1"
        Me.ADC1.Size = New System.Drawing.Size(114, 46)
        Me.ADC1.TabIndex = 30
        '
        'ADC0
        '
        Me.ADC0.Active = False
        Me.ADC0.Location = New System.Drawing.Point(0, 0)
        Me.ADC0.Margin = New System.Windows.Forms.Padding(2)
        Me.ADC0.Name = "ADC0"
        Me.ADC0.Size = New System.Drawing.Size(114, 46)
        Me.ADC0.TabIndex = 29
        '
        'imgIC
        '
        Me.imgIC.ImageStream = CType(resources.GetObject("imgIC.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgIC.TransparentColor = System.Drawing.Color.Transparent
        Me.imgIC.Images.SetKeyName(0, "IC8 Pin.bmp")
        Me.imgIC.Images.SetKeyName(1, "IC16 Pin.bmp")
        '
        'OpenProject
        '
        Me.OpenProject.DefaultExt = "bbp"
        Me.OpenProject.Filter = "Banana Board Projects|*.bbp"
        Me.OpenProject.InitialDirectory = "f:\code\pport\lpt\LPT.NET\bin"
        '
        'SaveFile
        '
        Me.SaveFile.DefaultExt = "bbp"
        Me.SaveFile.Filter = "Banana Board Projects|*.bbp"
        '
        'PanelTimer
        '
        Me.PanelTimer.Controls.Add(Me.lblClock)
        Me.PanelTimer.Controls.Add(Me.lblAddress)
        Me.PanelTimer.Controls.Add(Me.Label2)
        Me.PanelTimer.Controls.Add(Me.Label1)
        Me.PanelTimer.Location = New System.Drawing.Point(87, 225)
        Me.PanelTimer.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelTimer.Name = "PanelTimer"
        Me.PanelTimer.Size = New System.Drawing.Size(155, 93)
        Me.PanelTimer.TabIndex = 29
        Me.PanelTimer.Visible = False
        '
        'COMPort
        '
        Me.COMPort.BaudRate = 57600
        Me.COMPort.PortName = "COM4"
        '
        'tabs
        '
        Me.tabs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabs.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabs.Controls.Add(Me.TabPage1)
        Me.tabs.Controls.Add(Me.TabPage2)
        Me.tabs.Controls.Add(Me.TabPage3)
        Me.tabs.Location = New System.Drawing.Point(748, 42)
        Me.tabs.Margin = New System.Windows.Forms.Padding(2)
        Me.tabs.Name = "tabs"
        Me.tabs.SelectedIndex = 0
        Me.tabs.Size = New System.Drawing.Size(652, 580)
        Me.tabs.TabIndex = 30
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PanelTrace)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Size = New System.Drawing.Size(644, 552)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Trace"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.PanelTimer)
        Me.TabPage2.Controls.Add(Me.txtOut)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Size = New System.Drawing.Size(644, 552)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Analog"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.SplitDocs)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(644, 552)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Resources"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'SplitDocs
        '
        Me.SplitDocs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitDocs.Location = New System.Drawing.Point(0, 0)
        Me.SplitDocs.Name = "SplitDocs"
        '
        'SplitDocs.Panel1
        '
        Me.SplitDocs.Panel1.Controls.Add(Me.tvwDocs)
        '
        'SplitDocs.Panel2
        '
        Me.SplitDocs.Panel2.Controls.Add(Me.wb)
        Me.SplitDocs.Size = New System.Drawing.Size(644, 552)
        Me.SplitDocs.SplitterDistance = 214
        Me.SplitDocs.TabIndex = 0
        '
        'tvwDocs
        '
        Me.tvwDocs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwDocs.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvwDocs.ImageIndex = 0
        Me.tvwDocs.ImageList = Me.imgDocs
        Me.tvwDocs.Location = New System.Drawing.Point(0, 0)
        Me.tvwDocs.Name = "tvwDocs"
        TreeNode1.Name = "nodeLesson1"
        TreeNode1.Tag = "F:\Code\Banana Board\Documents\Lessons\Lesson1.htm"
        TreeNode1.Text = "Lesson 1 - Digital Gates"
        TreeNode2.ImageIndex = 0
        TreeNode2.Name = "nodeLessons"
        TreeNode2.Text = "Lessons"
        TreeNode3.ImageIndex = 3
        TreeNode3.Name = "Node3"
        TreeNode3.SelectedImageIndex = 3
        TreeNode3.Tag = "F:\Code\Banana Board\Documents\References\Binary Logic.htm"
        TreeNode3.Text = "Binary Logic"
        TreeNode4.ImageIndex = 1
        TreeNode4.Name = "nodeReferences"
        TreeNode4.SelectedImageIndex = 1
        TreeNode4.Text = "References"
        TreeNode5.ImageIndex = 2
        TreeNode5.Name = "nodeDatasheets"
        TreeNode5.SelectedImageIndex = 2
        TreeNode5.Text = "Datasheets"
        Me.tvwDocs.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode2, TreeNode4, TreeNode5})
        Me.tvwDocs.SelectedImageIndex = 0
        Me.tvwDocs.ShowRootLines = False
        Me.tvwDocs.Size = New System.Drawing.Size(214, 552)
        Me.tvwDocs.TabIndex = 0
        '
        'imgDocs
        '
        Me.imgDocs.ImageStream = CType(resources.GetObject("imgDocs.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgDocs.TransparentColor = System.Drawing.Color.Transparent
        Me.imgDocs.Images.SetKeyName(0, "lesson.gif")
        Me.imgDocs.Images.SetKeyName(1, "references.png")
        Me.imgDocs.Images.SetKeyName(2, "datasheets.gif")
        Me.imgDocs.Images.SetKeyName(3, "binary.gif")
        '
        'wb
        '
        Me.wb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wb.Location = New System.Drawing.Point(0, 0)
        Me.wb.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wb.Name = "wb"
        Me.wb.Size = New System.Drawing.Size(426, 552)
        Me.wb.TabIndex = 0
        Me.wb.Url = New System.Uri("about:blank", System.UriKind.Absolute)
        '
        'panelBreadboard
        '
        Me.panelBreadboard.BackColor = System.Drawing.Color.White
        Me.panelBreadboard.Controls.Add(Me.BreadBoard)
        Me.panelBreadboard.Location = New System.Drawing.Point(0, 1)
        Me.panelBreadboard.Margin = New System.Windows.Forms.Padding(2)
        Me.panelBreadboard.Name = "panelBreadboard"
        Me.panelBreadboard.Size = New System.Drawing.Size(426, 1241)
        Me.panelBreadboard.TabIndex = 33
        '
        'BreadBoard
        '
        Me.BreadBoard.Image = Global.BananaSerial.My.Resources.Resources.breadboard_top_64_rows
        Me.BreadBoard.Location = New System.Drawing.Point(101, 0)
        Me.BreadBoard.Margin = New System.Windows.Forms.Padding(2)
        Me.BreadBoard.Name = "BreadBoard"
        Me.BreadBoard.Size = New System.Drawing.Size(251, 1344)
        Me.BreadBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.BreadBoard.TabIndex = 15
        Me.BreadBoard.TabStop = False
        '
        'splitBreadBoard
        '
        Me.splitBreadBoard.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.splitBreadBoard.Location = New System.Drawing.Point(0, 24)
        Me.splitBreadBoard.Margin = New System.Windows.Forms.Padding(2)
        Me.splitBreadBoard.Name = "splitBreadBoard"
        Me.splitBreadBoard.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitBreadBoard.Panel1
        '
        Me.splitBreadBoard.Panel1.AutoScroll = True
        Me.splitBreadBoard.Panel1.Controls.Add(Me.TabControl1)
        '
        'splitBreadBoard.Panel2
        '
        Me.splitBreadBoard.Panel2.Controls.Add(Me.panelBitEditor)
        Me.splitBreadBoard.Panel2.Controls.Add(Me.pg)
        Me.splitBreadBoard.Size = New System.Drawing.Size(468, 620)
        Me.splitBreadBoard.SplitterDistance = 310
        Me.splitBreadBoard.TabIndex = 34
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(468, 310)
        Me.TabControl1.TabIndex = 34
        '
        'TabPage4
        '
        Me.TabPage4.AutoScroll = True
        Me.TabPage4.Controls.Add(Me.panelBreadboard)
        Me.TabPage4.Location = New System.Drawing.Point(4, 24)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(460, 282)
        Me.TabPage4.TabIndex = 0
        Me.TabPage4.Text = "BananaBoard"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.AutoScroll = True
        Me.TabPage5.BackColor = System.Drawing.Color.Silver
        Me.TabPage5.Controls.Add(Me.DAC1)
        Me.TabPage5.Controls.Add(Me.Pot1)
        Me.TabPage5.Controls.Add(Me.PanelADC)
        Me.TabPage5.Controls.Add(Me.DAC0)
        Me.TabPage5.Controls.Add(Me.Pot0)
        Me.TabPage5.Location = New System.Drawing.Point(4, 25)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(460, 281)
        Me.TabPage5.TabIndex = 1
        Me.TabPage5.Text = "Analog Devices"
        '
        'DAC1
        '
        Me.DAC1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DAC1.Location = New System.Drawing.Point(90, 160)
        Me.DAC1.Margin = New System.Windows.Forms.Padding(2)
        Me.DAC1.Name = "DAC1"
        Me.DAC1.Size = New System.Drawing.Size(85, 120)
        Me.DAC1.TabIndex = 1
        '
        'Pot1
        '
        Me.Pot1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pot1.Location = New System.Drawing.Point(91, 21)
        Me.Pot1.Margin = New System.Windows.Forms.Padding(2)
        Me.Pot1.Name = "Pot1"
        Me.Pot1.Size = New System.Drawing.Size(85, 120)
        Me.Pot1.TabIndex = 1
        '
        'DAC0
        '
        Me.DAC0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DAC0.Location = New System.Drawing.Point(2, 160)
        Me.DAC0.Margin = New System.Windows.Forms.Padding(2)
        Me.DAC0.Name = "DAC0"
        Me.DAC0.Size = New System.Drawing.Size(85, 120)
        Me.DAC0.TabIndex = 0
        '
        'Pot0
        '
        Me.Pot0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pot0.Location = New System.Drawing.Point(3, 21)
        Me.Pot0.Margin = New System.Windows.Forms.Padding(2)
        Me.Pot0.Name = "Pot0"
        Me.Pot0.Size = New System.Drawing.Size(85, 120)
        Me.Pot0.TabIndex = 0
        '
        'panelBitEditor
        '
        Me.panelBitEditor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.panelBitEditor.AutoScroll = True
        Me.panelBitEditor.BackColor = System.Drawing.Color.White
        Me.panelBitEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelBitEditor.Controls.Add(Me.pbTrace)
        Me.panelBitEditor.Location = New System.Drawing.Point(1, 241)
        Me.panelBitEditor.Margin = New System.Windows.Forms.Padding(2)
        Me.panelBitEditor.Name = "panelBitEditor"
        Me.panelBitEditor.Size = New System.Drawing.Size(466, 64)
        Me.panelBitEditor.TabIndex = 32
        '
        'pbTrace
        '
        Me.pbTrace.BackColor = System.Drawing.Color.White
        Me.pbTrace.Location = New System.Drawing.Point(0, 0)
        Me.pbTrace.Margin = New System.Windows.Forms.Padding(2)
        Me.pbTrace.Name = "pbTrace"
        Me.pbTrace.Size = New System.Drawing.Size(5119, 48)
        Me.pbTrace.TabIndex = 30
        Me.pbTrace.TabStop = False
        '
        'IC24
        '
        Me.IC24.BackColor = System.Drawing.Color.Transparent
        Me.IC24.Image = Global.BananaSerial.My.Resources.Resources.IC_24_Pin
        Me.IC24.Location = New System.Drawing.Point(561, 295)
        Me.IC24.Margin = New System.Windows.Forms.Padding(2)
        Me.IC24.Name = "IC24"
        Me.IC24.Size = New System.Drawing.Size(168, 229)
        Me.IC24.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.IC24.TabIndex = 35
        Me.IC24.TabStop = False
        Me.IC24.Visible = False
        '
        'IC40
        '
        Me.IC40.BackColor = System.Drawing.Color.Transparent
        Me.IC40.Image = Global.BananaSerial.My.Resources.Resources.IC_40_Pin
        Me.IC40.Location = New System.Drawing.Point(223, 23)
        Me.IC40.Margin = New System.Windows.Forms.Padding(2)
        Me.IC40.Name = "IC40"
        Me.IC40.Size = New System.Drawing.Size(168, 388)
        Me.IC40.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.IC40.TabIndex = 32
        Me.IC40.TabStop = False
        Me.IC40.Visible = False
        '
        'IC8
        '
        Me.IC8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IC8.BackColor = System.Drawing.Color.Transparent
        Me.IC8.Image = CType(resources.GetObject("IC8.Image"), System.Drawing.Image)
        Me.IC8.Location = New System.Drawing.Point(228, 566)
        Me.IC8.Margin = New System.Windows.Forms.Padding(2)
        Me.IC8.Name = "IC8"
        Me.IC8.Size = New System.Drawing.Size(84, 78)
        Me.IC8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.IC8.TabIndex = 24
        Me.IC8.TabStop = False
        Me.IC8.Visible = False
        '
        'IC18
        '
        Me.IC18.BackColor = System.Drawing.Color.Transparent
        Me.IC18.Image = Global.BananaSerial.My.Resources.Resources.IC_18_Pin
        Me.IC18.Location = New System.Drawing.Point(475, 470)
        Me.IC18.Margin = New System.Windows.Forms.Padding(2)
        Me.IC18.Name = "IC18"
        Me.IC18.Size = New System.Drawing.Size(84, 174)
        Me.IC18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.IC18.TabIndex = 31
        Me.IC18.TabStop = False
        Me.IC18.Visible = False
        '
        'IC28
        '
        Me.IC28.BackColor = System.Drawing.Color.Transparent
        Me.IC28.Image = Global.BananaSerial.My.Resources.Resources.IC_28_Pin
        Me.IC28.Location = New System.Drawing.Point(559, 23)
        Me.IC28.Margin = New System.Windows.Forms.Padding(2)
        Me.IC28.Name = "IC28"
        Me.IC28.Size = New System.Drawing.Size(168, 271)
        Me.IC28.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.IC28.TabIndex = 28
        Me.IC28.TabStop = False
        Me.IC28.Visible = False
        '
        'IC32
        '
        Me.IC32.BackColor = System.Drawing.Color.Transparent
        Me.IC32.Image = Global.BananaSerial.My.Resources.Resources.IC_32_Pin
        Me.IC32.Location = New System.Drawing.Point(391, 23)
        Me.IC32.Margin = New System.Windows.Forms.Padding(2)
        Me.IC32.Name = "IC32"
        Me.IC32.Size = New System.Drawing.Size(168, 310)
        Me.IC32.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.IC32.TabIndex = 27
        Me.IC32.TabStop = False
        Me.IC32.Visible = False
        '
        'IC20
        '
        Me.IC20.BackColor = System.Drawing.Color.Transparent
        Me.IC20.Image = Global.BananaSerial.My.Resources.Resources.IC_20_Pin
        Me.IC20.Location = New System.Drawing.Point(559, 450)
        Me.IC20.Margin = New System.Windows.Forms.Padding(2)
        Me.IC20.Name = "IC20"
        Me.IC20.Size = New System.Drawing.Size(84, 194)
        Me.IC20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.IC20.TabIndex = 26
        Me.IC20.TabStop = False
        Me.IC20.Visible = False
        '
        'IC14
        '
        Me.IC14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IC14.BackColor = System.Drawing.Color.Transparent
        Me.IC14.Image = Global.BananaSerial.My.Resources.Resources.IC14_Pin
        Me.IC14.Location = New System.Drawing.Point(308, 509)
        Me.IC14.Margin = New System.Windows.Forms.Padding(2)
        Me.IC14.Name = "IC14"
        Me.IC14.Size = New System.Drawing.Size(84, 136)
        Me.IC14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.IC14.TabIndex = 25
        Me.IC14.TabStop = False
        Me.IC14.Visible = False
        '
        'IC16
        '
        Me.IC16.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IC16.BackColor = System.Drawing.Color.Transparent
        Me.IC16.Image = CType(resources.GetObject("IC16.Image"), System.Drawing.Image)
        Me.IC16.Location = New System.Drawing.Point(392, 490)
        Me.IC16.Margin = New System.Windows.Forms.Padding(2)
        Me.IC16.Name = "IC16"
        Me.IC16.Size = New System.Drawing.Size(84, 155)
        Me.IC16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.IC16.TabIndex = 19
        Me.IC16.TabStop = False
        Me.IC16.Visible = False
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintDocument1
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'frmTrace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1444, 743)
        Me.Controls.Add(Me.IC24)
        Me.Controls.Add(Me.splitBreadBoard)
        Me.Controls.Add(Me.IC40)
        Me.Controls.Add(Me.IC8)
        Me.Controls.Add(Me.IC18)
        Me.Controls.Add(Me.tabs)
        Me.Controls.Add(Me.IC28)
        Me.Controls.Add(Me.PanelLCD)
        Me.Controls.Add(Me.PanelDigits)
        Me.Controls.Add(Me.IC32)
        Me.Controls.Add(Me.IC20)
        Me.Controls.Add(Me.IC14)
        Me.Controls.Add(Me.IC16)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.hsbFrequency)
        Me.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmTrace"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmTrace"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.PanelTrace.ResumeLayout(False)
        CType(Me.pbSelected, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelLCD.ResumeLayout(False)
        Me.PanelADC.ResumeLayout(False)
        Me.PanelTimer.ResumeLayout(False)
        Me.tabs.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.SplitDocs.Panel1.ResumeLayout(False)
        Me.SplitDocs.Panel2.ResumeLayout(False)
        Me.SplitDocs.ResumeLayout(False)
        Me.panelBreadboard.ResumeLayout(False)
        Me.panelBreadboard.PerformLayout()
        CType(Me.BreadBoard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitBreadBoard.Panel1.ResumeLayout(False)
        Me.splitBreadBoard.Panel2.ResumeLayout(False)
        Me.splitBreadBoard.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.panelBitEditor.ResumeLayout(False)
        CType(Me.pbTrace, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IC24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IC40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IC8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IC18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IC28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IC32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IC20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IC14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IC16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtOut As System.Windows.Forms.TextBox
    Friend WithEvents tmrPlot As System.Windows.Forms.Timer
    Friend WithEvents hsbFrequency As System.Windows.Forms.HScrollBar
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents imgLEDs As System.Windows.Forms.ImageList
    Friend WithEvents LED As System.Windows.Forms.PictureBox
    Friend WithEvents BreadBoard As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents pbSelected As System.Windows.Forms.PictureBox
    Friend WithEvents IC16 As System.Windows.Forms.PictureBox
    Friend WithEvents mnuNewProject As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdRun As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PasteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PanelTrace As System.Windows.Forms.Panel
    Friend WithEvents PanelDigits As System.Windows.Forms.Panel
    Friend WithEvents lblDigits As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblLCD As System.Windows.Forms.Label
    Friend WithEvents IC8 As System.Windows.Forms.PictureBox
    Friend WithEvents CutToolStripButton As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuManageChips As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCMOS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTTL As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLinear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents imgIC As System.Windows.Forms.ImageList
    Friend WithEvents OpenProject As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents pg As System.Windows.Forms.PropertyGrid
    Friend WithEvents IC14 As System.Windows.Forms.PictureBox
    Friend WithEvents IC20 As System.Windows.Forms.PictureBox
    Friend WithEvents IC32 As System.Windows.Forms.PictureBox
    Friend WithEvents IC28 As System.Windows.Forms.PictureBox
    Friend WithEvents PanelLCD As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblClock As System.Windows.Forms.Label
    Friend WithEvents DAC1 As BananaBoard.BananaDAC
    Friend WithEvents DAC0 As BananaBoard.BananaDAC
    Friend WithEvents PanelADC As System.Windows.Forms.Panel
    Friend WithEvents ADC7 As BananaBoard.BananaADC
    Friend WithEvents ADC6 As BananaBoard.BananaADC
    Friend WithEvents ADC5 As BananaBoard.BananaADC
    Friend WithEvents ADC4 As BananaBoard.BananaADC
    Friend WithEvents ADC3 As BananaBoard.BananaADC
    Friend WithEvents ADC2 As BananaBoard.BananaADC
    Friend WithEvents ADC1 As BananaBoard.BananaADC
    Friend WithEvents ADC0 As BananaBoard.BananaADC
    Friend WithEvents PanelTimer As System.Windows.Forms.Panel
    Friend WithEvents COMPort As System.IO.Ports.SerialPort
    Friend WithEvents CopyToolStripButton As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuReadRowConfig As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReadSamples As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSendRowConfig As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSendRowBits As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtClockDelay As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tabs As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents IC18 As System.Windows.Forms.PictureBox
    Friend WithEvents IC40 As System.Windows.Forms.PictureBox
    Friend WithEvents mnuSeperator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuMemory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuInterface As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Pot1 As BananaBoard.BananaPot
    Friend WithEvents Pot0 As BananaBoard.BananaPot
    Friend WithEvents panelBreadboard As System.Windows.Forms.Panel
    Friend WithEvents splitBreadBoard As System.Windows.Forms.SplitContainer
    Friend WithEvents panelBitEditor As System.Windows.Forms.Panel
    Friend WithEvents pbTrace As System.Windows.Forms.PictureBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents SplitDocs As System.Windows.Forms.SplitContainer
    Friend WithEvents tvwDocs As System.Windows.Forms.TreeView
    Friend WithEvents imgDocs As System.Windows.Forms.ImageList
    Friend WithEvents wb As System.Windows.Forms.WebBrowser
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents mnuWriteMatrix As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IC24 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPrintTrace As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
End Class
