Namespace Repository

    Public Class Settings

        Private DBC As New Data.Context()

        Public ReadOnly Property Settings As List(Of Entity.Settings)
            Get
                Return DBC.Settings().ToList()
            End Get
        End Property

        Public Function [Set](ByRef key As String, ByRef value As String) As Boolean
            Try
                Dim sets As Entity.Settings = New Entity.Settings() With {.Key = key, .Value = value}
                DBC.Settings.Add(sets)
                DBC.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function [Get](ByVal key As String) As Entity.Settings
            Return Settings.Where(Function(f) f.Key = key).FirstOrDefault
        End Function

        Public ReadOnly Property CurrentYear As Integer
            Get
                Return [Get]("Setting.Year").Value
            End Get
        End Property

        Public ReadOnly Property WorkLocation As List(Of Long)
            Get
                Dim ret As New List(Of Long)
                For Each wc As String In [Get]("WorkLocation").Value.Split(",")
                    ret.Add(Long.Parse(wc))
                Next
                Return ret
            End Get
        End Property

        Public Property RegistrationDate As Date
            Get
                Return Date.Parse([Get]("Setting.RegistrationDate").Value)
            End Get
            Set(value As Date)
                [Set]("Setting.RegistrationDate", value.ToString)
            End Set
        End Property

    End Class

End Namespace
