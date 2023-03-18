Public Class League_Add

    Private Sub League_Add_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.Gen.Change_Header(Me.Name)
        Main.Gen.TextName = Name_Box.Name
        Name_Box.Focus()
    End Sub



    Private Sub Name_Box_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Name_Box.KeyDown
        'Private Sub Keyboard(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            Price_Box.Focus()
        End If
    End Sub

    Private Sub Price_Box_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Price_Box.KeyUp
        If e.KeyCode = Keys.Enter Then
            Add_League.Focus()
        End If
    End Sub

    Private Sub Show_KB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Show_KB.Click
        If Show_KB.Text.Contains("Show") Then
            Show_KB.Text = "Hide KeyBoard"
            KeyboardForm.Show()
        Else
            Show_KB.Text = "Show Keyboard"
            KeyboardForm.Close()
        End If
    End Sub

    Private Sub Name_Box_Focus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Name_Box.Enter
        Main.Gen.TextName = Name_Box.Name
        'Name_Box.Focus()
        KeyboardForm.Focus()
    End Sub

    Private Sub Price_Box_Focus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Price_Box.Enter
        Main.Gen.TextName = Price_Box.Name
        KeyboardForm.Focus()
    End Sub

    Private Sub Add_League_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Add_League.KeyDown
        If e.KeyCode = Keys.Enter Then
            Add_Leagues()
        End If
    End Sub

    Private Sub Add_League_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add_League.Click
        Add_Leagues()
    End Sub

    Private Sub Add_Leagues()
        If Name_Box.Text.Length >= 3 And Price_Box.Text.Length = 4 Then
            If Check_League() Then
                Try
                    Dim PB As String = Price_Box.Text
                    PB = PB.Replace(" ", "0")
                    PB = PB.Substring(0, 2) & "." & PB.Substring(2, 2)
                    LeagueTableAdapter.Insert(Name_Box.Text, PB)
                    Main.Gen.get_err_msg(General_Functions.Error_Codes.League_Add_Suc)
                    Name_Box.ResetText()
                    Price_Box.ResetText()
                    Name_Box.Focus()
                    LeagueTableAdapter.Dispose()
                Catch ex As Exception
                    Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
                End Try
            Else
                Main.Gen.get_err_msg(General_Functions.Error_Codes.League_Exists)
                Name_Box.Focus()
            End If

        Else
            Main.Gen.get_err_msg(General_Functions.Error_Codes.No_League)
            Name_Box.Focus()
        End If
    End Sub

    Private Function Check_League()
        Try
            If QueriesTableAdapter.Check_League(Name_Box.Text) = "0" Then
                QueriesTableAdapter.Dispose()
                Return True
            Else
                QueriesTableAdapter.Dispose()
                Return False
            End If
        Catch ex As Exception
            Main.Gen.get_err_msg(General_Functions.Error_Codes.DB_Con_Err)
            Return False
        End Try
    End Function

End Class
