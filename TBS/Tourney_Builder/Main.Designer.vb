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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.Error_Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Progress_Status = New System.Windows.Forms.ToolStripProgressBar()
        Me.Info_Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HomeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ModulesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WeeksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BowlersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TournamentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddBowlersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditTournamentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TournamentReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.VectorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.FindLastScoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ReportsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorsAllComingSoonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DebugToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Header = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Error_Status, Me.Progress_Status, Me.Info_Status})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 540)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(784, 22)
        Me.StatusStrip.SizingGrip = False
        Me.StatusStrip.TabIndex = 0
        '
        'Error_Status
        '
        Me.Error_Status.AutoSize = False
        Me.Error_Status.Name = "Error_Status"
        Me.Error_Status.Size = New System.Drawing.Size(333, 17)
        Me.Error_Status.Spring = True
        Me.Error_Status.Text = "[Error]"
        Me.Error_Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Progress_Status
        '
        Me.Progress_Status.AutoSize = False
        Me.Progress_Status.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Progress_Status.Maximum = 99
        Me.Progress_Status.Name = "Progress_Status"
        Me.Progress_Status.Size = New System.Drawing.Size(100, 16)
        '
        'Info_Status
        '
        Me.Info_Status.AutoSize = False
        Me.Info_Status.Name = "Info_Status"
        Me.Info_Status.Size = New System.Drawing.Size(333, 17)
        Me.Info_Status.Spring = True
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.WeeksToolStripMenuItem, Me.BowlersToolStripMenuItem, Me.TournamentToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.VectorToolStripMenuItem, Me.DebugToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(784, 24)
        Me.MenuStrip.TabIndex = 0
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HomeToolStripMenuItem, Me.ToolStripSeparator1, Me.SaveToolStripMenuItem, Me.RestoreToolStripMenuItem, Me.NewToolStripMenuItem, Me.ToolStripSeparator2, Me.ModulesToolStripMenuItem, Me.SettingsToolStripMenuItem1, Me.UpdateToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'HomeToolStripMenuItem
        '
        Me.HomeToolStripMenuItem.Name = "HomeToolStripMenuItem"
        Me.HomeToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.HomeToolStripMenuItem.Text = "&Home"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(117, 6)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'RestoreToolStripMenuItem
        '
        Me.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem"
        Me.RestoreToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.RestoreToolStripMenuItem.Text = "&Restore"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.NewToolStripMenuItem.Text = "&New"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(117, 6)
        '
        'ModulesToolStripMenuItem
        '
        Me.ModulesToolStripMenuItem.Name = "ModulesToolStripMenuItem"
        Me.ModulesToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.ModulesToolStripMenuItem.Text = "&Modules"
        '
        'SettingsToolStripMenuItem1
        '
        Me.SettingsToolStripMenuItem1.Name = "SettingsToolStripMenuItem1"
        Me.SettingsToolStripMenuItem1.Size = New System.Drawing.Size(120, 22)
        Me.SettingsToolStripMenuItem1.Text = "&Settings"
        '
        'UpdateToolStripMenuItem
        '
        Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.UpdateToolStripMenuItem.Text = "&Update"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'WeeksToolStripMenuItem
        '
        Me.WeeksToolStripMenuItem.Name = "WeeksToolStripMenuItem"
        Me.WeeksToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.WeeksToolStripMenuItem.Text = "&Weeks"
        '
        'BowlersToolStripMenuItem
        '
        Me.BowlersToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InformationToolStripMenuItem})
        Me.BowlersToolStripMenuItem.Name = "BowlersToolStripMenuItem"
        Me.BowlersToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.BowlersToolStripMenuItem.Text = "&Bowlers"
        '
        'InformationToolStripMenuItem
        '
        Me.InformationToolStripMenuItem.Name = "InformationToolStripMenuItem"
        Me.InformationToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.InformationToolStripMenuItem.Text = "&Information"
        '
        'TournamentToolStripMenuItem
        '
        Me.TournamentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddBowlersToolStripMenuItem, Me.EditTToolStripMenuItem, Me.EditTournamentToolStripMenuItem, Me.ToolStripSeparator5})
        Me.TournamentToolStripMenuItem.Name = "TournamentToolStripMenuItem"
        Me.TournamentToolStripMenuItem.Size = New System.Drawing.Size(85, 20)
        Me.TournamentToolStripMenuItem.Text = "&Tournament"
        '
        'AddBowlersToolStripMenuItem
        '
        Me.AddBowlersToolStripMenuItem.Name = "AddBowlersToolStripMenuItem"
        Me.AddBowlersToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.AddBowlersToolStripMenuItem.Text = "&Bowlers"
        '
        'EditTToolStripMenuItem
        '
        Me.EditTToolStripMenuItem.Name = "EditTToolStripMenuItem"
        Me.EditTToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.EditTToolStripMenuItem.Text = "&ScoreSheet"
        '
        'EditTournamentToolStripMenuItem
        '
        Me.EditTournamentToolStripMenuItem.Name = "EditTournamentToolStripMenuItem"
        Me.EditTournamentToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.EditTournamentToolStripMenuItem.Text = "&Tournament"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(137, 6)
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TournamentReportToolStripMenuItem, Me.ToolStripSeparator4})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ReportsToolStripMenuItem.Text = "&Reports"
        '
        'TournamentReportToolStripMenuItem
        '
        Me.TournamentReportToolStripMenuItem.Name = "TournamentReportToolStripMenuItem"
        Me.TournamentReportToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.TournamentReportToolStripMenuItem.Text = "&Tournament Report"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(175, 6)
        '
        'VectorToolStripMenuItem
        '
        Me.VectorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem, Me.ToolStripSeparator3, Me.FindLastScoresToolStripMenuItem, Me.ToolStripSeparator6, Me.ReportsToolStripMenuItem1})
        Me.VectorToolStripMenuItem.Name = "VectorToolStripMenuItem"
        Me.VectorToolStripMenuItem.Size = New System.Drawing.Size(161, 20)
        Me.VectorToolStripMenuItem.Text = "&Scoreing Monitor (Testing)"
        Me.VectorToolStripMenuItem.Visible = False
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.SettingsToolStripMenuItem.Text = "&Settings"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(155, 6)
        '
        'FindLastScoresToolStripMenuItem
        '
        Me.FindLastScoresToolStripMenuItem.Name = "FindLastScoresToolStripMenuItem"
        Me.FindLastScoresToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.FindLastScoresToolStripMenuItem.Text = "&Find Last Scores"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(155, 6)
        '
        'ReportsToolStripMenuItem1
        '
        Me.ReportsToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ErrorsAllComingSoonToolStripMenuItem})
        Me.ReportsToolStripMenuItem1.Name = "ReportsToolStripMenuItem1"
        Me.ReportsToolStripMenuItem1.Size = New System.Drawing.Size(158, 22)
        Me.ReportsToolStripMenuItem1.Text = "&Reports"
        '
        'ErrorsAllComingSoonToolStripMenuItem
        '
        Me.ErrorsAllComingSoonToolStripMenuItem.Name = "ErrorsAllComingSoonToolStripMenuItem"
        Me.ErrorsAllComingSoonToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.ErrorsAllComingSoonToolStripMenuItem.Text = "Lane Errors"
        '
        'DebugToolStripMenuItem
        '
        Me.DebugToolStripMenuItem.Name = "DebugToolStripMenuItem"
        Me.DebugToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.DebugToolStripMenuItem.Text = "Debug"
        Me.DebugToolStripMenuItem.Visible = False
        '
        'Header
        '
        Me.Header.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Header.Location = New System.Drawing.Point(12, 24)
        Me.Header.Name = "Header"
        Me.Header.Size = New System.Drawing.Size(760, 38)
        Me.Header.TabIndex = 0
        Me.Header.Text = "Header"
        Me.Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(0, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(784, 430)
        Me.Panel1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.ForestGreen
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(28, 499)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(200, 38)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Bowlers"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Goldenrod
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(292, 499)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(200, 38)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "ScoreSheet"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Firebrick
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(556, 499)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(200, 38)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Tournament"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Tourney Builder|*.TBS"
        Me.SaveFileDialog1.RestoreDirectory = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Tourney Builder|*.TBS"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Header)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(800, 600)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "Main"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Tourney Builder"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents Error_Status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Progress_Status As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Info_Status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WeeksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TournamentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddBowlersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Header As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents EditTournamentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HomeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BowlersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VectorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ReportsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErrorsAllComingSoonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DebugToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FindLastScoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TournamentReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModulesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents UpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
