Namespace Repository

    Public Class NAV1

        Private DS As New FAAContext

        Public ReadOnly Property NAV1_list As List(Of Entity.NAV1)
            Get
                Return DS.NAV1.ToList()
            End Get
        End Property

        Public Sub Add(ByRef fix As Entity.NAV1)
            DS.NAV1.Add(fix)
        End Sub

        Public Function Finish() As Boolean
            Try
                DS.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
