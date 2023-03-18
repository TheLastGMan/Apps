Public Class TWR9

    Public Function Process(ByRef line As String) As Entity.TWR9
        Dim twr As New Entity.TWR9

        With twr
            .icao = GetPart(line, 5, 4)
            .atis_serial = GetPart(line, 9, 4)
            .hours = GetPart(line, 13, 200)
            .info = GetPart(line, 213, 100)
            .phone = GetPart(line, 313, 18)
        End With

        Return twr
    End Function

End Class
