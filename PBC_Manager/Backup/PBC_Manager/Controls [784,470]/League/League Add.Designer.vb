<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class League_Add
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
        Me.Add_League = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Price_Box = New System.Windows.Forms.MaskedTextBox
        Me.Show_KB = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Name_Box = New System.Windows.Forms.TextBox
        Me.LeagueTableAdapter = New PBC_Manager.PBCDataSetTableAdapters.LeagueTableAdapter
        Me.QueriesTableAdapter = New PBC_Manager.PBCDataSetTableAdapters.QueriesTableAdapter
        Me.SuspendLayout()
        '
        'Add_League
        '
        Me.Add_League.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Add_League.Font = New System.Drawing.Font("Cambria", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Add_League.Location = New System.Drawing.Point(211, 216)
        Me.Add_League.Name = "Add_League"
        Me.Add_League.Size = New System.Drawing.Size(340, 60)
        Me.Add_League.TabIndex = 3
        Me.Add_League.Text = "Add League"
        Me.Add_League.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(104, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 34)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.Label2.Location = New System.Drawing.Point(113, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 34)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Price :   $"
        '
        'Price_Box
        '
        Me.Price_Box.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.Price_Box.Location = New System.Drawing.Point(235, 130)
        Me.Price_Box.Mask = "0000"
        Me.Price_Box.Name = "Price_Box"
        Me.Price_Box.Size = New System.Drawing.Size(75, 41)
        Me.Price_Box.TabIndex = 2
        '
        'Show_KB
        '
        Me.Show_KB.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Show_KB.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.Show_KB.Location = New System.Drawing.Point(211, 387)
        Me.Show_KB.Name = "Show_KB"
        Me.Show_KB.Size = New System.Drawing.Size(340, 60)
        Me.Show_KB.TabIndex = 4
        Me.Show_KB.Text = "Show KeyBoard"
        Me.Show_KB.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(315, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(230, 25)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Format (1234) = $12.34"
        '
        'Name_Box
        '
        Me.Name_Box.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.Name_Box.Location = New System.Drawing.Point(201, 66)
        Me.Name_Box.Name = "Name_Box"
        Me.Name_Box.Size = New System.Drawing.Size(432, 41)
        Me.Name_Box.TabIndex = 5
        '
        'LeagueTableAdapter
        '
        Me.LeagueTableAdapter.ClearBeforeFill = True
        '
        'League_Add
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Name_Box)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Show_KB)
        Me.Controls.Add(Me.Price_Box)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Add_League)
        Me.Name = "League_Add"
        Me.Size = New System.Drawing.Size(784, 470)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Add_League As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Price_Box As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Show_KB As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Name_Box As System.Windows.Forms.TextBox
    Friend WithEvents LeagueTableAdapter As PBC_Manager.PBCDataSetTableAdapters.LeagueTableAdapter
    Friend WithEvents QueriesTableAdapter As PBC_Manager.PBCDataSetTableAdapters.QueriesTableAdapter

End Class
