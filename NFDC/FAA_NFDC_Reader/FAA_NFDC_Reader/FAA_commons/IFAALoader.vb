Public Interface IFAALoader

    Enum FAAResponse As Byte
        Invalid_File = 0
        Completed = 1
        Errorx = 2
        DB_Error = 3
    End Enum

    Function ParseFile(ByRef lines As List(Of String)) As FAAResponse

    ReadOnly Property FileType As String

    Event NextLine()
    Event SetCount(ByRef count As Integer, ByRef section As String)

End Interface
