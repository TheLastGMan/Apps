<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class League_Remove
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
        Me.LeagueBox = New System.Windows.Forms.ComboBox
        Me.Remove_League = New System.Windows.Forms.Button
        Me.LeagueTableAdapter = New PBC_Manager.PBCDataSetTableAdapters.LeagueTableAdapter
        Me.SuspendLayout()
        '
        'LeagueBox
        '
        Me.LeagueBox.DisplayMember = "League_Name"
        Me.LeagueBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LeagueBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LeagueBox.FormattingEnabled = True
        Me.LeagueBox.ItemHeight = 25
        Me.LeagueBox.Location = New System.Drawing.Point(167, 45)
        Me.LeagueBox.MaxDropDownItems = 10
        Me.LeagueBox.Name = "LeagueBox"
        Me.LeagueBox.Size = New System.Drawing.Size(450, 33)
        Me.LeagueBox.TabIndex = 1
        Me.LeagueBox.ValueMember = "League_Name"
        '
        'Remove_League
        '
        Me.Remove_League.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Remove_League.Font = New System.Drawing.Font("Cambria", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Remove_League.Location = New System.Drawing.Point(222, 371)
        Me.Remove_League.Name = "Remove_League"
        Me.Remove_League.Size = New System.Drawing.Size(340, 60)
        Me.Remove_League.TabIndex = 2
        Me.Remove_League.Text = "Remove League"
        Me.Remove_League.UseVisualStyleBackColor = False
        '
        'LeagueTableAdapter
        '
        Me.LeagueTableAdapter.ClearBeforeFill = True
        '
        'League_Remove
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Remove_League)
        Me.Controls.Add(Me.LeagueBox)
        Me.Name = "League_Remove"
        Me.Size = New System.Drawing.Size(784, 470)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LeagueBox As System.Windows.Forms.ComboBox
    Friend WithEvents Remove_League As System.Windows.Forms.Button
    Friend WithEvents LeagueTableAdapter As PBC_Manager.PBCDataSetTableAdapters.LeagueTableAdapter

End Class
