Public Class VectorFBowler

    Private Sub Vector_FBowler_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.FUNC.Change_Header("Find Bowlers Scores")
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub NBowler_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles NBowler.KeyDown
        If e.KeyCode = Keys.Enter Then
            Search_Bowler()
        End If
    End Sub

    Private Sub NBowler_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NBowler.Leave
        Search_Bowler()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Search_Bowler()
    End Sub

    Private Sub Search_Bowler()
        If NBowler.Text.Length > 0 Then
            Dim dat As String = Main.VDB.Find_Last_Bowler(NBowler.Text)
            Dim scores As String() = dat.Split("|")
            Dim datex As String() = {""}
            Dim datext As String() = {""}
            DataGridView1.Rows.Clear()
            If scores.Length > 1 Then
                For i As Integer = 0 To scores.Length - 2
                    DataGridView1.Rows.Add(scores(i).Split(","))
                    datext = DataGridView1.Rows(i).Cells(8).Value.ToString.Split(" ")
                    If datex(0).Length = 0 Then
                        datex(0) = datext(0)
                    End If
                    If Not datex(0) = datext(0) And ComboBox1.SelectedIndex Then
                        DataGridView1.Rows.RemoveAt(DataGridView1.Rows.Count - 1)
                        Exit For
                    End If
                Next
            Else
                DataGridView1.Rows.Add("No Data")
            End If
        Else
            MsgBox("bowler name is not long enough")
        End If
    End Sub

End Class
