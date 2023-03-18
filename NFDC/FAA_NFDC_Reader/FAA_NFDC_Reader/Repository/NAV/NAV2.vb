Namespace Repository

    Public Class NAV2

        Private DS As New FAAContext

        Public ReadOnly Property NAV2_list As List(Of Entity.NAV2)
            Get
                Return DS.NAV2.ToList()
            End Get
        End Property

        Public Sub Add(ByRef fix As Entity.NAV2)
            DS.NAV2.Add(fix)
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
