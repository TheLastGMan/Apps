<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Teams_View
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
        Me.League_Grid = New System.Windows.Forms.DataGridView
        Me.TeamsTableAdapter = New PBC_Manager.PBCDataSetTableAdapters.TeamsTableAdapter
        CType(Me.League_Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'League_Grid
        '
        Me.League_Grid.AllowUserToAddRows = False
        Me.League_Grid.AllowUserToDeleteRows = False
        Me.League_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.League_Grid.Location = New System.Drawing.Point(71, 85)
        Me.League_Grid.Name = "League_Grid"
        Me.League_Grid.ReadOnly = True
        Me.League_Grid.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.League_Grid.RowTemplate.Height = 30
        Me.League_Grid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.League_Grid.Size = New System.Drawing.Size(642, 300)
        Me.League_Grid.TabIndex = 1
        '
        'TeamsTableAdapter
        '
        Me.TeamsTableAdapter.ClearBeforeFill = True
        '
        'Teams_View
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.League_Grid)
        Me.Name = "Teams_View"
        Me.Size = New System.Drawing.Size(784, 470)
        CType(Me.League_Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents League_Grid As System.Windows.Forms.DataGridView
    Friend WithEvents TeamsTableAdapter As PBC_Manager.PBCDataSetTableAdapters.TeamsTableAdapter

End Class
