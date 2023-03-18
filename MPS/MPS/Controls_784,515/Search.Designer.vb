<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Search
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Namex = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Phone = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Address = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.City = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.State = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Zip = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Zip1 = New System.Windows.Forms.MaskedTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.State1 = New System.Windows.Forms.MaskedTextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.NPhone = New System.Windows.Forms.MaskedTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.City1 = New System.Windows.Forms.TextBox
        Me.Street = New System.Windows.Forms.TextBox
        Me.BName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.CID = New System.Windows.Forms.NumericUpDown
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Cust_Sort = New System.Windows.Forms.ComboBox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.ColumnHeadersHeight = 30
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Namex, Me.Phone, Me.Address, Me.City, Me.State, Me.Zip})
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(3, 142)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.DataGridView1.RowTemplate.Height = 34
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.Size = New System.Drawing.Size(778, 370)
        Me.DataGridView1.TabIndex = 7
        '
        'ID
        '
        Me.ID.FillWeight = 60.0!
        Me.ID.Frozen = True
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Width = 60
        '
        'Namex
        '
        Me.Namex.FillWeight = 180.0!
        Me.Namex.Frozen = True
        Me.Namex.HeaderText = "Name"
        Me.Namex.Name = "Namex"
        Me.Namex.ReadOnly = True
        Me.Namex.Width = 180
        '
        'Phone
        '
        Me.Phone.FillWeight = 110.0!
        Me.Phone.Frozen = True
        Me.Phone.HeaderText = "Phone"
        Me.Phone.Name = "Phone"
        Me.Phone.ReadOnly = True
        Me.Phone.Width = 110
        '
        'Address
        '
        Me.Address.FillWeight = 188.0!
        Me.Address.Frozen = True
        Me.Address.HeaderText = "Address"
        Me.Address.Name = "Address"
        Me.Address.ReadOnly = True
        Me.Address.Width = 188
        '
        'City
        '
        Me.City.FillWeight = 145.0!
        Me.City.Frozen = True
        Me.City.HeaderText = "City"
        Me.City.Name = "City"
        Me.City.ReadOnly = True
        Me.City.Width = 145
        '
        'State
        '
        Me.State.FillWeight = 35.0!
        Me.State.Frozen = True
        Me.State.HeaderText = "St."
        Me.State.Name = "State"
        Me.State.ReadOnly = True
        Me.State.Width = 35
        '
        'Zip
        '
        Me.Zip.FillWeight = 60.0!
        Me.Zip.Frozen = True
        Me.Zip.HeaderText = "Zip"
        Me.Zip.Name = "Zip"
        Me.Zip.ReadOnly = True
        Me.Zip.Width = 60
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Courier New", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(29, 112)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(726, 27)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Left Click to View Drillings AND Right Click to Add"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(305, 87)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 19)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Customer ID :"
        '
        'Zip1
        '
        Me.Zip1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Zip1.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.Zip1.Location = New System.Drawing.Point(556, 59)
        Me.Zip1.Mask = "00000"
        Me.Zip1.Name = "Zip1"
        Me.Zip1.Size = New System.Drawing.Size(71, 22)
        Me.Zip1.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(511, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 19)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Zip :"
        '
        'State1
        '
        Me.State1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.State1.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.State1.Location = New System.Drawing.Point(474, 59)
        Me.State1.Mask = ">??"
        Me.State1.Name = "State1"
        Me.State1.Size = New System.Drawing.Size(31, 22)
        Me.State1.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(417, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 19)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "State :"
        '
        'NPhone
        '
        Me.NPhone.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NPhone.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.NPhone.Location = New System.Drawing.Point(531, 3)
        Me.NPhone.Mask = "(999) 000-0000"
        Me.NPhone.Name = "NPhone"
        Me.NPhone.Size = New System.Drawing.Size(96, 22)
        Me.NPhone.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(467, 3)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 19)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Phone :"
        '
        'City1
        '
        Me.City1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.City1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.City1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.City1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.City1.Location = New System.Drawing.Point(206, 59)
        Me.City1.MaxLength = 32
        Me.City1.Name = "City1"
        Me.City1.Size = New System.Drawing.Size(205, 22)
        Me.City1.TabIndex = 3
        '
        'Street
        '
        Me.Street.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Street.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.Street.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Street.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Street.Location = New System.Drawing.Point(221, 31)
        Me.Street.MaxLength = 128
        Me.Street.Name = "Street"
        Me.Street.Size = New System.Drawing.Size(406, 22)
        Me.Street.TabIndex = 2
        '
        'BName
        '
        Me.BName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.BName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.BName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BName.Location = New System.Drawing.Point(244, 3)
        Me.BName.Name = "BName"
        Me.BName.Size = New System.Drawing.Size(220, 22)
        Me.BName.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(157, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 19)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "City :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(157, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Street :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(157, 3)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 19)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Customer :"
        '
        'CID
        '
        Me.CID.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CID.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.CID.Location = New System.Drawing.Point(406, 87)
        Me.CID.Name = "CID"
        Me.CID.Size = New System.Drawing.Size(74, 22)
        Me.CID.TabIndex = 0
        Me.CID.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(36, 4)
        '
        'Cust_Sort
        '
        Me.Cust_Sort.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cust_Sort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cust_Sort.DropDownWidth = 130
        Me.Cust_Sort.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.Cust_Sort.FormattingEnabled = True
        Me.Cust_Sort.Items.AddRange(New Object() {"Ends With", "Begins With", "Contains"})
        Me.Cust_Sort.Location = New System.Drawing.Point(12, 3)
        Me.Cust_Sort.Name = "Cust_Sort"
        Me.Cust_Sort.Size = New System.Drawing.Size(130, 23)
        Me.Cust_Sort.TabIndex = 0
        Me.Cust_Sort.TabStop = False
        '
        'Search
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkCyan
        Me.Controls.Add(Me.Cust_Sort)
        Me.Controls.Add(Me.CID)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Zip1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.State1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.NPhone)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.City1)
        Me.Controls.Add(Me.Street)
        Me.Controls.Add(Me.BName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label3)
        Me.Name = "Search"
        Me.Size = New System.Drawing.Size(784, 515)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Zip1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents State1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents NPhone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents City1 As System.Windows.Forms.TextBox
    Friend WithEvents Street As System.Windows.Forms.TextBox
    Friend WithEvents BName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CID As System.Windows.Forms.NumericUpDown
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Namex As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Phone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Address As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents City As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents State As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Zip As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cust_Sort As System.Windows.Forms.ComboBox

End Class
