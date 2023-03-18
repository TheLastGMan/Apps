<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Teams_Remove
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
        Me.Remove_Team = New System.Windows.Forms.Button
        Me.League_List = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Team_List = New System.Windows.Forms.ComboBox
        Me.LeagueTableAdapter = New PBC_Manager.PBCDataSetTableAdapters.LeagueTableAdapter
        Me.TeamsTableAdapter = New PBC_Manager.PBCDataSetTableAdapters.TeamsTableAdapter
        Me.SuspendLayout()
        '
        'Remove_Team
        '
        Me.Remove_Team.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Remove_Team.Font = New System.Drawing.Font("Cambria", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Remove_Team.Location = New System.Drawing.Point(222, 400)
        Me.Remove_Team.Name = "Remove_Team"
        Me.Remove_Team.Size = New System.Drawing.Size(340, 60)
        Me.Remove_Team.TabIndex = 2
        Me.Remove_Team.Text = "Remove Team"
        Me.Remove_Team.UseVisualStyleBackColor = False
        '
        'League_List
        '
        Me.League_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.League_List.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.League_List.FormattingEnabled = True
        Me.League_List.Location = New System.Drawing.Point(224, 45)
        Me.League_List.Name = "League_List"
        Me.League_List.Size = New System.Drawing.Size(432, 33)
        Me.League_List.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.Label2.Location = New System.Drawing.Point(111, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 34)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "League :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(127, 182)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 34)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Team :"
        '
        'Team_List
        '
        Me.Team_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Team_List.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.Team_List.FormattingEnabled = True
        Me.Team_List.Location = New System.Drawing.Point(224, 187)
        Me.Team_List.Name = "Team_List"
        Me.Team_List.Size = New System.Drawing.Size(432, 33)
        Me.Team_List.TabIndex = 2
        '
        'LeagueTableAdapter
        '
        Me.LeagueTableAdapter.ClearBeforeFill = True
        '
        'TeamsTableAdapter
        '
        Me.TeamsTableAdapter.ClearBeforeFill = True
        '
        'Teams_Remove
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Team_List)
        Me.Controls.Add(Me.League_List)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Remove_Team)
        Me.Name = "Teams_Remove"
        Me.Size = New System.Drawing.Size(784, 470)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Remove_Team As System.Windows.Forms.Button
    Friend WithEvents League_List As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Team_List As System.Windows.Forms.ComboBox
    Friend WithEvents LeagueTableAdapter As PBC_Manager.PBCDataSetTableAdapters.LeagueTableAdapter
    Friend WithEvents TeamsTableAdapter As PBC_Manager.PBCDataSetTableAdapters.TeamsTableAdapter

End Class
