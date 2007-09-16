<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BananaPot
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.PotValue = New System.Windows.Forms.Label
        Me.Knob = New knob.UserControl1
        Me.SuspendLayout()
        '
        'KnobLabel
        '
        Me.KnobLabel.BackColor = System.Drawing.Color.White
        Me.KnobLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.KnobLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.KnobLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KnobLabel.ForeColor = System.Drawing.Color.Green
        Me.KnobLabel.Location = New System.Drawing.Point(0, 0)
        Me.KnobLabel.Name = "KnobLabel"
        Me.KnobLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.KnobLabel.Size = New System.Drawing.Size(85, 18)
        Me.KnobLabel.TabIndex = 13
        Me.KnobLabel.Text = "POT 1"
        Me.KnobLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'PotValue
        '
        Me.PotValue.BackColor = System.Drawing.Color.Black
        Me.PotValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PotValue.Font = New System.Drawing.Font("LED Real", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PotValue.ForeColor = System.Drawing.Color.Lime
        Me.PotValue.Location = New System.Drawing.Point(0, 18)
        Me.PotValue.Name = "PotValue"
        Me.PotValue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PotValue.Size = New System.Drawing.Size(85, 26)
        Me.PotValue.TabIndex = 12
        Me.PotValue.Text = "00.00k"
        Me.PotValue.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Knob
        '
        Me.Knob.BackColor = System.Drawing.Color.Silver
        Me.Knob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Knob.cur_ang = 0
        Me.Knob.haslimits = True
        Me.Knob.islocked = False
        Me.Knob.Location = New System.Drawing.Point(0, 44)
        Me.Knob.max_ang = 255
        Me.Knob.min_ang = 0
        Me.Knob.myscale = ".57"
        Me.Knob.Name = "Knob"
        Me.Knob.Size = New System.Drawing.Size(85, 85)
        Me.Knob.TabIndex = 14
        '
        'BananaPot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.KnobLabel)
        Me.Controls.Add(Me.Knob)
        Me.Controls.Add(Me.PotValue)
        Me.Name = "BananaPot"
        Me.Size = New System.Drawing.Size(85, 130)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KnobLabel As System.Windows.Forms.Label
    Friend WithEvents PotValue As System.Windows.Forms.Label
    Friend WithEvents Knob As knob.UserControl1

End Class
