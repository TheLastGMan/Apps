Public Class DBLnkr

    Public Shared DB_Program As IDB_Template
    Public Shared DB_Logging As IDB_Template
    Public Shared DB_Logging_Enab As Boolean = False

    Public Enum DB_Extern_Result As SByte
        Failed_Both = 0
        Failed_DBLnk1 = 2
        Failed_DBLnk2 = 1
        Success = 3
    End Enum

    Public Shared Function DB_External_Setup() As SByte
        Dim DBFile As String = My.Application.Info.DirectoryPath & "\DB\DBClass.txt"
        Dim DBReader As New IO.StreamReader(DBFile, True)
        Dim ret As SByte = 0
        'Setup Program Database Reference
        Try
            DB_Program = Activator.CreateInstance(Type.GetType(DBReader.ReadLine()))
            ret += 1
        Catch ex As Exception
        End Try

        'Setup Logging Database Reference
        Try
            DB_Logging = Activator.CreateInstance(Type.GetType(DBReader.ReadLine()))
            DB_Logging_Enab = True
            ret += 2
        Catch ex As Exception
        End Try
        DBReader.Close()
        Return ret
    End Function

End Class
