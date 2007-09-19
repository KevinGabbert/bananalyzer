Public Class BananaTimer16

    Public Timer1 As New ATMega128.Timer16
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
            Return Val(AHz.Text)
        End Get
    End Property

#End Region
#Region "Event Handlers"

    'OCR = Output Compare Register 

    Private Sub Knob_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Knob.MouseMove

        If (e.Button = Windows.Forms.MouseButtons.Left) Then

            Select Case CInt(Knob.cur_ang / 32)
                Case 0 : PrescaleValue.Text = "0"
                Case 1 : PrescaleValue.Text = "1"
                Case 2 : PrescaleValue.Text = "8"
                Case 4 : PrescaleValue.Text = "64"
                Case 6 : PrescaleValue.Text = "256"
                Case 7 : PrescaleValue.Text = "1024"
            End Select

            Dim N As Integer = PrescaleValue.Text

            Timer1.CS = N
            Dim fOut As Double = 0
            If N > 0 Then
                fOut = fclk_IO / (2 * N * (1 + OCRAH.cur_ang))
            End If

            AHz.Text = Math.Round(fOut, 2).ToString("#.00") & " hz"
            If N > 0 Then
                fOut = fclk_IO / (2 * N * (1 + OCRB.cur_ang))
            End If

            BHz.Text = Math.Round(fOut, 2).ToString("#.00") & " hz"
            If N > 0 Then
                fOut = fclk_IO / (2 * N * (1 + OCRB.cur_ang))
            End If

            CHz.Text = Math.Round(fOut, 2).ToString("#.00") & " hz"
        End If

    End Sub

    Private Sub OCRAL_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles OCRAL.MouseMove

        If e.Button = Windows.Forms.MouseButtons.Left Then
            Timer1.OCRA = OCRAH.cur_ang * 256 + OCRAL.cur_ang

            OCA.Text = "0x" & OCRAH.cur_ang.ToString("X2") & OCRAL.cur_ang.ToString("X2")

            Dim N As Integer = PrescaleValue.Text
            Dim fOut As Double = 0
            If N > 0 Then
                fOut = fclk_IO / (2 * N * (1 + (OCRAH.cur_ang * 256 + OCRAL.cur_ang)))
            End If
            AHz.Text = Math.Round(fOut, 2).ToString("#.00") & " hz"
        End If

    End Sub
    Private Sub OCRAH_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles OCRAH.MouseMove

        If e.Button = Windows.Forms.MouseButtons.Left Then
            Timer1.OCRA = OCRAH.cur_ang * 256 + OCRAL.cur_ang

            OCA.Text = "0x" & OCRAH.cur_ang.ToString("X2") & OCRAL.cur_ang.ToString("X2")

            Dim N As Integer = PrescaleValue.Text
            Dim fOut As Double = 0

            If N > 0 Then
                fOut = fclk_IO / (2 * N * (1 + (OCRAH.cur_ang * 256 + OCRAL.cur_ang)))
            End If

            AHz.Text = Math.Round(fOut, 2).ToString("#.00") & " hz"
        End If

    End Sub
    Private Sub OCRB_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles OCRB.MouseMove

        If e.Button = Windows.Forms.MouseButtons.Left Then

            If OCRB.cur_ang < 256 Then Timer1.OCRB = OCRB.cur_ang : OCB.Text = OCRB.cur_ang


            Dim N As Integer = PrescaleValue.Text
            Dim fOut As Double = 0

            If N > 0 Then
                fOut = fclk_IO / (2 * N * (1 + OCRB.cur_ang))
            End If

            BHz.Text = Math.Round(fOut, 2).ToString("#.00") & " hz"
        End If

    End Sub
    Private Sub OCRC_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles OCRC.MouseMove

        If e.Button = Windows.Forms.MouseButtons.Left Then

            If OCRC.cur_ang < 256 Then Timer1.OCRC = OCRC.cur_ang : OCC.Text = OCRC.cur_ang
            Dim N As Integer = PrescaleValue.Text
            Dim fOut As Double = 0

            If N > 0 Then
                fOut = fclk_IO / (2 * N * (1 + OCRC.cur_ang))
            End If
            CHz.Text = Math.Round(fOut, 2).ToString("#.00") & " hz"

        End If

    End Sub

    Private Sub KnobLabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles KnobLabel.Click
        RaiseEvent LabelClick(Timer1, e)
    End Sub

#End Region

End Class
