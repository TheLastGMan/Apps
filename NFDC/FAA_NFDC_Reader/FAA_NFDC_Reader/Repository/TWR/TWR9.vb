Namespace Repository

    Public Class TWR9

        Private DS As New FAAContext

        Public ReadOnly Property TWR9_list As List(Of Entity.TWR9)
            Get
                Return DS.TWR9.ToList
            End Get
        End Property

        Public Sub Add(ByRef twr As Entity.TWR9)
            DS.TWR9.Add(twr)
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
