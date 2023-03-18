Namespace Repository

    Public Class TWR1

        Private DS As New FAAContext

        Public ReadOnly Property TWR1_list As List(Of Entity.TWR1)
            Get
                Return DS.TWR1.ToList
            End Get
        End Property

        Public Sub Add(ByRef twr As Entity.TWR1)
            DS.TWR1.Add(twr)
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
