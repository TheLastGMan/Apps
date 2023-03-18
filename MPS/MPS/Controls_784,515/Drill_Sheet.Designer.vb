<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Drill_Sheet
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
        Me.txt_phone = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Comments = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Street = New System.Windows.Forms.TextBox
        Me.City = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Phone = New System.Windows.Forms.MaskedTextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.State = New System.Windows.Forms.MaskedTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Zip = New System.Windows.Forms.MaskedTextBox
        Me.BName = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.DateD = New System.Windows.Forms.MaskedTextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Drill_Type = New System.Windows.Forms.ComboBox
        Me.Layout_Type = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Special_Txt = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.BColor = New System.Windows.Forms.TextBox
        Me.BWeight = New System.Windows.Forms.TextBox
        Me.BInitials = New System.Windows.Forms.TextBox
        Me.BNum = New System.Windows.Forms.TextBox
        Me.LR_Pitch = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.FB_Pitch = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Slug = New System.Windows.Forms.CheckBox
        Me.Grips = New System.Windows.Forms.CheckBox
        Me.TPitch = New System.Windows.Forms.TextBox
        Me.TSidePitch = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Hand = New System.Windows.Forms.ComboBox
        Me.MTSpan = New System.Windows.Forms.TextBox
        Me.RTSpan = New System.Windows.Forms.TextBox
        Me.MRSpan = New System.Windows.Forms.TextBox
        Me.MPitch = New System.Windows.Forms.TextBox
        Me.RPitch = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.MSize = New System.Windows.Forms.TextBox
        Me.RSize = New System.Windows.Forms.TextBox
        Me.TSize = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Fingered = New System.Windows.Forms.ComboBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Pic_Location = New System.Windows.Forms.PictureBox
        Me.Logo = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label24 = New System.Windows.Forms.Label
        Me.FID = New System.Windows.Forms.NumericUpDown
        Me.CID = New System.Windows.Forms.NumericUpDown
        Me.Choices = New System.Windows.Forms.Button
        Me.NForm = New System.Windows.Forms.Button
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Location, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(311, 13)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer :"
        '
        'txt_phone
        '
        Me.txt_phone.BackColor = System.Drawing.Color.Transparent
        Me.txt_phone.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_phone.Location = New System.Drawing.Point(5, 152)
        Me.txt_phone.Name = "txt_phone"
        Me.txt_phone.Size = New System.Drawing.Size(300, 23)
        Me.txt_phone.TabIndex = 0
        Me.txt_phone.Text = "(000) 000-0000"
        Me.txt_phone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(104, 395)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 22)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Comments"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Comments
        '
        Me.Comments.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Comments.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Comments.Location = New System.Drawing.Point(5, 420)
        Me.Comments.Multiline = True
        Me.Comments.Name = "Comments"
        Me.Comments.Size = New System.Drawing.Size(300, 82)
        Me.Comments.TabIndex = 28
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(311, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 19)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Street :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(311, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 19)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "City :"
        '
        'Street
        '
        Me.Street.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Street.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.Street.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Street.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Street.Location = New System.Drawing.Point(375, 41)
        Me.Street.MaxLength = 128
        Me.Street.Name = "Street"
        Me.Street.Size = New System.Drawing.Size(406, 22)
        Me.Street.TabIndex = 2
        '
        'City
        '
        Me.City.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.City.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.City.BackColor = System.Drawing.Color.WhiteSmoke
        Me.City.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.City.Location = New System.Drawing.Point(360, 69)
        Me.City.MaxLength = 32
        Me.City.Name = "City"
        Me.City.Size = New System.Drawing.Size(221, 22)
        Me.City.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(621, 13)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 19)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Phone :"
        '
        'Phone
        '
        Me.Phone.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Phone.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.Phone.Location = New System.Drawing.Point(685, 13)
        Me.Phone.Mask = "(999) 000-0000"
        Me.Phone.Name = "Phone"
        Me.Phone.Size = New System.Drawing.Size(96, 22)
        Me.Phone.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(587, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 19)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "State :"
        '
        'State
        '
        Me.State.BackColor = System.Drawing.Color.WhiteSmoke
        Me.State.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.State.Location = New System.Drawing.Point(644, 69)
        Me.State.Mask = ">??"
        Me.State.Name = "State"
        Me.State.Size = New System.Drawing.Size(31, 22)
        Me.State.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(680, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 19)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Zip :"
        '
        'Zip
        '
        Me.Zip.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Zip.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.Zip.Location = New System.Drawing.Point(725, 69)
        Me.Zip.Mask = "00000"
        Me.Zip.Name = "Zip"
        Me.Zip.Size = New System.Drawing.Size(56, 22)
        Me.Zip.TabIndex = 5
        '
        'BName
        '
        Me.BName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.BName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.BName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BName.Location = New System.Drawing.Point(398, 13)
        Me.BName.Name = "BName"
        Me.BName.Size = New System.Drawing.Size(220, 22)
        Me.BName.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(311, 97)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 19)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Date :"
        '
        'DateD
        '
        Me.DateD.BackColor = System.Drawing.Color.WhiteSmoke
        Me.DateD.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.DateD.Location = New System.Drawing.Point(360, 97)
        Me.DateD.Mask = "00/00/0000"
        Me.DateD.Name = "DateD"
        Me.DateD.ReadOnly = True
        Me.DateD.Size = New System.Drawing.Size(77, 22)
        Me.DateD.TabIndex = 0
        Me.DateD.TabStop = False
        Me.DateD.ValidatingType = GetType(Date)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(443, 97)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 19)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Customer ID :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(666, 122)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(105, 19)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Drilling Type"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(689, 178)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 19)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Layout"
        '
        'Drill_Type
        '
        Me.Drill_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Drill_Type.FormattingEnabled = True
        Me.Drill_Type.Items.AddRange(New Object() {"Conventional", "Finger Tip"})
        Me.Drill_Type.Location = New System.Drawing.Point(661, 144)
        Me.Drill_Type.Name = "Drill_Type"
        Me.Drill_Type.Size = New System.Drawing.Size(116, 21)
        Me.Drill_Type.TabIndex = 6
        '
        'Layout_Type
        '
        Me.Layout_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Layout_Type.FormattingEnabled = True
        Me.Layout_Type.Items.AddRange(New Object() {"12:00", "1:00", "10:30"})
        Me.Layout_Type.Location = New System.Drawing.Point(661, 200)
        Me.Layout_Type.Name = "Layout_Type"
        Me.Layout_Type.Size = New System.Drawing.Size(116, 21)
        Me.Layout_Type.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(670, 230)
        Me.Label12.Margin = New System.Windows.Forms.Padding(0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 19)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Special Info"
        '
        'Special_Txt
        '
        Me.Special_Txt.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Special_Txt.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Special_Txt.Location = New System.Drawing.Point(661, 252)
        Me.Special_Txt.MaxLength = 128
        Me.Special_Txt.Multiline = True
        Me.Special_Txt.Name = "Special_Txt"
        Me.Special_Txt.Size = New System.Drawing.Size(116, 40)
        Me.Special_Txt.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Cambria", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(682, 298)
        Me.Label13.Margin = New System.Windows.Forms.Padding(0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 19)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Ball Info"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(695, 317)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 19)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Color"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(690, 364)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 19)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Weight"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(691, 411)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 19)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Initials"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(687, 458)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(62, 19)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Ball No."
        '
        'BColor
        '
        Me.BColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.BColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.BColor.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BColor.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BColor.Location = New System.Drawing.Point(661, 339)
        Me.BColor.MaxLength = 32
        Me.BColor.Name = "BColor"
        Me.BColor.Size = New System.Drawing.Size(116, 22)
        Me.BColor.TabIndex = 9
        '
        'BWeight
        '
        Me.BWeight.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.BWeight.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.BWeight.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BWeight.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BWeight.Location = New System.Drawing.Point(661, 386)
        Me.BWeight.MaxLength = 32
        Me.BWeight.Name = "BWeight"
        Me.BWeight.Size = New System.Drawing.Size(116, 22)
        Me.BWeight.TabIndex = 10
        '
        'BInitials
        '
        Me.BInitials.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BInitials.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BInitials.Location = New System.Drawing.Point(661, 433)
        Me.BInitials.MaxLength = 32
        Me.BInitials.Name = "BInitials"
        Me.BInitials.Size = New System.Drawing.Size(116, 22)
        Me.BInitials.TabIndex = 11
        '
        'BNum
        '
        Me.BNum.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BNum.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BNum.Location = New System.Drawing.Point(661, 483)
        Me.BNum.MaxLength = 32
        Me.BNum.Name = "BNum"
        Me.BNum.Size = New System.Drawing.Size(116, 22)
        Me.BNum.TabIndex = 12
        '
        'LR_Pitch
        '
        Me.LR_Pitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LR_Pitch.FormattingEnabled = True
        Me.LR_Pitch.Items.AddRange(New Object() {"Left", "Right"})
        Me.LR_Pitch.Location = New System.Drawing.Point(460, 484)
        Me.LR_Pitch.Name = "LR_Pitch"
        Me.LR_Pitch.Size = New System.Drawing.Size(65, 21)
        Me.LR_Pitch.TabIndex = 26
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(369, 484)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(84, 19)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Side Pitch :"
        '
        'FB_Pitch
        '
        Me.FB_Pitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FB_Pitch.FormattingEnabled = True
        Me.FB_Pitch.Items.AddRange(New Object() {"FWD", "BK"})
        Me.FB_Pitch.Location = New System.Drawing.Point(345, 399)
        Me.FB_Pitch.Name = "FB_Pitch"
        Me.FB_Pitch.Size = New System.Drawing.Size(64, 21)
        Me.FB_Pitch.TabIndex = 27
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(353, 352)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(43, 19)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Pitch"
        '
        'Slug
        '
        Me.Slug.AutoSize = True
        Me.Slug.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Slug.Font = New System.Drawing.Font("Cambria", 12.0!)
        Me.Slug.Location = New System.Drawing.Point(541, 366)
        Me.Slug.Name = "Slug"
        Me.Slug.Size = New System.Drawing.Size(42, 37)
        Me.Slug.TabIndex = 25
        Me.Slug.Text = "Slug"
        Me.Slug.UseVisualStyleBackColor = True
        '
        'Grips
        '
        Me.Grips.AutoSize = True
        Me.Grips.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Grips.Font = New System.Drawing.Font("Cambria", 12.0!)
        Me.Grips.Location = New System.Drawing.Point(590, 230)
        Me.Grips.Name = "Grips"
        Me.Grips.Size = New System.Drawing.Size(50, 37)
        Me.Grips.TabIndex = 24
        Me.Grips.Text = "Grips"
        Me.Grips.UseVisualStyleBackColor = True
        '
        'TPitch
        '
        Me.TPitch.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TPitch.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPitch.Location = New System.Drawing.Point(460, 456)
        Me.TPitch.MaxLength = 8
        Me.TPitch.Name = "TPitch"
        Me.TPitch.Size = New System.Drawing.Size(65, 22)
        Me.TPitch.TabIndex = 22
        Me.TPitch.Text = "0"
        Me.TPitch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TSidePitch
        '
        Me.TSidePitch.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TSidePitch.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSidePitch.Location = New System.Drawing.Point(345, 374)
        Me.TSidePitch.MaxLength = 8
        Me.TSidePitch.Name = "TSidePitch"
        Me.TSidePitch.Size = New System.Drawing.Size(65, 22)
        Me.TSidePitch.TabIndex = 21
        Me.TSidePitch.Text = "0"
        Me.TSidePitch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(427, 138)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(54, 19)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Hand :"
        '
        'Hand
        '
        Me.Hand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Hand.FormattingEnabled = True
        Me.Hand.Items.AddRange(New Object() {"Left", "Right"})
        Me.Hand.Location = New System.Drawing.Point(482, 138)
        Me.Hand.Name = "Hand"
        Me.Hand.Size = New System.Drawing.Size(64, 21)
        Me.Hand.TabIndex = 29
        '
        'MTSpan
        '
        Me.MTSpan.BackColor = System.Drawing.Color.WhiteSmoke
        Me.MTSpan.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MTSpan.Location = New System.Drawing.Point(443, 298)
        Me.MTSpan.MaxLength = 8
        Me.MTSpan.Name = "MTSpan"
        Me.MTSpan.Size = New System.Drawing.Size(50, 22)
        Me.MTSpan.TabIndex = 14
        Me.MTSpan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RTSpan
        '
        Me.RTSpan.BackColor = System.Drawing.Color.WhiteSmoke
        Me.RTSpan.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RTSpan.Location = New System.Drawing.Point(499, 298)
        Me.RTSpan.MaxLength = 8
        Me.RTSpan.Name = "RTSpan"
        Me.RTSpan.Size = New System.Drawing.Size(50, 22)
        Me.RTSpan.TabIndex = 15
        Me.RTSpan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MRSpan
        '
        Me.MRSpan.BackColor = System.Drawing.Color.WhiteSmoke
        Me.MRSpan.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MRSpan.Location = New System.Drawing.Point(471, 167)
        Me.MRSpan.MaxLength = 8
        Me.MRSpan.Name = "MRSpan"
        Me.MRSpan.Size = New System.Drawing.Size(50, 22)
        Me.MRSpan.TabIndex = 13
        Me.MRSpan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MPitch
        '
        Me.MPitch.BackColor = System.Drawing.Color.WhiteSmoke
        Me.MPitch.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MPitch.Location = New System.Drawing.Point(371, 167)
        Me.MPitch.MaxLength = 8
        Me.MPitch.Name = "MPitch"
        Me.MPitch.Size = New System.Drawing.Size(50, 22)
        Me.MPitch.TabIndex = 19
        Me.MPitch.Text = "0"
        Me.MPitch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RPitch
        '
        Me.RPitch.BackColor = System.Drawing.Color.WhiteSmoke
        Me.RPitch.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RPitch.Location = New System.Drawing.Point(568, 167)
        Me.RPitch.MaxLength = 8
        Me.RPitch.Name = "RPitch"
        Me.RPitch.Size = New System.Drawing.Size(50, 22)
        Me.RPitch.TabIndex = 20
        Me.RPitch.Text = "0"
        Me.RPitch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(363, 192)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(43, 19)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Pitch"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(578, 192)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(43, 19)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Pitch"
        '
        'MSize
        '
        Me.MSize.BackColor = System.Drawing.Color.WhiteSmoke
        Me.MSize.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MSize.Location = New System.Drawing.Point(422, 223)
        Me.MSize.MaxLength = 8
        Me.MSize.Name = "MSize"
        Me.MSize.Size = New System.Drawing.Size(50, 22)
        Me.MSize.TabIndex = 16
        Me.MSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RSize
        '
        Me.RSize.BackColor = System.Drawing.Color.WhiteSmoke
        Me.RSize.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RSize.Location = New System.Drawing.Point(520, 223)
        Me.RSize.MaxLength = 8
        Me.RSize.Name = "RSize"
        Me.RSize.Size = New System.Drawing.Size(50, 22)
        Me.RSize.TabIndex = 17
        Me.RSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TSize
        '
        Me.TSize.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TSize.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSize.Location = New System.Drawing.Point(471, 374)
        Me.TSize.MaxLength = 8
        Me.TSize.Name = "TSize"
        Me.TSize.Size = New System.Drawing.Size(50, 22)
        Me.TSize.TabIndex = 18
        Me.TSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(325, 230)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(71, 19)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Fingered"
        '
        'Fingered
        '
        Me.Fingered.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Fingered.FormattingEnabled = True
        Me.Fingered.Items.AddRange(New Object() {"No", "Yes"})
        Me.Fingered.Location = New System.Drawing.Point(329, 252)
        Me.Fingered.Name = "Fingered"
        Me.Fingered.Size = New System.Drawing.Size(64, 21)
        Me.Fingered.TabIndex = 23
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.MPS.My.Resources.Resources.Grips
        Me.PictureBox2.Location = New System.Drawing.Point(582, 285)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(60, 64)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 22
        Me.PictureBox2.TabStop = False
        '
        'Pic_Location
        '
        Me.Pic_Location.BackColor = System.Drawing.Color.Transparent
        Me.Pic_Location.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Pic_Location.Location = New System.Drawing.Point(5, 185)
        Me.Pic_Location.Name = "Pic_Location"
        Me.Pic_Location.Size = New System.Drawing.Size(300, 200)
        Me.Pic_Location.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Pic_Location.TabIndex = 2
        Me.Pic_Location.TabStop = False
        '
        'Logo
        '
        Me.Logo.BackColor = System.Drawing.Color.Transparent
        Me.Logo.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Logo.Location = New System.Drawing.Point(5, 10)
        Me.Logo.Name = "Logo"
        Me.Logo.Size = New System.Drawing.Size(300, 136)
        Me.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Logo.TabIndex = 1
        Me.Logo.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.MPS.My.Resources.Resources.Layout
        Me.PictureBox1.Location = New System.Drawing.Point(371, 162)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(243, 288)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(620, 97)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(74, 19)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "Form ID :"
        '
        'FID
        '
        Me.FID.BackColor = System.Drawing.Color.WhiteSmoke
        Me.FID.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.FID.Location = New System.Drawing.Point(692, 97)
        Me.FID.Name = "FID"
        Me.FID.Size = New System.Drawing.Size(89, 22)
        Me.FID.TabIndex = 0
        Me.FID.TabStop = False
        '
        'CID
        '
        Me.CID.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CID.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.CID.Location = New System.Drawing.Point(551, 97)
        Me.CID.Name = "CID"
        Me.CID.Size = New System.Drawing.Size(70, 22)
        Me.CID.TabIndex = 0
        Me.CID.TabStop = False
        '
        'Choices
        '
        Me.Choices.BackColor = System.Drawing.Color.SpringGreen
        Me.Choices.Enabled = False
        Me.Choices.Font = New System.Drawing.Font("Cambria", 12.0!)
        Me.Choices.Location = New System.Drawing.Point(556, 454)
        Me.Choices.Name = "Choices"
        Me.Choices.Size = New System.Drawing.Size(91, 27)
        Me.Choices.TabIndex = 30
        Me.Choices.Text = "New User"
        Me.Choices.UseVisualStyleBackColor = False
        '
        'NForm
        '
        Me.NForm.BackColor = System.Drawing.Color.SpringGreen
        Me.NForm.Font = New System.Drawing.Font("Cambria", 12.0!)
        Me.NForm.Location = New System.Drawing.Point(556, 481)
        Me.NForm.Name = "NForm"
        Me.NForm.Size = New System.Drawing.Size(91, 27)
        Me.NForm.TabIndex = 31
        Me.NForm.Text = "New Form"
        Me.NForm.UseVisualStyleBackColor = False
        '
        'Drill_Sheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkCyan
        Me.Controls.Add(Me.NForm)
        Me.Controls.Add(Me.Choices)
        Me.Controls.Add(Me.CID)
        Me.Controls.Add(Me.FID)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Grips)
        Me.Controls.Add(Me.Slug)
        Me.Controls.Add(Me.Fingered)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.TSize)
        Me.Controls.Add(Me.RSize)
        Me.Controls.Add(Me.MSize)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.RPitch)
        Me.Controls.Add(Me.MPitch)
        Me.Controls.Add(Me.MRSpan)
        Me.Controls.Add(Me.RTSpan)
        Me.Controls.Add(Me.MTSpan)
        Me.Controls.Add(Me.Hand)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.TSidePitch)
        Me.Controls.Add(Me.TPitch)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.FB_Pitch)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.LR_Pitch)
        Me.Controls.Add(Me.BNum)
        Me.Controls.Add(Me.BInitials)
        Me.Controls.Add(Me.BWeight)
        Me.Controls.Add(Me.BColor)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Special_Txt)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Layout_Type)
        Me.Controls.Add(Me.Drill_Type)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DateD)
        Me.Controls.Add(Me.Label8)
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
        Me.Controls.Add(Me.Comments)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Pic_Location)
        Me.Controls.Add(Me.txt_phone)
        Me.Controls.Add(Me.Logo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Drill_Sheet"
        Me.Size = New System.Drawing.Size(784, 515)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Location, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Logo As System.Windows.Forms.PictureBox
    Friend WithEvents txt_phone As System.Windows.Forms.Label
    Friend WithEvents Pic_Location As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Comments As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Street As System.Windows.Forms.TextBox
    Friend WithEvents City As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Phone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents State As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Zip As System.Windows.Forms.MaskedTextBox
    Friend WithEvents BName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DateD As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Drill_Type As System.Windows.Forms.ComboBox
    Friend WithEvents Layout_Type As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Special_Txt As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents BColor As System.Windows.Forms.TextBox
    Friend WithEvents BWeight As System.Windows.Forms.TextBox
    Friend WithEvents BInitials As System.Windows.Forms.TextBox
    Friend WithEvents BNum As System.Windows.Forms.TextBox
    Friend WithEvents LR_Pitch As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents FB_Pitch As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Slug As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Grips As System.Windows.Forms.CheckBox
    Friend WithEvents TPitch As System.Windows.Forms.TextBox
    Friend WithEvents TSidePitch As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Hand As System.Windows.Forms.ComboBox
    Friend WithEvents MTSpan As System.Windows.Forms.TextBox
    Friend WithEvents RTSpan As System.Windows.Forms.TextBox
    Friend WithEvents MRSpan As System.Windows.Forms.TextBox
    Friend WithEvents MPitch As System.Windows.Forms.TextBox
    Friend WithEvents RPitch As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents MSize As System.Windows.Forms.TextBox
    Friend WithEvents RSize As System.Windows.Forms.TextBox
    Friend WithEvents TSize As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Fingered As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents FID As System.Windows.Forms.NumericUpDown
    Friend WithEvents CID As System.Windows.Forms.NumericUpDown
    Friend WithEvents Choices As System.Windows.Forms.Button
    Friend WithEvents NForm As System.Windows.Forms.Button

End Class
