Public Class BBProject
    Public RowAPins(31) As BBPin
    Public RowBPins(31) As BBPin
    Public RowOUTPins(31) As BBPin
    Public DigitPins(15) As BBPin
    Public Chips(7) As IC
    Public TraceRangeLabels As TraceRangeLabel()
End Class
Public Class TraceRangeLabel
    Public Row As Integer
    Public StartColumn As Integer
    Public EndColumn As Integer
    Public Text As String
End Class
Public Class IC
    Public Text As String = ""
    Public Description As String = ""
    Public PinCount As Integer = 0
    Public Pins() As BBPin
    Public Row As Integer = 0
End Class
Public Class BBPin
    Private _Row As Integer = 0
    Public Property Row() As Integer
        Get
            Return _Row
        End Get
        Set(ByVal value As Integer)
            _Row = value
        End Set
    End Property
    ' Col 0 = Outputs 0-15
    ' Col 1 = Inputs Left 0-31
    ' Col 2 = Inputs Right 0-31
    Private _Column As Integer = 0
    Public Property Column() As Integer
        Get
            Return _Column
        End Get
        Set(ByVal value As Integer)
            _Column = value
        End Set
    End Property
    Private _Text As String = ""
    Public Property Text() As String
        Get
            Return _Text
        End Get
        Set(ByVal value As String)
            _Text = value
        End Set
    End Property
    Private _Output As Boolean
    Public Property Output() As Boolean
        Get
            Return _Output
        End Get
        Set(ByVal value As Boolean)
            _Output = value
        End Set
    End Property
    Private _Clock As Boolean = False
    Public Property Clock() As Boolean
        Get
            Return _Clock
        End Get
        Set(ByVal value As Boolean)
            _Clock = value
        End Set
    End Property
    Private _ClockPulseWidth As Integer
    Public Property ClockPulseWidth() As Integer
        Get
            Return _ClockPulseWidth
        End Get
        Set(ByVal value As Integer)
            _ClockPulseWidth = value
        End Set
    End Property
    Private _Bits As String = "0"
    Public Property Bits() As String
        Get
            Return _Bits
        End Get
        Set(ByVal value As String)
            _Bits = value
        End Set
    End Property
    Private _BackColor As String = "White"
    Public Property BackColor() As String
        Get
            Return _BackColor
        End Get
        Set(ByVal value As String)
            _BackColor = value
        End Set
    End Property
    Private _ForeColor As String = "Blue"
    Public Property ForeColor() As String
        Get
            Return _ForeColor
        End Get
        Set(ByVal value As String)
            _ForeColor = value
        End Set
    End Property
End Class

Public Class BananaScript
    Private _Bits As New BitArray(255)
    Private _SerialData(255) As Byte
    Public Property SerialData() As Byte()
        Get
            Return _SerialData
        End Get
        Set(ByVal value As Byte())
            _SerialData = value
        End Set
    End Property
    Public Property Bits() As BitArray
        Get
            Return _Bits
        End Get
        Set(ByVal value As BitArray)
            _Bits = value
        End Set
    End Property
    Private _Commands() As BananaCommand = {New BananaCommand}
    Public Property Commands() As BananaCommand()
        Get
            Return _Commands
        End Get
        Set(ByVal value As BananaCommand())
            _Commands = value
        End Set
    End Property
    Public Sub New()
    End Sub
End Class

Public Class BananaCommand
    Private _Keyword As String = ""
    Public Property Keyword() As String
        Get
            Return _Keyword
        End Get
        Set(ByVal value As String)
            _Keyword = value
        End Set
    End Property
    Private _BitCount As Integer = 0
    Public Property BitCount() As Integer
        Get
            Return _BitCount
        End Get
        Set(ByVal value As Integer)
            _BitCount = value
            _Bits = New BitArray(value)
        End Set
    End Property
    Private _Bits As New BitArray(0)
    Public Property Bits() As BitArray
        Get
            Return _Bits
        End Get
        Set(ByVal value As BitArray)
            _Bits = value
        End Set
    End Property
End Class

