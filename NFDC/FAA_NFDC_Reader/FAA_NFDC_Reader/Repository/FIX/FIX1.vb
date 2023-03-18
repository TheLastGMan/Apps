Namespace Repository

    Public Class FIX1

        Private DS As New FAAContext

        Public ReadOnly Property FIX1_list As List(Of Entity.FIX1)
            Get
                Return DS.fix1.tolist()
            End Get
        End Property

        Public Sub Add(ByRef fix As Entity.FIX1)
            DS.FIX1.Add(fix)
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
