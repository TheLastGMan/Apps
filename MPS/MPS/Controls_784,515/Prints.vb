Public Class Prints

    Private Sub Prints_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel1.Controls.Add(New printpage)
    End Sub

    Private Sub ESC_Key(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            closeme()
        End If
    End Sub

    Private Sub closeme()
        If Main.FUNC._PRINTED Then
            Main.FUNC._PRINTED = False
            Close()
        Else
            If MsgBox("Close Without Printing?", MsgBoxStyle.YesNo, "Close") = MsgBoxResult.Yes Then
                Main.FUNC._PRINTED = False
                Close()
            End If
        End If
    End Sub
End Class