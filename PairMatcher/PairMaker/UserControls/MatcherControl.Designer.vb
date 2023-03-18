<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MatcherControl
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
        Me.NameGrid = New System.Windows.Forms.DataGridView()
        Me.NameCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Name2Col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.NameGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NameGrid
        '
        Me.NameGrid.AllowUserToAddRows = False
        Me.NameGrid.AllowUserToDeleteRows = False
        Me.NameGrid.AllowUserToResizeColumns = False
        Me.NameGrid.AllowUserToResizeRows = False
        Me.NameGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.NameGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameCol, Me.Name2Col})
        Me.NameGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NameGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.NameGrid.Location = New System.Drawing.Point(0, 0)
        Me.NameGrid.Name = "NameGrid"
        Me.NameGrid.ReadOnly = True
        Me.NameGrid.RowHeadersVisible = False
        Me.NameGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.NameGrid.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Century Schoolbook", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameGrid.RowTemplate.Height = 30
        Me.NameGrid.Size = New System.Drawing.Size(600, 345)
        Me.NameGrid.TabIndex = 4
        '
        'NameCol
        '
        Me.NameCol.Frozen = True
        Me.NameCol.HeaderText = "Name"
        Me.NameCol.Name = "NameCol"
        Me.NameCol.ReadOnly = True
        Me.NameCol.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.NameCol.Width = 285
        '
        'Name2Col
        '
        Me.Name2Col.Frozen = True
        Me.Name2Col.HeaderText = "Name 2"
        Me.Name2Col.Name = "Name2Col"
        Me.Name2Col.ReadOnly = True
        Me.Name2Col.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Name2Col.Width = 285
        '
        'MatcherControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.NameGrid)
        Me.Name = "MatcherControl"
        Me.Size = New System.Drawing.Size(600, 345)
        CType(Me.NameGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NameGrid As System.Windows.Forms.DataGridView
    Friend WithEvents NameCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Name2Col As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
