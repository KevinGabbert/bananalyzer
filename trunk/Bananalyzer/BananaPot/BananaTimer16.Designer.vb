<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BananaTimer16
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
        Me.OCRAH = New knob.UserControl1
        Me.Label2 = New System.Windows.Forms.Label
        Me.OCA = New System.Windows.Forms.Label
        Me.AHz = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.KnobLabel = New System.Windows.Forms.Label
        Me.Knob = New knob.UserControl1
        Me.PrescaleValue = New System.Windows.Forms.Label
        Me.OCRB = New knob.UserControl1
        Me.Label3 = New System.Windows.Forms.Label
        Me.OCB = New System.Windows.Forms.Label
        Me.OCRC = New knob.UserControl1
        Me.Label5 = New System.Windows.Forms.Label
        Me.OCC = New System.Windows.Forms.Label
        Me.BHz = New System.Windows.Forms.Label
        Me.CHz = New System.Windows.Forms.Label
        Me.OCRAL = New knob.UserControl1
        Me.SuspendLayout()
        '
        'OCRAH
        '
        Me.OCRAH.BackColor = System.Drawing.Color.Black
        Me.OCRAH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.OCRAH.cur_ang = 0
        Me.OCRAH.haslimits = True
        Me.OCRAH.islocked = False
        Me.OCRAH.Location = New System.Drawing.Point(0, 103)
        Me.OCRAH.max_ang = 255
        Me.OCRAH.min_ang = 0
        Me.OCRAH.myscale = ".175"
        Me.OCRAH.Name = "OCRAH"
        Me.OCRAH.Size = New System.Drawing.Size(26, 26)
        Me.OCRAH.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Silver
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(0, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(153, 18)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Output Compare A"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'OCA
        '
        Me.OCA.BackColor = System.Drawing.Color.Black
        Me.OCA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.OCA.Font = New System.Drawing.Font("LED Real", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OCA.ForeColor = System.Drawing.Color.Turquoise
        Me.OCA.Location = New System.Drawing.Point(51, 104)
        Me.OCA.Name = "OCA"
        Me.OCA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OCA.Size = New System.Drawing.Size(102, 25)
        Me.OCA.TabIndex = 29
        Me.OCA.Text = "0"
        Me.OCA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AHz
        '
        Me.AHz.BackColor = System.Drawing.Color.Black
        Me.AHz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AHz.Font = New System.Drawing.Font("LED Real", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AHz.ForeColor = System.Drawing.Color.Turquoise
        Me.AHz.Location = New System.Drawing.Point(0, 154)
        Me.AHz.Name = "AHz"
        Me.AHz.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AHz.Size = New System.Drawing.Size(153, 24)
        Me.AHz.TabIndex = 27
        Me.AHz.Text = "0.0000 hz"
        Me.AHz.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Silver
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(0, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(153, 18)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Prescale Factor"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
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
        Me.KnobLabel.TabIndex = 24
        Me.KnobLabel.Text = "16Bit Timer/Counter"
        Me.KnobLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Knob
        '
        Me.Knob.BackColor = System.Drawing.Color.Black
        Me.Knob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Knob.cur_ang = 0
        Me.Knob.haslimits = True
        Me.Knob.islocked = False
        Me.Knob.Location = New System.Drawing.Point(0, 35)
        Me.Knob.max_ang = 256
        Me.Knob.min_ang = 0
        Me.Knob.myscale = ".35"
        Me.Knob.Name = "Knob"
        Me.Knob.Size = New System.Drawing.Size(52, 52)
        Me.Knob.TabIndex = 25
        '
        'PrescaleValue
        '
        Me.PrescaleValue.BackColor = System.Drawing.Color.Black
        Me.PrescaleValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PrescaleValue.Font = New System.Drawing.Font("LED Real", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrescaleValue.ForeColor = System.Drawing.Color.Turquoise
        Me.PrescaleValue.Location = New System.Drawing.Point(51, 36)
        Me.PrescaleValue.Name = "PrescaleValue"
        Me.PrescaleValue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PrescaleValue.Size = New System.Drawing.Size(102, 51)
        Me.PrescaleValue.TabIndex = 23
        Me.PrescaleValue.Text = "0"
        Me.PrescaleValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OCRB
        '
        Me.OCRB.BackColor = System.Drawing.Color.Black
        Me.OCRB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.OCRB.cur_ang = 0
        Me.OCRB.haslimits = True
        Me.OCRB.islocked = False
        Me.OCRB.Location = New System.Drawing.Point(0, 195)
        Me.OCRB.max_ang = 255
        Me.OCRB.min_ang = 0
        Me.OCRB.myscale = ".35"
        Me.OCRB.Name = "OCRB"
        Me.OCRB.Size = New System.Drawing.Size(52, 52)
        Me.OCRB.TabIndex = 31
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Silver
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(0, 178)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(153, 18)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Output Compare B"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'OCB
        '
        Me.OCB.BackColor = System.Drawing.Color.Black
        Me.OCB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.OCB.Font = New System.Drawing.Font("LED Real", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OCB.ForeColor = System.Drawing.Color.Turquoise
        Me.OCB.Location = New System.Drawing.Point(51, 196)
        Me.OCB.Name = "OCB"
        Me.OCB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OCB.Size = New System.Drawing.Size(102, 51)
        Me.OCB.TabIndex = 32
        Me.OCB.Text = "0"
        Me.OCB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OCRC
        '
        Me.OCRC.BackColor = System.Drawing.Color.Black
        Me.OCRC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.OCRC.cur_ang = 0
        Me.OCRC.haslimits = True
        Me.OCRC.islocked = False
        Me.OCRC.Location = New System.Drawing.Point(0, 288)
        Me.OCRC.max_ang = 255
        Me.OCRC.min_ang = 0
        Me.OCRC.myscale = ".35"
        Me.OCRC.Name = "OCRC"
        Me.OCRC.Size = New System.Drawing.Size(52, 52)
        Me.OCRC.TabIndex = 34
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Silver
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(0, 271)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(153, 18)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Output Compare C"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'OCC
        '
        Me.OCC.BackColor = System.Drawing.Color.Black
        Me.OCC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.OCC.Font = New System.Drawing.Font("LED Real", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OCC.ForeColor = System.Drawing.Color.Turquoise
        Me.OCC.Location = New System.Drawing.Point(51, 289)
        Me.OCC.Name = "OCC"
        Me.OCC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OCC.Size = New System.Drawing.Size(102, 51)
        Me.OCC.TabIndex = 35
        Me.OCC.Text = "0"
        Me.OCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BHz
        '
        Me.BHz.BackColor = System.Drawing.Color.Black
        Me.BHz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BHz.Font = New System.Drawing.Font("LED Real", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BHz.ForeColor = System.Drawing.Color.Turquoise
        Me.BHz.Location = New System.Drawing.Point(0, 247)
        Me.BHz.Name = "BHz"
        Me.BHz.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BHz.Size = New System.Drawing.Size(153, 24)
        Me.BHz.TabIndex = 37
        Me.BHz.Text = "0.0000 hz"
        Me.BHz.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CHz
        '
        Me.CHz.BackColor = System.Drawing.Color.Black
        Me.CHz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CHz.Font = New System.Drawing.Font("LED Real", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHz.ForeColor = System.Drawing.Color.Turquoise
        Me.CHz.Location = New System.Drawing.Point(0, 339)
        Me.CHz.Name = "CHz"
        Me.CHz.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CHz.Size = New System.Drawing.Size(153, 24)
        Me.CHz.TabIndex = 38
        Me.CHz.Text = "0.0000 hz"
        Me.CHz.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OCRAL
        '
        Me.OCRAL.BackColor = System.Drawing.Color.Black
        Me.OCRAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.OCRAL.cur_ang = 0
        Me.OCRAL.haslimits = True
        Me.OCRAL.islocked = False
        Me.OCRAL.Location = New System.Drawing.Point(26, 103)
        Me.OCRAL.max_ang = 255
        Me.OCRAL.min_ang = 0
        Me.OCRAL.myscale = ".175"
        Me.OCRAL.Name = "OCRAL"
        Me.OCRAL.Size = New System.Drawing.Size(26, 26)
        Me.OCRAL.TabIndex = 39
        '
        'BananaTimer16
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.OCRAL)
        Me.Controls.Add(Me.CHz)
        Me.Controls.Add(Me.BHz)
        Me.Controls.Add(Me.OCRC)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.OCC)
        Me.Controls.Add(Me.OCRB)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.OCB)
        Me.Controls.Add(Me.OCRAH)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.OCA)
        Me.Controls.Add(Me.AHz)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.KnobLabel)
        Me.Controls.Add(Me.Knob)
        Me.Controls.Add(Me.PrescaleValue)
        Me.Name = "BananaTimer16"
        Me.Size = New System.Drawing.Size(154, 365)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OCRAH As knob.UserControl1
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OCA As System.Windows.Forms.Label
    Friend WithEvents AHz As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents KnobLabel As System.Windows.Forms.Label
    Friend WithEvents Knob As knob.UserControl1
    Friend WithEvents PrescaleValue As System.Windows.Forms.Label
    Friend WithEvents OCRB As knob.UserControl1
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents OCB As System.Windows.Forms.Label
    Friend WithEvents OCRC As knob.UserControl1
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents OCC As System.Windows.Forms.Label
    Friend WithEvents BHz As System.Windows.Forms.Label
    Friend WithEvents CHz As System.Windows.Forms.Label
    Friend WithEvents OCRAL As knob.UserControl1

End Class
