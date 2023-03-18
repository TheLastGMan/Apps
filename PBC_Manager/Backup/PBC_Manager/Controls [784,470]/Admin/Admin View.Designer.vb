<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_View
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Admin_UsersTableAdapter = New PBC_Manager.PBCDataSetTableAdapters.Admin_UsersTableAdapter
        Me.Admin_Grid = New System.Windows.Forms.DataGridView
        Me.PBCDataSet = New PBC_Manager.PBCDataSet
        Me.AdminUsersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FullNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.Admin_Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBCDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdminUsersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Admin_UsersTableAdapter
        '
        Me.Admin_UsersTableAdapter.ClearBeforeFill = True
        '
        'Admin_Grid
        '
        Me.Admin_Grid.AllowUserToAddRows = False
        Me.Admin_Grid.AllowUserToDeleteRows = False
        Me.Admin_Grid.AllowUserToResizeColumns = False
        Me.Admin_Grid.AllowUserToResizeRows = False
        Me.Admin_Grid.AutoGenerateColumns = False
        Me.Admin_Grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.Admin_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Admin_Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.FullNameDataGridViewTextBoxColumn})
        Me.Admin_Grid.DataSource = Me.AdminUsersBindingSource
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Admin_Grid.DefaultCellStyle = DataGridViewCellStyle1
        Me.Admin_Grid.Location = New System.Drawing.Point(71, 85)
        Me.Admin_Grid.Name = "Admin_Grid"
        Me.Admin_Grid.ReadOnly = True
        Me.Admin_Grid.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Admin_Grid.RowTemplate.Height = 30
        Me.Admin_Grid.Size = New System.Drawing.Size(642, 300)
        Me.Admin_Grid.TabIndex = 1
        '
        'PBCDataSet
        '
        Me.PBCDataSet.DataSetName = "PBCDataSet"
        Me.PBCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AdminUsersBindingSource
        '
        Me.AdminUsersBindingSource.DataMember = "Admin_Users"
        Me.AdminUsersBindingSource.DataSource = Me.PBCDataSet
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
        'FullNameDataGridViewTextBoxColumn
        '
        Me.FullNameDataGridViewTextBoxColumn.DataPropertyName = "Full Name"
        Me.FullNameDataGridViewTextBoxColumn.Frozen = True
        Me.FullNameDataGridViewTextBoxColumn.HeaderText = "Full Name"
        Me.FullNameDataGridViewTextBoxColumn.Name = "FullNameDataGridViewTextBoxColumn"
        Me.FullNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.FullNameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FullNameDataGridViewTextBoxColumn.Width = 500
        '
        'Admin_View
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Admin_Grid)
        Me.Name = "Admin_View"
        Me.Size = New System.Drawing.Size(784, 470)
        CType(Me.Admin_Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBCDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdminUsersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Admin_UsersTableAdapter As PBC_Manager.PBCDataSetTableAdapters.Admin_UsersTableAdapter
    Friend WithEvents Admin_Grid As System.Windows.Forms.DataGridView
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FullNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdminUsersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PBCDataSet As PBC_Manager.PBCDataSet

End Class
