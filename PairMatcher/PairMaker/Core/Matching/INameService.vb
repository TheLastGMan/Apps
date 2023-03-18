Public Interface INameService

    Function LoadNames() As List(Of String)
    Function SaveNames(ByRef names As List(Of String)) As Boolean

End Interface
