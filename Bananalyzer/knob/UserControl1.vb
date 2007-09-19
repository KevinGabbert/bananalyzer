'KNOB CONTROL IN VB.NET  BY ANDY RICHARDSON
'THIS KNOB CONTROL HAS A FEW PROPERTIES I MADE
'
'islocked - if true then the knob can't move
'haslimits - if true then the knob has limits like -300 degrees to 550 degrees, etc
'myscale  - the scale of the control
'
'To make this work  start a new usercontrol property in VB.NET, add a timer to the form and enable it.
'Then copy this code over.

Imports System.Reflection
Imports system.io
Public Class UserControl1

    Dim locked As Boolean = False
    Dim melocked As Boolean = False
    Dim knob1ismoving As Boolean = False

    Dim scales As String = "1"

    Dim angle As Integer
    Dim maxangle As Integer
    Dim minangle As Integer
    Dim mouseangle As Integer
    Dim curmouseangle As Integer
    Dim knobstartangle As Integer
    Dim oldmouseangle As Integer
    Dim revolutions As Integer

    Dim knob As Bitmap
    Dim knobbase As Bitmap

#Region "Properties"

    Property islocked() As Boolean
        Get
            islocked = melocked
        End Get
        Set(ByVal value As Boolean)
            melocked = value
        End Set
    End Property
    Property myscale() As String
        Get
            myscale = scales
        End Get
        Set(ByVal value As String)
            scales = value
        End Set
    End Property

    Property haslimits() As Boolean
        Get
            haslimits = locked
        End Get
        Set(ByVal value As Boolean)
            locked = value
        End Set
    End Property
    Property cur_ang() As Integer

        Get
            cur_ang = angle
        End Get
        Set(ByVal value As Integer)
            If locked = True Then
                If value > maxangle Then value = maxangle
                If value < minangle Then value = minangle
            End If
            angle = value
        End Set
    End Property
    Property max_ang() As Integer
        Get
            max_ang = maxangle
        End Get
        Set(ByVal value As Integer)
            maxangle = value
        End Set
    End Property
    Property min_ang() As Integer
        Get
            min_ang = minangle
        End Get
        Set(ByVal value As Integer)
            minangle = min_ang
        End Set
    End Property

#End Region

#Region "Event Handlers"

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        e.Graphics.ScaleTransform(scales, scales)

        knobbase = New Bitmap(GetEmbeddedResourceStream("knob.knobbase.png"))     'REPLACE New Bitmap(GetEmbeddedResourceStream("knob.knobbase.png")) with New Bitmap("PATH OF knobbase.png/knobbase")
        knob = New Bitmap(GetEmbeddedResourceStream("knob.knobtop.png"))          'DITTO except with knoptop.png of course

        Me.Height = knobbase.Height * scales
        Me.Width = knobbase.Width * scales
        e.Graphics.DrawImage(knobbase, 0, 0)
        e.Graphics.ResetTransform()
        e.Graphics.ScaleTransform(scales, scales)
        e.Graphics.TranslateTransform(75, 75)
        e.Graphics.RotateTransform(angle)
        e.Graphics.DrawImage(knob, -knob.Width \ 2, -knob.Height \ 2)

    End Sub
    Private Sub UserControl1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Refresh()
        EnableDoubleBuffering()
        Timer1.Enabled = False
    End Sub

#Region "UserControl1"

    Private Sub UserControl11_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Dim centerofknobx As Integer = Me.Width / 2
        Dim centerofknoby As Integer = Me.Height / 2

        If knob1ismoving = False Then
            knobstartangle = Me.cur_ang
            mouseangle = Int(Math.Atan2((e.Y - centerofknoby), (e.X - centerofknobx)) * (180 / Math.PI)) + 180
            knob1ismoving = True
        End If
        If melocked = True Then knob1ismoving = False
    End Sub
    Private Sub UserControl11_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If knob1ismoving = True Then
            Dim centerofknobx As Integer = Me.Width / 2
            Dim centerofknoby As Integer = Me.Height / 2
            Dim curmouseangle As Integer = Int(Math.Atan2((e.Y - centerofknoby), (e.X - centerofknobx)) * (180 / Math.PI)) + 180
            Dim difference As Integer = curmouseangle - mouseangle
            Dim knobangle As Integer = knobstartangle + difference
            angle = knobangle + (revolutions * 360)
            If locked = True Then
                If angle > maxangle Then angle = maxangle
                If angle < minangle Then angle = minangle
            End If
            If oldmouseangle > 300 And curmouseangle < 60 Then
                revolutions = revolutions + 1
                oldmouseangle = curmouseangle
            End If
            If oldmouseangle < 60 And curmouseangle > 300 Then
                revolutions = revolutions - 1
                oldmouseangle = curmouseangle
            End If
            oldmouseangle = curmouseangle
        End If
        Me.Refresh()
    End Sub
    Private Sub UserControl11_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        knob1ismoving = False
    End Sub

#End Region

#End Region
#Region "Functions"

    Protected Function GetEmbeddedResourceStream(ByVal ResourceName As String) As Stream
        Return System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(ResourceName)
    End Function
    Sub EnableDoubleBuffering()

        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer _
        Or ControlStyles.UserPaint _
        Or ControlStyles.AllPaintingInWmPaint, _
        True)

        Me.UpdateStyles()
    End Sub

#End Region

End Class
