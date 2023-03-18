Namespace Repository

    Public Class TWR8

        Private DS As New FAAContext

        Public ReadOnly Property TWR8_list As List(Of Entity.TWR8)
            Get
                Return DS.TWR8.ToList
            End Get
        End Property

        Public Sub Add(ByRef twr As Entity.TWR8)
            DS.TWR8.Add(twr)
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
