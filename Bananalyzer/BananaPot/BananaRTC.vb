Public Class BananaRTC

    Private Timer0 As New ATMega128.Timer0
    Public Event LabelClick(ByVal sender As Object, ByVal e As System.EventArgs)

    Public fclk_IO As Double = 0

#Region "Properties"

    Public Overrides Property Text() As String
        Get
            Return KnobLabel.Text
        End Get
        Set(ByVal value As String)
            KnobLabel.Text = value
        End Set
    End Property
    Public ReadOnly Property Value() As Double
        Get
            Return Val(Hz.Text)
        End Get
    End Property

#End Region
#Region "Event Handlers"

    Private Sub Knob_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Knob.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' (1, 8, 32, 64, 128, 256, or 1024)
            Select Case CInt(Knob.cur_ang / 32)
                Case 0
                    PrescaleValue.Text = "0"
                Case 1
                    PrescaleValue.Text = "1"
                Case 2
                    PrescaleValue.Text = "8"
                Case 3
                    PrescaleValue.Text = "32"
                Case 4
                    PrescaleValue.Text = "64"
                Case 5
                    PrescaleValue.Text = "128"
                Case 6
                    PrescaleValue.Text = "256"
                Case 7
                    PrescaleValue.Text = "1024"
            End Select
            Dim N As Integer = PrescaleValue.Text
            Timer0.CS = N
            Dim fOut As Double = 0
            If N > 0 Then
                fOut = fclk_IO / (2 * N * (1 + OCR0.cur_ang))
            End If
            Hz.Text = Math.Round(fOut, 2).ToString("#.00") & " hz"
        End If
    End Sub
    Private Sub OCR0_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles OCR0.MouseMove

        If e.Button = Windows.Forms.MouseButtons.Left Then
            If OCR0.cur_ang < 256 Then Timer0.OCR = OCR0.cur_ang : OC.Text = OCR0.cur_ang
            Dim N As Integer = PrescaleValue.Text
            Dim fOut As Double = 0
            If N > 0 Then
                fOut = fclk_IO / (2 * N * (1 + OCR0.cur_ang))
            End If
            Hz.Text = Math.Round(fOut, 2).ToString("#.00") & " hz"
        End If
    End Sub
    Private Sub KnobLabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles KnobLabel.Click
        RaiseEvent LabelClick(Timer0, e)
    End Sub

#End Region

End Class
