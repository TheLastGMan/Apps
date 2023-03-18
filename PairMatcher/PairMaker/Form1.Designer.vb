<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.EnterBtn = New System.Windows.Forms.Button()
        Me.MatchBtn = New System.Windows.Forms.Button()
        Me.PrintBtn = New System.Windows.Forms.Button()
        Me.ErrMsg = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'EnterBtn
        '
        Me.EnterBtn.BackColor = System.Drawing.Color.YellowGreen
        Me.EnterBtn.Font = New System.Drawing.Font("Century Schoolbook", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnterBtn.Location = New System.Drawing.Point(14, 388)
        Me.EnterBtn.Name = "EnterBtn"
        Me.EnterBtn.Size = New System.Drawing.Size(195, 40)
        Me.EnterBtn.TabIndex = 0
        Me.EnterBtn.Text = "&Enter"
        Me.EnterBtn.UseVisualStyleBackColor = False
        '
        'MatchBtn
        '
        Me.MatchBtn.BackColor = System.Drawing.Color.Goldenrod
        Me.MatchBtn.Font = New System.Drawing.Font("Century Schoolbook", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MatchBtn.Location = New System.Drawing.Point(215, 388)
        Me.MatchBtn.Name = "MatchBtn"
        Me.MatchBtn.Size = New System.Drawing.Size(195, 40)
        Me.MatchBtn.TabIndex = 1
        Me.MatchBtn.Text = "&Match"
        Me.MatchBtn.UseVisualStyleBackColor = False
        '
        'PrintBtn
        '
        Me.PrintBtn.BackColor = System.Drawing.Color.Firebrick
        Me.PrintBtn.Font = New System.Drawing.Font("Century Schoolbook", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrintBtn.Location = New System.Drawing.Point(416, 388)
        Me.PrintBtn.Name = "PrintBtn"
        Me.PrintBtn.Size = New System.Drawing.Size(195, 40)
        Me.PrintBtn.TabIndex = 2
        Me.PrintBtn.Text = "&Print"
        Me.PrintBtn.UseVisualStyleBackColor = False
        '
        'ErrMsg
        '
        Me.ErrMsg.BackColor = System.Drawing.Color.OldLace
        Me.ErrMsg.Font = New System.Drawing.Font("Century Schoolbook", 14.25!)
        Me.ErrMsg.ForeColor = System.Drawing.Color.OrangeRed
        Me.ErrMsg.Location = New System.Drawing.Point(14, 360)
        Me.ErrMsg.Name = "ErrMsg"
        Me.ErrMsg.Size = New System.Drawing.Size(597, 28)
        Me.ErrMsg.TabIndex = 3
        Me.ErrMsg.Text = "[Err Msg]"
        Me.ErrMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 441)
        Me.Controls.Add(Me.ErrMsg)
        Me.Controls.Add(Me.PrintBtn)
        Me.Controls.Add(Me.MatchBtn)
        Me.Controls.Add(Me.EnterBtn)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(640, 480)
        Me.MinimumSize = New System.Drawing.Size(640, 480)
        Me.Name = "Form1"
        Me.Text = "Pair Maker"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EnterBtn As System.Windows.Forms.Button
    Friend WithEvents MatchBtn As System.Windows.Forms.Button
    Friend WithEvents PrintBtn As System.Windows.Forms.Button
    Friend WithEvents ErrMsg As System.Windows.Forms.Label

End Class
