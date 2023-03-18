<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaveDB
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
        Me.Delete_DB = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.DBBox = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'Delete_DB
        '
        Me.Delete_DB.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Delete_DB.Font = New System.Drawing.Font("Cambria", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Delete_DB.Location = New System.Drawing.Point(34, 161)
        Me.Delete_DB.Name = "Delete_DB"
        Me.Delete_DB.Size = New System.Drawing.Size(211, 60)
        Me.Delete_DB.TabIndex = 10
        Me.Delete_DB.Text = "Save DB"
        Me.Delete_DB.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(84, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 34)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "DB File"
        '
        'DBBox
        '
        Me.DBBox.DisplayMember = "League_Name"
        Me.DBBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.DBBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DBBox.FormattingEnabled = True
        Me.DBBox.ItemHeight = 25
        Me.DBBox.Location = New System.Drawing.Point(17, 85)
        Me.DBBox.MaxDropDownItems = 10
        Me.DBBox.Name = "DBBox"
        Me.DBBox.Size = New System.Drawing.Size(250, 33)
        Me.DBBox.TabIndex = 8
        Me.DBBox.ValueMember = "League_Name"
        '
        'SaveDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 264)
        Me.Controls.Add(Me.Delete_DB)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DBBox)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(300, 300)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(300, 300)
        Me.Name = "SaveDB"
        Me.Text = "SaveDB"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Delete_DB As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DBBox As System.Windows.Forms.ComboBox
End Class
