<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Me.components = New System.ComponentModel.Container
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Remove_Team = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.BarCode_ID = New System.Windows.Forms.NumericUpDown
        Me.League_Grid = New System.Windows.Forms.DataGridView
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.League_Name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cost = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LeagueNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LeagueBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PBCDataSet = New PBC_Manager.PBCDataSet
        Me.Label4 = New System.Windows.Forms.Label
        Me.AutoLogon = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.LeagueTableAdapter = New PBC_Manager.PBCDataSetTableAdapters.LeagueTableAdapter
        Me.AutoLogonText = New System.Windows.Forms.MaskedTextBox
        CType(Me.BarCode_ID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.League_Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeagueBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBCDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.Label2.Location = New System.Drawing.Point(13, 283)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 34)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Prices : $"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.Label1.Location = New System.Drawing.Point(13, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(198, 34)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bar Code ID # :"
        '
        'Remove_Team
        '
        Me.Remove_Team.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Remove_Team.Font = New System.Drawing.Font("Cambria", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Remove_Team.Location = New System.Drawing.Point(222, 400)
        Me.Remove_Team.Name = "Remove_Team"
        Me.Remove_Team.Size = New System.Drawing.Size(340, 60)
        Me.Remove_Team.TabIndex = 5
        Me.Remove_Team.Text = "&Save Settings"
        Me.Remove_Team.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(208, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 22)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "(0000 - 9999)"
        '
        'BarCode_ID
        '
        Me.BarCode_ID.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.BarCode_ID.Location = New System.Drawing.Point(210, 41)
        Me.BarCode_ID.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.BarCode_ID.Name = "BarCode_ID"
        Me.BarCode_ID.Size = New System.Drawing.Size(120, 41)
        Me.BarCode_ID.TabIndex = 1
        Me.BarCode_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'League_Grid
        '
        Me.League_Grid.AllowUserToAddRows = False
        Me.League_Grid.AllowUserToDeleteRows = False
        Me.League_Grid.AutoGenerateColumns = False
        Me.League_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.League_Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.League_Name, Me.Cost, Me.IDDataGridViewTextBoxColumn, Me.LeagueNameDataGridViewTextBoxColumn, Me.CostDataGridViewTextBoxColumn})
        Me.League_Grid.DataSource = Me.LeagueBindingSource
        Me.League_Grid.Location = New System.Drawing.Point(146, 227)
        Me.League_Grid.Name = "League_Grid"
        Me.League_Grid.Size = New System.Drawing.Size(416, 146)
        Me.League_Grid.TabIndex = 4
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.Frozen = True
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ID.Width = 50
        '
        'League_Name
        '
        Me.League_Name.DataPropertyName = "League_Name"
        Me.League_Name.Frozen = True
        Me.League_Name.HeaderText = "League Name"
        Me.League_Name.MaxInputLength = 127
        Me.League_Name.Name = "League_Name"
        Me.League_Name.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.League_Name.Width = 247
        '
        'Cost
        '
        Me.Cost.DataPropertyName = "Cost"
        Me.Cost.Frozen = True
        Me.Cost.HeaderText = "Cost"
        Me.Cost.MaxInputLength = 5
        Me.Cost.Name = "Cost"
        Me.Cost.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Cost.Width = 75
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        '
        'LeagueNameDataGridViewTextBoxColumn
        '
        Me.LeagueNameDataGridViewTextBoxColumn.DataPropertyName = "League_Name"
        Me.LeagueNameDataGridViewTextBoxColumn.HeaderText = "League_Name"
        Me.LeagueNameDataGridViewTextBoxColumn.Name = "LeagueNameDataGridViewTextBoxColumn"
        '
        'CostDataGridViewTextBoxColumn
        '
        Me.CostDataGridViewTextBoxColumn.DataPropertyName = "Cost"
        Me.CostDataGridViewTextBoxColumn.HeaderText = "Cost"
        Me.CostDataGridViewTextBoxColumn.Name = "CostDataGridViewTextBoxColumn"
        '
        'LeagueBindingSource
        '
        Me.LeagueBindingSource.DataMember = "League"
        Me.LeagueBindingSource.DataSource = Me.PBCDataSet
        '
        'PBCDataSet
        '
        Me.PBCDataSet.DataSetName = "PBCDataSet"
        Me.PBCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.Label4.Location = New System.Drawing.Point(48, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(163, 34)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Auto Login :"
        '
        'AutoLogon
        '
        Me.AutoLogon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AutoLogon.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.AutoLogon.FormattingEnabled = True
        Me.AutoLogon.Items.AddRange(New Object() {"True", "False"})
        Me.AutoLogon.Location = New System.Drawing.Point(209, 146)
        Me.AutoLogon.Name = "AutoLogon"
        Me.AutoLogon.Size = New System.Drawing.Size(121, 42)
        Me.AutoLogon.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(418, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(265, 22)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Automatic Login ID (If Enabled)"
        '
        'LeagueTableAdapter
        '
        Me.LeagueTableAdapter.ClearBeforeFill = True
        '
        'AutoLogonText
        '
        Me.AutoLogonText.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.AutoLogonText.Location = New System.Drawing.Point(336, 146)
        Me.AutoLogonText.Name = "AutoLogonText"
        Me.AutoLogonText.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.AutoLogonText.Size = New System.Drawing.Size(445, 41)
        Me.AutoLogonText.TabIndex = 3
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.AutoLogonText)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.AutoLogon)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.League_Grid)
        Me.Controls.Add(Me.BarCode_ID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Remove_Team)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Name = "Settings"
        Me.Size = New System.Drawing.Size(784, 470)
        CType(Me.BarCode_ID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.League_Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeagueBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBCDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Remove_Team As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LeagueTableAdapter As PBC_Manager.PBCDataSetTableAdapters.LeagueTableAdapter
    Friend WithEvents LeagueBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PBCDataSet As PBC_Manager.PBCDataSet
    Friend WithEvents BarCode_ID As System.Windows.Forms.NumericUpDown
    Friend WithEvents League_Grid As System.Windows.Forms.DataGridView
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents League_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeagueNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents AutoLogon As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents AutoLogonText As System.Windows.Forms.MaskedTextBox

End Class
