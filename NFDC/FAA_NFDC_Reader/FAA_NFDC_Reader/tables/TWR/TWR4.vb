Public Class TWR4

    Public Function Process(ByRef line As String) As Entity.TWR4
        Return New Entity.TWR4 With {.icao = GetPart(line, 5, 4), .info = GetPart(line, 9, 100)}
    End Function

End Class
