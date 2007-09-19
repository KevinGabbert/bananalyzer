Public Class BananaDAC
    Public Event LabelClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

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
            Value = (CInt(Knob.cur_ang * 16) * 0.001220703125)
        End Get
    End Property

#End Region
#Region "Event Handlers"

    Private Sub Knob_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Knob.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Volts.Text = Math.Round((CInt(Knob.cur_ang * 16) * 0.001220703125), 3).ToString("0.000") & "V"
        End If
    End Sub
    Private Sub KnobLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KnobLabel.Click
        RaiseEvent LabelClick(sender, e)
    End Sub

#End Region

End Class
