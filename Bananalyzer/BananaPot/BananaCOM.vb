Public Class BananaCOM

    Private WithEvents COMPort As New IO.Ports.SerialPort("COM6", "57600", IO.Ports.Parity.None, 8, IO.Ports.StopBits.One)

#Region "Form Variables"

    Public Const BB_ProductID = "~" & Chr(0)
    Public Const BB_ADC = "~" & Chr(1)
    Public Const BB_ROW_CONFIG = 2
    Public Const BB_SAMPLE_START = 3
    Public Const BB_READ_SAMPLES = 4
    Public Const BB_READ_ROW_CONFIG = 5
    Public Const BB_SET_ROW_BITS = 6
    Public Const BB_CMD_SET_POT = 7
    Public Const BB_CMD_WRITE_MATRIX = &HA7

    Public Const ROW_ENABLE As Byte = 0
    Public Const ROW_INPUT As Byte = 1
    Public Const ROW_CLOCK As Byte = 2
    Public Const ROW_CLOCK_INVERT As Byte = 3
    Public Const ROW_HASBITS As Byte = 4

    Public Event Info(ByVal Message As String)
    Public Event SamplingComplete()
    Public Event RowConfigComplete()
    Public Event RowBitsSetComplete()
    Public Event SamplesRead(ByVal Samples() As Byte)
    Public Project As BBProject
    Public Auto As Boolean = False

    Private RowBitsSet As Boolean = False
    Private matrix_column As Integer = 0

#End Region

#Region "Events"

    Public Sub New()
        COMPort.Open()
    End Sub
    Protected Overrides Sub Finalize()
        COMPort.Close()
        MyBase.Finalize()
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub COMPort_ErrorReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialErrorReceivedEventArgs) Handles COMPort.ErrorReceived

    End Sub
    Private Sub COMPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles COMPort.DataReceived
        Static Data As String = ""
        Static OPCode As Byte()
        Do While COMPort.BytesToRead > 0
            If OPCode Is Nothing Then
                ReDim OPCode(0)
            Else
                ReDim Preserve OPCode(OPCode.Length)
            End If
            OPCode(OPCode.Length - 1) = COMPort.ReadByte
        Loop
        If OPCode IsNot Nothing AndAlso OPCode.Length > 1 AndAlso OPCode(OPCode.Length - 1) = 0 Then
            Select Case OPCode(0)
                Case 1 ' ADC
                    Dim Channel As Byte = OPCode(1)
                    Dim ADCValue As UInt16 = OPCode(2)
                    ADCValue = ADCValue << 8
                    ADCValue += OPCode(3)
                    'ADCText(ADCValue)
                Case BB_SAMPLE_START ' Sample Cycle Complete
                    RaiseEvent SamplingComplete()
                Case BB_ROW_CONFIG ' Row Config Set
                    RaiseEvent RowConfigComplete()
                Case BB_SET_ROW_BITS ' Row bits have been set
                    RowBitsSet = True
                Case 4 ' Read Samples
                    Dim Samples(4095) As Byte
                    Try
                        For i As Integer = 0 To 4095
                            Samples(i) = OPCode(i + 1)
                        Next
                        RaiseEvent SamplesRead(Samples)
                        For i As Integer = 1 To 64 Step 8
                            RaiseEvent Info("---------------------Cycle " & (i / 8).ToString("0000") & "----------------")
                            RaiseEvent Info("LEFT : A0=" & LongToBinary(OPCode(i + 0), True) & " B0=" & LongToBinary(OPCode(i + 1), True) & " A1=" & LongToBinary(OPCode(i + 2), True) & " B1=" & LongToBinary(OPCode(i + 3), True))
                            RaiseEvent Info("RIGHT: A2=" & LongToBinary(OPCode(i + 4), True) & " B2=" & LongToBinary(OPCode(i + 5), True) & " A3=" & LongToBinary(OPCode(i + 6), True) & " B3=" & LongToBinary(OPCode(i + 7), True))
                        Next
                    Catch ex As Exception
                        RaiseEvent SamplesRead(Samples)
                    End Try
                Case BB_READ_ROW_CONFIG
                    Dim OutRowCount As Integer = OPCode(1)
                    For i As Integer = 2 To OPCode.Length - 2 Step 66
                        Dim RowInfo As String = "Row Index: " & OPCode(i)
                        If OPCode(i + 1) And (1 << ROW_ENABLE) Then
                            RowInfo &= " | Enabled"
                        End If
                        If OPCode(i + 1) And (1 << ROW_CLOCK) Then
                            RowInfo &= " | Clock"
                        Else
                            If OPCode(i + 1) And (1 << ROW_INPUT) Then
                                RowInfo &= " | Input"
                            Else
                                RowInfo &= " | Output"
                                RowInfo &= " | Invert Clock=" & CBool(OPCode(i + 1) And (1 << ROW_CLOCK_INVERT)).ToString()
                                RowInfo &= " |"
                                For x As Integer = 0 To 63
                                    RowInfo &= OPCode(i + 2 + x).ToString("X2") & " "
                                Next
                            End If
                        End If
                        RaiseEvent Info(RowInfo)
                    Next
                Case 99
                    Dim Text As String = System.Text.ASCIIEncoding.ASCII.GetString(OPCode).Substring(1, OPCode.Length - 2)
                    RaiseEvent Info(Text)
                Case Else
                    'Stop
            End Select
            OPCode = Nothing
        End If
    End Sub

#End Region
#Region "Functions"

    Public Function BitsToBytes(ByVal Bits As String, ByVal Invert As Boolean) As Byte()
        Dim Bytes(Bits.Length / 8) As Byte
        Dim CurrentByte As Byte = 0
        Dim CurrentBit As Integer = 7
        For bit As Integer = Bits.Length - 1 To 0 Step -1
            If Bits.Substring(bit, 1) = "1" Then
                Bytes(CurrentByte) = Bytes(CurrentByte) Or (1 << CurrentBit)
            End If
            If CurrentBit = 0 Then
                CurrentBit = 7
                CurrentByte += 1
            Else
                CurrentBit -= 1
            End If
        Next
        Return Bytes
    End Function
    Public Function BitsToBytes(ByVal Bits As String) As Byte()
        Dim Bytes(Bits.Length / 8) As Byte
        Dim CurrentByte As Byte = 0
        Dim CurrentBit As Integer = 7
        For bit As Integer = 0 To Bits.Length - 1
            If Bits.Substring(bit, 1) = "1" Then
                Bytes(CurrentByte) = Bytes(CurrentByte) Or (1 << CurrentBit)
            End If
            If CurrentBit = 0 Then
                CurrentBit = 7
                CurrentByte += 1
            Else
                CurrentBit -= 1
            End If
        Next
        Return Bytes
    End Function

    Public Sub WriteLEDMatrixRAM(ByVal VideoData As Byte())
        Dim packet(17) As Byte
        packet(0) = &H7E    ' ~
        packet(1) = BB_CMD_WRITE_MATRIX
        Dim Bits As String = String.Empty
        Bits &= "0000000000000000"
        Bits &= "0010011100011000"
        Bits &= "0010010000100100"
        Bits &= "0010001000100100"
        Bits &= "1111000100100100"
        Bits &= "1010010100100100"
        Bits &= "1010001000011000"
        Bits &= "0000000000000000"

        VideoData = BitsToBytes(Bits, True)

        Dim s As New IO.BinaryReader(IO.File.Open(Application.StartupPath & "\Lessons\LED Matrix Driver\test.bmp", IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read))
        'VideoData = s.ReadBytes(64)
        s.Close()
        'Array.Copy(VideoData, 0, packet, 2, 16)
        COMPort.Write(packet, 0, 18)

        'For y As Integer = 0 To 200
        '    For col As Integer = 0 To 15
        '        For bite As Integer = 0 To 15
        '            packet(2 + bite) = packet(2 + bite) << 1
        '        Next
        '        COMPort.Write(packet, 0, 18)
        '    Next
        '    Bits = "0000110011000000"
        '    Bits &= "0001001100100000"
        '    Bits &= "0010000000010000"
        '    Bits &= "0010000000010000"
        '    Bits &= "0001000000100000"
        '    Bits &= "0000100001000000"
        '    Bits &= "0000010010000000"
        '    Bits &= "0000001100000000"
        '    VideoData = BitsToBytes(Bits)
        '    Array.Copy(VideoData, 0, packet, 2, 16)
        'Next
    End Sub

    ' Convert this Long value into a binary string.
    Public Function LongToBinary(ByVal long_value As Long, _
        Optional ByVal separate_bytes As Boolean = True) As _
        String
        ' Convert into hex.
        Dim hex_string As String = long_value.ToString("X2")

        '' Zero-pad to a full 16 characters.
        'hex_string = New String("0", 16 - hex_string.Length) & _
        '    hex_string

        ' Read the hexadecimal digits
        ' one at a time from right to left.
        Dim result_string As String = ""
        For digit_num As Integer = 0 To 1
            ' Convert this hexadecimal digit into a
            ' binary nibble.
            Dim digit_value As Integer = _
                Integer.Parse(hex_string.Substring(digit_num, _
                1), Globalization.NumberStyles.HexNumber)

            ' Convert the value into bits.
            Dim factor As Integer = 8
            Dim nibble_string As String = ""
            For bit As Integer = 0 To 3
                If digit_value And factor Then
                    nibble_string &= "1"
                Else
                    nibble_string &= "0"
                End If
                factor \= 2
            Next bit

            ' Add the nibble's string to the left of the
            ' result string.
            result_string &= nibble_string
        Next digit_num

        ' Add spaces between bytes if desired.
        If separate_bytes Then
            Dim tmp As String = ""
            For i As Integer = 0 To result_string.Length - 8 _
                Step 8
                tmp &= result_string.Substring(i, 8) & " "
            Next i
            result_string = tmp.Substring(0, tmp.Length - 1)
        End If

        ' Return the result.
        Return result_string
    End Function
    Public Sub Set_Pot(ByVal Index As Integer, ByVal value As Integer)
        Dim packet(3) As Byte
        packet(0) = &H7E    ' ~
        packet(1) = BB_CMD_SET_POT
        packet(2) = Index
        packet(3) = value
        COMPort.Write(packet, 0, 4)
    End Sub

    Public Sub Sample()
        Dim packet(1) As Byte
        packet(0) = &H7E    ' ~
        packet(1) = BB_SAMPLE_START
        COMPort.Write(packet, 0, 2)
    End Sub
    Public Sub ReadSamples()
        Dim packet(1) As Byte
        packet(0) = &H7E    ' ~
        packet(1) = BB_READ_SAMPLES
        COMPort.Write(packet, 0, 2)
    End Sub

    Public Sub SendRowBits(ByRef Project As BananaBoard.BBProject)
        Dim bbrow As Integer = 0
        For row As Integer = 0 To 31
            bbrow = row
            If Project.RowPins(bbrow).Output Then
                Dim RowBytes() As Byte = BitsToBytes(Project.RowPins(bbrow).Bits)
                Dim bits_packet(RowBytes.Length + 3) As Byte
                bits_packet(0) = &H7E    ' ~
                bits_packet(1) = BB_SET_ROW_BITS
                bits_packet(2) = bbrow
                bits_packet(3) = IIf(RowBytes.Length > 64, 64, RowBytes.Length)
                For b As Integer = 0 To RowBytes.Length - 1
                    If b < 64 Then bits_packet(b + 4) = RowBytes(b)
                Next
                COMPort.Write(bits_packet, 0, bits_packet.Length)
                RowBitsSet = False
            End If
        Next
        'For row As Integer = 0 To 31
        '    bbrow = 63 - row
        '    If Project.RowBPins(row).Output Then
        '        Dim RowBytes() As Byte = BitsToBytes(Project.RowBPins(row).Bits)
        '        Dim bits_packet(RowBytes.Length + 3) As Byte
        '        bits_packet(0) = &H7E    ' ~
        '        bits_packet(1) = BB_SET_ROW_BITS
        '        bits_packet(2) = bbrow
        '        bits_packet(3) = IIf(RowBytes.Length > 64, 64, RowBytes.Length)
        '        For b As Integer = 0 To RowBytes.Length - 1
        '            If b < 64 Then bits_packet(b + 4) = RowBytes(b)
        '        Next
        '        COMPort.Write(bits_packet, 0, bits_packet.Length)
        '        RowBitsSet = False
        '    End If
        'Next
        RaiseEvent RowBitsSetComplete()
    End Sub

    Public Sub RequestRowConfig()
        Dim packet(1) As Byte
        packet(0) = &H7E    ' ~
        packet(1) = BB_READ_ROW_CONFIG

        COMPort.Write(packet, 0, 2)
    End Sub
    Public Sub SendRowConfig(ByRef Project As BananaBoard.BBProject)
        Dim rows(63) As Byte
        Dim packet(69) As Byte
        packet(0) = &H7E    ' ~
        packet(1) = BB_ROW_CONFIG
        packet(2) = &HFF ' IIf(Project.PullUps, &HFF, 0)
        packet(3) = packet(2)
        packet(4) = Project.ClockStart ' clock start state
        packet(5) = Project.ClockDelay ' clock start state
        Dim bbrow As Integer = 0
        For row As Integer = 0 To 63 '31
            bbrow = row
            'Select Case row
            '    Case 0 To 7
            '        bbrow = 7 - row
            '    Case 8 To 15
            '        bbrow = 15 - row + 8
            '    Case 16 To 23
            '        bbrow = 23 - row + 16
            '    Case 24 To 31
            '        bbrow = 31 - row + 24
            'End Select
            Select Case Project.RowPins(row).PinFunction
                Case "Input"
                    rows(bbrow) = rows(bbrow) Or (1 << ROW_INPUT)
                    rows(bbrow) = rows(bbrow) Or (1 << ROW_ENABLE)
                Case "High ( +5V )"
                    rows(bbrow) = rows(bbrow) Or (0 << ROW_INPUT)
                    rows(bbrow) = rows(bbrow) Or (1 << ROW_ENABLE)
                Case "Rising Clock"
                    rows(bbrow) = rows(bbrow) Or (1 << ROW_CLOCK)
                    rows(bbrow) = rows(bbrow) Or (1 << ROW_ENABLE)
                Case "Falling Clock"
                    rows(bbrow) = rows(bbrow) Or (1 << ROW_CLOCK)
                    rows(bbrow) = rows(bbrow) Or (1 << ROW_CLOCK_INVERT)
                    rows(bbrow) = rows(bbrow) Or (1 << ROW_ENABLE)
                Case "Scripted Output"
                    rows(bbrow) = rows(bbrow) Or (0 << ROW_INPUT)
                    rows(bbrow) = rows(bbrow) Or (1 << ROW_ENABLE)
                Case "Low ( GND )"
                    rows(bbrow) = rows(bbrow) Or (0 << ROW_INPUT)
                    rows(bbrow) = rows(bbrow) Or (1 << ROW_ENABLE)
                Case "Analog Input"
                    rows(bbrow) = rows(bbrow) Or (1 << ROW_INPUT)
                    rows(bbrow) = rows(bbrow) Or (1 << ROW_ENABLE)
                Case Else
                    rows(bbrow) = rows(bbrow) Or (0 << ROW_ENABLE)
            End Select
            'If Project.RowAPins(row).Output Then
            '    rows(bbrow) = rows(bbrow) Or (0 << ROW_INPUT)
            'Else
            '    rows(bbrow) = rows(bbrow) Or (1 << ROW_INPUT)
            'End If
            'If Project.RowAPins(row).Clock Then
            '    rows(bbrow) = rows(bbrow) Or (1 << ROW_CLOCK)
            'End If
            'If Project.RowAPins(row).InvertClock Then
            '    rows(bbrow) = rows(bbrow) Or (1 << ROW_CLOCK_INVERT)
            'End If
            'If Project.RowAPins(row).Text.Length > 0 Then
            '    rows(bbrow) = rows(bbrow) Or (1 << ROW_ENABLE)
            'End If
            packet(bbrow + 6) = rows(bbrow)
        Next
        'For row As Integer = 0 To 31
        '    ' Invert rows breadboard rows numbered like an IC
        '    bbrow = 63 - row
        '    Dim RowBPin As BBPin = Nothing
        '    For Each Pin As BBPin In Project.RowBPins
        '        If Pin.Row = bbrow Then
        '            RowBPin = Pin
        '            Select Case RowBPin.PinFunction
        '                Case "Input"
        '                    rows(bbrow) = rows(bbrow) Or (1 << ROW_INPUT)
        '                    rows(bbrow) = rows(bbrow) Or (1 << ROW_ENABLE)
        '                Case "High ( +5V )"
        '                    rows(bbrow) = rows(bbrow) Or (0 << ROW_INPUT)
        '                    rows(bbrow) = rows(bbrow) Or (1 << ROW_ENABLE)
        '                Case "Rising Clock"
        '                    rows(bbrow) = rows(bbrow) Or (1 << ROW_CLOCK)
        '                    rows(bbrow) = rows(bbrow) Or (1 << ROW_ENABLE)
        '                Case "Falling Clock"
        '                    rows(bbrow) = rows(bbrow) Or (1 << ROW_ENABLE)
        '                    rows(bbrow) = rows(bbrow) Or (1 << ROW_CLOCK)
        '                    rows(bbrow) = rows(bbrow) Or (1 << ROW_CLOCK_INVERT)
        '                Case "Scripted Output"
        '                    rows(bbrow) = rows(bbrow) Or (0 << ROW_INPUT)
        '                    rows(bbrow) = rows(bbrow) Or (1 << ROW_ENABLE)
        '                Case "Low ( GND )"
        '                    rows(bbrow) = rows(bbrow) Or (0 << ROW_INPUT)
        '                    rows(bbrow) = rows(bbrow) Or (1 << ROW_ENABLE)
        '                Case "Analog Input"
        '                    rows(bbrow) = rows(bbrow) Or (1 << ROW_INPUT)
        '                    rows(bbrow) = rows(bbrow) Or (1 << ROW_ENABLE)
        '                Case Else
        '                    rows(bbrow) = rows(bbrow) Or (0 << ROW_ENABLE)
        '            End Select
        '            'If RowBPin.Output Then
        '            '    rows(bbrow) = rows(bbrow) Or (0 << ROW_INPUT)
        '            'Else
        '            '    rows(bbrow) = rows(bbrow) Or (1 << ROW_INPUT)
        '            'End If
        '            'If RowBPin.Clock Then
        '            '    rows(bbrow) = rows(bbrow) Or (1 << ROW_CLOCK)
        '            'End If
        '            'If RowBPin.InvertClock Then
        '            '    rows(bbrow) = rows(bbrow) Or (1 << ROW_CLOCK_INVERT)
        '            'End If
        '            'If RowBPin.Text.Length > 0 Then
        '            '    rows(bbrow) = rows(bbrow) Or (1 << ROW_ENABLE)
        '            'End If
        '            Exit For
        '        End If
        '    Next
        'packet(bbrow + 6) = rows(bbrow)
        'Next
        COMPort.Write(packet, 0, 70)
        Application.DoEvents()
        'SendRowBits(Project)
    End Sub

#End Region

End Class
