Imports System.ComponentModel
Imports System.Windows.Forms

Public Class BBProject

    Public PullUps As Boolean
    Public ClockStart As Byte
    Public ClockDelay As Long
    Public RowPins(63) As BBPin

    Public DigitPins(15) As BBPin
    Public Chips(7) As IC
    Public TraceRangeLabels As TraceRangeLabel()

    Public RowOUT As RowOUT

End Class

Public Class RowOUT

#Region "Constants"

    Const ROW_SCALE As Integer = 21
    Const ROW_MAX As Integer = 63

#End Region
#Region "Properties"

    Protected _label As Label()
    Protected _icon As PictureBox()
    Protected _pins(63) As BBPin

    Public Property Label() As Label()
        Get
            Return _label
        End Get
        Set(ByVal value As Label())
            _label = value
        End Set
    End Property
    Public Property Icon() As PictureBox()
        Get
            Return _icon
        End Get
        Set(ByVal value As PictureBox())
            _icon = value
        End Set
    End Property
    Public Property Pins() As BBPin()
        Get
            Return _pins
        End Get
        Set(ByVal value As BBPin())
            _pins = value
        End Set
    End Property

#End Region

    Public Sub New()



    End Sub

#Region "Functions"

    Public Sub Create_Label(ByRef currentRow As Integer, ByVal label() As Label)

        Me.Label = label

        Me.Label(currentRow) = New Label()
        Me.Label(currentRow).Width = 79
        Me.Label(currentRow).Left = ROW_SCALE
        Me.Label(currentRow).Height = ROW_SCALE
        Me.Label(currentRow).Top = currentRow * ROW_SCALE
        Me.Label(currentRow).Visible = True
        Me.Label(currentRow).Text = "USER " & currentRow + 1
        Me.Label(currentRow).BorderStyle = BorderStyle.None
        Me.Label(currentRow).TextAlign = ContentAlignment.MiddleLeft
        Me.Label(currentRow).BackColor = Color.White 'Color.Red ' KRG
        Me.Label(currentRow).ForeColor = Color.Blue
        Me.Label(currentRow).Tag = currentRow
        Me.Label(currentRow).AllowDrop = True

        If (currentRow < (ROW_MAX / 2)) Then
            Me.Label(currentRow).Tag = currentRow
        Else
            Me.Label(currentRow).Tag = currentRow - (ROW_MAX / 2)
        End If

    End Sub
    Public Sub Create_Icon(ByRef currentRow As Integer, ByVal picturebox() As PictureBox)

        picturebox(currentRow) = New PictureBox
        picturebox(currentRow).Width = ROW_SCALE
        picturebox(currentRow).Height = ROW_SCALE
        picturebox(currentRow).Top = currentRow * ROW_SCALE
        picturebox(currentRow).Left = 0
        picturebox(currentRow).SizeMode = PictureBoxSizeMode.CenterImage
        picturebox(currentRow).BorderStyle = BorderStyle.None
        'RowOutICON(currentRow).BackColor = Color.Red ' Testing KRG
        picturebox(currentRow).Visible = True

        If (currentRow < (ROW_MAX / 2)) Then
            picturebox(currentRow).Tag = currentRow
        Else
            picturebox(currentRow).Tag = currentRow - (ROW_MAX / 2)
        End If

    End Sub

#End Region

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
    Public Flip As Boolean
End Class

Public Class BBChip
    Dim _Value As String
    <DisplayName("Part Number")> _
    <Category("Info")> _
    Public Property Value() As String
        Get
            Return _Value
        End Get
        Set(ByVal value As String)
            _Value = value
        End Set
    End Property

    Dim _Description As String
    <DisplayName("Part Description")> _
    <Category("Info")> _
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property

    Dim _Pins() As BBPin
    <Browsable(False)> _
    Public Property Pins() As BBPin()
        Get
            Return _Pins
        End Get
        Set(ByVal value As BBPin())
            _Pins = value
        End Set
    End Property

    Private _DataSheet As String = ""
    <DisplayName("Datasheet")> _
    <Category("Info")> _
    <Description("File path of a PDF Datasheet describing the function of the component.")> _
    Public Property DataSheet() As String
        Get
            Return _DataSheet
        End Get
        Set(ByVal value As String)
            _DataSheet = value
        End Set
    End Property
End Class

Public Class BBPin
    Private _Row As Integer = 0
    <DisplayName("BananaBoard Row Index")> _
    <Category("General")> _
    Public Property Row() As Integer
        Get
            Return _Row
        End Get
        Set(ByVal value As Integer)
            _Row = value
        End Set
    End Property

    Private _Column As Integer = 0
    <Browsable(False)> _
    Public Property Column() As Integer
        Get
            Return _Column
        End Get
        Set(ByVal value As Integer)
            _Column = value
        End Set
    End Property

    Private _Text As String = ""
    <DisplayName("Pin Name")> _
    <Category("General")> _
    <Description("Text describing the function of the row.")> _
    Public Property Text() As String
        Get
            Return _Text
        End Get
        Set(ByVal value As String)
            _Text = value
        End Set
    End Property

    Private _Output As Boolean
    <Browsable(False)> _
    <DisplayName("Output")> _
    <Category("Settings")> _
    <Description("Changes the direction of the row to Output.")> _
    Public Property Output() As Boolean
        Get
            Return _Output
        End Get
        Set(ByVal value As Boolean)
            _Output = value
        End Set
    End Property

    Private _Clock As Boolean = False
    <Browsable(False)> _
    <DisplayName("Output Clock")> _
    <Category("Settings")> _
    <Description("Sends a clock pulse to the row.")> _
    Public Property Clock() As Boolean
        Get
            Return _Clock
        End Get
        Set(ByVal value As Boolean)
            _Clock = value
        End Set
    End Property

    Private _InvertClock As Boolean = False
    <Browsable(False)> _
    <DisplayName("Output Clock Starts at 1")> _
    <Category("Settings")> _
    <Description("Inverts the clock pulse.")> _
    Public Property InvertClock() As Boolean
        Get
            Return _InvertClock
        End Get
        Set(ByVal value As Boolean)
            _InvertClock = value
        End Set
    End Property

    Private _ClockPulseWidth As Integer
    <Browsable(False)> _
    Public Property ClockPulseWidth() As Integer
        Get
            Return _ClockPulseWidth
        End Get
        Set(ByVal value As Integer)
            _ClockPulseWidth = value
        End Set
    End Property

    Private _Bits As String = "0"
    <Browsable(False)> _
    <DisplayName("Output Mask")> _
    <Category("Settings")> _
    <Description("Defines the bits output on the row. If the row is configured to output a clock pulse, the clock is sent only during cycles masked '1'.")> _
    Public Property Bits() As String
        Get
            Return _Bits
        End Get
        Set(ByVal value As String)
            _Bits = value
        End Set
    End Property

    Private _BackColor As String = "White"
    <Browsable(False)> _
    Public Property BackColor() As String
        Get
            Return _BackColor
        End Get
        Set(ByVal value As String)
            _BackColor = value
        End Set
    End Property

    Private _ForeColor As String = "Blue"
    <Browsable(False)> _
    Public Property ForeColor() As String
        Get
            Return _ForeColor
        End Get
        Set(ByVal value As String)
            _ForeColor = value
        End Set
    End Property

    Private _PinFunction As String
    <Category("Settings")> _
    <DisplayName("Function")> _
    <TypeConverter(GetType(BBPinFunctionList)), _
    DefaultValueAttribute("")> _
    <Description("Defines the function of the current Row/Pin.")> _
    Public Property PinFunction() As String
        Get
            Return _PinFunction
        End Get
        Set(ByVal value As String)
            _PinFunction = value
        End Set
    End Property

    Private _PullUp As Boolean
    <DisplayName("Enable Pull Up Resistor")> _
    <Category("Settings")> _
    <Description("Causes an Input pin to read a default value of High.")> _
    Public Property PullUp() As Boolean
        Get
            Return _PullUp
        End Get
        Set(ByVal value As Boolean)
            _PullUp = value
        End Set
    End Property

End Class
Public Class BBPot
    Private _Index As Integer = 0
    <DisplayName("Pot Index")> _
    <Category("General")> _
    Public Property Index() As Integer
        Get
            Return _Index
        End Get
        Set(ByVal value As Integer)
            _Index = value
        End Set
    End Property

    Private _Text As String = ""
    <DisplayName("Pot Name")> _
    <Category("General")> _
    <Description("Text describing the function of the pot.")> _
    Public Property Text() As String
        Get
            Return _Text
        End Get
        Set(ByVal value As String)
            _Text = value
        End Set
    End Property

    Private _Enabled As Boolean
    <Browsable(False)> _
    <DisplayName("Enabled")> _
    <Category("Settings")> _
    <Description("Enables this Pot for use during a sampling run.")> _
    Public Property Enabled() As Boolean
        Get
            Return _Enabled
        End Get
        Set(ByVal value As Boolean)
            _Enabled = value
        End Set
    End Property

    Private _Values As Byte()
    <Browsable(False)> _
    <DisplayName("Output Script")> _
    <Category("Settings")> _
    <Description("Defines the values output to the pot during each cycle of a sampling run.")> _
    Public Property Values() As Byte()
        Get
            Return _Values
        End Get
        Set(ByVal value As Byte())
            _Values = value
        End Set
    End Property

    Private _PotFunction As String
    <Category("Settings")> _
    <DisplayName("Function")> _
    <TypeConverter(GetType(BBPotFunctionList)), _
    DefaultValueAttribute("")> _
    <Description("Defines the function of the current Row/Pin.")> _
    Public Property PotFunction() As String
        Get
            Return _PotFunction
        End Get
        Set(ByVal value As String)
            _PotFunction = value
        End Set
    End Property
End Class

Public Class BBPinFunctionList : Inherits System.ComponentModel.StringConverter
    Public Overloads Overrides Function GetStandardValues(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection
        Dim _OPs As String() = New String() {"", "Input", "High ( +5V )", "Low ( GND )", "Rising Clock", "Falling Clock", "Scripted Output", "Analog Input"}
        Return New StandardValuesCollection(_OPs)
    End Function
    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
End Class
Public Class BBPotFunctionList : Inherits System.ComponentModel.StringConverter

    Public Overloads Overrides Function GetStandardValues(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection
        Dim _OPs As String() = New String() {"", "Max (10k Ohms)", "Min (0 Ohms)", "Half (5k Ohms)", "Falling Sawtooth", "Rising Sawtooth", "Scripted Output"}
        Return New StandardValuesCollection(_OPs)
    End Function
    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function

End Class

'Dim _ParentPin As BBPin
'Public Property ParentPin() As BBPin
'    Get
'        Return _ParentPin
'    End Get
'    Set(ByVal value As BBPin)
'        _ParentPin = value
'    End Set
'End Property