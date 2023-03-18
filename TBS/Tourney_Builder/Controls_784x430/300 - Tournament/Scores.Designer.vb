<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Scores
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BS = New System.Windows.Forms.DataGridView()
        Me.Num = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bowler = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AboveBelow = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Series4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Average = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.HS_Men = New System.Windows.Forms.Label()
        Me.HS_Women = New System.Windows.Forms.Label()
        CType(Me.BS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BS
        '
        Me.BS.AllowUserToAddRows = False
        Me.BS.AllowUserToDeleteRows = False
        Me.BS.AllowUserToResizeColumns = False
        Me.BS.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.BS.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.BS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BS.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.BS.ColumnHeadersHeight = 25
        Me.BS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.BS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Num, Me.Bowler, Me.AboveBelow, Me.Series4, Me.Average})
        Me.BS.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.BS.Location = New System.Drawing.Point(0, 45)
        Me.BS.MultiSelect = False
        Me.BS.Name = "BS"
        Me.BS.ReadOnly = True
        Me.BS.RowHeadersVisible = False
        Me.BS.RowHeadersWidth = 4
        Me.BS.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.BS.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.BS.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BS.RowTemplate.Height = 40
        Me.BS.RowTemplate.ReadOnly = True
        Me.BS.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.BS.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.BS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.BS.ShowCellErrors = False
        Me.BS.ShowCellToolTips = False
        Me.BS.ShowEditingIcon = False
        Me.BS.ShowRowErrors = False
        Me.BS.Size = New System.Drawing.Size(784, 385)
        Me.BS.TabIndex = 1
        '
        'Num
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Num.DefaultCellStyle = DataGridViewCellStyle3
        Me.Num.FillWeight = 30.0!
        Me.Num.Frozen = True
        Me.Num.HeaderText = "#"
        Me.Num.Name = "Num"
        Me.Num.ReadOnly = True
        Me.Num.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Num.Width = 30
        '
        'Bowler
        '
        Me.Bowler.FillWeight = 174.0!
        Me.Bowler.Frozen = True
        Me.Bowler.HeaderText = "Bowler"
        Me.Bowler.Name = "Bowler"
        Me.Bowler.ReadOnly = True
        Me.Bowler.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Bowler.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Bowler.Width = 174
        '
        'AboveBelow
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.AboveBelow.DefaultCellStyle = DataGridViewCellStyle4
        Me.AboveBelow.FillWeight = 80.0!
        Me.AboveBelow.Frozen = True
        Me.AboveBelow.HeaderText = "+/-"
        Me.AboveBelow.Name = "AboveBelow"
        Me.AboveBelow.ReadOnly = True
        Me.AboveBelow.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.AboveBelow.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.AboveBelow.Width = 75
        '
        'Series4
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Series4.DefaultCellStyle = DataGridViewCellStyle5
        Me.Series4.Frozen = True
        Me.Series4.HeaderText = "Series 3G/4XG"
        Me.Series4.Name = "Series4"
        Me.Series4.ReadOnly = True
        Me.Series4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Series4.Width = 115
        '
        'Average
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Average.DefaultCellStyle = DataGridViewCellStyle6
        Me.Average.FillWeight = 80.0!
        Me.Average.Frozen = True
        Me.Average.HeaderText = "Average"
        Me.Average.Name = "Average"
        Me.Average.ReadOnly = True
        Me.Average.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Average.Width = 80
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Cambria", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 39)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Top M :"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Cambria", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(408, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 39)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Top F :"
        '
        'HS_Men
        '
        Me.HS_Men.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.HS_Men.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HS_Men.Location = New System.Drawing.Point(117, 12)
        Me.HS_Men.Name = "HS_Men"
        Me.HS_Men.Size = New System.Drawing.Size(275, 26)
        Me.HS_Men.TabIndex = 0
        Me.HS_Men.Text = "High Score - Mens"
        '
        'HS_Women
        '
        Me.HS_Women.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.HS_Women.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HS_Women.Location = New System.Drawing.Point(489, 12)
        Me.HS_Women.Name = "HS_Women"
        Me.HS_Women.Size = New System.Drawing.Size(275, 26)
        Me.HS_Women.TabIndex = 0
        Me.HS_Women.Text = "High Score - Womens"
        '
        'Scores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.HS_Women)
        Me.Controls.Add(Me.HS_Men)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BS)
        Me.Name = "Scores"
        Me.Size = New System.Drawing.Size(784, 430)
        CType(Me.BS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BS As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents HS_Men As System.Windows.Forms.Label
    Friend WithEvents HS_Women As System.Windows.Forms.Label
    Friend WithEvents Num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bowler As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AboveBelow As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Series4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Average As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
