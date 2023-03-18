Public Class KeyboardForm

    Private x As Short = 0
    Private y As Short = 0

    Private Sub KeyboardForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.Gen.cont = New Keyboard
        Panel1.Controls.Add(Main.Gen.cont)
        Get_Main_Loc()
        Set_Loc(x, y)
    End Sub

    Private Sub Set_Loc(ByVal x As Int16, ByVal y As Int16)
        x += 4
        y += (Main.Height - 470)
        Me.Location = New Point(x, y)
    End Sub

    Private Sub Get_Main_Loc()
        x = Main.Location.X()
        y = Main.Location.Y()
    End Sub

End Class