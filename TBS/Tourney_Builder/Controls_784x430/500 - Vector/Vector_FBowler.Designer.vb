<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VectorFBowler
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
        Me.NBowler = New System.Windows.Forms.TextBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Namew = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Lane = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Game = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Score = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Strikes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Spares = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Splits = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Split_Conversion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Datex = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(262, 50)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bowlers Name" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(As It Appears On Screen)"
        '
        'NBowler
        '
        Me.NBowler.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.NBowler.Location = New System.Drawing.Point(310, 17)
        Me.NBowler.Name = "NBowler"
        Me.NBowler.Size = New System.Drawing.Size(396, 31)
        Me.NBowler.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Namew, Me.Lane, Me.Game, Me.Score, Me.Strikes, Me.Spares, Me.Splits, Me.Split_Conversion, Me.Datex})
        Me.DataGridView1.Location = New System.Drawing.Point(3, 86)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(778, 341)
        Me.DataGridView1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(328, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(157, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Only Show Last Time"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownHeight = 100
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.IntegralHeight = False
        Me.ComboBox1.Items.AddRange(New Object() {"No", "Yes"})
        Me.ComboBox1.Location = New System.Drawing.Point(491, 52)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(120, 28)
        Me.ComboBox1.TabIndex = 2
        '
        'Namew
        '
        Me.Namew.Frozen = True
        Me.Namew.HeaderText = "Name"
        Me.Namew.Name = "Namew"
        Me.Namew.ReadOnly = True
        '
        'Lane
        '
        Me.Lane.FillWeight = 50.0!
        Me.Lane.Frozen = True
        Me.Lane.HeaderText = "Lane"
        Me.Lane.Name = "Lane"
        Me.Lane.ReadOnly = True
        Me.Lane.Width = 50
        '
        'Game
        '
        Me.Game.FillWeight = 50.0!
        Me.Game.Frozen = True
        Me.Game.HeaderText = "Game"
        Me.Game.Name = "Game"
        Me.Game.ReadOnly = True
        Me.Game.Width = 50
        '
        'Score
        '
        Me.Score.FillWeight = 75.0!
        Me.Score.Frozen = True
        Me.Score.HeaderText = "Score"
        Me.Score.Name = "Score"
        Me.Score.ReadOnly = True
        Me.Score.Width = 75
        '
        'Strikes
        '
        Me.Strikes.Frozen = True
        Me.Strikes.HeaderText = "Strikes"
        Me.Strikes.Name = "Strikes"
        Me.Strikes.ReadOnly = True
        Me.Strikes.Width = 90
        '
        'Spares
        '
        Me.Spares.Frozen = True
        Me.Spares.HeaderText = "Spares"
        Me.Spares.Name = "Spares"
        Me.Spares.ReadOnly = True
        Me.Spares.Width = 90
        '
        'Splits
        '
        Me.Splits.Frozen = True
        Me.Splits.HeaderText = "Splits"
        Me.Splits.Name = "Splits"
        Me.Splits.ReadOnly = True
        Me.Splits.Width = 90
        '
        'Split_Conversion
        '
        Me.Split_Conversion.Frozen = True
        Me.Split_Conversion.HeaderText = "Split Conversion"
        Me.Split_Conversion.Name = "Split_Conversion"
        Me.Split_Conversion.ReadOnly = True
        Me.Split_Conversion.Width = 90
        '
        'Datex
        '
        Me.Datex.FillWeight = 130.0!
        Me.Datex.Frozen = True
        Me.Datex.HeaderText = "Date"
        Me.Datex.Name = "Datex"
        Me.Datex.ReadOnly = True
        Me.Datex.Width = 130
        '
        'VectorFBowler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.NBowler)
        Me.Controls.Add(Me.Label1)
        Me.Name = "VectorFBowler"
        Me.Size = New System.Drawing.Size(784, 430)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NBowler As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Namex As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Namew As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lane As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Game As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Score As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Strikes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Spares As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Splits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Split_Conversion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Datex As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
