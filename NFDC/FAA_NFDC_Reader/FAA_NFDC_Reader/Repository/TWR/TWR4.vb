Namespace Repository

    Public Class TWR4

        Private DS As New FAAContext

        Public ReadOnly Property TWR4_list As List(Of Entity.TWR4)
            Get
                Return DS.TWR4.ToList
            End Get
        End Property

        Public Sub Add(ByRef twr As Entity.TWR4)
            DS.TWR4.Add(twr)
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
