Namespace Repository

    Public Class TWR2

        Private DS As New FAAContext

        Public ReadOnly Property TWR2_list As List(Of Entity.TWR2)
            Get
                Return DS.TWR2.ToList
            End Get
        End Property

        Public Sub Add(ByRef twr As Entity.TWR2)
            DS.TWR2.Add(twr)
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
