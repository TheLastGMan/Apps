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
        Me.From1 = New System.Windows.Forms.TextBox
        Me.To1 = New System.Windows.Forms.TextBox
        Me.Subject1 = New System.Windows.Forms.TextBox
        Me.Cc1 = New System.Windows.Forms.TextBox
        Me.Message1 = New System.Windows.Forms.TextBox
        Me.Send1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtCnt = New System.Windows.Forms.NumericUpDown
        CType(Me.TxtCnt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'From1
        '
        Me.From1.Location = New System.Drawing.Point(70, 12)
        Me.From1.Name = "From1"
        Me.From1.Size = New System.Drawing.Size(542, 20)
        Me.From1.TabIndex = 0
        '
        'To1
        '
        Me.To1.Location = New System.Drawing.Point(70, 38)
        Me.To1.Name = "To1"
        Me.To1.Size = New System.Drawing.Size(542, 20)
        Me.To1.TabIndex = 1
        '
        'Subject1
        '
        Me.Subject1.Location = New System.Drawing.Point(70, 64)
        Me.Subject1.Name = "Subject1"
        Me.Subject1.Size = New System.Drawing.Size(542, 20)
        Me.Subject1.TabIndex = 2
        '
        'Cc1
        '
        Me.Cc1.Location = New System.Drawing.Point(70, 90)
        Me.Cc1.Name = "Cc1"
        Me.Cc1.Size = New System.Drawing.Size(542, 20)
        Me.Cc1.TabIndex = 3
        '
        'Message1
        '
        Me.Message1.Location = New System.Drawing.Point(12, 116)
        Me.Message1.MaxLength = 160
        Me.Message1.Multiline = True
        Me.Message1.Name = "Message1"
        Me.Message1.Size = New System.Drawing.Size(600, 285)
        Me.Message1.TabIndex = 4
        '
        'Send1
        '
        Me.Send1.Location = New System.Drawing.Point(245, 407)
        Me.Send1.Name = "Send1"
        Me.Send1.Size = New System.Drawing.Size(135, 34)
        Me.Send1.TabIndex = 5
        Me.Send1.Text = "&Send Email"
        Me.Send1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "From:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "To:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Subject:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(42, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "cc:"
        '
        'TxtCnt
        '
        Me.TxtCnt.Location = New System.Drawing.Point(429, 416)
        Me.TxtCnt.Maximum = New Decimal(New Integer() {160, 0, 0, 0})
        Me.TxtCnt.Name = "TxtCnt"
        Me.TxtCnt.ReadOnly = True
        Me.TxtCnt.Size = New System.Drawing.Size(87, 20)
        Me.TxtCnt.TabIndex = 0
        Me.TxtCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtCnt.Value = New Decimal(New Integer() {160, 0, 0, 0})
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 444)
        Me.Controls.Add(Me.TxtCnt)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Send1)
        Me.Controls.Add(Me.Message1)
        Me.Controls.Add(Me.Cc1)
        Me.Controls.Add(Me.Subject1)
        Me.Controls.Add(Me.To1)
        Me.Controls.Add(Me.From1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.TxtCnt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents From1 As System.Windows.Forms.TextBox
    Friend WithEvents To1 As System.Windows.Forms.TextBox
    Friend WithEvents Subject1 As System.Windows.Forms.TextBox
    Friend WithEvents Cc1 As System.Windows.Forms.TextBox
    Friend WithEvents Message1 As System.Windows.Forms.TextBox
    Friend WithEvents Send1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtCnt As System.Windows.Forms.NumericUpDown

End Class
