<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BananaRTC
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.KnobLabel = New System.Windows.Forms.Label
        Me.PrescaleValue = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Hz = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.OC = New System.Windows.Forms.Label
        Me.OCR0 = New knob.UserControl1
        Me.Knob = New knob.UserControl1
        Me.SuspendLayout()
        '
        'KnobLabel
        '
        Me.KnobLabel.BackColor = System.Drawing.Color.White
        Me.KnobLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.KnobLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.KnobLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KnobLabel.ForeColor = System.Drawing.Color.Green
        Me.KnobLabel.Location = New System.Drawing.Point(0, 0)
        Me.KnobLabel.Name = "KnobLabel"
        Me.KnobLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.KnobLabel.Size = New System.Drawing.Size(153, 18)
        Me.KnobLabel.TabIndex = 16
        Me.KnobLabel.Text = "Real Time Clock"
        Me.KnobLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'PrescaleValue
        '
        Me.PrescaleValue.BackColor = System.Drawing.Color.Black
        Me.PrescaleValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PrescaleValue.Font = New System.Drawing.Font("LED Real", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrescaleValue.ForeColor = System.Drawing.Color.Turquoise
        Me.PrescaleValue.Location = New System.Drawing.Point(51, 60)
        Me.PrescaleValue.Name = "PrescaleValue"
        Me.PrescaleValue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PrescaleValue.Size = New System.Drawing.Size(102, 51)
        Me.PrescaleValue.TabIndex = 15
        Me.PrescaleValue.Text = "0"
        Me.PrescaleValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Silver
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(0, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(153, 18)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Prescale Factor"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Hz
        '
        Me.Hz.BackColor = System.Drawing.Color.Black
        Me.Hz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Hz.Font = New System.Drawing.Font("LED Real", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Hz.ForeColor = System.Drawing.Color.Turquoise
        Me.Hz.Location = New System.Drawing.Point(0, 18)
        Me.Hz.Name = "Hz"
        Me.Hz.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Hz.Size = New System.Drawing.Size(153, 24)
        Me.Hz.TabIndex = 19
        Me.Hz.Text = "0.0000 hz"
        Me.Hz.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Silver
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(0, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(153, 18)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Output Compare"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'OC
        '
        Me.OC.BackColor = System.Drawing.Color.Black
        Me.OC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.OC.Font = New System.Drawing.Font("LED Real", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OC.ForeColor = System.Drawing.Color.Turquoise
        Me.OC.Location = New System.Drawing.Point(51, 128)
        Me.OC.Name = "OC"
        Me.OC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OC.Size = New System.Drawing.Size(102, 51)
        Me.OC.TabIndex = 21
        Me.OC.Text = "0"
        Me.OC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OCR0
        '
        Me.OCR0.BackColor = System.Drawing.Color.Silver
        Me.OCR0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.OCR0.cur_ang = 0
        Me.OCR0.haslimits = True
        Me.OCR0.islocked = False
        Me.OCR0.Location = New System.Drawing.Point(0, 127)
        Me.OCR0.max_ang = 255
        Me.OCR0.min_ang = 0
        Me.OCR0.myscale = ".35"
        Me.OCR0.Name = "OCR0"
        Me.OCR0.Size = New System.Drawing.Size(52, 52)
        Me.OCR0.TabIndex = 20
        '
        'Knob
        '
        Me.Knob.BackColor = System.Drawing.Color.Silver
        Me.Knob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Knob.cur_ang = 0
        Me.Knob.haslimits = True
        Me.Knob.islocked = False
        Me.Knob.Location = New System.Drawing.Point(0, 59)
        Me.Knob.max_ang = 256
        Me.Knob.min_ang = 0
        Me.Knob.myscale = ".35"
        Me.Knob.Name = "Knob"
        Me.Knob.Size = New System.Drawing.Size(52, 52)
        Me.Knob.TabIndex = 17
        '
        'BananaRTC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.OCR0)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.OC)
        Me.Controls.Add(Me.Hz)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.KnobLabel)
        Me.Controls.Add(Me.Knob)
        Me.Controls.Add(Me.PrescaleValue)
        Me.Name = "BananaRTC"
        Me.Size = New System.Drawing.Size(155, 180)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KnobLabel As System.Windows.Forms.Label
    Friend WithEvents Knob As knob.UserControl1
    Friend WithEvents PrescaleValue As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Hz As System.Windows.Forms.Label
    Friend WithEvents OCR0 As knob.UserControl1
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OC As System.Windows.Forms.Label

End Class
