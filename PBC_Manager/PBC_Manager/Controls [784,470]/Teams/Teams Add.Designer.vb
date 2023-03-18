<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Teams_Add
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
        Me.Add_Team = New System.Windows.Forms.Button
        Me.League_List = New System.Windows.Forms.ComboBox
        Me.LeagueTableAdapter = New PBC_Manager.PBCDataSetTableAdapters.LeagueTableAdapter
        Me.TeamsTableAdapter = New PBC_Manager.PBCDataSetTableAdapters.TeamsTableAdapter
        Me.QueriesTableAdapter = New PBC_Manager.PBCDataSetTableAdapters.QueriesTableAdapter
        Me.SuspendLayout()
        '
        'Name_Box
        '
        Me.Name_Box.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.Name_Box.Location = New System.Drawing.Point(225, 111)
        Me.Name_Box.Name = "Name_Box"
        Me.Name_Box.Size = New System.Drawing.Size(432, 41)
        Me.Name_Box.TabIndex = 2
        '
        'Show_KB
        '
        Me.Show_KB.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Show_KB.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.Show_KB.Location = New System.Drawing.Point(235, 336)
        Me.Show_KB.Name = "Show_KB"
        Me.Show_KB.Size = New System.Drawing.Size(340, 60)
        Me.Show_KB.TabIndex = 4
        Me.Show_KB.Text = "Show KeyBoard"
        Me.Show_KB.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.Label2.Location = New System.Drawing.Point(112, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 34)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "League :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(128, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 34)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name :"
        '
        'Add_Team
        '
        Me.Add_Team.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Add_Team.Font = New System.Drawing.Font("Cambria", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Add_Team.Location = New System.Drawing.Point(235, 240)
        Me.Add_Team.Name = "Add_Team"
        Me.Add_Team.Size = New System.Drawing.Size(340, 60)
        Me.Add_Team.TabIndex = 3
        Me.Add_Team.Text = "Add Team"
        Me.Add_Team.UseVisualStyleBackColor = False
        '
        'League_List
        '
        Me.League_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.League_List.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.League_List.FormattingEnabled = True
        Me.League_List.Location = New System.Drawing.Point(225, 45)
        Me.League_List.Name = "League_List"
        Me.League_List.Size = New System.Drawing.Size(432, 33)
        Me.League_List.TabIndex = 1
        '
        'LeagueTableAdapter
        '
        Me.LeagueTableAdapter.ClearBeforeFill = True
        '
        'TeamsTableAdapter
        '
        Me.TeamsTableAdapter.ClearBeforeFill = True
        '
        'Teams_Add
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.League_List)
        Me.Controls.Add(Me.Name_Box)
        Me.Controls.Add(Me.Show_KB)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Add_Team)
        Me.Name = "Teams_Add"
        Me.Size = New System.Drawing.Size(784, 410)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Name_Box As System.Windows.Forms.TextBox
    Friend WithEvents Show_KB As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Add_Team As System.Windows.Forms.Button
    Friend WithEvents League_List As System.Windows.Forms.ComboBox
    Friend WithEvents LeagueTableAdapter As PBC_Manager.PBCDataSetTableAdapters.LeagueTableAdapter
    Friend WithEvents TeamsTableAdapter As PBC_Manager.PBCDataSetTableAdapters.TeamsTableAdapter
    Friend WithEvents QueriesTableAdapter As PBC_Manager.PBCDataSetTableAdapters.QueriesTableAdapter

End Class
