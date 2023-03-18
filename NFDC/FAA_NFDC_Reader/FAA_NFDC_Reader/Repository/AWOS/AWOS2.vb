Namespace Repository

    Public Class AWOS2

        Private DS As New FAAContext

        Public ReadOnly Property AWOS2_list As List(Of Entity.AWOS2)
            Get
                Return DS.AWOS2.ToList
            End Get
        End Property

        Public Sub Add(ByRef awos As Entity.AWOS2)
            DS.AWOS2.Add(awos)
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
