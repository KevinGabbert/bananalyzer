Public Class BananaPot
    Public Shadows Event Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'Public Shadows Event MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    Public Event ValueChanged(ByVal sender As Object, ByVal value As Byte)

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
            Value = Knob.cur_ang
        End Get
    End Property

    Private Sub Knob_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Knob.MouseDoubleClick
        ' RaiseEvent MouseDoubleClick(Me, e)
    End Sub
    Private Sub Knob_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Knob.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.PotValue.Text = Math.Round((CInt(Knob.cur_ang / 4) * 156.25) / 1000, 2).ToString("00.00") & "K"
            RaiseEvent ValueChanged(Me, Knob.cur_ang)
        End If
    End Sub

    Private Sub KnobLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KnobLabel.Click
        RaiseEvent Click(Me, e)
    End Sub
End Class
