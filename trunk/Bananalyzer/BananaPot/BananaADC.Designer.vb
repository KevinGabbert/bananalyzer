<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BananaADC
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BananaADC))
        Me.ADC0Label = New System.Windows.Forms.Label
        Me.lblVolts = New System.Windows.Forms.Label
        Me.LED = New System.Windows.Forms.PictureBox
        Me.imgLEDs = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.LED, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ADC0Label
        '
        Me.ADC0Label.BackColor = System.Drawing.Color.White
        Me.ADC0Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ADC0Label.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ADC0Label.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ADC0Label.ForeColor = System.Drawing.Color.Green
        Me.ADC0Label.Location = New System.Drawing.Point(22, 0)
        Me.ADC0Label.Name = "ADC0Label"
        Me.ADC0Label.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ADC0Label.Size = New System.Drawing.Size(92, 23)
        Me.ADC0Label.TabIndex = 16
        Me.ADC0Label.Text = "ADC 0"
        Me.ADC0Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblVolts
        '
        Me.lblVolts.BackColor = System.Drawing.Color.Black
        Me.lblVolts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVolts.Font = New System.Drawing.Font("LED Real", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVolts.ForeColor = System.Drawing.Color.Yellow
        Me.lblVolts.Location = New System.Drawing.Point(0, 23)
        Me.lblVolts.Name = "lblVolts"
        Me.lblVolts.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVolts.Size = New System.Drawing.Size(114, 26)
        Me.lblVolts.TabIndex = 15
        Me.lblVolts.Text = "0.000V"
        Me.lblVolts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED
        '
        Me.LED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED.Image = Global.BananaBoard.My.Resources.Resources.LED0
        Me.LED.Location = New System.Drawing.Point(0, 0)
        Me.LED.Name = "LED"
        Me.LED.Size = New System.Drawing.Size(23, 23)
        Me.LED.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.LED.TabIndex = 17
        Me.LED.TabStop = False
        '
        'imgLEDs
        '
        Me.imgLEDs.ImageStream = CType(resources.GetObject("imgLEDs.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLEDs.TransparentColor = System.Drawing.Color.Transparent
        Me.imgLEDs.Images.SetKeyName(0, "LED0.bmp")
        Me.imgLEDs.Images.SetKeyName(1, "LED1.bmp")
        '
        'BananaADC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LED)
        Me.Controls.Add(Me.ADC0Label)
        Me.Controls.Add(Me.lblVolts)
        Me.Name = "BananaADC"
        Me.Size = New System.Drawing.Size(114, 50)
        CType(Me.LED, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ADC0Label As System.Windows.Forms.Label
    Friend WithEvents lblVolts As System.Windows.Forms.Label
    Friend WithEvents LED As System.Windows.Forms.PictureBox
    Friend WithEvents imgLEDs As System.Windows.Forms.ImageList

End Class
