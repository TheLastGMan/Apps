<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BHistory
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
        Me.Bowler_Name = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.BowlHist = New Reports.Bowler_History.BowlHist()
        Me.HistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.BowlHist, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bowler_Name
        '
        Me.Bowler_Name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Bowler_Name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.Bowler_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.Bowler_Name.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bowler_Name.FormattingEnabled = True
        Me.Bowler_Name.Location = New System.Drawing.Point(317, 3)
        Me.Bowler_Name.Name = "Bowler_Name"
        Me.Bowler_Name.Size = New System.Drawing.Size(300, 30)
        Me.Bowler_Name.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(167, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 25)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Bowler Name :"
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "BHist"
        ReportDataSource1.Value = Me.HistoryBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Bowler_History.Bowler_History.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 40)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ShowBackButton = False
        Me.ReportViewer1.ShowContextMenu = False
        Me.ReportViewer1.ShowCredentialPrompts = False
        Me.ReportViewer1.ShowDocumentMapButton = False
        Me.ReportViewer1.ShowFindControls = False
        Me.ReportViewer1.ShowParameterPrompts = False
        Me.ReportViewer1.ShowPromptAreaButton = False
        Me.ReportViewer1.Size = New System.Drawing.Size(784, 390)
        Me.ReportViewer1.TabIndex = 4
        Me.ReportViewer1.ZoomPercent = 75
        '
        'BowlHist
        '
        Me.BowlHist.DataSetName = "BowlHist"
        Me.BowlHist.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'HistoryBindingSource
        '
        Me.HistoryBindingSource.DataMember = "History"
        Me.HistoryBindingSource.DataSource = Me.BowlHist
        '
        'BHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.Bowler_Name)
        Me.Controls.Add(Me.Label2)
        Me.Name = "BHistory"
        Me.Size = New System.Drawing.Size(784, 430)
        CType(Me.BowlHist, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Bowler_Name As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents HistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BowlHist As Reports.Bowler_History.BowlHist

End Class
