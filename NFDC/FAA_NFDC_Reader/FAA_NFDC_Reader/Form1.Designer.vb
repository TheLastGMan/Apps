<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Parse_AFD = New System.Windows.Forms.Button()
        Me.BrowseBox = New System.Windows.Forms.TextBox()
        Me.BrowseBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ProgressLbl = New System.Windows.Forms.Label()
        Me.FileProgressLbl = New System.Windows.Forms.Label()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'Parse_AFD
        '
        Me.Parse_AFD.Location = New System.Drawing.Point(12, 57)
        Me.Parse_AFD.Name = "Parse_AFD"
        Me.Parse_AFD.Size = New System.Drawing.Size(260, 40)
        Me.Parse_AFD.TabIndex = 0
        Me.Parse_AFD.Text = "Parse AFD"
        Me.Parse_AFD.UseVisualStyleBackColor = True
        '
        'BrowseBox
        '
        Me.BrowseBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.BrowseBox.Location = New System.Drawing.Point(15, 31)
        Me.BrowseBox.Name = "BrowseBox"
        Me.BrowseBox.Size = New System.Drawing.Size(155, 20)
        Me.BrowseBox.TabIndex = 1
        '
        'BrowseBtn
        '
        Me.BrowseBtn.Location = New System.Drawing.Point(176, 31)
        Me.BrowseBtn.Name = "BrowseBtn"
        Me.BrowseBtn.Size = New System.Drawing.Size(96, 22)
        Me.BrowseBtn.TabIndex = 2
        Me.BrowseBtn.Text = "Browse"
        Me.BrowseBtn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(260, 19)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "AFD Location"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.ShowNewFolderButton = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(15, 183)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(257, 23)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 4
        '
        'ProgressLbl
        '
        Me.ProgressLbl.Location = New System.Drawing.Point(12, 165)
        Me.ProgressLbl.Name = "ProgressLbl"
        Me.ProgressLbl.Size = New System.Drawing.Size(260, 15)
        Me.ProgressLbl.TabIndex = 5
        Me.ProgressLbl.Text = "[progress]"
        Me.ProgressLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FileProgressLbl
        '
        Me.FileProgressLbl.Location = New System.Drawing.Point(12, 209)
        Me.FileProgressLbl.Name = "FileProgressLbl"
        Me.FileProgressLbl.Size = New System.Drawing.Size(260, 15)
        Me.FileProgressLbl.TabIndex = 7
        Me.FileProgressLbl.Text = "[progress]"
        Me.FileProgressLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(15, 227)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(257, 23)
        Me.ProgressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar2.TabIndex = 6
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.FileProgressLbl)
        Me.Controls.Add(Me.ProgressBar2)
        Me.Controls.Add(Me.ProgressLbl)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BrowseBtn)
        Me.Controls.Add(Me.BrowseBox)
        Me.Controls.Add(Me.Parse_AFD)
        Me.Name = "Form1"
        Me.Text = "E"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Parse_AFD As System.Windows.Forms.Button
    Friend WithEvents BrowseBox As System.Windows.Forms.TextBox
    Friend WithEvents BrowseBtn As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressLbl As System.Windows.Forms.Label
    Friend WithEvents FileProgressLbl As System.Windows.Forms.Label
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar

End Class
