Namespace Repository

    Public Class NATFIX

        Private DS As New FAAContext

        Public ReadOnly Property NATFIX_list As List(Of Entity.NATFIX)
            Get
                Return DS.NATFIX.ToList()
            End Get
        End Property

        Public Sub Add(ByRef fix As Entity.NATFIX)
            DS.NATFIX.Add(fix)
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
