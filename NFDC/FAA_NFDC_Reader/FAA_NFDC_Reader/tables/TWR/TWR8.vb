Public Class TWR8

    Public Function Process(ByRef line As String) As Entity.TWR8
        Dim twr As New Entity.TWR8

        With twr
            .icao = GetPart(line, 5, 4)
            .ClassB = GetPart(line, 9, 1)
            .ClassC = GetPart(line, 10, 1)
            .ClassD = GetPart(line, 11, 1)
            .ClassE = GetPart(line, 12, 1)
            .airspace_hours = GetPart(line, 13, 300)
        End With

        Return twr
    End Function

End Class
