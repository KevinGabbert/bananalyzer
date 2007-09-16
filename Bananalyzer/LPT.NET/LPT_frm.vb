Option Strict Off
Option Explicit On
Friend Class LPT_Form
	Inherits System.Windows.Forms.Form
	' Parallel port monitor
	
	' PortAddress is the address of the data register.
	' PortAddress+1 is the feedback register.
	' PortAddress+2 is the control register.
	Dim PortAddress As Short
	' Flag to keep track of self-inflicted events.
	Dim Self As Boolean
	
	' Show program information.

    Const CLOCK_ON As Integer = 0
    Const CLOCK_OFF As Integer = 1
    Const RESET_ON As Integer = 0
    Const RESET_OFF As Integer = 2
    Const RW_ON As Integer = 4
    Const RW_OFF As Integer = 0
    Const SAMPLE_ON As Integer = 0
    Const SAMPLE_OFF As Integer = 8
    Const READ_ON As Integer = 32
    Const READ_OFF As Integer = 0

    Private Sub cmdRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRead.Click
        txtOut.Text = ""
        pb.Image = New Bitmap(pb.Width, pb.Height)
        ' Reset
        Out(&H378 + 2, RESET_ON + CLOCK_OFF + RW_OFF + SAMPLE_OFF)
        DrawTrace(0)
        ' Init Read
        Out(&H378 + 2, READ_ON + RESET_OFF + CLOCK_OFF + RW_OFF + SAMPLE_OFF)
        Out(&H378, 0)
        DrawTrace(0)

        Dim Address As UInt16 = 0
        Dim HexLine As String = ""
        Dim ASCLine As String = ""
        Dim BytesWide As Integer = 0
        For Address = 0 To &H900
            Out(&H378 + 2, READ_ON + RESET_OFF + CLOCK_ON + RW_OFF + SAMPLE_OFF)
            DrawTrace(Address)
            Dim Data As UInt16 = Inp(&H378)
            HexLine &= Data.ToString("X2") & " "
            ASCLine &= IIf(Data > 64 And Data < 127, Chr(Data), ".")
            BytesWide += 1
            If BytesWide = 16 Then
                DebugPrint((Address - 15).ToString("X4") & ": " & HexLine & " " & ASCLine)
                BytesWide = 0
                HexLine = ""
                ASCLine = ""
            End If
            Out(&H378 + 2, READ_ON + RESET_OFF + CLOCK_OFF + RW_OFF + SAMPLE_OFF)
            DrawTrace(Address)
            Dim status As UInt16 = Inp(&H378 + 1)
            If status And 128 Then Exit For
        Next Address


    End Sub
    Dim LastY As Integer = 0
    Private Sub DrawTrace(ByVal Address As UInt16)
        Dim g As Graphics = Drawing.Graphics.FromImage(pb.Image)
        Dim Yb As Boolean = Inp(&H37A) And 1
        Dim Y As Integer = IIf(Yb, 10, 0)
        If Address > 0 Then
            g.DrawLine(Pens.Blue, (Address - 1) * 10, LastY, Address * 10, Y)
            LastY = Y
        End If

    End Sub
    Private Sub DebugPrint(ByVal text As String)
        txtOut.Text &= text & vbCrLf
        Application.DoEvents()
    End Sub

    Private Sub cmdWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWrite.Click
        txtOut.Text = ""
        ' Reset
        Out(&H378 + 2, RESET_ON + CLOCK_OFF + RW_OFF + SAMPLE_OFF)
        ' Init Write
        Out(&H378, 0)
        Out(&H378 + 2, RESET_OFF + CLOCK_OFF + RW_ON + SAMPLE_OFF)

        Dim Address As UInt16 = 0
        Dim HexLine As String = ""
        Dim ASCLine As String = ""
        Dim BytesWide As Integer = 0

        For Address = 0 To &H900
            Out(&H378, BytesWide)
            Out(&H378 + 2, READ_OFF + RESET_OFF + CLOCK_ON + RW_ON + SAMPLE_OFF)
            Dim Data As UInt16 = BytesWide
            HexLine &= Data.ToString("X2") & " "
            ASCLine &= IIf(Data > 64 And Data < 127, Chr(Data), ".")
            BytesWide += 1
            If BytesWide = 16 Then
                DebugPrint((Address - 15).ToString("X4") & ": " & HexLine & " " & ASCLine)
                BytesWide = 0
                HexLine = ""
                ASCLine = ""
            End If
            Out(&H378 + 2, READ_OFF + RESET_OFF + CLOCK_OFF + RW_ON + SAMPLE_OFF)
            Dim status As UInt16 = Inp(&H378 + 1)
            If status And 128 Then Exit For
        Next Address

    End Sub

    Private Sub InitializeComponent()
        Me.txtOut = New System.Windows.Forms.TextBox
        Me.cmdRead = New System.Windows.Forms.Button
        Me.cmdWrite = New System.Windows.Forms.Button
        Me.pb = New System.Windows.Forms.PictureBox
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtOut
        '
        Me.txtOut.Location = New System.Drawing.Point(5, 4)
        Me.txtOut.Multiline = True
        Me.txtOut.Name = "txtOut"
        Me.txtOut.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOut.Size = New System.Drawing.Size(942, 247)
        Me.txtOut.TabIndex = 0
        '
        'cmdRead
        '
        Me.cmdRead.Location = New System.Drawing.Point(862, 495)
        Me.cmdRead.Name = "cmdRead"
        Me.cmdRead.Size = New System.Drawing.Size(75, 23)
        Me.cmdRead.TabIndex = 1
        Me.cmdRead.Text = "Read"
        Me.cmdRead.UseVisualStyleBackColor = True
        '
        'cmdWrite
        '
        Me.cmdWrite.Location = New System.Drawing.Point(25, 504)
        Me.cmdWrite.Name = "cmdWrite"
        Me.cmdWrite.Size = New System.Drawing.Size(75, 23)
        Me.cmdWrite.TabIndex = 2
        Me.cmdWrite.Text = "Write"
        Me.cmdWrite.UseVisualStyleBackColor = True
        '
        'pb
        '
        Me.pb.Location = New System.Drawing.Point(5, 257)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(941, 222)
        Me.pb.TabIndex = 3
        Me.pb.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(418, 497)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'LPT_Form
        '
        Me.ClientSize = New System.Drawing.Size(952, 538)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.pb)
        Me.Controls.Add(Me.cmdWrite)
        Me.Controls.Add(Me.cmdRead)
        Me.Controls.Add(Me.txtOut)
        Me.Name = "LPT_Form"
        CType(Me.pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtOut As System.Windows.Forms.TextBox
    Friend WithEvents cmdRead As System.Windows.Forms.Button
    Friend WithEvents cmdWrite As System.Windows.Forms.Button
    Friend WithEvents pb As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button

    Private Sub LPT_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class