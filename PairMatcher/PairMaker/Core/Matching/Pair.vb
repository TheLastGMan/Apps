Namespace Matching

    Public Class Pair : Implements IPair

        Public Function PairUp(ByRef people As List(Of String)) As List(Of MatchPair) Implements IPair.PairUp
            Dim ret As New List(Of MatchPair)

            'one to one pair, no duplicate names in list
            Dim RND As New Random(Now.Millisecond * Now.Second)
            While people.Count > 0
                Dim sv As Integer = RND.Next(people.Count)
                Dim nv As Integer = 0

                'loop until we get a different next person
                While True
                    nv = RND.Next(people.Count)
                    If Not sv = nv Then
                        Exit While
                    End If
                End While

                Dim n1 As String = people(sv)
                Dim n2 As String = people(nv)

                ret.Add(New MatchPair With {.Name1 = n1, .Name2 = n2})
                people.Remove(n1)
                people.Remove(n2)
            End While

            Return ret
        End Function

    End Class

End Namespace