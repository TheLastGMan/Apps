<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class settings
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Phone = New System.Windows.Forms.TextBox
        Me.Logo = New System.Windows.Forms.TextBox
        Me.AreaCode = New System.Windows.Forms.NumericUpDown
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.BGColor = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.PrintWindow = New System.Windows.Forms.ComboBox
        Me.DefPage = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        CType(Me.AreaCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(316, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 42)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Settings"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(174, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(210, 31)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Phone Number :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(216, 210)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(168, 31)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Logo Name :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(54, 437)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(330, 31)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Drilling Sheet Back Color :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(226, 261)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(158, 31)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Area Code :"
        '
        'Phone
        '
        Me.Phone.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.Phone.Location = New System.Drawing.Point(390, 149)
        Me.Phone.MaxLength = 15
        Me.Phone.Name = "Phone"
        Me.Phone.Size = New System.Drawing.Size(391, 38)
        Me.Phone.TabIndex = 5
        '
        'Logo
        '
        Me.Logo.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.Logo.Location = New System.Drawing.Point(390, 207)
        Me.Logo.MaxLength = 15
        Me.Logo.Name = "Logo"
        Me.Logo.Size = New System.Drawing.Size(391, 38)
        Me.Logo.TabIndex = 6
        '
        'AreaCode
        '
        Me.AreaCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.AreaCode.Location = New System.Drawing.Point(390, 259)
        Me.AreaCode.Maximum = New Decimal(New Integer() {899, 0, 0, 0})
        Me.AreaCode.Minimum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.AreaCode.Name = "AreaCode"
        Me.AreaCode.Size = New System.Drawing.Size(195, 38)
        Me.AreaCode.TabIndex = 7
        Me.AreaCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.AreaCode.Value = New Decimal(New Integer() {200, 0, 0, 0})
        '
        'BGColor
        '
        Me.BGColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.BGColor.Location = New System.Drawing.Point(390, 428)
        Me.BGColor.Name = "BGColor"
        Me.BGColor.Size = New System.Drawing.Size(391, 48)
        Me.BGColor.TabIndex = 8
        Me.BGColor.Text = "Button1"
        Me.BGColor.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(106, 316)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(278, 31)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Print in New Window :"
        '
        'PrintWindow
        '
        Me.PrintWindow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PrintWindow.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.PrintWindow.FormattingEnabled = True
        Me.PrintWindow.Items.AddRange(New Object() {"No", "Yes"})
        Me.PrintWindow.Location = New System.Drawing.Point(390, 313)
        Me.PrintWindow.Name = "PrintWindow"
        Me.PrintWindow.Size = New System.Drawing.Size(391, 39)
        Me.PrintWindow.TabIndex = 9
        '
        'DefPage
        '
        Me.DefPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DefPage.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.DefPage.FormattingEnabled = True
        Me.DefPage.Items.AddRange(New Object() {"Drilling", "Search"})
        Me.DefPage.Location = New System.Drawing.Point(390, 370)
        Me.DefPage.Name = "DefPage"
        Me.DefPage.Size = New System.Drawing.Size(391, 39)
        Me.DefPage.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(198, 373)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(186, 31)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Default Page :"
        '
        'settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DefPage)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PrintWindow)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BGColor)
        Me.Controls.Add(Me.AreaCode)
        Me.Controls.Add(Me.Logo)
        Me.Controls.Add(Me.Phone)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "settings"
        Me.Size = New System.Drawing.Size(784, 515)
        CType(Me.AreaCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Phone As System.Windows.Forms.TextBox
    Friend WithEvents Logo As System.Windows.Forms.TextBox
    Friend WithEvents AreaCode As System.Windows.Forms.NumericUpDown
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents BGColor As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PrintWindow As System.Windows.Forms.ComboBox
    Friend WithEvents DefPage As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
