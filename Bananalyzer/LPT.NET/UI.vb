Imports System.Windows.Forms
Imports BananaBoard
Imports System.Collections.Generic

Public Class UI

    Public _rowOUT As RowOUT

    Public Property RowOUT() As RowOUT
        Get
            Return _rowOUT
        End Get
        Set(ByVal value As RowOUT)
            _rowOUT = value
        End Set
    End Property

End Class

Public Class RowOUT

#Region "Constants"

    Const ROW_SCALE As Integer = 21
    Const ROW_MAX As Integer = 64

#End Region
#Region "Properties"

    Protected _label As New List(Of Label)
    Protected _icon As New List(Of PictureBox)
    Protected _pins As New List(Of BBPin)

    Public Property Label() As List(Of Label)
        Get
            Return _label
        End Get
        Set(ByVal value As List(Of Label))
            _label = value
        End Set
    End Property
    Public Property Icon() As List(Of PictureBox)
        Get
            Return _icon
        End Get
        Set(ByVal value As List(Of PictureBox))
            _icon = value
        End Set
    End Property
    Public Property Pins() As List(Of BBPin)
        Get
            Return _pins
        End Get
        Set(ByVal value As List(Of BBPin))
            _pins = value
        End Set
    End Property

#End Region

    Sub New()

        For i As Integer = 1 To ROW_MAX
            _label.Add(New Label)
            _icon.Add(New PictureBox)
            _pins.Add(New BBPin)
        Next

    End Sub

#Region "Functions"

    Public Sub Create_Label(ByRef currentRow As Integer, ByVal label As List(Of Label))

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
    Public Sub Create_Icon(ByRef currentRow As Integer, ByVal picturebox As List(Of PictureBox))

        picturebox(currentRow) = New PictureBox
        picturebox(currentRow).Width = ROW_SCALE
        picturebox(currentRow).Height = ROW_SCALE
        picturebox(currentRow).Top = currentRow * ROW_SCALE
        picturebox(currentRow).Left = 0
        picturebox(currentRow).SizeMode = PictureBoxSizeMode.CenterImage
        picturebox(currentRow).BorderStyle = BorderStyle.None

        picturebox(currentRow).Visible = True

        If (currentRow < (ROW_MAX / 2)) Then
            picturebox(currentRow).Tag = currentRow
        Else
            picturebox(currentRow).Tag = currentRow - (ROW_MAX / 2)
        End If

    End Sub

#End Region

End Class