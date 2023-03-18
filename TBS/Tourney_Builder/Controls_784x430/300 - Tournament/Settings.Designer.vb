<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TOF = New System.Windows.Forms.ComboBox()
        Me.AssName = New System.Windows.Forms.TextBox()
        Me.AssNameTxt = New System.Windows.Forms.Label()
        Me.RootNS = New System.Windows.Forms.Label()
        Me.NmSpace = New System.Windows.Forms.TextBox()
        Me.AER = New System.Windows.Forms.Button()
        Me.DER = New System.Windows.Forms.Button()
        Me.FR = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LeagueName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DisplayName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Lucida Sans", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(277, 155)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(239, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "External File Additions"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Lucida Sans", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(282, 179)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(224, 22)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "(Advanced User Only)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Lucida Sans", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(28, 225)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Reference Type :"
        '
        'TOF
        '
        Me.TOF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TOF.Font = New System.Drawing.Font("Lucida Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOF.FormattingEnabled = True
        Me.TOF.Items.AddRange(New Object() {"Report", "Tournament"})
        Me.TOF.Location = New System.Drawing.Point(177, 222)
        Me.TOF.Name = "TOF"
        Me.TOF.Size = New System.Drawing.Size(233, 26)
        Me.TOF.TabIndex = 3
        '
        'AssName
        '
        Me.AssName.Font = New System.Drawing.Font("Lucida Sans", 14.25!)
        Me.AssName.Location = New System.Drawing.Point(177, 290)
        Me.AssName.Name = "AssName"
        Me.AssName.Size = New System.Drawing.Size(233, 30)
        Me.AssName.TabIndex = 5
        '
        'AssNameTxt
        '
        Me.AssNameTxt.AutoSize = True
        Me.AssNameTxt.Font = New System.Drawing.Font("Lucida Sans", 12.0!, System.Drawing.FontStyle.Bold)
        Me.AssNameTxt.Location = New System.Drawing.Point(31, 296)
        Me.AssNameTxt.Name = "AssNameTxt"
        Me.AssNameTxt.Size = New System.Drawing.Size(141, 18)
        Me.AssNameTxt.TabIndex = 5
        Me.AssNameTxt.Text = "Assembly Class :"
        '
        'RootNS
        '
        Me.RootNS.AutoSize = True
        Me.RootNS.Font = New System.Drawing.Font("Lucida Sans", 12.0!, System.Drawing.FontStyle.Bold)
        Me.RootNS.Location = New System.Drawing.Point(14, 332)
        Me.RootNS.Name = "RootNS"
        Me.RootNS.Size = New System.Drawing.Size(158, 18)
        Me.RootNS.TabIndex = 6
        Me.RootNS.Text = "Root Namespace :"
        '
        'NmSpace
        '
        Me.NmSpace.Font = New System.Drawing.Font("Lucida Sans", 14.25!)
        Me.NmSpace.Location = New System.Drawing.Point(177, 326)
        Me.NmSpace.Name = "NmSpace"
        Me.NmSpace.Size = New System.Drawing.Size(233, 30)
        Me.NmSpace.TabIndex = 6
        '
        'AER
        '
        Me.AER.BackColor = System.Drawing.Color.ForestGreen
        Me.AER.Font = New System.Drawing.Font("Lucida Sans", 12.0!, System.Drawing.FontStyle.Bold)
        Me.AER.Location = New System.Drawing.Point(144, 362)
        Me.AER.Name = "AER"
        Me.AER.Size = New System.Drawing.Size(181, 54)
        Me.AER.TabIndex = 8
        Me.AER.Text = "Add External Reference"
        Me.AER.UseVisualStyleBackColor = False
        '
        'DER
        '
        Me.DER.BackColor = System.Drawing.Color.Firebrick
        Me.DER.Font = New System.Drawing.Font("Lucida Sans", 12.0!, System.Drawing.FontStyle.Bold)
        Me.DER.Location = New System.Drawing.Point(505, 362)
        Me.DER.Name = "DER"
        Me.DER.Size = New System.Drawing.Size(181, 54)
        Me.DER.TabIndex = 9
        Me.DER.Text = "Delete External Reference"
        Me.DER.UseVisualStyleBackColor = False
        '
        'FR
        '
        Me.FR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FR.Font = New System.Drawing.Font("Lucida Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FR.FormattingEnabled = True
        Me.FR.Location = New System.Drawing.Point(479, 304)
        Me.FR.Name = "FR"
        Me.FR.Size = New System.Drawing.Size(233, 26)
        Me.FR.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Lucida Sans", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(530, 282)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 18)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "File Reference :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Lucida Sans", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(320, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 22)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "League Name"
        '
        'LeagueName
        '
        Me.LeagueName.Font = New System.Drawing.Font("Lucida Sans", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LeagueName.Location = New System.Drawing.Point(203, 33)
        Me.LeagueName.MaxLength = 15
        Me.LeagueName.Name = "LeagueName"
        Me.LeagueName.Size = New System.Drawing.Size(374, 30)
        Me.LeagueName.TabIndex = 13
        Me.LeagueName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Lucida Sans", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(44, 260)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 18)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Display Name :"
        '
        'DisplayName
        '
        Me.DisplayName.Font = New System.Drawing.Font("Lucida Sans", 14.25!)
        Me.DisplayName.Location = New System.Drawing.Point(177, 254)
        Me.DisplayName.Name = "DisplayName"
        Me.DisplayName.Size = New System.Drawing.Size(233, 30)
        Me.DisplayName.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(339, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 15)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "15 Character Max"
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DisplayName)
        Me.Controls.Add(Me.LeagueName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.FR)
        Me.Controls.Add(Me.DER)
        Me.Controls.Add(Me.AER)
        Me.Controls.Add(Me.NmSpace)
        Me.Controls.Add(Me.RootNS)
        Me.Controls.Add(Me.AssNameTxt)
        Me.Controls.Add(Me.AssName)
        Me.Controls.Add(Me.TOF)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Settings"
        Me.Size = New System.Drawing.Size(784, 430)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TOF As System.Windows.Forms.ComboBox
    Friend WithEvents AssName As System.Windows.Forms.TextBox
    Friend WithEvents AssNameTxt As System.Windows.Forms.Label
    Friend WithEvents RootNS As System.Windows.Forms.Label
    Friend WithEvents NmSpace As System.Windows.Forms.TextBox
    Friend WithEvents AER As System.Windows.Forms.Button
    Friend WithEvents DER As System.Windows.Forms.Button
    Friend WithEvents FR As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LeagueName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DisplayName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
