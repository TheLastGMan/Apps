<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Vector_Settings
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.IP1 = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.IP2 = New System.Windows.Forms.NumericUpDown
        Me.Label4 = New System.Windows.Forms.Label
        Me.IP3 = New System.Windows.Forms.NumericUpDown
        Me.IP4 = New System.Windows.Forms.NumericUpDown
        Me.IPPort = New System.Windows.Forms.NumericUpDown
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.SMon = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.USRDb = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.USRName = New System.Windows.Forms.TextBox
        Me.USRPassword = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.SSmon = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.IUSRDb = New System.Windows.Forms.TextBox
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.IP1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IP2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IP3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IP4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IPPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.Label1.Location = New System.Drawing.Point(162, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "IP Address :"
        '
        'IP1
        '
        Me.IP1.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.IP1.Location = New System.Drawing.Point(289, 76)
        Me.IP1.Maximum = New Decimal(New Integer() {223, 0, 0, 0})
        Me.IP1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.IP1.Name = "IP1"
        Me.IP1.Size = New System.Drawing.Size(73, 33)
        Me.IP1.TabIndex = 2
        Me.IP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.IP1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.Label2.Location = New System.Drawing.Point(364, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 26)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.Label3.Location = New System.Drawing.Point(455, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 26)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "."
        '
        'IP2
        '
        Me.IP2.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.IP2.Location = New System.Drawing.Point(379, 76)
        Me.IP2.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.IP2.Name = "IP2"
        Me.IP2.Size = New System.Drawing.Size(73, 33)
        Me.IP2.TabIndex = 3
        Me.IP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.Label4.Location = New System.Drawing.Point(546, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 26)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "."
        '
        'IP3
        '
        Me.IP3.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.IP3.Location = New System.Drawing.Point(470, 76)
        Me.IP3.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.IP3.Name = "IP3"
        Me.IP3.Size = New System.Drawing.Size(73, 33)
        Me.IP3.TabIndex = 4
        Me.IP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IP4
        '
        Me.IP4.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.IP4.Location = New System.Drawing.Point(562, 76)
        Me.IP4.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.IP4.Name = "IP4"
        Me.IP4.Size = New System.Drawing.Size(73, 33)
        Me.IP4.TabIndex = 5
        Me.IP4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IPPort
        '
        Me.IPPort.Enabled = False
        Me.IPPort.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.IPPort.Location = New System.Drawing.Point(289, 124)
        Me.IPPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.IPPort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.IPPort.Name = "IPPort"
        Me.IPPort.Size = New System.Drawing.Size(91, 33)
        Me.IPPort.TabIndex = 6
        Me.IPPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.IPPort.Value = New Decimal(New Integer() {1433, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.Label5.Location = New System.Drawing.Point(221, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 26)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Port :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.Label6.Location = New System.Drawing.Point(115, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(168, 26)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Scoring Monitor :"
        '
        'SMon
        '
        Me.SMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SMon.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.SMon.FormattingEnabled = True
        Me.SMon.Items.AddRange(New Object() {"Vector", "AMF"})
        Me.SMon.Location = New System.Drawing.Point(289, 23)
        Me.SMon.Name = "SMon"
        Me.SMon.Size = New System.Drawing.Size(122, 34)
        Me.SMon.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(417, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(259, 20)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "(AMF is currently NOT SUPPORTED)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.Label8.Location = New System.Drawing.Point(121, 216)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(162, 26)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "DataBase Name :"
        '
        'USRDb
        '
        Me.USRDb.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.USRDb.Location = New System.Drawing.Point(289, 216)
        Me.USRDb.MaxLength = 255
        Me.USRDb.Name = "USRDb"
        Me.USRDb.Size = New System.Drawing.Size(163, 33)
        Me.USRDb.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.Button1.Location = New System.Drawing.Point(310, 384)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(165, 39)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Test Connection"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'USRName
        '
        Me.USRName.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.USRName.Location = New System.Drawing.Point(289, 255)
        Me.USRName.MaxLength = 255
        Me.USRName.Name = "USRName"
        Me.USRName.Size = New System.Drawing.Size(163, 33)
        Me.USRName.TabIndex = 8
        '
        'USRPassword
        '
        Me.USRPassword.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.USRPassword.Location = New System.Drawing.Point(289, 294)
        Me.USRPassword.MaxLength = 255
        Me.USRPassword.Name = "USRPassword"
        Me.USRPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.USRPassword.Size = New System.Drawing.Size(163, 33)
        Me.USRPassword.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.Label9.Location = New System.Drawing.Point(167, 258)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 26)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "UserName :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.Label10.Location = New System.Drawing.Point(172, 297)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(111, 26)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Password :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.Label11.Location = New System.Drawing.Point(61, 343)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(222, 26)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Show Scoring Monitor :"
        '
        'SSmon
        '
        Me.SSmon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SSmon.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.SSmon.FormattingEnabled = True
        Me.SSmon.Items.AddRange(New Object() {"No", "Yes"})
        Me.SSmon.Location = New System.Drawing.Point(289, 340)
        Me.SSmon.Name = "SSmon"
        Me.SSmon.Size = New System.Drawing.Size(122, 34)
        Me.SSmon.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.Label12.Location = New System.Drawing.Point(43, 168)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(240, 26)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Internal DataBase Name :"
        '
        'IUSRDb
        '
        Me.IUSRDb.Font = New System.Drawing.Font("Cambria", 15.75!)
        Me.IUSRDb.Location = New System.Drawing.Point(289, 168)
        Me.IUSRDb.MaxLength = 255
        Me.IUSRDb.Name = "IUSRDb"
        Me.IUSRDb.Size = New System.Drawing.Size(163, 33)
        Me.IUSRDb.TabIndex = 12
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(132, 26)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(131, 22)
        Me.ToolStripMenuItem1.Text = "Show Password"
        '
        'Vector_Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.IUSRDb)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.SSmon)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.USRPassword)
        Me.Controls.Add(Me.USRName)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.USRDb)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.SMon)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.IPPort)
        Me.Controls.Add(Me.IP4)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.IP3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.IP2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.IP1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Vector_Settings"
        Me.Size = New System.Drawing.Size(784, 430)
        CType(Me.IP1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IP2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IP3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IP4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IPPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents IP1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents IP2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents IP3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents IP4 As System.Windows.Forms.NumericUpDown
    Friend WithEvents IPPort As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SMon As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents USRDb As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents USRName As System.Windows.Forms.TextBox
    Friend WithEvents USRPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents SSmon As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents IUSRDb As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem

End Class
