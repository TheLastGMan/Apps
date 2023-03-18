Public Class BarCode_Checker

    Private Sub BarCode_Checker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.Gen.Change_Header(Me.Name)
        BC.Focus.Equals(True)
    End Sub

    Private Sub Generate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Generate.Click
        Draw_BC()
        BC_Chk.Focus()
    End Sub

    Private Sub BC_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BC.KeyDown
        If e.KeyCode = Keys.Enter Then
            Draw_BC()
            BC_Chk.Focus.Equals(True)
        End If
        'Private Sub Keyboard(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        '    'MsgBox("KeyPress")
        'End Sub
    End Sub

    Private Sub Draw_BC()
        Dim bar As New BarCode
        Dim tf As Boolean = True
        PictureBox1.ResetText()
        If BC.Text.Length = 6 Then
            bar.EAN13_Draw(BC.Text, PictureBox1)
            Dim Font = New Font("Courier New", 32)
            Dim strFormat As New StringFormat
            'Width of 7
            '  0px to Start White
            ' 49px to Fist Long
            ' 70px to First Short
            '364px to Start Mid Sect
            '399px to Start 2nd Short
            '693px to Start End Row
            '714px to Start White Space
            strFormat.Alignment = StringAlignment.Center
            strFormat.FormatFlags = StringFormatFlags.NoWrap
            PictureBox1.CreateGraphics.DrawString(bar.EAN13_Code.ToString().Substring(0, 1), Font, New System.Drawing.SolidBrush(Color.Black), 25, PictureBox1.Height - 60, strFormat)
            PictureBox1.CreateGraphics.DrawString(bar.EAN13_Code.ToString().Substring(1, 6), Font, New System.Drawing.SolidBrush(Color.Black), 222, PictureBox1.Height - 60, strFormat)
            PictureBox1.CreateGraphics.DrawString(bar.EAN13_Code.ToString().Substring(7, 6), Font, New System.Drawing.SolidBrush(Color.Black), 546, PictureBox1.Height - 60, strFormat)
        Else
            Main.Gen.get_err_msg(General_Functions.Error_Codes.No_BC)
        End If
    End Sub

    Private Sub BC_Chk_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BC_Chk.KeyDown
        If e.KeyCode = Keys.Enter Then
            BC.Focus()
        End If
    End Sub

End Class
