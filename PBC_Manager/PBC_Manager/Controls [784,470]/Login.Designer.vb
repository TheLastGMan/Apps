<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Me.UID = New System.Windows.Forms.Label
        Me.PASSWORD = New System.Windows.Forms.MaskedTextBox
        Me.SUBMIT = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Admin_UsersTableAdapter = New PBC_Manager.PBCDataSetTableAdapters.Admin_UsersTableAdapter
        Me.SuspendLayout()
        '
        'UID
        '
        Me.UID.AutoSize = True
        Me.UID.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UID.Location = New System.Drawing.Point(151, 21)
        Me.UID.Name = "UID"
        Me.UID.Size = New System.Drawing.Size(108, 25)
        Me.UID.TabIndex = 0
        Me.UID.Text = "User ID :"
        '
        'PASSWORD
        '
        Me.PASSWORD.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PASSWORD.Location = New System.Drawing.Point(265, 18)
        Me.PASSWORD.Name = "PASSWORD"
        Me.PASSWORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.PASSWORD.Size = New System.Drawing.Size(244, 33)
        Me.PASSWORD.TabIndex = 1
        '
        'SUBMIT
        '
        Me.SUBMIT.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SUBMIT.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.SUBMIT.FlatAppearance.BorderSize = 2
        Me.SUBMIT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime
        Me.SUBMIT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SUBMIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SUBMIT.Font = New System.Drawing.Font("Verdana", 15.75!)
        Me.SUBMIT.Location = New System.Drawing.Point(515, 18)
        Me.SUBMIT.Name = "SUBMIT"
        Me.SUBMIT.Size = New System.Drawing.Size(135, 33)
        Me.SUBMIT.TabIndex = 42
        Me.SUBMIT.Text = "&Submit"
        Me.SUBMIT.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(0, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(784, 410)
        Me.Panel1.TabIndex = 43
        '
        'Admin_UsersTableAdapter
        '
        Me.Admin_UsersTableAdapter.ClearBeforeFill = True
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.SUBMIT)
        Me.Controls.Add(Me.PASSWORD)
        Me.Controls.Add(Me.UID)
        Me.Name = "Login"
        Me.Size = New System.Drawing.Size(784, 470)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UID As System.Windows.Forms.Label
    Friend WithEvents PASSWORD As System.Windows.Forms.MaskedTextBox
    Friend WithEvents SUBMIT As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Admin_UsersTableAdapter As PBC_Manager.PBCDataSetTableAdapters.Admin_UsersTableAdapter

End Class
