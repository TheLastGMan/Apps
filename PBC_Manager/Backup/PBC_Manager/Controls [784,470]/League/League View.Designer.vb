<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class League_View
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
        Me.League_Grid = New System.Windows.Forms.DataGridView
        Me.LeagueTableAdapter = New PBC_Manager.PBCDataSetTableAdapters.LeagueTableAdapter
        Me.PBCDataSet = New PBC_Manager.PBCDataSet
        Me.LeagueBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LeagueNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.League_Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBCDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeagueBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'League_Grid
        '
        Me.League_Grid.AllowUserToAddRows = False
        Me.League_Grid.AllowUserToDeleteRows = False
        Me.League_Grid.AllowUserToResizeColumns = False
        Me.League_Grid.AllowUserToResizeRows = False
        Me.League_Grid.AutoGenerateColumns = False
        Me.League_Grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.League_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.League_Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.LeagueNameDataGridViewTextBoxColumn, Me.CostDataGridViewTextBoxColumn})
        Me.League_Grid.DataSource = Me.LeagueBindingSource
        Me.League_Grid.Location = New System.Drawing.Point(71, 85)
        Me.League_Grid.Name = "League_Grid"
        Me.League_Grid.ReadOnly = True
        Me.League_Grid.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.League_Grid.RowTemplate.Height = 30
        Me.League_Grid.Size = New System.Drawing.Size(642, 300)
        Me.League_Grid.TabIndex = 0
        '
        'LeagueTableAdapter
        '
        Me.LeagueTableAdapter.ClearBeforeFill = True
        '
        'PBCDataSet
        '
        Me.PBCDataSet.DataSetName = "PBCDataSet"
        Me.PBCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LeagueBindingSource
        '
        Me.LeagueBindingSource.DataMember = "League"
        Me.LeagueBindingSource.DataSource = Me.PBCDataSet
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.Frozen = True
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'LeagueNameDataGridViewTextBoxColumn
        '
        Me.LeagueNameDataGridViewTextBoxColumn.DataPropertyName = "League_Name"
        Me.LeagueNameDataGridViewTextBoxColumn.Frozen = True
        Me.LeagueNameDataGridViewTextBoxColumn.HeaderText = "League Name"
        Me.LeagueNameDataGridViewTextBoxColumn.Name = "LeagueNameDataGridViewTextBoxColumn"
        Me.LeagueNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.LeagueNameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.LeagueNameDataGridViewTextBoxColumn.Width = 350
        '
        'CostDataGridViewTextBoxColumn
        '
        Me.CostDataGridViewTextBoxColumn.DataPropertyName = "Cost"
        Me.CostDataGridViewTextBoxColumn.Frozen = True
        Me.CostDataGridViewTextBoxColumn.HeaderText = "Cost"
        Me.CostDataGridViewTextBoxColumn.Name = "CostDataGridViewTextBoxColumn"
        Me.CostDataGridViewTextBoxColumn.ReadOnly = True
        Me.CostDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CostDataGridViewTextBoxColumn.Width = 150
        '
        'League_View
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.League_Grid)
        Me.Name = "League_View"
        Me.Size = New System.Drawing.Size(784, 470)
        CType(Me.League_Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBCDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeagueBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents League_Grid As System.Windows.Forms.DataGridView
    Friend WithEvents LeagueTableAdapter As PBC_Manager.PBCDataSetTableAdapters.LeagueTableAdapter
    Friend WithEvents LeagueBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PBCDataSet As PBC_Manager.PBCDataSet
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeagueNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
