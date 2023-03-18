Namespace Repository

    Public Class AWOS1

        Private DS As New FAAContext

        Public ReadOnly Property AWOS1_list As List(Of Entity.AWOS1)
            Get
                Return DS.AWOS1.ToList
            End Get
        End Property

        Public Sub Add(ByRef awos As Entity.AWOS1)
            DS.AWOS1.Add(awos)
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
