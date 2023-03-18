<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.components = New System.ComponentModel.Container
        Me.TIMER = New System.Windows.Forms.Timer(Me.components)
        Me.START = New System.Windows.Forms.Button
        Me.Timer_Text = New System.Windows.Forms.Label
        Me.QUIT = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TIMER
        '
        Me.TIMER.Interval = 1000
        '
        'START
        '
        Me.START.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.START.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.START.ForeColor = System.Drawing.Color.DeepPink
        Me.START.Location = New System.Drawing.Point(12, 14)
        Me.START.Name = "START"
        Me.START.Size = New System.Drawing.Size(140, 49)
        Me.START.TabIndex = 1
        Me.START.Text = "Start"
        Me.START.UseVisualStyleBackColor = False
        '
        'Timer_Text
        '
        Me.Timer_Text.BackColor = System.Drawing.Color.DarkRed
        Me.Timer_Text.Font = New System.Drawing.Font("Courier New", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Timer_Text.ForeColor = System.Drawing.Color.Yellow
        Me.Timer_Text.Location = New System.Drawing.Point(12, 14)
        Me.Timer_Text.Name = "Timer_Text"
        Me.Timer_Text.Size = New System.Drawing.Size(140, 47)
        Me.Timer_Text.TabIndex = 2
        Me.Timer_Text.Text = "10:00"
        Me.Timer_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'QUIT
        '
        Me.QUIT.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.QUIT.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QUIT.ForeColor = System.Drawing.Color.DeepPink
        Me.QUIT.Location = New System.Drawing.Point(123, 15)
        Me.QUIT.Name = "QUIT"
        Me.QUIT.Size = New System.Drawing.Size(29, 49)
        Me.QUIT.TabIndex = 3
        Me.QUIT.Text = "E"
        Me.QUIT.UseVisualStyleBackColor = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(165, 77)
        Me.ControlBox = False
        Me.Controls.Add(Me.QUIT)
        Me.Controls.Add(Me.START)
        Me.Controls.Add(Me.Timer_Text)
        Me.ForeColor = System.Drawing.SystemColors.Control
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TIMER As System.Windows.Forms.Timer
    Friend WithEvents START As System.Windows.Forms.Button
    Friend WithEvents Timer_Text As System.Windows.Forms.Label
    Friend WithEvents QUIT As System.Windows.Forms.Button

End Class
