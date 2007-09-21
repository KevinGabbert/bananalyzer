Imports System.Drawing.Graphics
Imports System.Xml.Serialization
Imports System.IO
Imports BananaBoard

Public Class frmTrace
    Delegate Sub SetTextCallback(ByVal [text] As String)
    Private WithEvents ATMega As New BananaBoard.BananaCOM

#Region "Constants"

    Const CLOCK_ON As Integer = 0
    Const CLOCK_OFF As Integer = 1
    Const RESET_ON As Integer = 0
    Const RESET_OFF As Integer = 2
    Const RW_ON As Integer = 4
    Const RW_OFF As Integer = 0
    Const ROM_ON As Integer = 0
    Const ROM_OFF As Integer = 8
    Const READ_ON As Integer = 32
    Const READ_OFF As Integer = 0
    Const ROW_SCALE As Integer = 21

#End Region
#Region "Variables"

    Private ROWLabel(63) As Label
    Private RowICON(63) As PictureBox

    Private LEDASTATE(31) As Boolean

    Private ROWOUTLabel(63) As Label
    Private RowOutICON(63) As PictureBox

    Private DigitLabel(31) As Label
    Private DigitSourceLabel(31) As Label

    Private Project As New BananaBoard.BBProject
    Dim Chips(7) As PictureBox

    Dim MaxCycles As Integer = 90

    'mnuAdd8pin_Click
    Dim ICCount As Integer = 0
    Dim Auto As Boolean = False

    Private ProjectName As String = "" 'mnuOpen

    Private dsChips As DataSet
    Private Chip As BananaBoard.BBChip
    Private ChipsFileName As String = Application.StartupPath & "/BananaChips.db"

    Dim Last() As Boolean = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
    Dim Lasta() As Boolean = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
    Dim LastOUTa() As Boolean = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
    Dim LastOUT() As Boolean = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
    Dim Cycle As Integer = 0
    Dim LastAddress As Integer = 0

    Dim action As Integer = 0
    Private Address As UInt32 = 0
    Private HexLine As String = ""
    Private ASCLine As String = ""
    Private BytesWide As Integer = 0
    Private Index As Integer = 0
    Private msg As String = "_|"
    Dim d0 As Integer = 0

    Private X As Integer = 0
    Private x1 As Integer = 0
    Private y1 As Integer = 100

    Dim Cycles As Integer = 0
    Dim Clock As Byte = 0
    Dim Rst As Byte = 2
    Dim OutValue As Byte = 0

    Dim Dragging As Boolean = False
    Dim mousex As Integer = 0
    Dim mousey As Integer = 0

    Dim LastOutRowSelected As Label = Nothing

#End Region

#Region "Event Handlers"

#Region "Form"

    Private Sub frmTrace_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Set_frmTrace_Info() '
        Me.Set_BreadboardX() '
        Me.Set_TabsX() '

        Me.Set_Row_Control(0, 31, BreadBoard.Left - ROW_SCALE)
        Me.Set_Row_Control(32, 63, BreadBoard.Left + BreadBoard.Width)

        ReDim Project.RowOUTPins(63)

        Me.Set_RowOut_Control()

        PanelTimer.Left = ROWLabel(0).Left + ROWLabel(0).Width + 1  'B!

        Me.Set_pb()
        Me.ClearTrace()
        Me.Set_DigitSourceLabel()
        Me.Set_pgX()
        Me.Set_pots()

        Me.Set_DAC()
        Me.Set_ADC()
        Me.Set_Timer()

        Me.ResumeLayout()
        Me.LoadChips()
    End Sub

#End Region
#Region "Row Stuff"

    Private Sub RowOut_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim c As Control = CType(sender, Control)
        'e.Graphics.DrawLine(Pens.LightGray, 0, 0, c.Width, 0)
        Try
            e.Graphics.DrawLine(Pens.LightGray, 0, c.Height - 1, c.Width, c.Height - 1)
            If sender.GetType Is GetType(Label) Then
                Dim RowLabel As Label = CType(sender, Label)
                If Project.RowOUTPins(RowLabel.Tag) IsNot Nothing AndAlso Project.RowOUTPins(RowLabel.Tag).Text.Contains("~") Then
                    Dim Text As String = Project.RowOUTPins(RowLabel.Tag).Text
                    Dim Left As Integer = e.Graphics.MeasureString(Text.Substring(0, Text.IndexOf("~")), RowLabel.Font, 79).Width + 1
                    Text = Text.Substring(Text.IndexOf("~") + 1)
                    Dim TextWidth As Integer = e.Graphics.MeasureString(Text, RowLabel.Font, 79).Width - 5
                    ' Right side
                    e.Graphics.DrawLine(Pens.Black, Left, 3, Left + TextWidth, 3)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Row_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim RowLabel As Label = CType(sender, Label)
        If RowLabel.TextAlign = ContentAlignment.MiddleLeft Then

            ' TODO: this will need fixing
            'If Project.RowBPins(RowLabel.Tag - 32).Text.Contains("~") Then
            '    Dim Text As String = Project.RowBPins(RowLabel.Tag - 32).Text
            '    Dim Left As Integer = e.Graphics.MeasureString(Text.Substring(0, Text.IndexOf("~")), RowLabel.Font, 79).Width + 1

            '    Text = Text.Substring(Text.IndexOf("~") + 1)
            '    Dim TextWidth As Integer = e.Graphics.MeasureString(Text, RowLabel.Font, 79).Width - 5
            '    ' Right side
            '    e.Graphics.DrawLine(Pens.Black, Left, 3, Left + TextWidth, 3)
            'End If

        Else
            If Project.RowPins(RowLabel.Tag).Text.Contains("~") Then
                Dim TextWidth As Integer = e.Graphics.MeasureString(Project.RowPins(RowLabel.Tag).Text.Replace("~", ""), RowLabel.Font, 79).Width - 7
                'Left Side
                Dim Left As Integer = RowLabel.Width - TextWidth - 5
                e.Graphics.DrawLine(Pens.Black, Left, 3, 75, 3)
            End If
        End If
    End Sub

    Private Sub ROWOUTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ROW As Label = CType(sender, Label)
        ROW.Text = InputBox("Row Label", "BananaBoard", ROW.Text)
        Project.RowOUTPins(ROW.Tag).Text = ROW.Text
    End Sub

    Private Sub ROW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ROW As Label = CType(sender, Label)
        ROW.Text = InputBox("Row Label", "BananaBoard", ROW.Text)
        Project.RowPins(ROW.Tag).Text = ROW.Text

    End Sub

    Private Sub ROW_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim ROW As Label = CType(sender, Label)
        ClearRowLabelSelect()
        ROW.BorderStyle = BorderStyle.FixedSingle
        DoDragDrop(sender, DragDropEffects.Copy)
        pg.Visible = True
        pg.BringToFront()
        If e.Clicks = 2 Then
            ROW_Click(sender, e)
        End If
        'ROW.BackColor = Color.LightGray
        If Project.RowPins(ROW.Tag).Text = "" Then Project.RowPins(ROW.Tag).Text = ROW.Text
        pg.SelectedObject = Project.RowPins(ROW.Tag)
        ICEditor.ClearTrace(pbTrace)
        ICEditor.DrawTrace(pbTrace, Project.RowPins(ROW.Tag))
    End Sub
    'Private Sub ROWB_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    '    Dim ROW As Label = CType(sender, Label)
    '    ClearRowLabelSelect()
    '    ROW.BorderStyle = BorderStyle.FixedSingle
    '    DoDragDrop(sender, DragDropEffects.Copy)
    '    pg.Visible = True
    '    pg.BringToFront()
    '    If e.Clicks = 2 Then
    '        ROWB_Click(sender, e)
    '    End If
    '    'If Project.RowBPins(ROW.Tag).Text = "" Then Project.RowBPins(ROW.Tag).Text = ROW.Text
    '    pg.SelectedObject = Project.RowBPins(ROW.Tag - 32)
    '    ICEditor.ClearTrace(pbTrace)
    '    ICEditor.DrawTrace(pbTrace, Project.RowBPins(ROW.Tag - 32))

    'End Sub
    'Private Sub ROWB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim ROW As Label = CType(sender, Label)
    '    ROW.Text = InputBox("Row Label", "BananaBoard", ROW.Text)
    '    Project.RowBPins(ROW.Tag - 32).Text = ROW.Text

    'End Sub

#Region "ROWOUT"

    Private Sub ROWOUT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ROW As Label = CType(sender, Label)
        ROW.Text = InputBox("Row Label", "BananaBoard", ROW.Text)
        If ROW.Text.Length = 0 Then
            ROW.BackColor = Color.White
            ROW.ForeColor = Color.Blue
            RowOutICON(ROW.Tag).Image = ICEditor.imgRowIcons.Images(0)
        End If
        If Project.RowOUTPins.Length < 64 Then ReDim Preserve Project.RowOUTPins(63)
        If Project.RowOUTPins(ROW.Tag) Is Nothing Then Project.RowOUTPins(ROW.Tag) = New BBPin
        Project.RowOUTPins(ROW.Tag).Text = ROW.Text
        ROW.Text = ROW.Text.Replace("~", String.Empty)
    End Sub
    Private Sub ROWOUT_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        'See if there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.Label", True) Then
            'TreeNode found allow move effect
            e.Effect = DragDropEffects.Copy
        Else
            'No TreeNode found, prevent move
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub ROWOUT_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        If e.Data.GetDataPresent("System.Windows.Forms.Label", True) Then
            pbSelected.Image = New Bitmap(pbSelected.Width, pbSelected.Height)
            Dim TargetROW As Label = CType(sender, Label)
            Dim TargetIcon As PictureBox = RowOutICON(TargetROW.Tag)
            Dim DroppedROW As Label = CType(e.Data.GetData("System.Windows.Forms.Label"), Label)
            TargetROW.Text = DroppedROW.Text
            Project.RowOUTPins(TargetROW.Tag).Text = DroppedROW.Text
            Project.RowOUTPins(TargetROW.Tag).Row = DroppedROW.Tag
            If DroppedROW.Parent.Name = "PanelTrace" Then
                Project.RowOUTPins(TargetROW.Tag) = Project.RowOUTPins(DroppedROW.Tag)
                TargetIcon.Image = RowOutICON(DroppedROW.Tag).Image
                DroppedROW.Text = ""
                RowOutICON(DroppedROW.Tag).Image = ICEditor.imgRowIcons.Images(8)
                Project.RowOUTPins(DroppedROW.Tag) = New BBPin
            Else
                If DroppedROW.TextAlign = ContentAlignment.MiddleRight Then
                    ' left side A
                    Project.RowOUTPins(TargetROW.Tag) = Project.RowPins(DroppedROW.Tag)
                    'Project.RowOUTPins(TargetROW.Tag).ParentPin = Project.RowAPins(DroppedROW.Tag)
                    TargetIcon.Image = ICEditor.GetRowIcon(Project.RowPins(DroppedROW.Tag), 999)
                Else
                    ' right side B
                    ''Project.RowOUTPins(TargetROW.Tag) = Project.RowBPins(DroppedROW.Tag - 32)
                    'Project.RowOUTPins(TargetROW.Tag).ParentPin = Project.RowBPins(DroppedROW.Tag - 32)
                    ''TargetIcon.Image = ICEditor.GetRowIcon(Project.RowBPins(DroppedROW.Tag - 32), 999)
                End If
            End If
        End If
    End Sub
    Private Sub ROWOUT_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim ROW As Label = CType(sender, Label)
        'ClearRowLabelSelect()
        'ROW.BorderStyle = BorderStyle.FixedSingle
        DoDragDrop(sender, DragDropEffects.Copy)
        If e.Clicks = 2 Then
            ROWOUT_Click(sender, e)
        End If
        'If Project.RowBPins(ROW.Tag).Text = "" Then Project.RowBPins(ROW.Tag).Text = ROW.Text
        'pg.SelectedObject = Project.RowBPins(ROW.Tag - 32)
        'ICEditor.ClearTrace(pbTrace)
        'ICEditor.DrawTrace(pbTrace, Project.RowBPins(ROW.Tag - 32))
    End Sub

#End Region

#End Region
#Region "LCD"

    Private Sub LCD_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        'See if there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.Label", True) Then
            'TreeNode found allow move effect
            e.Effect = DragDropEffects.Copy
        Else
            'No TreeNode found, prevent move
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub LCD_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        If e.Data.GetDataPresent("System.Windows.Forms.Label", True) Then
            Dim TargetROW As Label = DigitSourceLabel(e.X / ROW_SCALE)
            Dim DroppedROW As Label = CType(e.Data.GetData("System.Windows.Forms.Label"), Label)
            TargetROW.Text = DroppedROW.Text
            TargetROW.BackColor = DroppedROW.BackColor
            TargetROW.ForeColor = DroppedROW.ForeColor

            Project.DigitPins(TargetROW.Tag) = New BBPin
            Project.DigitPins(TargetROW.Tag).Text = DroppedROW.Text
            Project.DigitPins(TargetROW.Tag).BackColor = DroppedROW.BackColor.Name
            Project.DigitPins(TargetROW.Tag).ForeColor = DroppedROW.ForeColor.Name

            If DroppedROW.TextAlign = ContentAlignment.MiddleCenter Then
                Project.DigitPins(TargetROW.Tag).Output = True
                Project.DigitPins(TargetROW.Tag).Column = 0
            Else
                If DroppedROW.TextAlign = ContentAlignment.MiddleRight Then
                    Project.DigitPins(TargetROW.Tag).Output = False
                    Project.DigitPins(TargetROW.Tag).Column = 1
                Else
                    Project.DigitPins(TargetROW.Tag).Output = False
                    Project.DigitPins(TargetROW.Tag).Column = 2
                End If
            End If
            Project.DigitPins(TargetROW.Tag).Row = DroppedROW.Tag
        End If
    End Sub

#End Region
#Region "IC"

    Private Sub IC_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If e.Clicks = 2 Then
                IC_DoubleClick(sender, e)
            Else
                sender.Cursor = Cursors.Hand
                sender.BringtoFront()
                Dragging = True
                mousex = -e.X
                mousey = -e.Y
                Dim clipleft As Integer = Me.PointToClient(MousePosition).X - sender.Location.X
                Dim cliptop As Integer = Me.PointToClient(MousePosition).Y - sender.Location.Y - ROW_SCALE
                Dim clipwidth As Integer = Me.ClientSize.Width - (sender.Width - clipleft)
                Dim clipheight As Integer = Me.ClientSize.Height - (sender.Height - cliptop)
                Windows.Forms.Cursor.Clip = Me.RectangleToScreen(New Rectangle(clipleft, cliptop, clipwidth, clipheight))
                sender.Invalidate()
            End If
        End If
    End Sub
    Private Sub IC_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If Dragging Then
            'move control to new position
            Dim MPosition As New Point()
            MPosition = Me.PointToClient(MousePosition)
            MPosition.Offset(mousex, mousey)
            If MPosition.Y < BreadBoard.Top + splitBreadBoard.Panel1.Height - sender.Height And MPosition.Y >= BreadBoard.Top - 5 Then
                'ensure control cannot leave container
                If MPosition.X < BreadBoard.Left + (BreadBoard.Width) And MPosition.X >= BreadBoard.Left Then
                    sender.Location = MPosition
                End If
            End If
        End If
    End Sub
    Private Sub IC_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If Dragging Then
            'end the dragging
            sender.Cursor = Cursors.Arrow
            Dragging = False
            Windows.Forms.Cursor.Clip = Nothing
            ' snap to grid
            sender.Left = ROW_SCALE * IIf(Project.Chips(sender.Tag).PinCount > 20, 2, 4) + BreadBoard.Left - 1 ' CInt(IC1.Location.X / ROW_SCALE) * ROW_SCALE + 4
            sender.Top = CInt(sender.Location.Y / ROW_SCALE) * ROW_SCALE + 4
            sender.Invalidate()
            Project.Chips(sender.Tag).Row = CInt(sender.Location.Y / ROW_SCALE) - 1
            ClearRowLabelSelect()
            sender.BorderStyle = BorderStyle.FixedSingle
        End If
    End Sub
    Private Sub IC_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim IC As PictureBox = CType(sender, PictureBox)
        Project.Chips(IC.Tag).Flip = Not Project.Chips(IC.Tag).Flip
        IC.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
        IC.Refresh()

    End Sub

#End Region
#Region "pg"

    Private Sub pg_labelpaint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim c As Control = CType(sender, Control)
        'c.BackColor = Color.Transparent
        'Application.DoEvents()
        Dim g As Drawing.Graphics = e.Graphics ' Drawing.Graphics.FromHwnd(CType(pg.Controls(0).Controls(0), Control).Handle)
        Try
            Dim Top As Integer = 0
            For x As Integer = 0 To c.Width Step 20
                g.DrawLine(Pens.LightGray, x, Top, x, c.Height)
            Next
            For y As Integer = Top To c.Height Step ROW_SCALE
                g.DrawLine(Pens.LightGray, 0, y, c.Width, y)
            Next
        Catch ex As Exception
            Application.DoEvents()
        End Try
    End Sub
    Private Sub pg_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pg.Paint
        Dim c As Control = CType(pg.Controls(2), Control)
        'If c.BackgroundImage Is Nothing Then
        '    c.BackgroundImage = New Bitmap(c.Width, c.Height)
        'End If
        Application.DoEvents()

        Dim g As Drawing.Graphics = Drawing.Graphics.FromHwnd(CType(pg.Controls(2), Control).Handle)

        Try
            Dim Top As Integer = 6 * 17
            For x As Integer = 0 To c.Width Step 20
                g.DrawLine(Pens.LightGray, x, Top, x, c.Height)
            Next
            For y As Integer = Top To c.Height Step ROW_SCALE
                g.DrawLine(Pens.LightGray, 0, y, c.Width, y)
            Next
        Catch ex As Exception
            Application.DoEvents()
        End Try

    End Sub
    Private Sub pg_PropertyValueChanged(ByVal s As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles pg.PropertyValueChanged
        Select Case pg.SelectedObject.GetType.Name
            Case "BBPin"
                Dim Pin As BananaBoard.BBPin = CType(pg.SelectedObject, BBPin) ' Chip.Pins(GetSelectedLabel.Tag)
                Select Case e.ChangedItem.Label
                    Case "Output"
                    Case "Function"
                        Select Case e.ChangedItem.Value.ToString
                            Case "Input", "Analog Input"
                                Pin.Output = False
                                Pin.InvertClock = False
                                Pin.Clock = False
                                Pin.Bits = ""
                            Case "High ( +5V )"
                                Pin.Output = True
                                Pin.InvertClock = False
                                Pin.Clock = False
                                Pin.Bits = New String("1", 512)
                            Case "Low ( GND )"
                                Pin.Output = True
                                Pin.InvertClock = False
                                Pin.Clock = False
                                Pin.Bits = "0"
                            Case "Rising Clock"
                                Pin.Output = True
                                Pin.Clock = True
                                Pin.InvertClock = False
                                Pin.Bits = New String("1", 512)
                            Case "Falling Clock"
                                Pin.Output = True
                                Pin.Clock = True
                                Pin.InvertClock = True
                                Pin.Bits = New String("1", 512)
                            Case "Scripted Output"
                                Pin.Output = True
                                Pin.Clock = False
                                Pin.InvertClock = False
                                Pin.Bits = "00"
                                ICEditor.ClearTrace(pbTrace)
                                'DrawEditTrace(Pin)
                        End Select
                        pg.SelectedObject = Pin
                        ' Dim ImageIndex As Integer = GetRowIcon(Pin)
                        ' If GetSelectedLabel.Tag > (Chip.Pins.Length / 2) - 1 AndAlso ImageIndex < 2 Or ImageIndex = 5 Then GetIconByIndex(GetSelectedLabel.Tag).Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
                        ICEditor.ClearTrace(pbTrace)
                        'DrawEditTrace(Pin)
                End Select
                If Pin.Row < 32 Then
                    RowICON(Pin.Row).Image = ICEditor.GetRowIcon(Pin, 32)
                    ROWLabel(Pin.Row).Text = Pin.Text
                Else
                    RowICON(63 - Pin.Row).Image = ICEditor.GetRowIcon(Pin, 32) 'B
                    ROWLabel(63 - Pin.Row).Text = Pin.Text  'B
                End If
            Case "BBPot"

        End Select
    End Sub

#End Region
#Region "ATMega"

    Private Sub ATMega_Info(ByVal Message As String) Handles ATMega.Info
        DebugPrint(Message)
    End Sub
    Private Sub ATMega_RowBitsSetComplete() Handles ATMega.RowBitsSetComplete
        DebugPrint("Row Bits Set!")
        If Auto Then ATMega.Sample()
        Auto = False
    End Sub
    Private Sub ATMega_RowConfigComplete() Handles ATMega.RowConfigComplete
        DebugPrint("Row Config Complete!")
        If Auto Then ATMega.SendRowBits(Project)
    End Sub
    Private Sub ATMega_SamplesRead(ByVal Samples() As Byte) Handles ATMega.SamplesRead
        'Me.Cursor = Cursors.WaitCursor
        Dim y As Integer = 0
        Dim x As Integer = 0
        Application.DoEvents()
        ClearTrace()
        Dim g As Graphics = System.Drawing.Graphics.FromImage(pbSelected.Image)
        Dim RowOUTIndex As Integer = 0
        For RowOUTIndex = 0 To Project.RowOUTPins.Length - 1
            Dim bbrow As BBPin = Project.RowOUTPins(RowOUTIndex)
            If bbrow IsNot Nothing Then
                Select Case bbrow.Row
                    Case 0 To 7 ' left side
                        If bbrow.Text.Length > 0 Then
                            For sample As Integer = 0 To 511
                                x = sample * 10
                                Dim sample_base As Integer = sample * 8
                                Dim sample_value As Boolean = (Samples(sample_base) And (1 << (bbrow.Row)))
                                Dim Bin As String = ATMega.LongToBinary(Samples(sample_base))
                                Dim last_sample_value As Boolean = False
                                If sample_base > 7 Then last_sample_value = (Samples(sample_base - 8) And (1 << (bbrow.Row)))
                                If last_sample_value Then
                                    If sample_value Then
                                        ' Hold High
                                        g.DrawLine(Pens.Red, x, y + 5, x + 10, y + 5)
                                    Else
                                        ' Falling Edge
                                        g.DrawLine(Pens.Blue, x, y + 5, x, y + 15)
                                        g.DrawLine(Pens.Blue, x, y + 15, x + 10, y + 15)
                                    End If
                                Else
                                    If sample_value Then
                                        ' Rising Edge
                                        g.DrawLine(Pens.Red, x, y + 15, x, y + 5)
                                        g.DrawLine(Pens.Red, x, y + 5, x + 10, y + 5)
                                    Else
                                        ' Hold low
                                        g.DrawLine(Pens.Blue, x, y + 15, x + 10, y + 15)
                                    End If
                                End If
                            Next
                        End If
                    Case 8 To 15 ' left side
                        If bbrow.Text.Length > 0 Then
                            For sample As Integer = 0 To 511
                                x = sample * 10
                                Dim sample_base As Integer = sample * 8 + 1
                                Dim sample_value As Boolean = (Samples(sample_base) And (1 << (bbrow.Row - 8)))
                                Dim Bin As String = ATMega.LongToBinary(Samples(sample_base))
                                Dim last_sample_value As Boolean = False
                                If sample_base > 7 Then last_sample_value = (Samples(sample_base - 8) And (1 << (bbrow.Row - 8)))
                                If last_sample_value Then
                                    If sample_value Then
                                        ' Hold High
                                        g.DrawLine(Pens.Red, x, y + 5, x + 10, y + 5)
                                    Else
                                        ' Falling Edge
                                        g.DrawLine(Pens.Blue, x, y + 5, x, y + 15)
                                        g.DrawLine(Pens.Blue, x, y + 15, x + 10, y + 15)
                                    End If
                                Else
                                    If sample_value Then
                                        ' Rising Edge
                                        g.DrawLine(Pens.Red, x, y + 15, x, y + 5)
                                        g.DrawLine(Pens.Red, x, y + 5, x + 10, y + 5)
                                    Else
                                        ' Hold low
                                        g.DrawLine(Pens.Blue, x, y + 15, x + 10, y + 15)
                                    End If
                                End If
                            Next
                        End If
                    Case 16 To 23 ' left side
                        If bbrow.Text.Length > 0 Then
                            For sample As Integer = 0 To 511
                                x = sample * 10
                                Dim sample_base As Integer = sample * 8 + 2
                                Dim sample_value As Boolean = (Samples(sample_base) And (1 << (bbrow.Row - 16)))
                                Dim Bin As String = ATMega.LongToBinary(Samples(sample_base))
                                Dim last_sample_value As Boolean = False
                                If sample_base > 7 Then last_sample_value = (Samples(sample_base - 8) And (1 << (bbrow.Row - 16)))
                                If last_sample_value Then
                                    If sample_value Then
                                        ' Hold High
                                        g.DrawLine(Pens.Red, x, y + 5, x + 10, y + 5)
                                    Else
                                        ' Falling Edge
                                        g.DrawLine(Pens.Blue, x, y + 5, x, y + 15)
                                        g.DrawLine(Pens.Blue, x, y + 15, x + 10, y + 15)
                                    End If
                                Else
                                    If sample_value Then
                                        ' Rising Edge
                                        g.DrawLine(Pens.Red, x, y + 15, x, y + 5)
                                        g.DrawLine(Pens.Red, x, y + 5, x + 10, y + 5)
                                    Else
                                        ' Hold low
                                        g.DrawLine(Pens.Blue, x, y + 15, x + 10, y + 15)
                                    End If
                                End If
                            Next
                        End If
                    Case 24 To 31 ' left side
                        If bbrow.Text.Length > 0 Then
                            For sample As Integer = 0 To 511
                                x = sample * 10
                                Dim sample_base As Integer = sample * 8 + 3
                                Dim sample_value As Boolean = (Samples(sample_base) And (1 << (bbrow.Row - 24)))
                                Dim Bin As String = ATMega.LongToBinary(Samples(sample_base))
                                Dim last_sample_value As Boolean = False
                                If sample_base > 7 Then last_sample_value = (Samples(sample_base - 8) And (1 << (bbrow.Row - 24)))
                                If last_sample_value Then
                                    If sample_value Then
                                        ' Hold High
                                        g.DrawLine(Pens.Red, x, y + 5, x + 10, y + 5)
                                    Else
                                        ' Falling Edge
                                        g.DrawLine(Pens.Blue, x, y + 5, x, y + 15)
                                        g.DrawLine(Pens.Blue, x, y + 15, x + 10, y + 15)
                                    End If
                                Else
                                    If sample_value Then
                                        ' Rising Edge
                                        g.DrawLine(Pens.Red, x, y + 15, x, y + 5)
                                        g.DrawLine(Pens.Red, x, y + 5, x + 10, y + 5)
                                    Else
                                        ' Hold low
                                        g.DrawLine(Pens.Blue, x, y + 15, x + 10, y + 15)
                                    End If
                                End If
                            Next
                        End If
                    Case 32 To 39 ' right side
                        For sample As Integer = 0 To 511
                            x = sample * 10
                            Dim sample_base As Integer = (sample * 8) + 4
                            Dim sample_value As Boolean = (Samples(sample_base) And (1 << (bbrow.Row - 32)))
                            Dim last_sample_value As Boolean = False
                            If sample_base > 7 Then last_sample_value = (Samples(sample_base - 8) And (1 << (bbrow.Row - 32)))
                            If last_sample_value Then
                                If sample_value Then
                                    ' Hold High
                                    g.DrawLine(Pens.Red, x, y + 5, x + 10, y + 5)
                                Else
                                    ' Falling Edge
                                    g.DrawLine(Pens.Blue, x, y + 5, x, y + 15)
                                    g.DrawLine(Pens.Blue, x, y + 15, x + 10, y + 15)
                                End If
                            Else
                                If sample_value Then
                                    ' Rising Edge
                                    g.DrawLine(Pens.Red, x, y + 15, x, y + 5)
                                    g.DrawLine(Pens.Red, x, y + 5, x + 10, y + 5)
                                Else
                                    ' Hold low
                                    g.DrawLine(Pens.Blue, x, y + 15, x + 10, y + 15)
                                End If
                            End If
                        Next
                    Case 40 To 47 ' right side
                        For sample As Integer = 0 To 511
                            x = sample * 10
                            Dim sample_base As Integer = (sample * 8) + 5
                            Dim sample_value As Boolean = (Samples(sample_base) And (1 << (bbrow.Row - 40)))
                            Dim last_sample_value As Boolean = False
                            If sample_base > 7 Then last_sample_value = (Samples(sample_base - 8) And (1 << (bbrow.Row - 40)))
                            If last_sample_value Then
                                If sample_value Then
                                    ' Hold High
                                    g.DrawLine(Pens.Red, x, y + 5, x + 10, y + 5)
                                Else
                                    ' Falling Edge
                                    g.DrawLine(Pens.Blue, x, y + 5, x, y + 15)
                                    g.DrawLine(Pens.Blue, x, y + 15, x + 10, y + 15)
                                End If
                            Else
                                If sample_value Then
                                    ' Rising Edge
                                    g.DrawLine(Pens.Red, x, y + 15, x, y + 5)
                                    g.DrawLine(Pens.Red, x, y + 5, x + 10, y + 5)
                                Else
                                    ' Hold low
                                    g.DrawLine(Pens.Blue, x, y + 15, x + 10, y + 15)
                                End If
                            End If
                        Next
                    Case 48 To 55 ' right side
                        For sample As Integer = 0 To 511
                            x = sample * 10
                            Dim sample_base As Integer = (sample * 8) + 6
                            Dim sample_value As Boolean = (Samples(sample_base) And (1 << (bbrow.Row - 48)))
                            Dim last_sample_value As Boolean = False
                            If sample_base > 7 Then last_sample_value = (Samples(sample_base - 8) And (1 << (bbrow.Row - 48)))
                            If last_sample_value Then
                                If sample_value Then
                                    ' Hold High
                                    g.DrawLine(Pens.Red, x, y + 5, x + 10, y + 5)
                                Else
                                    ' Falling Edge
                                    g.DrawLine(Pens.Blue, x, y + 5, x, y + 15)
                                    g.DrawLine(Pens.Blue, x, y + 15, x + 10, y + 15)
                                End If
                            Else
                                If sample_value Then
                                    ' Rising Edge
                                    g.DrawLine(Pens.Red, x, y + 15, x, y + 5)
                                    g.DrawLine(Pens.Red, x, y + 5, x + 10, y + 5)
                                Else
                                    ' Hold low
                                    g.DrawLine(Pens.Blue, x, y + 15, x + 10, y + 15)
                                End If
                            End If
                        Next
                    Case 56 To 63 ' right side
                        For sample As Integer = 0 To 511
                            x = sample * 10
                            Dim sample_base As Integer = (sample * 8) + 7
                            Dim sample_value As Boolean = (Samples(sample_base) And (1 << (bbrow.Row - 56)))
                            Dim last_sample_value As Boolean = False
                            If sample_base > 7 Then last_sample_value = (Samples(sample_base - 8) And (1 << (bbrow.Row - 56)))
                            If last_sample_value Then
                                If sample_value Then
                                    ' Hold High
                                    g.DrawLine(Pens.Red, x, y + 5, x + 10, y + 5)
                                Else
                                    ' Falling Edge
                                    g.DrawLine(Pens.Blue, x, y + 5, x, y + 15)
                                    g.DrawLine(Pens.Blue, x, y + 15, x + 10, y + 15)
                                End If
                            Else
                                If sample_value Then
                                    ' Rising Edge
                                    g.DrawLine(Pens.Red, x, y + 15, x, y + 5)
                                    g.DrawLine(Pens.Red, x, y + 5, x + 10, y + 5)
                                Else
                                    ' Hold low
                                    g.DrawLine(Pens.Blue, x, y + 15, x + 10, y + 15)
                                End If
                            End If
                        Next
                End Select
                y += ROW_SCALE
            End If
        Next

        ' draw saved trace range labels
        'For Each t As TraceRangeLabel In Project.TraceRangeLabels
        '    If t IsNot Nothing Then
        '        DrawTraceRangeLabel(t.Text, t.Row, t.StartColumn, t.EndColumn)
        '    End If
        'Next
        g.ReleaseHdc(g.GetHdc)
        pbSelected.Invalidate()
    End Sub
    Private Sub ATMega_SamplingComplete() Handles ATMega.SamplingComplete
        DebugPrint("Sampling Complete!")
        ATMega.Project = Project
        ATMega.ReadSamples()
    End Sub

#End Region
#Region "Pot0"

    Private Sub Pot0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pot0.Click, Pot1.Click
        pg.SelectedObject = sender.Tag
    End Sub
    Private Sub Pot0_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pot0.MouseDown
        pg.SelectedObject = sender.Tag
    End Sub
    Private Sub Pot0_ValueChanged(ByVal sender As Object, ByVal value As Byte) Handles Pot0.ValueChanged
        ATMega.Set_Pot(0, Pot0.Value)
    End Sub

#End Region
#Region "Menu Items"

    Private Sub mnuManageChips_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuManageChips.Click

        Dim frmChips As New ICEditor()
        frmChips.ShowDialog(Me)
        LoadChips()

    End Sub
    Private Sub mnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSave.Click

        If SaveFile.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim s As New XmlSerializer(GetType(BBProject))
            Dim st As New System.IO.StreamWriter(SaveFile.FileName)
            s.Serialize(st, Project)
            st.Close()
            Me.Text = "Banana Board - " & IO.Path.GetFileNameWithoutExtension(SaveFile.FileName)
        End If

    End Sub
    Private Sub mnuOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpen.Click

        cmdRun.Enabled = True
        If OpenProject.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            For y As Integer = 0 To 7
                panelBreadboard.Controls.Remove(Chips(y))
            Next
            Dim s As New XmlSerializer(GetType(BBProject))
            Dim st As New System.IO.StreamReader(OpenProject.FileName)
            ProjectName = IO.Path.GetFileNameWithoutExtension(OpenProject.FileName)
            Me.Text = "Banana Board - " & ProjectName
            Project = s.Deserialize(st)
            If Project.TraceRangeLabels Is Nothing Then
                ReDim Project.TraceRangeLabels(0)
            End If
            For y As Integer = 0 To 7
                Me.Controls.Remove(Chips(y))
            Next
            Dim RowLabelTT As ToolTip
            For y As Integer = 0 To 63 '31
                If Project.RowPins(y) Is Nothing Then
                    Project.RowPins(y) = New BBPin()
                End If

                'If Project.RowBPins(y) Is Nothing Then
                '    Project.RowBPins(y) = New BBPin()
                'End If
                Project.RowPins(y).Row = y


                ROWLabel(y).Text = Project.RowPins(y).Text.Replace("~", "")
                RowLabelTT = New ToolTip
                RowLabelTT.SetToolTip(ROWLabel(y), "BananaRow " & y.ToString) 'A
                RowICON(y).Image = ICEditor.GetRowIcon(Project.RowPins(y), 32)


                'Project.RowBPins(y).Row = 63 - y
                'ROWLabel(y + 32).Text = Project.RowBPins(y).Text.Replace("~", "") 'B
                'RowLabelTT = New ToolTip
                'RowLabelTT.SetToolTip(ROWLabel(y + 32), "BananaRow B" & y.ToString) 'B
                'RowICON(y + 32).Image = ICEditor.GetRowIcon(Project.RowBPins(y), 32) 'B

            Next y
            ICCount = 0
            For y As Integer = 0 To 7
                If Project.Chips(y) IsNot Nothing Then
                    CreateIC(y, Project.Chips(y).PinCount, Project.Chips(y).Text, Project.Chips(y).Description, Project.Chips(y).Row, Project.Chips(y).Flip)
                    ICCount += 1
                End If
            Next y
            If Project.RowOUTPins.Length < 64 Then ReDim Preserve Project.RowOUTPins(63)
            For y As Integer = 0 To 63
                If Project.RowOUTPins(y) IsNot Nothing AndAlso Project.RowOUTPins(y).Text.Length > 0 Then
                    ROWOUTLabel(y).Text = Project.RowOUTPins(y).Text.Replace("~", "")
                    Dim tt As New ToolTip()
                    tt.SetToolTip(RowOutICON(y), Project.RowOUTPins(y).PinFunction)
                Else
                    Project.RowOUTPins(y) = New BBPin
                    ROWOUTLabel(y).Text = ""
                End If
                RowOutICON(y).Image = ICEditor.GetRowIcon(Project.RowOUTPins(y), 999)
            Next y
            st.Close()

            txtClockDelay.Text = Project.ClockDelay
        End If
    End Sub
    Private Sub mnuAdd8Pin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim mnu As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim Pins As Integer = Val(mnu.Text)
        Dim ChipNo As String = InputBox("Chip #?", "Banana Board", "IC" & ICCount + 1)
        Dim Desc As String = InputBox("Chip Description?", "Banana Board", "IC" & ICCount + 1)
        CreateIC(ICCount, Pins, ChipNo, Desc, 0, False)
        ICCount += 1

    End Sub
    Private Sub mnuNewProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewProject.Click

        Project = New BBProject
        For y As Integer = 0 To 7
            panelBreadboard.Controls.Remove(Chips(y))
        Next
        For y As Integer = 0 To 63 '31
            Project.RowPins(y) = New BBPin
            Project.RowPins(y).Row = y

            'Project.RowBPins(y) = New BBPin
            'Project.RowBPins(y).Row = 63 - y 'TODO: positional fix may be needed here

            Project.RowOUTPins(y) = New BBPin
            Project.RowPins(y).Text = ""
            'Project.RowBPins(y).Text = ""
            Project.RowOUTPins(y).Text = ""
            If y < 8 Then
                If Chips(y) IsNot Nothing Then Chips(y) = Nothing
            End If
            If y < 16 Then
                Project.DigitPins(y) = New BBPin
                DigitSourceLabel(y).Text = ""
            End If
            ROWOUTLabel(y).Text = ""
            ROWOUTLabel(y + 32).Text = ""
            RowOutICON(y).Image = ICEditor.imgRowIcons.Images(8)
            RowOutICON(y + 32).Image = ICEditor.imgRowIcons.Images(8)
            ROWLabel(y).Text = ""

            ROWLabel(y + 32).Text = "" 'B
            RowICON(y).Image = ICEditor.imgRowIcons.Images(8)
            RowICON(y + 32).Image = ICEditor.imgRowIcons.Images(8) 'B
        Next
        ICCount = 0

    End Sub
    Private Sub mnuReadRowConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReadRowConfig.Click
        ATMega.Project = Project
        ATMega.RequestRowConfig()
    End Sub
    Private Sub mnuReadSamples_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReadSamples.Click
        ATMega.Project = Project
        ATMega.ReadSamples()
    End Sub
    Private Sub mnuSendRowConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSendRowConfig.Click
        'Project.ClockStart = IIf(chkClockStart.Checked, 1, 0)
        Project.ClockDelay = Val(txtClockDelay.Text)
        ATMega.SendRowConfig(Project)
    End Sub
    Private Sub mnuSendRowBits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSendRowBits.Click
        ATMega.SendRowBits(Project)
    End Sub
    Private Sub mnuWriteMatrix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuWriteMatrix.Click
        Dim i As Image = ICEditor.imgRowIcons.Images(0)

        i.Save(Application.StartupPath & "\Lessons\LED Matrix Driver\test.bmp", System.Drawing.Imaging.ImageFormat.MemoryBmp)
        ATMega.WriteLEDMatrixRAM(Nothing)
    End Sub
    Private Sub mnuPrintTrace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintTrace.Click
        PrintDocument1.DefaultPageSettings.Landscape = True
        PrintPreviewDialog1.Document = PrintDocument1
        If PrintPreviewDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
            'PrintDocument1.Print()
        End If
        'If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '    PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
        '    PrintDocument1.Print()
        'End If
    End Sub
    Private Sub mnuAdd4040_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim Pins As Integer = 16
        Dim ChipNo As String = "HCF4040BE"
        Dim Desc As String = "12 Bit Binary Counter"
        Dim Row As Integer = 0
        If ICCount > 0 Then
            Row = Project.Chips(ICCount - 1).Row + (Project.Chips(ICCount - 1).PinCount / 2)
        End If
        CreateIC(ICCount, Pins, ChipNo, Desc, Row, False)
        ICCount += 1

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim BaseFont As Font = ROWOUTLabel(0).Font
        Dim Title As String = ""
        If Title.Length = 0 Then Title = InputBox("Printout Title?", "BananaPrint", ProjectName)
        ProjectName = Title
        Dim LabelTop As Integer = 1
        Dim LabelLeft As Integer = RowOutICON(0).Width
        Dim TraceLeft As Integer = RowOutICON(0).Width + ROWOUTLabel(0).Width + 1
        Dim TraceTop As Integer = 0
        Dim TopMargin As Integer = 50
        Dim RowCount As Integer = (e.PageBounds.Height - 50) / ROW_SCALE
        Dim l As Label = Nothing
        For i As Integer = 0 To RowCount - 1
            l = ROWOUTLabel(i)
            LabelTop = (i * ROW_SCALE) + 4 + TopMargin
            e.Graphics.DrawImage(RowOutICON(i).Image, 0, i * ROW_SCALE + TopMargin)
            e.Graphics.DrawLine(Pens.LightGray, 0, i * ROW_SCALE + TopMargin - 1, TraceLeft, i * ROW_SCALE + TopMargin - 1)
            e.Graphics.DrawString(l.Text, BaseFont, Brushes.Black, LabelLeft, LabelTop)
            If Project.RowOUTPins.Length > i AndAlso Project.RowOUTPins(i).Text.Contains("~") Then
                Dim Text As String = Project.RowOUTPins(i).Text
                Dim Left As Integer = e.Graphics.MeasureString(Text.Substring(0, Text.IndexOf("~")), l.Font, 79).Width + 1
                Text = Text.Substring(Text.IndexOf("~") + 1)
                Dim TextWidth As Integer = e.Graphics.MeasureString(Text, BaseFont, 79).Width - 5
                ' Right side
                e.Graphics.DrawLine(Pens.Black, LabelLeft + Left, LabelTop - 1, LabelLeft + Left + TextWidth, LabelTop - 1)
            End If
        Next
        e.Graphics.DrawRectangle(Pens.Blue, 1, 1, e.PageBounds.Width - 2, TopMargin - 3)
        e.Graphics.DrawString(ProjectName, New Font(BaseFont.FontFamily.Name, BaseFont.Size + 5, FontStyle.Bold), Brushes.Black, 10, 13)
        e.Graphics.DrawLine(Pens.LightGray, TraceLeft, TopMargin, TraceLeft, pbSelected.Height)
        ' e.Graphics.DrawImage(pbSelected.Image, TraceLeft, TopMargin, pbSelected.Width, pbSelected.Height)
        e.Graphics.DrawImageUnscaledAndClipped(pbSelected.Image, New Rectangle(TraceLeft, TopMargin, e.PageBounds.Width - TraceLeft, e.PageBounds.Height - TopMargin))

    End Sub

#End Region
#Region "PictureBoxes"

    Private Sub pbTrace_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbTrace.MouseDoubleClick
        Dim BitIndex As Integer = Int(e.X / 20)
        Dim Pin As BananaBoard.BBPin = CType(pg.SelectedObject, BananaBoard.BBPin)
        If Pin.Output Then
            Dim bits As String = Pin.Bits.PadRight(512, "0")
            If bits.Substring(BitIndex, 1) = "1" Then
                Pin.Bits = bits.Substring(0, BitIndex) + "0" + bits.Substring(BitIndex + 1)
            Else
                Pin.Bits = bits.Substring(0, BitIndex) + "1" + bits.Substring(BitIndex + 1)
            End If
            pg.Refresh()
            ICEditor.ClearTrace(pbTrace)
            ICEditor.DrawTrace(pbTrace, Pin)
            mnuSave.Enabled = True
        End If
    End Sub
    Private Sub pbSelected_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbSelected.DoubleClick
        Static State As Boolean = False
        Static Start As Integer = 0
        Dim Column As Integer = CInt((Control.MousePosition.X - pbSelected.Left) / 20)
        Dim y As Integer = Control.MousePosition.Y
        Static Row As Integer = 0
        If State Then
            Dim Text As String = InputBox("Span Label Text?", "Banana Board", "t1")

            DrawTraceRangeLabel(Text, Row, Start, Column)

            ReDim Preserve Project.TraceRangeLabels(Project.TraceRangeLabels.Length)
            Project.TraceRangeLabels(Project.TraceRangeLabels.Length - 1) = New TraceRangeLabel
            Project.TraceRangeLabels(Project.TraceRangeLabels.Length - 1).Text = Text
            Project.TraceRangeLabels(Project.TraceRangeLabels.Length - 1).Row = Row
            Project.TraceRangeLabels(Project.TraceRangeLabels.Length - 1).StartColumn = Start
            Project.TraceRangeLabels(Project.TraceRangeLabels.Length - 1).EndColumn = Column
            State = False
        Else
            Start = Column
            Row = CInt(y - PanelTrace.Top) / ROW_SCALE
            State = True

        End If
    End Sub

#End Region
#Region "Buttons"

    Private Sub cmdRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRun.Click
        Auto = True
        txtOut.Text = ""
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.Opaque, True)
        pbSelected.Image = New Bitmap(pbSelected.Width, pbSelected.Height)
        'pg.Enabled = False
        'cmdRun.Enabled = False
        Cycles = 0

        'Project.ClockStart = IIf(chkClockStart.Checked, 1, 0)
        Project.ClockDelay = Val(txtClockDelay.Text)

        ATMega.Project = Project
        ATMega.SendRowConfig(Project)
    End Sub
    Private Sub ADDChip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim ChipRow As DataRow = sender.Tag
        Dim Chip As New BBChip()
        Dim ChipXML As String = ChipRow("ChipXML")
        ' Create a memory stream containing the xml to deserialize
        Dim ms As New System.IO.MemoryStream(ChipXML.Length)
        ms.Write(System.Text.ASCIIEncoding.ASCII.GetBytes(ChipXML), 0, ChipXML.Length)
        ms.Position = 0
        ' Deserialize memory stream contents
        Dim xs As New Xml.Serialization.XmlSerializer(GetType(BananaBoard.BBChip))
        Chip = xs.Deserialize(ms)
        Dim Pin1Row As Integer = 0
        If ICCount > 0 AndAlso Project.Chips(ICCount - 1) IsNot Nothing Then
            Pin1Row = Project.Chips(ICCount - 1).Row + Project.Chips(ICCount - 1).PinCount / 2
        End If
        CreateIC(ICCount, Chip.Pins.Length, Chip.Value, Chip.Description, Pin1Row, True)
        ICCount += 1
        For PinNumber As Integer = 1 To Chip.Pins.Length
            Dim Pin As BBPin = Chip.Pins(PinNumber - 1)
            If PinNumber <= (Chip.Pins.Length) / 2 Then
                Pin.Row = Pin1Row + PinNumber - 1
                Project.RowPins(Pin1Row + PinNumber - 1) = Pin
                ROWLabel(Pin1Row + PinNumber - 1).Text = Pin.Text.Replace("~", String.Empty)
                RowICON(Pin1Row + PinNumber - 1).Image = ICEditor.GetRowIcon(Pin, 32)
            Else
                'Dim RowIndex As Integer = 32 + Pin1Row + ((Chip.Pins.Length) - PinNumber)
                'Pin.Row = 63 - Pin1Row - ((Chip.Pins.Length) - PinNumber)
                'Project.RowBPins(RowIndex - 32) = Pin
                'ROWLabel(RowIndex - 32).Text = Pin.Text.Replace("~", String.Empty) 'B
                'RowICON(RowIndex - 32).Image = ICEditor.GetRowIcon(Pin, 32) 'B
            End If
        Next

    End Sub

#End Region
#Region "Labels"

    Private Sub DrawTraceRangeLabel(ByVal text As String, ByVal Row As Integer, ByVal Start As Integer, ByVal Column As Integer)
        Application.DoEvents()
        Dim g As Graphics = Drawing.Graphics.FromImage(pbSelected.Image)
        Dim f As New Font("Arial", 7, FontStyle.Regular)
        Dim TextWidth As Integer = g.MeasureString(text, f).Width
        Dim TextX As Integer = Start * 20 + ((((Column * 20) - (Start * 20)) / 2) - (TextWidth / 2))
        g.DrawLine(Pens.Black, Column * 20 - 1, Row * ROW_SCALE, Column * 20 - 4, Row * ROW_SCALE - 2)
        g.DrawLine(Pens.Black, Column * 20 - 1, Row * ROW_SCALE, Column * 20 - 4, Row * ROW_SCALE + 2)
        g.DrawLine(Pens.Black, Start * 20 + 1, Row * ROW_SCALE, Start * 20 + 4, Row * ROW_SCALE - 2)
        g.DrawLine(Pens.Black, Start * 20 + 1, Row * ROW_SCALE, Start * 20 + 4, Row * ROW_SCALE + 2)
        g.DrawString(text, f, Brushes.Black, TextX, Row * ROW_SCALE - 5)
        g.DrawLine(Pens.Black, Start * 20 + 1, Row * ROW_SCALE, TextX, Row * ROW_SCALE)
        g.DrawLine(Pens.Black, TextX + TextWidth, Row * ROW_SCALE, Column * 20 - 1, Row * ROW_SCALE)
        g.Dispose()
        pbSelected.Invalidate()

    End Sub
    Private Sub DAC0_LabelClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DAC0.LabelClick
        pg.SelectedObject = sender
        pg.Visible = True
    End Sub
    Private Sub RTC_LabelClick(ByVal sender As Object, ByVal e As System.EventArgs)
        pg.SelectedObject = sender
        pg.Visible = True
    End Sub

#End Region
#Region "Treeview"

    Private Sub tvwDocs_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwDocs.AfterSelect
        If e.Node IsNot Nothing AndAlso e.Node.Tag IsNot Nothing AndAlso e.Node.Tag.ToString.Length > 0 Then
            wb.Navigate(e.Node.Tag)
        Else
            wb.Navigate("about:blank")
        End If
    End Sub

#End Region
#Region "Tabs"

    Private Sub tabs_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabs.DoubleClick

        tabs.BringToFront()
        tabs.Dock = IIf(tabs.Dock = DockStyle.Fill, DockStyle.None, DockStyle.Fill)
        If tabs.Dock <> DockStyle.Fill Then
            tabs.Left = splitBreadBoard.Width
            tabs.Top = ToolStrip1.Height
            tabs.Height = Me.Height - ToolStrip1.Height - 28
            tabs.Width = Me.Width - tabs.Left
            tabs.Anchor = AnchorStyles.Bottom And AnchorStyles.Right And AnchorStyles.Top And AnchorStyles.Left
        End If

    End Sub

#End Region
#Region "Panels"

    Private Sub panelBreadboard_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles panelBreadboard.Paint
        Dim g As Drawing.Graphics = e.Graphics

        Try
            For x As Integer = 0 To Me.Width Step 20
                g.DrawLine(Pens.LightGray, x, 0, x, BreadBoard.Height)
            Next
            For y As Integer = 20 To BreadBoard.Height Step ROW_SCALE
                g.DrawLine(Pens.LightGray, 0, y, panelBreadboard.Width, y)
            Next
        Catch ex As Exception
            Application.DoEvents()
        End Try

    End Sub

#End Region

#End Region
#Region "Functions"

#Region "Set Rows"

    Private Sub Set_Row_ICON(ByVal icon() As PictureBox, ByVal item As Integer, ByVal top As Integer, ByVal left As Integer)

        icon(item) = New PictureBox()
        icon(item).Width = ROW_SCALE
        icon(item).Height = ROW_SCALE
        icon(item).Top = top
        icon(item).Left = left
        icon(item).Image = ICEditor.imgRowIcons.Images(8)
        icon(item).SizeMode = PictureBoxSizeMode.CenterImage
        icon(item).BorderStyle = BorderStyle.None
        icon(item).Visible = True
        icon(item).Tag = item + 32

        AddHandler icon(item).Paint, AddressOf RowOut_Paint
        panelBreadboard.Controls.Add(icon(item))
        icon(item).BringToFront()

    End Sub

    Private Sub Set_RowA_Label(ByVal item As Integer)

        ROWLabel(item) = New Label()
        ROWLabel(item).Width = 79
        ROWLabel(item).Height = ROW_SCALE
        ROWLabel(item).Left = BreadBoard.Left - 100
        ROWLabel(item).Top = RowICON(item).Top + 1
        ROWLabel(item).Visible = True
        ROWLabel(item).Text = String.Empty
        ROWLabel(item).BorderStyle = BorderStyle.None
        ROWLabel(item).TextAlign = ContentAlignment.MiddleRight
        ROWLabel(item).BackColor = Color.Transparent
        ROWLabel(item).ForeColor = Color.Black
        ROWLabel(item).Tag = item

        AddHandler ROWLabel(item).DoubleClick, AddressOf ROW_Click
        AddHandler ROWLabel(item).MouseDown, AddressOf ROW_MouseDown
        AddHandler ROWLabel(item).Paint, AddressOf Row_Paint

        panelBreadboard.Controls.Add(ROWLabel(item))
        ROWLabel(item).BringToFront()

    End Sub
    'Private Sub Set_ROWB_Label(ByVal item As Integer)

    '    ROWBLabel(item) = New Label()
    '    ROWBLabel(item).Width = 79
    '    ROWBLabel(item).Left = RowBICON(item).Left + ROW_SCALE
    '    ROWBLabel(item).Height = ROW_SCALE
    '    ROWBLabel(item).Top = RowBICON(item).Top + 1
    '    ROWBLabel(item).Visible = True
    '    ROWBLabel(item).Text = String.Empty
    '    ROWBLabel(item).BackColor = Color.Transparent
    '    ROWBLabel(item).ForeColor = Color.Black
    '    ROWBLabel(item).BorderStyle = BorderStyle.None
    '    ROWBLabel(item).RightToLeft = Windows.Forms.RightToLeft.No
    '    ROWBLabel(item).TextAlign = ContentAlignment.MiddleLeft

    '    AddHandler ROWBLabel(item).DoubleClick, AddressOf ROWB_Click
    '    AddHandler ROWBLabel(item).MouseDown, AddressOf ROWB_MouseDown
    '    AddHandler ROWBLabel(item).Paint, AddressOf Row_Paint

    '    panelBreadboard.Controls.Add(ROWBLabel(item))
    '    ROWBLabel(item).BringToFront()

    'End Sub

    Private Sub Set_Row_Control(ByVal first As Integer, ByVal last As Integer, ByVal iconLeft As Integer)

        For item As Integer = first To last
            Me.Set_Row_ICON(Me.RowICON, item, item * ROW_SCALE + BreadBoard.Top, iconLeft)

            Me.Set_RowA_Label(item)
            Me.Set_ROW_Pins(Project.RowPins(item), ROWLabel(item).Text)
        Next item

    End Sub
    'Private Sub Set_RowB_Control(ByVal first As Integer, ByVal last As Integer)

    '    For item As Integer = first To last
    '        Me.Set_Row_ICON(Me.RowBICON, item, item * ROW_SCALE + BreadBoard.Top, BreadBoard.Left + BreadBoard.Width)

    '        Me.Set_ROWB_Label(item)
    '        Me.Set_ROW_Pins(Project.RowBPins(item), ROWBLabel(item).Text)
    '    Next item

    'End Sub

    Private Sub Set_ROW_Pins(ByRef BBPin As BBPin, ByRef pinText As String)

        If (BBPin Is Nothing) Then BBPin = New BBPin
        BBPin.Text = pinText

    End Sub

#End Region

    Private Sub LoadChips()
        If Not IO.File.Exists(ChipsFileName) Then
            dsChips = New DataSet
            Dim dtChips As New DataTable("Chips")
            dtChips.Columns.Add("ID", GetType(Integer))
            dtChips.Columns("ID").AutoIncrement = True
            dtChips.Columns.Add("Value")
            dtChips.Columns.Add("Description")
            dtChips.Columns.Add("Family")
            dtChips.Columns.Add("ChipXML")
            dtChips.Columns.Add("DataSheet")
            dsChips.Tables.Add(dtChips)
            SaveDB()
        Else
            LoadDB()
            Dim dtChips As DataTable = dsChips.Tables("Chips")
            If Not dtChips.Columns.Contains("DataSheet") Then
                dtChips.Columns.Add("DataSheet")
            End If
        End If

        PopulateICs("CMOS")
        PopulateICs("TTL")
        PopulateICs("Interface")
        PopulateICs("Memory")
        PopulateICs("Linear")
    End Sub
    Private Sub SaveDB()
        Dim s As New XmlSerializer(GetType(DataSet))
        Dim st As New System.IO.StreamWriter(ChipsFileName)
        s.Serialize(st, dsChips)
        st.Close()
    End Sub
    Private Sub LoadDB()
        Dim s As New XmlSerializer(GetType(DataSet))
        Dim st As New System.IO.StreamReader(ChipsFileName)
        dsChips = s.Deserialize(st)
    End Sub
    Private Sub PopulateICs(ByVal Family As String)
        Select Case Family
            Case "CMOS"
                mnuCMOS.DropDownItems.Clear()
            Case "TTL"
                mnuTTL.DropDownItems.Clear()
            Case "Interface"
                mnuInterface.DropDownItems.Clear()
            Case "Memory"
                mnuLinear.DropDownItems.Clear()
            Case "Linear"
                mnuLinear.DropDownItems.Clear()
        End Select
        For Each row As DataRow In dsChips.Tables("Chips").Select("Family = '" + Family + "'")
            Dim NewMenuItem As ToolStripDropDownItem = Nothing
            Select Case Family
                Case "CMOS"
                    NewMenuItem = mnuCMOS.DropDownItems.Add(row("Value") & " - " & row("Description"))
                Case "TTL"
                    NewMenuItem = mnuTTL.DropDownItems.Add(row("Value") & " - " & row("Description"))
                Case "Interface"
                    NewMenuItem = mnuInterface.DropDownItems.Add(row("Value") & " - " & row("Description"))
                Case "Memory"
                    NewMenuItem = mnuMemory.DropDownItems.Add(row("Value") & " - " & row("Description"))
                Case "Linear"
                    NewMenuItem = mnuLinear.DropDownItems.Add(row("Value") & " - " & row("Description"))
            End Select
            AddHandler NewMenuItem.Click, AddressOf ADDChip_Click
            NewMenuItem.Tag = row
        Next
    End Sub
    Private Sub ClearTrace()
        pbSelected.Image = New Bitmap(pbSelected.Width, pbSelected.Height)
        Application.DoEvents()
        Dim g As Drawing.Graphics = Nothing
        Try
Retry:
            g = Drawing.Graphics.FromImage(pbSelected.Image)
            For x As Integer = 0 To pbSelected.Width Step 20
                g.DrawLine(Pens.LightGray, x, 0, x, pbSelected.Height)
            Next
            For y As Integer = 20 To pbSelected.Height Step ROW_SCALE
                g.DrawLine(Pens.LightGray, 0, y, pbSelected.Width, y)
            Next
        Catch ex As Exception
            Application.DoEvents()
            GoTo Retry
        End Try
    End Sub
    Private Sub CreateIC(ByVal Index As Integer, ByVal Pins As Integer, ByVal ChipNo As String, ByVal Desc As String, ByVal Row As Integer, ByVal flip As Boolean)
        Chips(Index) = New PictureBox()
        Chips(Index).SizeMode = PictureBoxSizeMode.StretchImage
        Select Case Pins
            Case 8
                Chips(Index).Image = IC8.Image.Clone
            Case 14
                Chips(Index).Image = IC14.Image.Clone
            Case 16
                Chips(Index).Image = IC16.Image.Clone
            Case 18
                Chips(Index).Image = IC18.Image.Clone
            Case 20
                Chips(Index).Image = IC20.Image.Clone
            Case 24
                Chips(Index).Image = IC24.Image.Clone
            Case 28
                Chips(Index).Image = IC28.Image.Clone
            Case 32
                Chips(Index).Image = IC32.Image.Clone
            Case 40
                Chips(Index).Image = IC40.Image.Clone
        End Select
        Chips(Index).Height = ROW_SCALE * (Pins / 2)
        Chips(Index).Top = BreadBoard.Top + (Row * ROW_SCALE)
        Chips(Index).Width = 84 + IIf(Pins > 20, 84, 0)
        Chips(Index).Left = BreadBoard.Left + (BreadBoard.Width / 2) - IIf(Pins > 20, 84, 42)
        Chips(Index).Visible = True
        Chips(Index).Tag = Index
        AddHandler Chips(Index).MouseDown, AddressOf IC_MouseDown
        AddHandler Chips(Index).MouseMove, AddressOf IC_MouseMove
        AddHandler Chips(Index).MouseUp, AddressOf IC_MouseUp

        panelBreadboard.Controls.Add(Chips(Index))
        Chips(Index).BringToFront()
        DrawICNumber(Chips(Index), ChipNo, Desc)

        Project.Chips(Index) = New IC
        Project.Chips(Index).Text = ChipNo
        Project.Chips(Index).Description = Desc
        Project.Chips(Index).PinCount = Pins
        Project.Chips(Index).Row = Row
        Project.Chips(Index).Flip = flip
        If flip Then
            Chips(Index).Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            Chips(Index).Refresh()
        End If
    End Sub
    Private Sub ClearRowLabelSelect()
        For Each l As Object In panelBreadboard.Controls
            If l.GetType Is GetType(Label) Or l.GetType Is GetType(PictureBox) Then
                l.BorderStyle = BorderStyle.None
            End If
        Next
    End Sub
    Private Sub DebugPrint(ByVal text As String)
        If txtOut.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf DebugPrint)
            Me.Invoke(d, New Object() {[text]})
        Else
            If text.StartsWith("~") Then txtOut.Text = "" : text = text.Substring(1, text.Length - 1)
            txtOut.Text &= Now & ": " & [text] & vbCrLf
            Application.DoEvents()
        End If
    End Sub
    Private Sub DrawICNumber(ByVal IC As PictureBox, ByVal PartNo As String, ByVal PartDesc As String)

        Dim g As Graphics = Drawing.Graphics.FromImage(IC.Image)
        Dim F As New Font("Arial", 10, FontStyle.Regular)
        g.RotateTransform(270)
        g.TranslateTransform( _
            IC.ClientSize.Width / 2, _
            IC.ClientSize.Height / 2, _
            Drawing2D.MatrixOrder.Append)

        Dim string_format As New StringFormat
        string_format.Alignment = StringAlignment.Center
        string_format.LineAlignment = StringAlignment.Center

        g.DrawString(PartNo, Me.Font, Brushes.WhiteSmoke, 0, -8, string_format)
        g.DrawString(PartDesc, Me.Font, Brushes.WhiteSmoke, 0, 5, string_format)

        IC.Refresh()

    End Sub
    Private Sub ReadLPT()

        Dim Data As UInt16 = Inp(&H378)
        HexLine &= Data.ToString("X2") & " "
        ASCLine &= IIf(Data > 32 And Data < 127, Chr(Data), ".")
        BytesWide += 1
        If BytesWide = 32 Then
            DebugPrint((Address - 15).ToString("X4") & ": " & HexLine & " " & ASCLine)
            BytesWide = 0
            HexLine = ""
            ASCLine = ""
        End If

    End Sub

    Private Sub Set_frmTrace_Info()
        Me.SuspendLayout()
        Me.Text = "Banana Board 128"
        Me.Height = BreadBoard.Height / 2 + ToolStrip1.Height + panelBitEditor.Height
    End Sub
    Private Sub Set_BreadboardX()

        BreadBoard.Top = 0
        BreadBoard.Left = 79 + ROW_SCALE
        splitBreadBoard.Top = Me.ToolStrip1.Height
        splitBreadBoard.Left = 0
        splitBreadBoard.Height = Me.Height - ToolStrip1.Height - 28
        splitBreadBoard.SplitterDistance = BreadBoard.Height / 3
        panelBreadboard.Width = 200 + BreadBoard.Width + 5
        splitBreadBoard.Width = panelBreadboard.Width + 25

    End Sub
    Private Sub Set_TabsX()

        tabs.Left = splitBreadBoard.Width
        tabs.Top = ToolStrip1.Height
        tabs.Height = Me.Height - ToolStrip1.Height - 28
        tabs.Width = Me.Width - tabs.Left

    End Sub

    Private Sub Set_RowOut_Control()
        For y As Integer = 0 To 63
            RowOutICON(y) = New PictureBox
            RowOutICON(y).Width = ROW_SCALE
            RowOutICON(y).Height = ROW_SCALE
            RowOutICON(y).Top = y * ROW_SCALE
            RowOutICON(y).Left = 0
            RowOutICON(y).SizeMode = PictureBoxSizeMode.CenterImage
            RowOutICON(y).BorderStyle = BorderStyle.None

            RowOutICON(y).Visible = True
            RowOutICON(y).Tag = y + 32
            AddHandler RowOutICON(y).Paint, AddressOf RowOut_Paint

            PanelTrace.Controls.Add(RowOutICON(y))

            ROWOUTLabel(y) = New Label()
            ROWOUTLabel(y).Width = 79
            ROWOUTLabel(y).Left = ROW_SCALE
            ROWOUTLabel(y).Height = ROW_SCALE
            ROWOUTLabel(y).Top = y * ROW_SCALE
            ROWOUTLabel(y).Visible = True
            ROWOUTLabel(y).Text = "USER " & y + 1
            ROWOUTLabel(y).BorderStyle = BorderStyle.None
            ROWOUTLabel(y).TextAlign = ContentAlignment.MiddleLeft
            ROWOUTLabel(y).BackColor = Color.White
            ROWOUTLabel(y).ForeColor = Color.Blue
            ROWOUTLabel(y).Tag = y
            ROWOUTLabel(y).AllowDrop = True

            AddHandler ROWOUTLabel(y).Paint, AddressOf RowOut_Paint
            AddHandler ROWOUTLabel(y).DoubleClick, AddressOf ROWOUT_Click
            AddHandler ROWOUTLabel(y).MouseDown, AddressOf ROWOUT_MouseDown
            AddHandler ROWOUTLabel(y).DragOver, AddressOf ROWOUT_DragOver
            AddHandler ROWOUTLabel(y).DragDrop, AddressOf ROWOUT_DragDrop

            PanelTrace.Controls.Add(ROWOUTLabel(y))
            ROWOUTLabel(y).BringToFront()
        Next y
    End Sub
    Private Sub Set_DigitSourceLabel()
        For y As Integer = 0 To 15
            DigitSourceLabel(y) = New Label()
            DigitSourceLabel(y).Width = 14
            DigitSourceLabel(y).Left = y * ROW_SCALE + 3
            DigitSourceLabel(y).Height = PanelADC.Height
            DigitSourceLabel(y).Top = 0
            DigitSourceLabel(y).Visible = True
            DigitSourceLabel(y).Text = "D " & y
            DigitSourceLabel(y).BorderStyle = BorderStyle.None
            DigitSourceLabel(y).TextAlign = ContentAlignment.TopCenter
            DigitSourceLabel(y).BackColor = Color.Silver
            DigitSourceLabel(y).ForeColor = Color.Blue
            DigitSourceLabel(y).Tag = y
            PanelLCD.Controls.Add(DigitSourceLabel(y))
        Next
    End Sub

    Private Sub Set_pb()
        pbSelected.Left = ROWOUTLabel(0).Width + ROW_SCALE
        pbSelected.Top = 0
        pbSelected.Width = 5120
        pbSelected.Height = ROW_SCALE * 64
        pbSelected.BorderStyle = BorderStyle.None
    End Sub
    Private Sub Set_pgX()

        pg.Height = splitBreadBoard.Panel2.Height - panelBitEditor.Height - 2
        pg.Controls(0).Controls(0).BackColor = Color.Transparent
        pg.Controls(0).Controls(1).BackColor = Color.Transparent
        AddHandler pg.Controls(0).Paint, AddressOf pg_labelpaint

    End Sub
    Private Sub Set_pots()
        Dim pot As New BBPot

        pot.Text = "Pot 1"
        pot.Enabled = False
        pot.Index = 0

        Pot0.Tag = pot
        Pot0.Text = "Pot 1"

        pot = New BBPot
        pot.Text = "Pot 2"
        pot.Enabled = False
        pot.Index = 1

        Pot1.Tag = pot
        Pot1.Text = "Pot 2"
    End Sub
    Private Sub Set_ADC()
        'Analog to Digital

        ADC0.Text = "ADC 1"
        ADC1.Text = "ADC 2"
        ADC2.Text = "ADC 3"
        ADC3.Text = "ADC 4"
        ADC4.Text = "ADC 5"
        ADC5.Text = "ADC 6"
        ADC6.Text = "ADC 7"
        ADC7.Text = "ADC 8"
    End Sub
    Private Sub Set_DAC()
        DAC0.Text = "DAC 1"
        DAC1.Text = "DAC 2"
    End Sub
    Private Sub Set_Timer()
        Dim Timer1 As New BananaBoard.BananaTimer16
        Timer1.fclk_IO = 16000000
        Timer1.Visible = True
        AddHandler Timer1.LabelClick, AddressOf RTC_LabelClick
        PanelTimer.Controls.Add(Timer1)
        Timer1.BringToFront()
    End Sub

#End Region

End Class


'Private Sub Set_RowA_ICON(ByVal item As Integer)

'    RowAICON(item) = New PictureBox()
'    RowAICON(item).Width = ROW_SCALE
'    RowAICON(item).Height = ROW_SCALE
'    RowAICON(item).Top = item * ROW_SCALE + BreadBoard.Top
'    RowAICON(item).Left = BreadBoard.Left - ROW_SCALE
'    RowAICON(item).Image = ICEditor.imgRowIcons.Images(8)
'    RowAICON(item).SizeMode = PictureBoxSizeMode.CenterImage
'    RowAICON(item).BorderStyle = BorderStyle.None
'    RowAICON(item).Visible = True
'    RowAICON(item).Tag = item + 32

'    AddHandler RowAICON(item).Paint, AddressOf RowOut_Paint
'    panelBreadboard.Controls.Add(RowAICON(item))
'    RowAICON(item).BringToFront()

'End Sub
'Private Sub Set_ROWB_ICON(ByVal item As Integer)

'    RowBICON(item) = New PictureBox()
'    RowBICON(item).Width = ROW_SCALE
'    RowBICON(item).Height = ROW_SCALE
'    RowBICON(item).Top = item * ROW_SCALE + BreadBoard.Top
'    RowBICON(item).Left = BreadBoard.Left + BreadBoard.Width
'    RowBICON(item).SizeMode = PictureBoxSizeMode.CenterImage
'    RowBICON(item).Image = ICEditor.imgRowIcons.Images(8)
'    RowBICON(item).BorderStyle = BorderStyle.None
'    RowBICON(item).Visible = True
'    RowBICON(item).Tag = item + 32

'    AddHandler RowBICON(item).Paint, AddressOf RowOut_Paint

'    panelBreadboard.Controls.Add(RowBICON(item))
'    RowBICON(item).BringToFront()
'End Sub


'Private Sub chkClockStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
'    'Project.ClockStart = IIf(chkClockStart.Checked, 1, 0)
'End Sub
'Private Sub chkPullUps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
'    'Project.PullUps = chkPullUps.Checked
'End Sub

'Private Sub ROWOUT_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
'    Dim ROW As Label = CType(sender, Label)
'    DoDragDrop(sender, DragDropEffects.Copy)
'    pg.Visible = True
'    pg.BringToFront()
'    If e.Clicks = 2 Then
'        ROWOUTA_Click(sender, e)
'    End If
'    If LastOutRowSelected IsNot Nothing Then
'        If LastOutRowSelected IsNot ROW Then
'            If Project.RowAPins(LastOutRowSelected.Tag) IsNot Nothing Then
'                LastOutRowSelected.BackColor = Color.FromName(Project.RowAPins(LastOutRowSelected.Tag).BackColor)
'            Else
'                LastOutRowSelected.BackColor = Color.White
'            End If
'            LastOutRowSelected = ROW
'        End If
'    Else
'        LastOutRowSelected = ROW
'    End If
'    ROW.BackColor = Color.LightGray
'    pg.SelectedObject = Project.RowAPins(ROW.Tag)
'End Sub