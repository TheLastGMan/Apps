Public Class Keyboard

    Private CAPx As Boolean = False
    Private SHIFTx As Boolean = False

    Private Sub Keyboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Key_Clicks(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t11.Click, t12.Click, t13.Click, t14.Click, t15.Click, t16.Click, t17.Click, t18.Click, t19.Click, t110.Click, _
                                                                                                t21.Click, t22.Click, t23.Click, t24.Click, t25.Click, t26.Click, t27.Click, t28.Click, t29.Click, t210.Click, _
                                                                                                t31.Click, t32.Click, t33.Click, t34.Click, t35.Click, t36.Click, t37.Click, t38.Click, t39.Click, _
                                                                                                t41.Click, t42.Click, t43.Click, t44.Click, t45.Click, t46.Click, t47.Click
        'Main.PANEL1.Controls(0).Controls(Main.Gen.TextName).Text &= GetText(sender.ToString())
        SendText(GetText(sender.ToString()))
        Check_CS()
    End Sub

    Private Sub SendText(ByVal msg As String)
        Try
            Main.PANEL1.Controls(0).Controls(Main.Gen.TextName).Text &= msg
        Catch ex As Exception
            Throw_KB_Error()
        End Try
    End Sub

    Private Function GetText(ByVal str As String)
        Dim start As Byte = str.IndexOf("Text:")
        Return str.Substring(start + 6, 1)
    End Function

    Private Sub SPACE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPACE.Click
        'PASSWORD.Text &= " "
        SendText(" ")
    End Sub

    Private Sub SHIFT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SHIFT.Click
        If SHIFTx Then
            SHIFTx = False
        Else
            SHIFTx = True
        End If
        Check_CS()
    End Sub

    Private Sub CAPS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CAPS.Click
        If CAPx Then
            CAPx = False
        Else
            CAPx = True
        End If
        Check_CS()
    End Sub

    Private Sub BACKSPACE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BACKSPACE.Click
        Try
            Main.PANEL1.Controls(0).Controls(Main.Gen.TextName).Focus.Equals(True)
            SendKeys.SendWait("{BACKSPACE}")
            KeyboardForm.Focus()
        Catch ex As Exception
            Throw_KB_Error()
        End Try
    End Sub

    Private Sub Check_CS()
        Dim tt() As String = {"t11", "t12", "t13", "t14", "t15", "t16", "t17", "t18", "t19", "t110", "t21", "t22", "t23", "t24", "t25", "t26", "t27", "t28", "t29", "t210", "t31", "t32", "t33", "t34", "t35", "t36", "t37", "t38", "t39", "t41", "t42", "t43", "t44", "t45", "t46", "t47"}
        Dim lc() As String = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"}
        Dim uc() As String = {"!", "@", "#", "$", "%", "^", "&&", "*", "(", ")"}
        For i As Integer = 0 To tt.Length - 1 Step 1
            If i < 10 Then
                If CAPx Or SHIFTx Then
                    Controls(tt(i)).Text = uc(i)
                Else
                    Controls(tt(i)).Text = lc(i)
                End If
            Else
                If CAPx Or SHIFTx Then
                    Controls(tt(i)).Text = Controls(tt(i)).Text.ToUpper()
                Else
                    Controls(tt(i)).Text = Controls(tt(i)).Text.ToLower()
                End If
            End If
        Next
        SHIFTx = False
    End Sub

    Private Sub RET_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RET.Click
        Try
            Main.PANEL1.Controls(0).Controls(Main.Gen.TextName).Focus.Equals(True)
            SendKeys.Send("{ENTER}")
        Catch ex As Exception
            Throw_KB_Error()
        End Try
    End Sub

    Private Sub Throw_KB_Error()
        Main.Gen.get_err_msg(General_Functions.Error_Codes.No_KeyB)
    End Sub

    Private Sub Lefts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lefts.Click
        Try
            Main.PANEL1.Controls(0).Controls(Main.Gen.TextName).Focus.Equals(True)
            SendKeys.Send("{LEFT}")
        Catch ex As Exception
            Throw_KB_Error()
        End Try
    End Sub
End Class
