Imports System.Windows.Forms
Imports BananaBoard

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