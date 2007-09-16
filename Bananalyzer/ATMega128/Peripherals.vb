Imports System.ComponentModel

Public Class ADC

End Class
Public Class DAC

End Class
Public Class POT

End Class

Public Class Timer0
    ' Asynchronous Status Register
    Private _ASSR(4) As Boolean
    ' Asynchronous Timer/Counter0
    Private _sAS0 As String = "32.768Khz Real Time Clock"
    Private _AS0 As Boolean = True

    <Category("Options"), _
    Description("Selects the clock source for the timer."), _
    TypeConverter(GetType(AS0List)), _
    DisplayName("Timebase")> _
    Public Property AS0() As String
        Get
            Return _sAS0
        End Get
        Set(ByVal value As String)
            _sAS0 = value
            If Val(value) = 32.768 Then
                _AS0 = True
            Else
                _AS0 = False
            End If
        End Set
    End Property

    Private _WGM As String = "00 - Normal"
    <Category("Options"), Description(""), _
    DisplayName("Waveform Generation Mode"), _
    TypeConverter(GetType(WGModeList))> _
    Public Property WGM() As String
        Get
            Return _WGM
        End Get
        Set(ByVal value As String)
            _WGM = value
            COM = "00 - Output Disabled"
        End Set
    End Property
    Private _COM As String = "01 - Toggle"
    <Category("Options"), Description(""), _
    DisplayName("Waveform Output Mode"), _
    TypeConverter(GetType(COMModeList))> _
    Public Property COM() As String
        Get
            Return _COM
        End Get
        Set(ByVal value As String)
            _COM = value
        End Set
    End Property
    Public CS As Integer ' Prescale divisor
    Public OCR As Byte ' Output Compare value
End Class

Public Class Timer16
    Private _WGM As String = "00 - Normal"
    <Category("Options"), Description(""), _
    DisplayName("Waveform Generation Mode"), _
    TypeConverter(GetType(WG16ModeList))> _
    Public Property WGM() As String
        Get
            Return _WGM
        End Get
        Set(ByVal value As String)
            _WGM = value
            COMA = "01 - Toggle"
            COMB = "01 - Toggle"
            COMC = "01 - Toggle"
        End Set
    End Property
    Private _COMA As String = "01 - Toggle"
    <Category("Options"), Description(""), _
    DisplayName("Waveform Output Mode A"), _
    TypeConverter(GetType(COM16ModeList))> _
    Public Property COMA() As String
        Get
            Return _COMA
        End Get
        Set(ByVal value As String)
            _COMA = value
        End Set
    End Property
    Private _COMB As String = "01 - Toggle"
    <Category("Options"), Description(""), _
    DisplayName("Waveform Output Mode B"), _
    TypeConverter(GetType(COM16ModeList))> _
    Public Property COMB() As String
        Get
            Return _COMB
        End Get
        Set(ByVal value As String)
            _COMB = value
        End Set
    End Property
    Private _COMC As String = "01 - Toggle"
    <Category("Options"), Description(""), _
    DisplayName("Waveform Output Mode C"), _
    TypeConverter(GetType(COM16ModeList))> _
    Public Property COMC() As String
        Get
            Return _COMC
        End Get
        Set(ByVal value As String)
            _COMC = value
        End Set
    End Property
    Public CS As Integer ' Prescale divisor
    Public OCRA As Integer ' Output Compare value
    Public OCRB As Integer ' Output Compare value
    Public OCRC As Integer ' Output Compare value
End Class
Public Class Timer2

End Class
Public Class Timer3

End Class

Public Class WGModeList : Inherits System.ComponentModel.StringConverter
    Public Overloads Overrides Function GetStandardValues(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection
        Dim _Modes As String() = New String() {"00 - Normal", "01 - Phase Correct PWM", "10 - Clear Timer on Compare", "11 - Fast PWM"}
        Return New StandardValuesCollection(_Modes)
    End Function
    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overloads Overrides Function _
        GetStandardValuesExclusive(ByVal context _
        As System.ComponentModel.ITypeDescriptorContext) _
        As Boolean
        Return True
    End Function
End Class
Public Class COMModeList : Inherits System.ComponentModel.StringConverter
    Public Overloads Overrides Function GetStandardValues(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection
        Dim Timer As Timer0 = CType(context.Instance, Timer0)
        Select Case Timer.WGM.Substring(0, 2)
            Case "00", "10"
                Dim _Modes As String() = {"00 - Output Disabled", "01 - Toggle", "10 - Clear", "11 - Set"}
                Return New StandardValuesCollection(_Modes)
            Case "01"
                Dim _Modes As String() = {"00 - Output Disabled", "10 - Up Clear Down Set", "11 - Up Set Down Clear"}
                Return New StandardValuesCollection(_Modes)
            Case "11"
                Dim _Modes As String() = {"00 - Output Disabled", "10 - Non-Inverting", "11 - Inverting"}
                Return New StandardValuesCollection(_Modes)
        End Select
        Return Nothing
    End Function
    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overloads Overrides Function _
        GetStandardValuesExclusive(ByVal context _
        As System.ComponentModel.ITypeDescriptorContext) _
        As Boolean
        Return True
    End Function
End Class
Public Class WG16ModeList : Inherits System.ComponentModel.StringConverter
    Public Overloads Overrides Function GetStandardValues(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection
        Dim _Modes As String() = New String() { _
        "0000 - Normal", _
        "0001 - PWM, Phase Correct, 8-bit", _
        "0010 - PWM, Phase Correct, 9-bit", _
        "0011 - PWM, Phase Correct, 10-bit", _
        "0101 - Fast PWM, 8-bit", _
        "0110 - Fast PWM, 9-bit", _
        "0111 - Fast PWM, 10-bit", _
        "1000 - PWM, Phase and Frequency Correct", _
        "1001 - PWM, Phase and Frequency Correct", _
        "1010 - PWM, Phase Correct External", _
        "1100 - Clear on Compare External", _
        "1111 - Fast PWM External" _
        }
        Return New StandardValuesCollection(_Modes)
    End Function
    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overloads Overrides Function _
        GetStandardValuesExclusive(ByVal context _
        As System.ComponentModel.ITypeDescriptorContext) _
        As Boolean
        Return True
    End Function
End Class
Public Class COM16ModeList : Inherits System.ComponentModel.StringConverter
    Public Overloads Overrides Function GetStandardValues(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection
        Dim Timer As Timer16 = CType(context.Instance, Timer16)
        Select Case Timer.WGM.Substring(0, 4)
            Case "0000", "0100", "1100"
                Dim _Modes As String() = {"00 - Output Disabled", "01 - Toggle", "10 - Clear", "11 - Set"}
                Return New StandardValuesCollection(_Modes)
            Case "0101", "0110", "0111", "1110", "1111"
                Dim _Modes As String() = {"00 - Output Disabled", "01 - Toggle", "10 - Non-Inverting", "11 - Inverting"}
                Return New StandardValuesCollection(_Modes)
            Case Else
                Dim _Modes As String() = {"00 - Output Disabled", "01 - Toggle", "10 - Up Clear Down Set", "11 - Up Set Down Clear"}
                Return New StandardValuesCollection(_Modes)
        End Select
        Return Nothing
    End Function
    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overloads Overrides Function _
        GetStandardValuesExclusive(ByVal context _
        As System.ComponentModel.ITypeDescriptorContext) _
        As Boolean
        Return True
    End Function
End Class
Public Class AS0List : Inherits System.ComponentModel.StringConverter
    Public Overloads Overrides Function GetStandardValues(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection
        Dim _Modes As String() = New String() {"32.768Khz Real Time Clock", "16.000Mhz CPU Clock"}
        Return New StandardValuesCollection(_Modes)
    End Function
    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overloads Overrides Function _
        GetStandardValuesExclusive(ByVal context _
        As System.ComponentModel.ITypeDescriptorContext) _
        As Boolean
        Return True
    End Function
End Class
