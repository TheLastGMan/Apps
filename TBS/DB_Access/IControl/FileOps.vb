Public Class FileOps

    ''' <summary>
    ''' File Structure for DBClassList.txt
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure DBClassList
        'D - DataBase, U - UserControl, T - Tournament, R - Report
        'Type [D,U,T,R] | Description | Class Reference
        Public Type As Char
        Public Desc As String
        Public CRef As String
    End Structure

    Private Structure FileInfo
        Shared ERR As Boolean = False
        Shared ERR_MSG As String = ""
        Shared File As String = ""
        Shared LineLst As New ArrayList
    End Structure

    Private _ERR As Boolean = False

    Public DBClassList_Ary As ArraySegment(Of DBClassList)

    Public Sub New(ByRef File As String)
        FileInfo.File = File
        ReadFile()
    End Sub

    Private Sub ReadFile()
        'if no contents in file, cache file
        If Not FileInfo.LineLst.Count > 0 Then
            Dim DBFile As String = FileInfo.File
            'read and cache file
            Try
                Dim DBReader As New IO.StreamReader(DBFile, True)
                While DBReader.Peek <> -1
                    Dim line As String = DBReader.ReadLine()
                    FileInfo.LineLst.Add(line)
                End While
                DBReader.Close()
            Catch ex As Exception
                FileInfo.ERR = True
                FileInfo.ERR_MSG = ex.Message
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Searches for lines starting with the [type] specified
    ''' </summary>
    ''' <param name="type">type to search for {T,U,R,D}</param>
    ''' <returns>ArrayList(Of DBClassList)</returns>
    ''' <remarks></remarks>
    Public Function Search_File(Optional ByRef type As String = "D") As ArrayList
        Dim tmpary As New ArrayList
        If FileInfo.ERR Then
            Dim DBI As New DBClassList
            DBI.Desc = "-1"
            DBI.CRef = FileInfo.ERR
            tmpary.Add(DBI)
        Else
            For Each line As String In FileInfo.LineLst
                If Not line.StartsWith("//") Then
                    If line.StartsWith(type) Then
                        Dim info As String() = line.Split("|")
                        Dim DBI As New DBClassList
                        'Description, Class Reference
                        DBI.Desc = info(1)
                        DBI.CRef = info(2)
                        tmpary.Add(DBI)
                    End If
                    '             |      0      |      1
                    '//Type [D,U] | Description | Class Reference
                End If
            Next
        End If
        Return tmpary
    End Function

    ''' <summary>
    ''' Delete exact reference CREF and Rewrites to file
    ''' </summary>
    ''' <param name="ref">Exact reference to delete</param>
    ''' <returns>True if deleted successful, False if not</returns>
    ''' <remarks></remarks>
    Public Function Delete_Reference(ByRef ref As String) As Boolean
        If FileInfo.ERR Then
            Return False
        Else
            For i As Integer = 0 To FileInfo.LineLst.Count - 1
                Dim cnt As Integer = i
                'MsgBox(cnt & " - " & FileInfo.LineLst(cnt))
                If FileInfo.LineLst(i).ToString.Contains(ref) Then
                    FileInfo.LineLst.RemoveAt(i)
                    Exit For
                End If
            Next
            Flush()
            Return True
        End If
    End Function

    ''' <summary>
    ''' outpus the file assembly namespace used for dynamic importing
    ''' </summary>
    ''' <param name="assembly_file_ref">the specific class you wish to inherit, typicall [root_namespace].file_class</param>
    ''' <param name="root_namespace">root namespace of the application</param>
    ''' <returns>string</returns>
    ''' <remarks></remarks>
    Public Function Create_Reference_String(ByRef assembly_file_ref As String, ByRef root_namespace As String) As String
        Return assembly_file_ref & ", " & root_namespace
    End Function

    ''' <summary>
    ''' Check weather the reference already exists, true if it does, false if it does not
    ''' </summary>
    ''' <param name="BDI">DBClassList of parameters</param>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Function Exists_Reference(ByRef BDI As DBClassList) As Boolean
        Dim ret As Boolean = False
        Try
            For Each fle In FileInfo.LineLst
                If fle = BDI.Type & "|" & BDI.Desc & "|" & BDI.CRef Then
                    ret = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function

    ''' <summary>
    ''' Writes the reference specified in DBClassList to file
    ''' </summary>
    ''' <param name="BDI">DBClassList of parameters</param>
    ''' <returns>True if write successful and False if not</returns>
    ''' <remarks></remarks>
    Public Function Write_Reference(ByRef BDI As DBClassList) As Boolean
        Try
            Dim Fp As New IO.StreamWriter(FileInfo.File, True)
            Fp.WriteLine(BDI.Type & "|" & BDI.Desc & "|" & BDI.CRef)
            FileInfo.LineLst.Add(BDI.Type & "|" & BDI.Desc & "|" & BDI.CRef)
            Fp.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Flushes context of FileLst to file [In Progress]
    ''' </summary>
    ''' <returns>True if content flushed and False if not</returns>
    ''' <remarks></remarks>
    Public Function Flush() As Boolean
        Try
            Dim Fp As New IO.StreamWriter(FileInfo.File, False)
            For Each line As String In FileInfo.LineLst
                Fp.WriteLine(line)
            Next
            Fp.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
