<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Change_Lane
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.Lane_Pick = New System.Windows.Forms.ComboBox()
        Me.Okay = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BName = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Lane_Pick
        '
        Me.Lane_Pick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Lane_Pick.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lane_Pick.FormattingEnabled = True
        Me.Lane_Pick.Location = New System.Drawing.Point(32, 114)
        Me.Lane_Pick.Name = "Lane_Pick"
        Me.Lane_Pick.Size = New System.Drawing.Size(200, 30)
        Me.Lane_Pick.TabIndex = 4
        '
        'Okay
        '
        Me.Okay.BackColor = System.Drawing.Color.ForestGreen
        Me.Okay.Font = New System.Drawing.Font("Cambria", 14.25!)
        Me.Okay.Location = New System.Drawing.Point(264, 76)
        Me.Okay.Name = "Okay"
        Me.Okay.Size = New System.Drawing.Size(159, 37)
        Me.Okay.TabIndex = 7
        Me.Okay.Text = "Change Lane"
        Me.Okay.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DarkRed
        Me.Button1.Font = New System.Drawing.Font("Cambria", 14.25!)
        Me.Button1.Location = New System.Drawing.Point(264, 128)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(159, 37)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(65, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 25)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Move To Lane"
        '
        'BName
        '
        Me.BName.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BName.Location = New System.Drawing.Point(12, 18)
        Me.BName.Name = "BName"
        Me.BName.Size = New System.Drawing.Size(411, 26)
        Me.BName.TabIndex = 10
        Me.BName.Text = "[BName]"
        Me.BName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Change_Lane
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 177)
        Me.Controls.Add(Me.BName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Okay)
        Me.Controls.Add(Me.Lane_Pick)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Change_Lane"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Lane"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lane_Pick As System.Windows.Forms.ComboBox
    Friend WithEvents Okay As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BName As System.Windows.Forms.Label

End Class
