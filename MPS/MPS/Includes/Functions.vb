Public Class Functions

    Public Cont As UserControl
    Public _BID As Integer = 0
    Public _BNT As String = ""
    Public _PHONE As String = ""
    Public _SEARCH As Boolean = True
    Public _SBNT As String = ""
    Public _SPHONE As String = ""
    Public _SID As Integer = 0
    Public _PRINTFID As Integer = 0
    Public _PRINTED As Boolean = False
    'Public Sub Change_Header(ByVal text As String)
    'Main.Header.Text = text
    Public gold As Color = Color.Gold
    Public silver As Color = Color.Silver
    Public genback As Color = Color.WhiteSmoke

    Public Sub Change_Cont(Optional ByVal override As Boolean = False)
        Dim found As Boolean = False
        Try
            If Not Main.Panel1.Controls(0).Name = Cont.Name Or override Then
                Main.Panel1.Controls.Clear()
                Main.Panel1.Controls.Add(Cont)
            End If
        Catch ex As Exception
            Main.Panel1.Controls.Clear()
            Main.Panel1.Controls.Add(Cont)
        End Try
    End Sub

    Public Sub load_default()
        Select Case My.Settings.DefaultPage
            Case 0
                Main.Drill_Sheet()
            Case 1
                Main.Search()
        End Select
    End Sub

    Public Sub dmsg(ByVal msg As String)
#If DEBUG Then
        MsgBox(msg)
#End If
    End Sub

    Public Function Uppercase_Words(ByVal name As String) As String
        If name.Length > 0 Then
            Dim words As String() = name.Split(" ")
            Dim upper As String
            For i As Integer = 0 To words.Count - 1
                Try
                    upper = words(i).Substring(0, 1)
                    upper = upper.ToUpper()
                    words(i) = upper & words(i).Substring(1, words(i).Length - 1)
                Catch ex As Exception
                    upper = ""
                    words(i) = ""
                End Try
            Next
            'put name back together
            name = ""
            For i As Integer = 0 To words.Count - 1
                If Not i = words.Count - 1 Then
                    name &= words(i) & " "
                Else
                    name &= words(i)
                End If
            Next
        End If
        Return name
    End Function

    Public Sub shutdown()
        'handles shutdown events

    End Sub

End Class
