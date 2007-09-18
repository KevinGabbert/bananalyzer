Imports System.Data
Imports System.Xml
Imports System.Xml.Serialization

'TODO: frmTrace and ICEditor both could go single path on that ic drawing stuff

Public Class ICEditor

    Private dsChips As DataSet
    Dim CurrentChipRow As DataRow
    Private Chip As BananaBoard.BBChip

    Dim ChipsFileName As String = Application.StartupPath & "/BananaChips.db"
    Private NewChip As Boolean = False

#Region "Event Handlers"

#Region "Form"

    Private Sub ICEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
        'Me.Height = 441 + ToolStrip1.Height + 6
        pg.Left = 391
        pg.Width = Me.Width - pg.Left - 6
        'pg.Height = Me.Height - Panel1.Height - ToolStrip1.Height
        Panel1.Left = 0
        ' PopulateICs("CMOS")
        Me.BackColor = Color.White ' Color.FromArgb(160, 160, 160)

    End Sub

#End Region
#Region "Row"

    Private Sub ROW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ROW As Label = CType(sender, Label)
        ROW.Text = InputBox("Row Label", "BananaBoard", ROW.Text)
        'Project.RowAPins(ROW.Tag).Text = ROW.Text
    End Sub
    Private Sub ROW_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim ROW As Label = CType(sender, Label)
        'DoDragDrop(sender, DragDropEffects.Copy)
        'pg.Visible = True
        'pg.BringToFront()
        If e.Clicks = 2 Then
            ROW_Click(sender, e)
        End If
        'ROW.BackColor = Color.LightGray
        'If Project.RowAPins(ROW.Tag).Text = "" Then Project.RowAPins(ROW.Tag).Text = ROW.Text
        pg.SelectedObject = Chip.Pins(ROW.Tag)
        ChipPic.BorderStyle = BorderStyle.None
        For Each l As Control In Me.Controls
            If l.GetType Is GetType(Label) Then
                CType(l, Label).BorderStyle = BorderStyle.None
            End If
        Next
        ROW.BorderStyle = BorderStyle.FixedSingle
        ClearTrace(pbTrace)
        Select Case Chip.Pins(ROW.Tag).PinFunction
            Case "Input"
                If Chip.Pins(ROW.Tag).PullUp Then
                    Chip.Pins(ROW.Tag).Bits = New String("1", 512)
                Else
                    Chip.Pins(ROW.Tag).Bits = New String("I", 512)
                End If
                DrawTrace(pbTrace, Chip.Pins(ROW.Tag))
            Case "Rising Clock"
                DrawTrace(pbTrace, Chip.Pins(ROW.Tag))
            Case "Falling Clock"
                DrawTrace(pbTrace, Chip.Pins(ROW.Tag))
            Case "High ( +5V )"
                DrawTrace(pbTrace, Chip.Pins(ROW.Tag))
            Case "Low ( GND )"
                DrawTrace(pbTrace, Chip.Pins(ROW.Tag))
            Case "Scripted Output"
                DrawTrace(pbTrace, Chip.Pins(ROW.Tag))
        End Select
    End Sub
    Private Sub ROW_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim RowLabel As Label = CType(sender, Label)
        If Chip.Pins(RowLabel.Tag).Text.Contains("~") Then
            If RowLabel.TextAlign = ContentAlignment.MiddleLeft Then
                Dim Text As String = Chip.Pins(RowLabel.Tag).Text
                Dim Left As Integer = e.Graphics.MeasureString(Text.Substring(0, Text.IndexOf("~")), RowLabel.Font, 79).Width + 1
                Text = Text.Substring(Text.IndexOf("~") + 1)
                Dim TextWidth As Integer = e.Graphics.MeasureString(Text, RowLabel.Font, 79).Width - 5
                ' Right side
                e.Graphics.DrawLine(Pens.Black, Left, 3, Left + TextWidth, 3)
            Else
                Dim TextWidth As Integer = e.Graphics.MeasureString(Chip.Pins(RowLabel.Tag).Text.Replace("~", ""), RowLabel.Font, 79).Width - 7
                'Left Side
                Dim Left As Integer = RowLabel.Width - TextWidth - 5
                e.Graphics.DrawLine(Pens.Black, Left, 3, 75, 3)
            End If
        End If

    End Sub

#End Region
#Region "Menu"

    Private Sub mnuSaveChip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaveChip.Click

        If NewChip And Chip.Value.Length > 0 And Chip.Description.Length > 0 Then
            Dim NewRow As DataRow = dsChips.Tables("Chips").NewRow
            NewRow("Value") = Chip.Value
            NewRow("Description") = Chip.Description
            NewRow("Family") = cboFamily.SelectedItem

            Dim ms As New IO.MemoryStream
            Dim xs As New Xml.Serialization.XmlSerializer(Chip.GetType)
            xs.Serialize(ms, Chip)
            ms.Position = 0
            Dim Buf(ms.Length - 1) As Byte
            ms.Read(Buf, 0, ms.Length)

            Dim ChipXML As String = System.Text.ASCIIEncoding.ASCII.GetString(Buf)
            NewRow("ChipXML") = ChipXML
            dsChips.Tables("Chips").Rows.Add(NewRow)
            dsChips.AcceptChanges()
            Dim s As New XmlSerializer(GetType(DataSet))
            Dim st As New System.IO.StreamWriter(ChipsFileName)
            s.Serialize(st, dsChips)
            st.Close()
            NewChip = False
            cboIC.Enabled = True
            mnuSaveChip.Enabled = False
            cboFamily.SelectedItem = NewRow("Family")
        Else
            Dim ms As New IO.MemoryStream
            Dim xs As New Xml.Serialization.XmlSerializer(Chip.GetType)
            xs.Serialize(ms, Chip)
            ms.Position = 0
            Dim Buf(ms.Length - 1) As Byte
            ms.Read(Buf, 0, ms.Length)

            Dim ChipXML As String = System.Text.ASCIIEncoding.ASCII.GetString(Buf)
            CurrentChipRow("ChipXML") = ChipXML
            CurrentChipRow.AcceptChanges()
            dsChips.AcceptChanges()
            Dim s As New XmlSerializer(GetType(DataSet))
            Dim st As New System.IO.StreamWriter(ChipsFileName)
            s.Serialize(st, dsChips)
            st.Close()
            mnuSaveChip.Enabled = False
        End If

    End Sub
    Private Sub mnuAddChip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAdd8Pin.Click, mnuAdd14Pin.Click, mnuAdd16Pin.Click, mnuAdd18Pin.Click, mnuAdd20Pin.Click, mnuAdd24Pin.Click, mnuAdd28Pin.Click, mnuAdd32Pin.Click, mnuAdd40Pin.Click

        Dim mnu As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim Pins As Integer = Val(mnu.Text)
        Dim Value As String = InputBox("Chip #?", "Banana Board", "")
        Dim Desc As String = InputBox("Chip Description?", "Banana Board", "")
        Chip = New BananaBoard.BBChip()
        Chip.Description = Desc
        Chip.Value = Value
        ReDim Chip.Pins(Pins - 1)
        For pin As Integer = 0 To Pins - 1
            Chip.Pins(pin) = New BananaBoard.BBPin
        Next
        NewChip = True
        CreateIC(Pins, Value, Desc, False)
        cboIC.SelectedIndex = cboIC.Items.Add(Value & " - " & Desc)
        cboIC.Enabled = False
        cboFamily.SelectedIndex = 0
        If Value.StartsWith("74") Then cboFamily.SelectedIndex = 1
        If Value.StartsWith("LM") Then cboFamily.SelectedIndex = 2

    End Sub

#End Region
#Region "ICEditor"

    Private Sub ICEditor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim g As Drawing.Graphics = e.Graphics

        Try
            For x As Integer = 0 To Me.Width Step 20
                g.DrawLine(Pens.LightGray, x, 0, x, Me.Height)
            Next
            For y As Integer = 0 To Me.Height Step 21
                g.DrawLine(Pens.LightGray, 0, y, Me.Width, y)
            Next
        Catch ex As Exception
            Application.DoEvents()
        End Try

    End Sub
    Private Sub ICEditor_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If cboFamily.SelectedIndex < 0 Then cboFamily.SelectedIndex = 0
    End Sub

#End Region
#Region "ComboBoxes"

    Private Sub cboFamily_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFamily.SelectedIndexChanged
        If Not NewChip Then PopulateICs(cboFamily.Text)
    End Sub
    Private Sub cboIC_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIC.SelectedIndexChanged

        If NewChip Then Exit Sub
        If cboIC.SelectedIndex = -1 Or dsChips.Tables("Chips").Rows.Count = 0 Then Exit Sub
        Dim row As DataRow = dsChips.Tables("Chips").Select("Family = '" + cboFamily.SelectedItem + "'")(cboIC.SelectedIndex)
        Dim ChipXML As String = row("ChipXML")
        ' Create a memory stream containing the xml to deserialize
        Dim ms As New System.IO.MemoryStream(ChipXML.Length)
        ms.Write(System.Text.ASCIIEncoding.ASCII.GetBytes(ChipXML), 0, ChipXML.Length)
        ms.Position = 0
        ' Deserialize memory stream contents
        Dim xs As New Xml.Serialization.XmlSerializer(GetType(BananaBoard.BBChip))
        Chip = xs.Deserialize(ms)
        CreateIC(Chip.Pins.Length, Chip.Value, Chip.Description, False)
        NewChip = False
        mnuSaveChip.Enabled = False
        CurrentChipRow = row
        pg.Focus()

    End Sub

#End Region

    Private Sub pg_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pg.Paint

        Dim c As Control = CType(pg.Controls(2), Control)
        'If c.BackgroundImage Is Nothing Then
        '    c.BackgroundImage = New Bitmap(c.Width, c.Height)
        'End If
        Application.DoEvents()

        Dim g As Drawing.Graphics = Drawing.Graphics.FromHwnd(CType(pg.Controls(2), Control).Handle)

        Try
            Dim Top As Integer = 6 * 16
            For x As Integer = 0 To c.Width Step 20
                g.DrawLine(Pens.LightGray, x, Top, x, c.Height)
            Next
            For y As Integer = Top To c.Height Step 21
                g.DrawLine(Pens.LightGray, 0, y, c.Width, y)
            Next
        Catch ex As Exception
            Application.DoEvents()
        End Try

    End Sub
    Private Sub ChipPic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChipPic.Click

        For Each l As Control In Me.Controls
            If l.GetType Is GetType(Label) Then
                CType(l, Label).BorderStyle = BorderStyle.None
            End If
        Next
        pg.SelectedObject = Chip
        ChipPic.BorderStyle = BorderStyle.FixedSingle

    End Sub
    Private Sub pg_PropertyValueChanged(ByVal s As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles pg.PropertyValueChanged

        mnuSaveChip.Enabled = True
        Select Case e.ChangedItem.Label
            Case "Pin Name"
                GetSelectedLabel.Text = e.ChangedItem.Value.ToString.Replace("~", "")
                GetSelectedLabel.Invalidate()
            Case "Output"
            Case "Function"
                Dim Pin As BananaBoard.BBPin = Chip.Pins(GetSelectedLabel.Tag)
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
                End Select
                pg.SelectedObject = Pin
                ' Dim ImageIndex As Integer = GetRowIcon(Pin)
                GetIconByIndex(GetSelectedLabel.Tag).Image = GetRowIcon(Pin, Chip.Pins.Length / 2)
                ' If GetSelectedLabel.Tag > (Chip.Pins.Length / 2) - 1 AndAlso ImageIndex < 2 Or ImageIndex = 5 Then GetIconByIndex(GetSelectedLabel.Tag).Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
                ClearTrace(pbTrace)
                DrawTrace(pbTrace, Pin)
        End Select

    End Sub
    Private Sub pbTrace_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbTrace.MouseDoubleClick

        Dim BitIndex As Integer = Int(e.X / 20)
        Dim Pin As BananaBoard.BBPin = CType(pg.SelectedObject, BananaBoard.BBPin)
        If Not Pin.Clock And Pin.Output Then
            Dim bits As String = Pin.Bits.PadRight(512, "0")
            If bits.Substring(BitIndex, 1) = "1" Then
                Pin.Bits = bits.Substring(0, BitIndex) + "0" + bits.Substring(BitIndex + 1)
            Else
                Pin.Bits = bits.Substring(0, BitIndex) + "1" + bits.Substring(BitIndex + 1)
            End If
            pg.Refresh()
            ClearTrace(pbTrace)
            DrawTrace(pbTrace, Pin)
            mnuSaveChip.Enabled = True
        End If

    End Sub

#End Region
#Region "Functions"

    Private Sub CreateIC(ByVal Pins As Integer, ByVal Value As String, ByVal Desc As String, ByVal flip As Boolean)
        Dim rl As New Collection
        For Each l As Control In Me.Controls
            If l.GetType Is GetType(Label) Then rl.Add(l)
            If l.GetType Is GetType(PictureBox) AndAlso l.Name <> "ChipPic" AndAlso Name <> "pbTrace" Then rl.Add(l)
        Next
        For Each l As Control In rl
            Me.Controls.Remove(l)
        Next
        ChipPic.Visible = False
        ChipPic.SizeMode = PictureBoxSizeMode.StretchImage
        Dim ChipPicImage As Image = Nothing
        Select Case Pins
            Case 8
                ChipPicImage = frmTrace.IC8.Image.Clone
            Case 14
                ChipPicImage = frmTrace.IC14.Image.Clone
            Case 16
                ChipPicImage = frmTrace.IC16.Image.Clone
            Case 18
                ChipPicImage = frmTrace.IC18.Image.Clone
            Case 20
                ChipPicImage = frmTrace.IC20.Image.Clone
            Case 24
                ChipPicImage = frmTrace.IC24.Image.Clone
            Case 28
                ChipPicImage = frmTrace.IC28.Image.Clone
            Case 32
                ChipPicImage = frmTrace.IC32.Image.Clone
            Case 40
                ChipPicImage = frmTrace.IC40.Image.Clone
        End Select
        ChipPicImage.RotateFlip(RotateFlipType.Rotate180FlipNone)
        ChipPic.Image = ChipPicImage
        ChipPic.Height = 21 * (Pins / 2)
        ChipPic.Width = 84 + IIf(Pins > 20, 84, 0)
        ChipPic.Top = (((Me.Height - Panel1.Height) / 2) - (ChipPic.Height / 2))
        ChipPic.Left = (((Me.Width - pg.Width) / 2) - (ChipPic.Width / 2))
        ChipPic.Visible = True
        'Me.Width = ChipPic.Left + ChipPic.Width + 80 + pg.Width
        ' Panel1.Width = pg.Width

        Me.Controls.Add(ChipPic)
        ChipPic.BringToFront()
        DrawICNumber(ChipPic, Value, Desc)

        For row As Integer = 0 To (Pins / 2) - 1
            Dim ROWALabel As Label = New Label()

            ROWALabel.Width = 79
            ROWALabel.Left = ChipPic.Left - 101
            ROWALabel.Height = 21
            ROWALabel.Top = ChipPic.Top + row * 21
            ROWALabel.Visible = True

            Dim ROWAIcon As PictureBox = New PictureBox
            ROWAIcon.Left = ChipPic.Left - 21
            ROWAIcon.Top = ROWALabel.Top
            ROWAIcon.Height = 21
            ROWAIcon.Width = 21
            Chip.Pins(row).Row = row
            ROWAIcon.Image = GetRowIcon(Chip.Pins(row), Chip.Pins.Length / 2)
            ROWAIcon.SizeMode = PictureBoxSizeMode.CenterImage
            ROWAIcon.Tag = row
            ROWAIcon.Visible = True
            ROWAIcon.BackColor = Color.Transparent
            'AddHandler ROWAIcon.DoubleClick, AddressOf RowIcon_DoubleClick
            Me.Controls.Add(ROWAIcon)

            If NewChip Then
                ROWALabel.Text = row + 1
            Else
                ROWALabel.Text = Chip.Pins(row).Text.Replace("~", "")
            End If
            ROWALabel.BorderStyle = IIf(row = 0, BorderStyle.FixedSingle, BorderStyle.None)
            ROWALabel.TextAlign = ContentAlignment.MiddleRight
            If NewChip Then
                Chip.Pins(row) = New BananaBoard.BBPin
                Chip.Pins(row).Text = row + 1
            End If
            ROWALabel.ForeColor = Color.Black
            ROWALabel.BackColor = ROWAIcon.BackColor
            ROWALabel.Tag = row
            AddHandler ROWALabel.MouseDown, AddressOf ROW_MouseDown
            AddHandler ROWALabel.Paint, AddressOf ROW_Paint
            Me.Controls.Add(ROWALabel)
            ROWALabel.BringToFront()
            Dim g As Graphics = Graphics.FromHwnd(ROWALabel.Handle)
            g.DrawLine(Pens.White, 2, 2, 76, 2)
            ROWALabel.Refresh()

            Dim ROWBLabel As Label = New Label()
            ROWBLabel.Width = 79
            ROWBLabel.Left = ChipPic.Left + ChipPic.Width + 21
            ROWBLabel.Height = 21
            ROWBLabel.Top = ChipPic.Top + row * 21
            ROWBLabel.Visible = True
            Dim ROWBIcon As PictureBox = New PictureBox
            ROWBIcon.Left = ROWBLabel.Left - 21
            ROWBIcon.Top = ROWBLabel.Top
            ROWBIcon.Height = 21
            ROWBIcon.Width = 21
            Chip.Pins(Pins - row - 1).Row = (Pins - row - 1)
            ROWBIcon.Image = GetRowIcon(Chip.Pins(Pins - row - 1), Chip.Pins.Length / 2) ' imgRowIcons.Images(ImageIndex)
            ROWBIcon.SizeMode = PictureBoxSizeMode.CenterImage
            ROWBIcon.Tag = Pins - row - 1
            ROWBIcon.BackColor = Color.Transparent
            ROWBIcon.Visible = True
            'AddHandler ROWBIcon.DoubleClick, AddressOf RowIcon_DoubleClick
            Me.Controls.Add(ROWBIcon)

            If NewChip Then
                ROWBLabel.Text = Pins - row
            Else
                ROWBLabel.Text = Chip.Pins(Pins - row - 1).Text.Replace("~", "")
            End If
            ROWBLabel.BorderStyle = BorderStyle.None
            ROWBLabel.TextAlign = ContentAlignment.MiddleLeft
            If NewChip Then
                Chip.Pins(Pins - row - 1) = New BananaBoard.BBPin
                Chip.Pins(Pins - row - 1).Text = Pins - row
            End If
            ROWBLabel.ForeColor = Color.Black
            ROWBLabel.BackColor = Color.Transparent
            ROWBLabel.Tag = Pins - row - 1
            AddHandler ROWBLabel.MouseDown, AddressOf ROW_MouseDown
            AddHandler ROWBLabel.Paint, AddressOf ROW_Paint
            Me.Controls.Add(ROWBLabel)
            ROWBLabel.BringToFront()
        Next

        ChipPic.Refresh()
        ChipPic.Visible = True
        pg.SelectedObject = Chip.Pins(0)
        ClearTrace(pbTrace)
        DrawTrace(pbTrace, Chip.Pins(0))
    End Sub
    Private Sub PopulateICs(ByVal Family As String)
        cboIC.Items.Clear()
        For Each row As DataRow In dsChips.Tables("Chips").Select("Family = '" + Family + "'")
            cboIC.Items.Add(row("Value") & " - " & row("Description"))
        Next
        If cboIC.Items.Count > 0 Then cboIC.SelectedIndex = 0
    End Sub

    Public Function GetRowIcon(ByVal Pin As BananaBoard.BBPin, ByVal FlipStartIndex As Integer) As Image
        Dim ImageIndex As Integer = 0
        Select Case Pin.PinFunction
            Case "Input"
                ImageIndex = 0
            Case "High ( +5V )"
                ImageIndex = IIf(Pin.Text = "VCC", 6, 5)
            Case "Rising Clock"
                ImageIndex = 2
            Case "Falling Clock"
                ImageIndex = 3
            Case "Scripted Output"
                ImageIndex = 4
            Case "Low ( GND )"
                ImageIndex = IIf(Pin.Text = "GND", 7, 1)
            Case "Analog Input"
                ImageIndex = 9
            Case Else
                ImageIndex = 8
        End Select
        Dim IconImage As Image = imgRowIcons.Images(ImageIndex)
        If Pin.Row >= FlipStartIndex AndAlso (ImageIndex < 2 Or ImageIndex = 5) Then
            IconImage.RotateFlip(RotateFlipType.RotateNoneFlipX)
        End If
        Return IconImage
    End Function

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

    Public Sub ClearTrace(ByVal pb As PictureBox)
        Dim y As Integer = 0
        Dim x As Integer
        Dim g As Graphics
        Application.DoEvents()
        pb.Image = New Bitmap(pb.Width, pb.Height)
        g = Drawing.Graphics.FromImage(pb.Image)
        For x = 0 To pb.Width Step 20
            g.DrawLine(Pens.LightGray, x, 0, x, pb.Height)
            g.DrawString(x / 20, Me.Font, Brushes.Black, x, 17)
        Next
    End Sub
    Public Sub DrawTrace(ByRef pb As PictureBox, ByVal Pin As BananaBoard.BBPin)
        Dim y As Integer = 0
        Dim x As Integer
        Dim scale As Integer = IIf(Pin.Clock, 10, 20)
        Dim g As Graphics
        Application.DoEvents()
        g = Drawing.Graphics.FromImage(pb.Image)
        Dim Bits As String = Pin.Bits.PadRight(512, "0")
        Dim sample_value As Boolean = Not Pin.InvertClock
        Dim last_sample_value As Boolean = Pin.InvertClock
        For sample As Integer = 0 To 511
            x = sample * scale
            If Not Pin.Clock Then
                sample_value = (Bits.Substring(sample, 1) = "1")
                If sample > 0 Then last_sample_value = (Bits.Substring(sample - 1, 1) = "1")
            Else
                If Bits.Substring(sample / 2, 1) = "1" Then
                    sample_value = Not sample_value
                    last_sample_value = Not sample_value
                Else
                    sample_value = False
                    last_sample_value = Not sample_value
                End If
            End If
            If last_sample_value Then
                If sample_value Then
                    ' Hold High
                    g.DrawLine(Pens.Red, x, y + 5, x + scale, y + 5)
                Else
                    ' Falling Edge
                    g.DrawLine(Pens.Blue, x, y + 5, x, y + 15)
                    g.DrawLine(Pens.Blue, x, y + 15, x + scale, y + 15)
                End If
            Else
                If sample_value Then
                    ' Rising Edge
                    g.DrawLine(Pens.Red, x, y + 15, x, y + 5)
                    g.DrawLine(Pens.Red, x, y + 5, x + scale, y + 5)
                Else
                    ' Hold low
                    g.DrawLine(Pens.Blue, x, y + 15, x + scale, y + 15)
                End If
            End If
        Next
        pb.Invalidate()
    End Sub

    Private Function GetSelectedLabel() As Label
        For Each l As Control In Me.Controls
            If l.GetType Is GetType(Label) Then
                If CType(l, Label).BorderStyle = BorderStyle.FixedSingle Then
                    Return CType(l, Label)
                End If
            End If
        Next
        Return Nothing
    End Function
    Private Function GetIconByIndex(ByVal Index As Integer) As PictureBox
        For Each l As Control In Me.Controls
            If l.GetType Is GetType(PictureBox) And l.Name <> "ChipPic" And l.Name <> "pbTrace" Then
                If CType(l, PictureBox).Tag = Index Then
                    Return CType(l, PictureBox)
                End If
            End If
        Next
        Return Nothing
    End Function

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

#End Region

End Class


'Private Sub RowIcon_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
'    Dim RowAICON As PictureBox = CType(sender, PictureBox)
'    Dim Pin As BananaBoard.BBPin = Chip.Pins(RowAICON.Tag)
'    Dim ImageIndex As Integer = GetRowIcon(Pin)
'    ImageIndex += 1
'    If ImageIndex = 8 Then ImageIndex = 0
'    Select Case ImageIndex
'        Case 0 ' Input
'            Pin.Output = False
'            Pin.InvertClock = False
'            Pin.Clock = False
'            Pin.Bits = "0"
'        Case 1 ' Output
'            Pin.Output = True
'            Pin.InvertClock = False
'            Pin.Clock = False
'            Pin.Bits = "0"
'        Case 2 ' Clock
'            Pin.Output = True
'            Pin.Clock = True
'            Pin.InvertClock = False
'            Pin.Bits = New String("1", 512)
'        Case 3 ' Inverted Clock
'            Pin.Output = True
'            Pin.Clock = True
'            Pin.InvertClock = True
'            Pin.Bits = New String("1", 512)
'        Case 4 ' Scripted Output
'            Pin.Output = True
'            Pin.Clock = False
'            Pin.InvertClock = False
'            Pin.Bits = "00"
'    End Select
'    RowAICON.Image = imgRowIcons.Images(ImageIndex)
'    If ImageIndex < 2 Then RowAICON.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
'    pg.SelectedObject = Pin
'    ChipPic.BorderStyle = BorderStyle.None
'    For Each l As Control In Me.Controls
'        If l.GetType Is GetType(Label) Then
'            If l.Tag = RowAICON.Tag Then
'                CType(l, Label).BorderStyle = BorderStyle.FixedSingle
'            Else
'                CType(l, Label).BorderStyle = BorderStyle.None
'            End If
'        End If
'    Next
'    mnuSaveChip.Enabled = True
'End Sub