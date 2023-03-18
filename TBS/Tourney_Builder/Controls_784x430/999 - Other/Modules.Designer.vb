<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Modules
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ModName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Typex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsInstalled = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DownUninstall = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.FileReference = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AssemblyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.typeh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fileurl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Cambria", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeight = 75
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ModName, Me.Typex, Me.IsInstalled, Me.DownUninstall, Me.FileReference, Me.AssemblyName, Me.typeh, Me.fileurl})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Cambria", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DataGridView1.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Cambria", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.RowTemplate.ReadOnly = True
        Me.DataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.ShowCellErrors = False
        Me.DataGridView1.ShowCellToolTips = False
        Me.DataGridView1.ShowEditingIcon = False
        Me.DataGridView1.ShowRowErrors = False
        Me.DataGridView1.Size = New System.Drawing.Size(784, 657)
        Me.DataGridView1.TabIndex = 0
        '
        'ModName
        '
        Me.ModName.Frozen = True
        Me.ModName.HeaderText = "Module Name"
        Me.ModName.Name = "ModName"
        Me.ModName.ReadOnly = True
        Me.ModName.Width = 300
        '
        'Typex
        '
        Me.Typex.Frozen = True
        Me.Typex.HeaderText = "Type"
        Me.Typex.Name = "Typex"
        Me.Typex.ReadOnly = True
        Me.Typex.Width = 200
        '
        'IsInstalled
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.IsInstalled.DefaultCellStyle = DataGridViewCellStyle2
        Me.IsInstalled.Frozen = True
        Me.IsInstalled.HeaderText = "Loaded"
        Me.IsInstalled.Name = "IsInstalled"
        Me.IsInstalled.ReadOnly = True
        '
        'DownUninstall
        '
        Me.DownUninstall.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DownUninstall.Frozen = True
        Me.DownUninstall.HeaderText = "Install / Uninstall"
        Me.DownUninstall.Name = "DownUninstall"
        Me.DownUninstall.ReadOnly = True
        Me.DownUninstall.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DownUninstall.Width = 184
        '
        'FileReference
        '
        Me.FileReference.Frozen = True
        Me.FileReference.HeaderText = "FileReference"
        Me.FileReference.Name = "FileReference"
        Me.FileReference.ReadOnly = True
        Me.FileReference.Visible = False
        '
        'AssemblyName
        '
        Me.AssemblyName.Frozen = True
        Me.AssemblyName.HeaderText = "Assembly Name"
        Me.AssemblyName.Name = "AssemblyName"
        Me.AssemblyName.ReadOnly = True
        Me.AssemblyName.Visible = False
        '
        'typeh
        '
        Me.typeh.Frozen = True
        Me.typeh.HeaderText = "typeh"
        Me.typeh.Name = "typeh"
        Me.typeh.ReadOnly = True
        Me.typeh.Visible = False
        '
        'fileurl
        '
        Me.fileurl.HeaderText = "fileurl"
        Me.fileurl.Name = "fileurl"
        Me.fileurl.ReadOnly = True
        Me.fileurl.Visible = False
        '
        'Modules
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Modules"
        Me.Size = New System.Drawing.Size(784, 657)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ModName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Typex As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsInstalled As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DownUninstall As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents FileReference As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssemblyName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents typeh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fileurl As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
