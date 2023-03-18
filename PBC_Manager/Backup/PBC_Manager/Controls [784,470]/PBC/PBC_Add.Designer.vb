<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PBC_Add
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Team_List = New System.Windows.Forms.ComboBox
        Me.League_List = New System.Windows.Forms.ComboBox
        Me.Show_KB = New System.Windows.Forms.Button
        Me.Issue__Button = New System.Windows.Forms.Button
        Me.Name_Box = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Card_ID = New System.Windows.Forms.TextBox
        Me.TeamsTableAdapter = New PBC_Manager.PBCDataSetTableAdapters.TeamsTableAdapter
        Me.LeagueTableAdapter = New PBC_Manager.PBCDataSetTableAdapters.LeagueTableAdapter
        Me.Master_SheetTableAdapter = New PBC_Manager.PBCDataSetTableAdapters.Master_SheetTableAdapter
        Me.PBC_Status = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 14.25!)
        Me.Label1.Location = New System.Drawing.Point(134, 197)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 14.25!)
        Me.Label2.Location = New System.Drawing.Point(124, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 22)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "League :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 14.25!)
        Me.Label3.Location = New System.Drawing.Point(138, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 22)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Team :"
        '
        'Team_List
        '
        Me.Team_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Team_List.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.Team_List.FormattingEnabled = True
        Me.Team_List.Location = New System.Drawing.Point(206, 84)
        Me.Team_List.Name = "Team_List"
        Me.Team_List.Size = New System.Drawing.Size(432, 33)
        Me.Team_List.TabIndex = 2
        '
        'League_List
        '
        Me.League_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.League_List.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.League_List.FormattingEnabled = True
        Me.League_List.Location = New System.Drawing.Point(206, 37)
        Me.League_List.Name = "League_List"
        Me.League_List.Size = New System.Drawing.Size(432, 33)
        Me.League_List.TabIndex = 1
        '
        'Show_KB
        '
        Me.Show_KB.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Show_KB.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.Show_KB.Location = New System.Drawing.Point(222, 385)
        Me.Show_KB.Name = "Show_KB"
        Me.Show_KB.Size = New System.Drawing.Size(340, 60)
        Me.Show_KB.TabIndex = 7
        Me.Show_KB.Text = "Show KeyBoard"
        Me.Show_KB.UseVisualStyleBackColor = False
        '
        'Issue__Button
        '
        Me.Issue__Button.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Issue__Button.Font = New System.Drawing.Font("Cambria", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Issue__Button.Location = New System.Drawing.Point(222, 302)
        Me.Issue__Button.Name = "Issue__Button"
        Me.Issue__Button.Size = New System.Drawing.Size(340, 60)
        Me.Issue__Button.TabIndex = 6
        Me.Issue__Button.Text = "Issue PBC"
        Me.Issue__Button.UseVisualStyleBackColor = False
        '
        'Name_Box
        '
        Me.Name_Box.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.Name_Box.Location = New System.Drawing.Point(206, 192)
        Me.Name_Box.Name = "Name_Box"
        Me.Name_Box.Size = New System.Drawing.Size(432, 31)
        Me.Name_Box.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cambria", 14.25!)
        Me.Label4.Location = New System.Drawing.Point(119, 244)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 22)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Card ID :"
        '
        'Card_ID
        '
        Me.Card_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.Card_ID.Location = New System.Drawing.Point(206, 239)
        Me.Card_ID.MaxLength = 13
        Me.Card_ID.Name = "Card_ID"
        Me.Card_ID.Size = New System.Drawing.Size(212, 31)
        Me.Card_ID.TabIndex = 5
        '
        'TeamsTableAdapter
        '
        Me.TeamsTableAdapter.ClearBeforeFill = True
        '
        'LeagueTableAdapter
        '
        Me.LeagueTableAdapter.ClearBeforeFill = True
        '
        'Master_SheetTableAdapter
        '
        Me.Master_SheetTableAdapter.ClearBeforeFill = True
        '
        'PBC_Status
        '
        Me.PBC_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PBC_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.PBC_Status.FormattingEnabled = True
        Me.PBC_Status.Location = New System.Drawing.Point(206, 139)
        Me.PBC_Status.Name = "PBC_Status"
        Me.PBC_Status.Size = New System.Drawing.Size(432, 33)
        Me.PBC_Status.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Cambria", 14.25!)
        Me.Label5.Location = New System.Drawing.Point(140, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 22)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Type :"
        '
        'PBC_Add
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PBC_Status)
        Me.Controls.Add(Me.Card_ID)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Name_Box)
        Me.Controls.Add(Me.Show_KB)
        Me.Controls.Add(Me.Issue__Button)
        Me.Controls.Add(Me.Team_List)
        Me.Controls.Add(Me.League_List)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PBC_Add"
        Me.Size = New System.Drawing.Size(784, 470)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Team_List As System.Windows.Forms.ComboBox
    Friend WithEvents League_List As System.Windows.Forms.ComboBox
    Friend WithEvents TeamsTableAdapter As PBC_Manager.PBCDataSetTableAdapters.TeamsTableAdapter
    Friend WithEvents Show_KB As System.Windows.Forms.Button
    Friend WithEvents Issue__Button As System.Windows.Forms.Button
    Friend WithEvents LeagueTableAdapter As PBC_Manager.PBCDataSetTableAdapters.LeagueTableAdapter
    Friend WithEvents Name_Box As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Card_ID As System.Windows.Forms.TextBox
    Friend WithEvents Master_SheetTableAdapter As PBC_Manager.PBCDataSetTableAdapters.Master_SheetTableAdapter
    Friend WithEvents PBC_Status As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
