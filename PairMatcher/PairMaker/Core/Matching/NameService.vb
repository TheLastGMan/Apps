Namespace Matching

    Public Class NameService : Implements INameService

        Private NameFile As String = "names.txt"

        Public Function LoadNames() As List(Of String) Implements INameService.LoadNames
            Dim lst As New List(Of String)
            If IO.File.Exists(NameFile) Then
                Using SR As New IO.StreamReader(NameFile)
                    While Not SR.EndOfStream
                        Dim line As String = SR.ReadLine.Trim
                        If line.Length > 0 Then
                            lst.Add(line)
                        End If
                    End While
                End Using
                Return lst
            Else
                Return lst
            End If
        End Function

        Public Function SaveNames(ByRef names As List(Of String)) As Boolean Implements INameService.SaveNames
            Dim previous As List(Of String) = LoadNames()
            previous.AddRange(names)
            Using SW As New IO.StreamWriter(NameFile, False)
                Dim distinctlst As List(Of String) = names.Distinct().ToList
                distinctlst.ForEach(Sub(f) SW.WriteLine(f.Trim()))
            End Using
            Return True
        End Function

    End Class

End Namespace
