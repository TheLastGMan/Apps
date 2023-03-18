Namespace Repository

    Public Class TWR3

        Private DS As New FAAContext

        Public ReadOnly Property TWR3_list As List(Of Entity.TWR3)
            Get
                Return DS.TWR3.ToList
            End Get
        End Property

        Public Sub Add(ByRef twr As Entity.TWR3)
            DS.TWR3.Add(twr)
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
