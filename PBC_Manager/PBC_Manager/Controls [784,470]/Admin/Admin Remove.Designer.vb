<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Remove
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
        Me.Remove_Admin = New System.Windows.Forms.Button
        Me.AdminBox = New System.Windows.Forms.ComboBox
        Me.Admin_UsersTableAdapter = New PBC_Manager.PBCDataSetTableAdapters.Admin_UsersTableAdapter
        Me.SuspendLayout()
        '
        'Remove_Admin
        '
        Me.Remove_Admin.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Remove_Admin.Font = New System.Drawing.Font("Cambria", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Remove_Admin.Location = New System.Drawing.Point(222, 368)
        Me.Remove_Admin.Name = "Remove_Admin"
        Me.Remove_Admin.Size = New System.Drawing.Size(340, 60)
        Me.Remove_Admin.TabIndex = 4
        Me.Remove_Admin.Text = "Remove Admin"
        Me.Remove_Admin.UseVisualStyleBackColor = False
        '
        'AdminBox
        '
        Me.AdminBox.DisplayMember = "League_Name"
        Me.AdminBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AdminBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdminBox.FormattingEnabled = True
        Me.AdminBox.ItemHeight = 25
        Me.AdminBox.Location = New System.Drawing.Point(167, 42)
        Me.AdminBox.MaxDropDownItems = 10
        Me.AdminBox.Name = "AdminBox"
        Me.AdminBox.Size = New System.Drawing.Size(450, 33)
        Me.AdminBox.TabIndex = 3
        Me.AdminBox.ValueMember = "League_Name"
        '
        'Admin_UsersTableAdapter
        '
        Me.Admin_UsersTableAdapter.ClearBeforeFill = True
        '
        'Admin_Remove
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Remove_Admin)
        Me.Controls.Add(Me.AdminBox)
        Me.Name = "Admin_Remove"
        Me.Size = New System.Drawing.Size(784, 470)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Remove_Admin As System.Windows.Forms.Button
    Friend WithEvents AdminBox As System.Windows.Forms.ComboBox
    Friend WithEvents Admin_UsersTableAdapter As PBC_Manager.PBCDataSetTableAdapters.Admin_UsersTableAdapter

End Class
