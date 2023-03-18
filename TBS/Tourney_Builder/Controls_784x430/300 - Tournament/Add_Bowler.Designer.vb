<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Add_Bowler
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Lane_Pick = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Edit_Scores = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.USBC_ID = New System.Windows.Forms.TextBox()
        Me.Sex = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Bowler_Name = New System.Windows.Forms.ComboBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SMonImport = New System.Windows.Forms.Button()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bowler = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Aliasx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Series3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.series4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Average = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Edit_Scores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lane_Pick
        '
        Me.Lane_Pick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Lane_Pick.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lane_Pick.FormattingEnabled = True
        Me.Lane_Pick.Location = New System.Drawing.Point(328, 16)
        Me.Lane_Pick.Name = "Lane_Pick"
        Me.Lane_Pick.Size = New System.Drawing.Size(200, 30)
        Me.Lane_Pick.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(250, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Lane"
        '
        'Edit_Scores
        '
        Me.Edit_Scores.AllowUserToAddRows = False
        Me.Edit_Scores.AllowUserToDeleteRows = False
        Me.Edit_Scores.AllowUserToResizeColumns = False
        Me.Edit_Scores.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.Edit_Scores.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Edit_Scores.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Edit_Scores.ColumnHeadersHeight = 25
        Me.Edit_Scores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Edit_Scores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Bowler, Me.Aliasx, Me.Series3, Me.series4, Me.Average})
        Me.Edit_Scores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.Edit_Scores.EnableHeadersVisualStyles = False
        Me.Edit_Scores.Location = New System.Drawing.Point(6, 162)
        Me.Edit_Scores.MultiSelect = False
        Me.Edit_Scores.Name = "Edit_Scores"
        Me.Edit_Scores.RowHeadersVisible = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.Edit_Scores.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.Edit_Scores.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit_Scores.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Edit_Scores.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.Edit_Scores.RowTemplate.Height = 40
        Me.Edit_Scores.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Edit_Scores.ShowCellErrors = False
        Me.Edit_Scores.ShowCellToolTips = False
        Me.Edit_Scores.ShowEditingIcon = False
        Me.Edit_Scores.ShowRowErrors = False
        Me.Edit_Scores.Size = New System.Drawing.Size(775, 265)
        Me.Edit_Scores.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(91, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 25)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Bowler Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(351, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 25)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Sex"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(467, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 25)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "USBC ID"
        '
        'USBC_ID
        '
        Me.USBC_ID.Font = New System.Drawing.Font("Cambria", 14.25!)
        Me.USBC_ID.Location = New System.Drawing.Point(446, 91)
        Me.USBC_ID.Name = "USBC_ID"
        Me.USBC_ID.Size = New System.Drawing.Size(129, 30)
        Me.USBC_ID.TabIndex = 5
        '
        'Sex
        '
        Me.Sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Sex.Font = New System.Drawing.Font("Cambria", 14.25!)
        Me.Sex.FormattingEnabled = True
        Me.Sex.Items.AddRange(New Object() {"M", "F"})
        Me.Sex.Location = New System.Drawing.Point(328, 90)
        Me.Sex.MaxDropDownItems = 2
        Me.Sex.Name = "Sex"
        Me.Sex.Size = New System.Drawing.Size(88, 30)
        Me.Sex.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.ForestGreen
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Cambria", 14.25!)
        Me.Button1.Location = New System.Drawing.Point(608, 88)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(159, 37)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Add New Bowler"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Bowler_Name
        '
        Me.Bowler_Name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Bowler_Name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.Bowler_Name.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bowler_Name.FormattingEnabled = True
        Me.Bowler_Name.Location = New System.Drawing.Point(17, 90)
        Me.Bowler_Name.Name = "Bowler_Name"
        Me.Bowler_Name.Size = New System.Drawing.Size(280, 30)
        Me.Bowler_Name.TabIndex = 3
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(321, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "(Right Click) on the bowlers name below to view options"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(534, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(138, 30)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "[Home] - Previous Lane" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[End] - Next Lane"
        '
        'SMonImport
        '
        Me.SMonImport.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SMonImport.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold)
        Me.SMonImport.Location = New System.Drawing.Point(31, 11)
        Me.SMonImport.Name = "SMonImport"
        Me.SMonImport.Size = New System.Drawing.Size(193, 38)
        Me.SMonImport.TabIndex = 8
        Me.SMonImport.Text = "Import Scores"
        Me.SMonImport.UseVisualStyleBackColor = False
        Me.SMonImport.Visible = False
        '
        'ID
        '
        Me.ID.Frozen = True
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ID.Visible = False
        '
        'Bowler
        '
        Me.Bowler.Frozen = True
        Me.Bowler.HeaderText = "Bowler Name"
        Me.Bowler.MaxInputLength = 255
        Me.Bowler.Name = "Bowler"
        Me.Bowler.ReadOnly = True
        Me.Bowler.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Bowler.Width = 150
        '
        'Aliasx
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Aliasx.DefaultCellStyle = DataGridViewCellStyle3
        Me.Aliasx.Frozen = True
        Me.Aliasx.HeaderText = "Scoreing Alias"
        Me.Aliasx.MaxInputLength = 255
        Me.Aliasx.Name = "Aliasx"
        Me.Aliasx.Visible = False
        Me.Aliasx.Width = 150
        '
        'Series3
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Series3.DefaultCellStyle = DataGridViewCellStyle4
        Me.Series3.Frozen = True
        Me.Series3.HeaderText = "3G Series"
        Me.Series3.MaxInputLength = 3
        Me.Series3.Name = "Series3"
        Me.Series3.ReadOnly = True
        Me.Series3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Series3.Width = 85
        '
        'series4
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.series4.DefaultCellStyle = DataGridViewCellStyle5
        Me.series4.Frozen = True
        Me.series4.HeaderText = "4G Series"
        Me.series4.MaxInputLength = 4
        Me.series4.Name = "series4"
        Me.series4.ReadOnly = True
        Me.series4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.series4.Width = 85
        '
        'Average
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Average.DefaultCellStyle = DataGridViewCellStyle6
        Me.Average.Frozen = True
        Me.Average.HeaderText = "Average"
        Me.Average.MaxInputLength = 6
        Me.Average.Name = "Average"
        Me.Average.ReadOnly = True
        Me.Average.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Average.Width = 95
        '
        'Add_Bowler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SMonImport)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Bowler_Name)
        Me.Controls.Add(Me.Sex)
        Me.Controls.Add(Me.Edit_Scores)
        Me.Controls.Add(Me.Lane_Pick)
        Me.Controls.Add(Me.USBC_ID)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "Add_Bowler"
        Me.Size = New System.Drawing.Size(784, 430)
        CType(Me.Edit_Scores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lane_Pick As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Edit_Scores As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents USBC_ID As System.Windows.Forms.TextBox
    Friend WithEvents Sex As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Bowler_Name As System.Windows.Forms.ComboBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents SMonImport As System.Windows.Forms.Button
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bowler As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aliasx As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Series3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents series4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Average As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
