Namespace Repository

    Public Class COM

        Private DS As New FAAContext()

        Public ReadOnly Property ComDB As List(Of Entity.COM)
            Get
                Return DS.COM.ToList()
            End Get
        End Property

        Public Sub Add(ByRef com As Entity.COM)
            DS.COM.Add(com)
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
