Namespace Repository

    Public Class TWR7

        Private DS As New FAAContext

        Public ReadOnly Property TWR7_list As List(Of Entity.TWR7)
            Get
                Return DS.TWR7.ToList
            End Get
        End Property

        Public Sub Add(ByRef twr As Entity.TWR7)
            DS.TWR7.Add(twr)
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
