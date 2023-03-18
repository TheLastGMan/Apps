<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class User_Edit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.CID = New System.Windows.Forms.NumericUpDown
        Me.Label9 = New System.Windows.Forms.Label
        Me.Zip = New System.Windows.Forms.MaskedTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.State = New System.Windows.Forms.MaskedTextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Phone = New System.Windows.Forms.MaskedTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.City = New System.Windows.Forms.TextBox
        Me.Street = New System.Windows.Forms.TextBox
        Me.BName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Updater = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.CID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CID
        '
        Me.CID.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CID.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.CID.Location = New System.Drawing.Point(259, 6)
        Me.CID.Name = "CID"
        Me.CID.Size = New System.Drawing.Size(70, 22)
        Me.CID.TabIndex = 0
        Me.CID.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(151, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 19)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Customer ID :"
        '
        'Zip
        '
        Me.Zip.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Zip.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.Zip.Location = New System.Drawing.Point(419, 87)
        Me.Zip.Mask = "00000"
        Me.Zip.Name = "Zip"
        Me.Zip.Size = New System.Drawing.Size(56, 22)
        Me.Zip.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(374, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 19)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Zip :"
        '
        'State
        '
        Me.State.BackColor = System.Drawing.Color.WhiteSmoke
        Me.State.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.State.Location = New System.Drawing.Point(338, 87)
        Me.State.Mask = ">??"
        Me.State.Name = "State"
        Me.State.Size = New System.Drawing.Size(31, 22)
        Me.State.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(281, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 19)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "State :"
        '
        'Phone
        '
        Me.Phone.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Phone.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.Phone.Location = New System.Drawing.Point(379, 31)
        Me.Phone.Mask = "(999) 000-0000"
        Me.Phone.Name = "Phone"
        Me.Phone.Size = New System.Drawing.Size(96, 22)
        Me.Phone.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(315, 31)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 19)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Phone :"
        '
        'City
        '
        Me.City.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.City.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.City.BackColor = System.Drawing.Color.WhiteSmoke
        Me.City.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.City.Location = New System.Drawing.Point(54, 87)
        Me.City.MaxLength = 32
        Me.City.Name = "City"
        Me.City.Size = New System.Drawing.Size(221, 22)
        Me.City.TabIndex = 3
        '
        'Street
        '
        Me.Street.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Street.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.Street.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Street.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Street.Location = New System.Drawing.Point(69, 59)
        Me.Street.MaxLength = 128
        Me.Street.Name = "Street"
        Me.Street.Size = New System.Drawing.Size(406, 22)
        Me.Street.TabIndex = 2
        '
        'BName
        '
        Me.BName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.BName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.BName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BName.Location = New System.Drawing.Point(92, 31)
        Me.BName.Name = "BName"
        Me.BName.Size = New System.Drawing.Size(220, 22)
        Me.BName.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 19)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "City :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 19)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Street :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 31)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer :"
        '
        'Updater
        '
        Me.Updater.BackColor = System.Drawing.Color.SpringGreen
        Me.Updater.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Updater.Location = New System.Drawing.Point(94, 115)
        Me.Updater.Name = "Updater"
        Me.Updater.Size = New System.Drawing.Size(147, 41)
        Me.Updater.TabIndex = 6
        Me.Updater.Text = "Update"
        Me.Updater.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.IndianRed
        Me.Button1.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(244, 115)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(147, 41)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'User_Edit
        '
        Me.AcceptButton = Me.Updater
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(484, 164)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Updater)
        Me.Controls.Add(Me.CID)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Zip)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.State)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Phone)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.City)
        Me.Controls.Add(Me.Street)
        Me.Controls.Add(Me.BName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(500, 200)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(500, 200)
        Me.Name = "User_Edit"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Edit User - ([Name])"
        CType(Me.CID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CID As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Zip As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents State As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Phone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents City As System.Windows.Forms.TextBox
    Friend WithEvents Street As System.Windows.Forms.TextBox
    Friend WithEvents BName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Updater As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
