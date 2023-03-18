Namespace Repository

    Public Class APT1

        Private DS As New FAAContext

        Public ReadOnly Property APT1_list As List(Of Entity.APT)
            Get
                Return DS.APT1.ToList()
            End Get
        End Property

        Public Sub Add(ByRef fix As Entity.APT)
            DS.APT1.Add(fix)
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
