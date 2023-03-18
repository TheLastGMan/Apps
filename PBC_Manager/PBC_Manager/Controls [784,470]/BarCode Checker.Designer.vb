<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BarCode_Checker
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Generate = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.BC_Chk = New System.Windows.Forms.TextBox
        Me.BC_Chk_Txt = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BC = New System.Windows.Forms.MaskedTextBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Generate
        '
        Me.Generate.Font = New System.Drawing.Font("Courier New", 20.25!)
        Me.Generate.Location = New System.Drawing.Point(427, 44)
        Me.Generate.Name = "Generate"
        Me.Generate.Size = New System.Drawing.Size(149, 45)
        Me.Generate.TabIndex = 2
        Me.Generate.Text = "Generate"
        Me.Generate.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(8, 95)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(763, 291)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.WaitOnLoad = True
        '
        'BC_Chk
        '
        Me.BC_Chk.Font = New System.Drawing.Font("Courier New", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BC_Chk.Location = New System.Drawing.Point(374, 405)
        Me.BC_Chk.MaxLength = 13
        Me.BC_Chk.Name = "BC_Chk"
        Me.BC_Chk.Size = New System.Drawing.Size(245, 38)
        Me.BC_Chk.TabIndex = 0
        Me.BC_Chk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BC_Chk_Txt
        '
        Me.BC_Chk_Txt.AutoSize = True
        Me.BC_Chk_Txt.Font = New System.Drawing.Font("Courier New", 20.25!)
        Me.BC_Chk_Txt.Location = New System.Drawing.Point(163, 408)
        Me.BC_Chk_Txt.Name = "BC_Chk_Txt"
        Me.BC_Chk_Txt.Size = New System.Drawing.Size(205, 30)
        Me.BC_Chk_Txt.TabIndex = 0
        Me.BC_Chk_Txt.Text = "BarCode Scan"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(151, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 34)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "6 Digit # :"
        '
        'BC
        '
        Me.BC.Font = New System.Drawing.Font("Courier New", 20.25!)
        Me.BC.Location = New System.Drawing.Point(285, 47)
        Me.BC.Mask = "000000"
        Me.BC.Name = "BC"
        Me.BC.Size = New System.Drawing.Size(129, 38)
        Me.BC.TabIndex = 2
        Me.BC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BarCode_Checker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.BC)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BC_Chk_Txt)
        Me.Controls.Add(Me.BC_Chk)
        Me.Controls.Add(Me.Generate)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "BarCode_Checker"
        Me.Size = New System.Drawing.Size(784, 470)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Generate As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BC_Chk As System.Windows.Forms.TextBox
    Friend WithEvents BC_Chk_Txt As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BC As System.Windows.Forms.MaskedTextBox

End Class
