<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Weeks
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
		Me.Week_Remove = New System.Windows.Forms.Button()
		Me.Week_Add = New System.Windows.Forms.Button()
		Me.Weeks_DEL = New System.Windows.Forms.ComboBox()
		Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.GAMES_Week = New System.Windows.Forms.NumericUpDown()
		Me.SCORE_Mins = New System.Windows.Forms.NumericUpDown()
		Me.WChange = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.TStyle = New System.Windows.Forms.ComboBox()
		Me.vv = New System.Windows.Forms.Label()
		CType(Me.GAMES_Week, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.SCORE_Mins, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Week_Remove
		'
		Me.Week_Remove.BackColor = System.Drawing.Color.Firebrick
		Me.Week_Remove.Cursor = System.Windows.Forms.Cursors.Hand
		Me.Week_Remove.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Week_Remove.Location = New System.Drawing.Point(544, 307)
		Me.Week_Remove.Name = "Week_Remove"
		Me.Week_Remove.Size = New System.Drawing.Size(200, 69)
		Me.Week_Remove.TabIndex = 4
		Me.Week_Remove.Text = "&Remove"
		Me.Week_Remove.UseVisualStyleBackColor = False
		'
		'Week_Add
		'
		Me.Week_Add.BackColor = System.Drawing.Color.ForestGreen
		Me.Week_Add.Cursor = System.Windows.Forms.Cursors.Hand
		Me.Week_Add.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Week_Add.Location = New System.Drawing.Point(544, 28)
		Me.Week_Add.Name = "Week_Add"
		Me.Week_Add.Size = New System.Drawing.Size(200, 69)
		Me.Week_Add.TabIndex = 2
		Me.Week_Add.Text = "&Add"
		Me.Week_Add.UseVisualStyleBackColor = False
		'
		'Weeks_DEL
		'
		Me.Weeks_DEL.AllowDrop = True
		Me.Weeks_DEL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Weeks_DEL.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Weeks_DEL.FormattingEnabled = True
		Me.Weeks_DEL.Location = New System.Drawing.Point(214, 346)
		Me.Weeks_DEL.Name = "Weeks_DEL"
		Me.Weeks_DEL.Size = New System.Drawing.Size(249, 30)
		Me.Weeks_DEL.TabIndex = 3
		'
		'DateTimePicker1
		'
		Me.DateTimePicker1.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
		Me.DateTimePicker1.Location = New System.Drawing.Point(214, 45)
		Me.DateTimePicker1.MaxDate = New Date(2999, 12, 31, 0, 0, 0, 0)
		Me.DateTimePicker1.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
		Me.DateTimePicker1.Name = "DateTimePicker1"
		Me.DateTimePicker1.Size = New System.Drawing.Size(249, 30)
		Me.DateTimePicker1.TabIndex = 1
		Me.DateTimePicker1.Value = New Date(2009, 12, 10, 0, 0, 0, 0)
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold)
		Me.Label2.Location = New System.Drawing.Point(141, 51)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(67, 22)
		Me.Label2.TabIndex = 7
		Me.Label2.Text = "Week :"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold)
		Me.Label3.Location = New System.Drawing.Point(46, 141)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(162, 22)
		Me.Label3.TabIndex = 8
		Me.Label3.Text = "Games For Week :"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold)
		Me.Label4.Location = New System.Drawing.Point(23, 193)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(185, 22)
		Me.Label4.TabIndex = 9
		Me.Label4.Text = "Show Scores Above :"
		'
		'GAMES_Week
		'
		Me.GAMES_Week.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold)
		Me.GAMES_Week.Location = New System.Drawing.Point(214, 139)
		Me.GAMES_Week.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
		Me.GAMES_Week.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
		Me.GAMES_Week.Name = "GAMES_Week"
		Me.GAMES_Week.Size = New System.Drawing.Size(249, 30)
		Me.GAMES_Week.TabIndex = 10
		Me.GAMES_Week.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.GAMES_Week.Value = New Decimal(New Integer() {4, 0, 0, 0})
		'
		'SCORE_Mins
		'
		Me.SCORE_Mins.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold)
		Me.SCORE_Mins.Location = New System.Drawing.Point(214, 191)
		Me.SCORE_Mins.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
		Me.SCORE_Mins.Name = "SCORE_Mins"
		Me.SCORE_Mins.Size = New System.Drawing.Size(249, 30)
		Me.SCORE_Mins.TabIndex = 11
		Me.SCORE_Mins.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.SCORE_Mins.Value = New Decimal(New Integer() {600, 0, 0, 0})
		'
		'WChange
		'
		Me.WChange.BackColor = System.Drawing.Color.Goldenrod
		Me.WChange.Cursor = System.Windows.Forms.Cursors.Hand
		Me.WChange.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.WChange.Location = New System.Drawing.Point(544, 161)
		Me.WChange.Name = "WChange"
		Me.WChange.Size = New System.Drawing.Size(200, 69)
		Me.WChange.TabIndex = 12
		Me.WChange.Text = "&Change"
		Me.WChange.UseVisualStyleBackColor = False
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(564, 379)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(160, 20)
		Me.Label1.TabIndex = 13
		Me.Label1.Text = "Remove Active Week"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.Location = New System.Drawing.Point(553, 100)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(182, 20)
		Me.Label5.TabIndex = 14
		Me.Label5.Text = "Add Week With Settings"
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.Location = New System.Drawing.Point(516, 243)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(256, 20)
		Me.Label6.TabIndex = 15
		Me.Label6.Text = "Change Active Week With Settings"
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Font = New System.Drawing.Font("Cambria", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label7.Location = New System.Drawing.Point(293, 111)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(91, 25)
		Me.Label7.TabIndex = 16
		Me.Label7.Text = "Settings"
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Font = New System.Drawing.Font("Cambria", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label8.Location = New System.Drawing.Point(274, 318)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(129, 25)
		Me.Label8.TabIndex = 17
		Me.Label8.Text = "Active Week"
		'
		'TStyle
		'
		Me.TStyle.AllowDrop = True
		Me.TStyle.BackColor = System.Drawing.Color.White
		Me.TStyle.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TStyle.FormattingEnabled = True
		Me.TStyle.Location = New System.Drawing.Point(214, 243)
		Me.TStyle.MaxDropDownItems = 32
		Me.TStyle.Name = "TStyle"
		Me.TStyle.Size = New System.Drawing.Size(249, 30)
		Me.TStyle.Sorted = True
		Me.TStyle.TabIndex = 18
		'
		'vv
		'
		Me.vv.AutoSize = True
		Me.vv.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold)
		Me.vv.Location = New System.Drawing.Point(35, 246)
		Me.vv.Name = "vv"
		Me.vv.Size = New System.Drawing.Size(173, 22)
		Me.vv.TabIndex = 19
		Me.vv.Text = "Tournament Style :"
		'
		'Weeks
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.vv)
		Me.Controls.Add(Me.TStyle)
		Me.Controls.Add(Me.Label8)
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.WChange)
		Me.Controls.Add(Me.SCORE_Mins)
		Me.Controls.Add(Me.GAMES_Week)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.DateTimePicker1)
		Me.Controls.Add(Me.Weeks_DEL)
		Me.Controls.Add(Me.Week_Remove)
		Me.Controls.Add(Me.Week_Add)
		Me.Name = "Weeks"
		Me.Size = New System.Drawing.Size(784, 430)
		CType(Me.GAMES_Week, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.SCORE_Mins, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents Week_Remove As System.Windows.Forms.Button
    Friend WithEvents Week_Add As System.Windows.Forms.Button
    Friend WithEvents Weeks_DEL As System.Windows.Forms.ComboBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GAMES_Week As System.Windows.Forms.NumericUpDown
    Friend WithEvents SCORE_Mins As System.Windows.Forms.NumericUpDown
    Friend WithEvents WChange As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TStyle As System.Windows.Forms.ComboBox
    Friend WithEvents vv As System.Windows.Forms.Label

End Class
