<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PBC_Redeem
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
        Me.Label4 = New System.Windows.Forms.Label
        Me.Show_KB = New System.Windows.Forms.Button
        Me.Redeem_Button = New System.Windows.Forms.Button
        Me.Undo_Redeem = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.PBC_Status = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Red_Box = New System.Windows.Forms.ComboBox
        Me.Card_ID = New System.Windows.Forms.TextBox
        Me.Master_SheetTableAdapter = New PBC_Manager.PBCDataSetTableAdapters.Master_SheetTableAdapter
        Me.Card_Status = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cambria", 14.25!)
        Me.Label4.Location = New System.Drawing.Point(224, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 22)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Card ID :"
        '
        'Show_KB
        '
        Me.Show_KB.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Show_KB.Font = New System.Drawing.Font("Cambria", 21.75!)
        Me.Show_KB.Location = New System.Drawing.Point(222, 382)
        Me.Show_KB.Name = "Show_KB"
        Me.Show_KB.Size = New System.Drawing.Size(340, 60)
        Me.Show_KB.TabIndex = 0
        Me.Show_KB.Text = "Show KeyBoard"
        Me.Show_KB.UseVisualStyleBackColor = False
        '
        'Redeem_Button
        '
        Me.Redeem_Button.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Redeem_Button.Font = New System.Drawing.Font("Cambria", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Redeem_Button.Location = New System.Drawing.Point(222, 299)
        Me.Redeem_Button.Name = "Redeem_Button"
        Me.Redeem_Button.Size = New System.Drawing.Size(340, 60)
        Me.Redeem_Button.TabIndex = 3
        Me.Redeem_Button.Text = "Redeem PBC"
        Me.Redeem_Button.UseVisualStyleBackColor = False
        '
        'Undo_Redeem
        '
        Me.Undo_Redeem.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Undo_Redeem.Font = New System.Drawing.Font("Cambria", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Undo_Redeem.Location = New System.Drawing.Point(629, 113)
        Me.Undo_Redeem.Name = "Undo_Redeem"
        Me.Undo_Redeem.Size = New System.Drawing.Size(118, 60)
        Me.Undo_Redeem.TabIndex = 0
        Me.Undo_Redeem.Text = "Undo"
        Me.Undo_Redeem.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Cambria", 14.25!)
        Me.Label5.Location = New System.Drawing.Point(544, 181)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 22)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Type :"
        '
        'PBC_Status
        '
        Me.PBC_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PBC_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.PBC_Status.FormattingEnabled = True
        Me.PBC_Status.Location = New System.Drawing.Point(610, 176)
        Me.PBC_Status.Name = "PBC_Status"
        Me.PBC_Status.Size = New System.Drawing.Size(151, 33)
        Me.PBC_Status.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 14.25!)
        Me.Label1.Location = New System.Drawing.Point(269, 186)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Type :"
        '
        'Red_Box
        '
        Me.Red_Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Red_Box.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.Red_Box.FormattingEnabled = True
        Me.Red_Box.Location = New System.Drawing.Point(335, 181)
        Me.Red_Box.Name = "Red_Box"
        Me.Red_Box.Size = New System.Drawing.Size(151, 33)
        Me.Red_Box.TabIndex = 2
        '
        'Card_ID
        '
        Me.Card_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.Card_ID.Location = New System.Drawing.Point(311, 133)
        Me.Card_ID.MaxLength = 13
        Me.Card_ID.Name = "Card_ID"
        Me.Card_ID.Size = New System.Drawing.Size(194, 31)
        Me.Card_ID.TabIndex = 1
        '
        'Master_SheetTableAdapter
        '
        Me.Master_SheetTableAdapter.ClearBeforeFill = True
        '
        'Card_Status
        '
        Me.Card_Status.Font = New System.Drawing.Font("Cambria", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Card_Status.Location = New System.Drawing.Point(261, 223)
        Me.Card_Status.Name = "Card_Status"
        Me.Card_Status.Size = New System.Drawing.Size(272, 70)
        Me.Card_Status.TabIndex = 0
        Me.Card_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 14.25!)
        Me.Label2.Location = New System.Drawing.Point(597, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(164, 44)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Quick Undo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(undoes last entry)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PBC_Redeem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Card_Status)
        Me.Controls.Add(Me.Card_ID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Red_Box)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PBC_Status)
        Me.Controls.Add(Me.Undo_Redeem)
        Me.Controls.Add(Me.Show_KB)
        Me.Controls.Add(Me.Redeem_Button)
        Me.Controls.Add(Me.Label4)
        Me.Name = "PBC_Redeem"
        Me.Size = New System.Drawing.Size(784, 470)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Show_KB As System.Windows.Forms.Button
    Friend WithEvents Redeem_Button As System.Windows.Forms.Button
    Friend WithEvents Undo_Redeem As System.Windows.Forms.Button
    Friend WithEvents Master_SheetTableAdapter As PBC_Manager.PBCDataSetTableAdapters.Master_SheetTableAdapter
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PBC_Status As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Red_Box As System.Windows.Forms.ComboBox
    Friend WithEvents Card_ID As System.Windows.Forms.TextBox
    Friend WithEvents Card_Status As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
