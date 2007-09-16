Public Class BananaADC
    Public Const AVREF As Double = 5
    Private _Active As Boolean = False
    Public Overrides Property Text() As String
        Get
            Return Me.ADC0Label.Text
        End Get
        Set(ByVal value As String)
            ADC0Label.Text = value
        End Set
    End Property
    Public ReadOnly Property Volts() As Double
        Get
            Return Val(lblVolts.Text)
        End Get
    End Property
    Public Property Active() As Boolean
        Get
            Return _Active
        End Get
        Set(ByVal value As Boolean)
            _Active = value
            LED.Image = IIf(value, imgLEDs.Images(1), imgLEDs.Images(0))
        End Set
    End Property
    Private Sub LED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LED.Click
        _Active = Not _Active
        LED.Image = IIf(_Active, imgLEDs.Images(1), imgLEDs.Images(0))
    End Sub
    Public Sub SetVolts(ByVal ADCValue As UInt16)
        lblVolts.Text = Math.Round(ADCValue * (AVREF / 1023), 3).ToString("0.000") & " V"
    End Sub
End Class
