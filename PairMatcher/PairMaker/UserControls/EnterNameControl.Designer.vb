<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnterNameControl
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.NameBox = New System.Windows.Forms.TextBox()
        Me.NameLbl = New System.Windows.Forms.Label()
        Me.AddNameBtn = New System.Windows.Forms.Button()
        Me.NameGrid = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NameCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.NameGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NameBox
        '
        Me.NameBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.NameBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.NameBox.Font = New System.Drawing.Font("Century Schoolbook", 14.25!)
        Me.NameBox.Location = New System.Drawing.Point(96, 10)
        Me.NameBox.MaxLength = 128
        Me.NameBox.Name = "NameBox"
        Me.NameBox.Size = New System.Drawing.Size(292, 30)
        Me.NameBox.TabIndex = 0
        '
        'NameLbl
        '
        Me.NameLbl.AutoSize = True
        Me.NameLbl.Font = New System.Drawing.Font("Century Schoolbook", 14.25!)
        Me.NameLbl.Location = New System.Drawing.Point(12, 13)
        Me.NameLbl.Name = "NameLbl"
        Me.NameLbl.Size = New System.Drawing.Size(78, 23)
        Me.NameLbl.TabIndex = 1
        Me.NameLbl.Text = "Name : "
        '
        'AddNameBtn
        '
        Me.AddNameBtn.BackColor = System.Drawing.Color.Turquoise
        Me.AddNameBtn.Font = New System.Drawing.Font("Century Schoolbook", 14.25!)
        Me.AddNameBtn.Location = New System.Drawing.Point(397, 4)
        Me.AddNameBtn.Name = "AddNameBtn"
        Me.AddNameBtn.Size = New System.Drawing.Size(183, 40)
        Me.AddNameBtn.TabIndex = 2
        Me.AddNameBtn.Text = "&Add Name"
        Me.AddNameBtn.UseVisualStyleBackColor = False
        '
        'NameGrid
        '
        Me.NameGrid.AllowUserToAddRows = False
        Me.NameGrid.AllowUserToResizeColumns = False
        Me.NameGrid.AllowUserToResizeRows = False
        Me.NameGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.NameGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.NameCol})
        Me.NameGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.NameGrid.Location = New System.Drawing.Point(16, 50)
        Me.NameGrid.Name = "NameGrid"
        Me.NameGrid.ReadOnly = True
        Me.NameGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.NameGrid.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Century Schoolbook", 14.25!)
        Me.NameGrid.RowTemplate.Height = 30
        Me.NameGrid.Size = New System.Drawing.Size(565, 295)
        Me.NameGrid.TabIndex = 3
        '
        'ID
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ID.DefaultCellStyle = DataGridViewCellStyle1
        Me.ID.Frozen = True
        Me.ID.HeaderText = "#"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ID.Width = 75
        '
        'NameCol
        '
        Me.NameCol.Frozen = True
        Me.NameCol.HeaderText = "Name"
        Me.NameCol.Name = "NameCol"
        Me.NameCol.ReadOnly = True
        Me.NameCol.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.NameCol.Width = 425
        '
        'EnterNameControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.NameGrid)
        Me.Controls.Add(Me.AddNameBtn)
        Me.Controls.Add(Me.NameLbl)
        Me.Controls.Add(Me.NameBox)
        Me.Name = "EnterNameControl"
        Me.Size = New System.Drawing.Size(600, 345)
        CType(Me.NameGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NameBox As System.Windows.Forms.TextBox
    Friend WithEvents NameLbl As System.Windows.Forms.Label
    Friend WithEvents AddNameBtn As System.Windows.Forms.Button
    Friend WithEvents NameGrid As System.Windows.Forms.DataGridView
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameCol As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
