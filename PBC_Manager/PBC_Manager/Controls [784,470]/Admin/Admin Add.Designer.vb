<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Add
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
        Me.Name_Box = New System.Windows.Forms.TextBox
        Me.Show_KB = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Add_Admin = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Pass1 = New System.Windows.Forms.MaskedTextBox
        Me.Pass2 = New System.Windows.Forms.MaskedTextBox
        Me.Admin_UsersTableAdapter = New PBC_Manager.PBCDataSetTableAdapters.Admin_UsersTableAdapter
        Me.QueriesTableAdapter = New PBC_Manager.PBCDataSetTableAdapters.QueriesTableAdapter
        Me.Label4 = New System.Windows.Forms.Label
        Me.AdminTF = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'Name_Box
        '
        Me.Name_Box.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.Name_Box.Location = New System.Drawing.Point(264, 45)
        Me.Name_Box.Name = "Name_Box"
        Me.Name_Box.Size = New System.Drawing.Size(432, 41)
        Me.Name_Box.TabIndex = 1
        '
        'Show_KB
        '
        Me.Show_KB.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Show_KB.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.Show_KB.Location = New System.Drawing.Point(235, 366)
        Me.Show_KB.Name = "Show_KB"
        Me.Show_KB.Size = New System.Drawing.Size(340, 60)
        Me.Show_KB.TabIndex = 6
        Me.Show_KB.Text = "Show KeyBoard"
        Me.Show_KB.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.Label2.Location = New System.Drawing.Point(121, 177)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 34)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Password :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(167, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 34)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name :"
        '
        'Add_Admin
        '
        Me.Add_Admin.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Add_Admin.Font = New System.Drawing.Font("Cambria", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Add_Admin.Location = New System.Drawing.Point(235, 285)
        Me.Add_Admin.Name = "Add_Admin"
        Me.Add_Admin.Size = New System.Drawing.Size(340, 60)
        Me.Add_Admin.TabIndex = 5
        Me.Add_Admin.Text = "&Add Admin"
        Me.Add_Admin.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.Label3.Location = New System.Drawing.Point(129, 223)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 34)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Re-Enter :"
        '
        'Pass1
        '
        Me.Pass1.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.Pass1.Location = New System.Drawing.Point(264, 174)
        Me.Pass1.Name = "Pass1"
        Me.Pass1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.Pass1.Size = New System.Drawing.Size(432, 41)
        Me.Pass1.TabIndex = 3
        '
        'Pass2
        '
        Me.Pass2.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.Pass2.Location = New System.Drawing.Point(264, 221)
        Me.Pass2.Name = "Pass2"
        Me.Pass2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.Pass2.Size = New System.Drawing.Size(432, 41)
        Me.Pass2.TabIndex = 4
        '
        'Admin_UsersTableAdapter
        '
        Me.Admin_UsersTableAdapter.ClearBeforeFill = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.Label4.Location = New System.Drawing.Point(47, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(336, 34)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Add Admin/Edit Settings :"
        '
        'AdminTF
        '
        Me.AdminTF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AdminTF.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.AdminTF.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.AdminTF.FormattingEnabled = True
        Me.AdminTF.Items.AddRange(New Object() {"True", "False"})
        Me.AdminTF.Location = New System.Drawing.Point(389, 119)
        Me.AdminTF.Name = "AdminTF"
        Me.AdminTF.Size = New System.Drawing.Size(121, 42)
        Me.AdminTF.TabIndex = 7
        '
        'Admin_Add
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.AdminTF)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Pass2)
        Me.Controls.Add(Me.Pass1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Name_Box)
        Me.Controls.Add(Me.Show_KB)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Add_Admin)
        Me.Name = "Admin_Add"
        Me.Size = New System.Drawing.Size(784, 470)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Name_Box As System.Windows.Forms.TextBox
    Friend WithEvents Show_KB As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Add_Admin As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Pass1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Pass2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Admin_UsersTableAdapter As PBC_Manager.PBCDataSetTableAdapters.Admin_UsersTableAdapter
    Friend WithEvents QueriesTableAdapter As PBC_Manager.PBCDataSetTableAdapters.QueriesTableAdapter
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents AdminTF As System.Windows.Forms.ComboBox

End Class
