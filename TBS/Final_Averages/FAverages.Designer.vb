<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FAverages
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DBFAverages = New Reports.Final_Averages.DBFAverages()
        Me.FAveragesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DBFAverages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FAveragesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "FAVEset"
        ReportDataSource1.Value = Me.FAveragesBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Final_Averages.Fin_Aves.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ShowBackButton = False
        Me.ReportViewer1.ShowContextMenu = False
        Me.ReportViewer1.ShowCredentialPrompts = False
        Me.ReportViewer1.ShowDocumentMapButton = False
        Me.ReportViewer1.ShowFindControls = False
        Me.ReportViewer1.ShowParameterPrompts = False
        Me.ReportViewer1.ShowPromptAreaButton = False
        Me.ReportViewer1.Size = New System.Drawing.Size(784, 430)
        Me.ReportViewer1.TabIndex = 0
        Me.ReportViewer1.ZoomPercent = 75
        '
        'DBFAverages
        '
        Me.DBFAverages.DataSetName = "DBFAverages"
        Me.DBFAverages.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FAveragesBindingSource
        '
        Me.FAveragesBindingSource.DataMember = "FAverages"
        Me.FAveragesBindingSource.DataSource = Me.DBFAverages
        '
        'FAverages
        '
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "FAverages"
        Me.Size = New System.Drawing.Size(784, 430)
        CType(Me.DBFAverages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FAveragesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents FAveragesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DBFAverages As Reports.Final_Averages.DBFAverages

End Class
