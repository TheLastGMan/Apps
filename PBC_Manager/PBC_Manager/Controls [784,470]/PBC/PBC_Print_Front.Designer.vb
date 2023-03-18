<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PBC_Print_Front
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
        Me.PBC_Print = New Microsoft.Reporting.WinForms.ReportViewer
        Me.DateTime = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.PB_CardsTableAdapter = New PBC_Manager.PBCDataSetTableAdapters.PB_CardsTableAdapter
        Me.SuspendLayout()
        '
        'PBC_Print
        '
        Me.PBC_Print.Location = New System.Drawing.Point(0, 42)
        Me.PBC_Print.Name = "PBC_Print"
        Me.PBC_Print.ShowBackButton = False
        Me.PBC_Print.ShowContextMenu = False
        Me.PBC_Print.ShowCredentialPrompts = False
        Me.PBC_Print.ShowDocumentMapButton = False
        Me.PBC_Print.ShowFindControls = False
        Me.PBC_Print.ShowPageNavigationControls = False
        Me.PBC_Print.ShowParameterPrompts = False
        Me.PBC_Print.ShowPromptAreaButton = False
        Me.PBC_Print.ShowRefreshButton = False
        Me.PBC_Print.ShowStopButton = False
        Me.PBC_Print.Size = New System.Drawing.Size(784, 428)
        Me.PBC_Print.TabIndex = 3
        '
        'DateTime
        '
        Me.DateTime.CustomFormat = "MMM dd, yyyy"
        Me.DateTime.Font = New System.Drawing.Font("Cambria", 14.25!)
        Me.DateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTime.Location = New System.Drawing.Point(382, 5)
        Me.DateTime.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        Me.DateTime.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.DateTime.Name = "DateTime"
        Me.DateTime.Size = New System.Drawing.Size(158, 30)
        Me.DateTime.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 14.25!)
        Me.Label1.Location = New System.Drawing.Point(230, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Expiration Date :"
        '
        'PB_CardsTableAdapter
        '
        Me.PB_CardsTableAdapter.ClearBeforeFill = True
        '
        'PBC_Print_Front
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTime)
        Me.Controls.Add(Me.PBC_Print)
        Me.Name = "PBC_Print_Front"
        Me.Size = New System.Drawing.Size(784, 470)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PBC_Print As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PB_CardsTableAdapter As PBC_Manager.PBCDataSetTableAdapters.PB_CardsTableAdapter

End Class
