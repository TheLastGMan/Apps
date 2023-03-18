Public Class TWR2

    Public Function Process(ByRef line As String) As Entity.TWR2
        Dim twr As New Entity.TWR2

        With twr
            .icao = GetPart(line, 5, 4)
            .military_pmsv = GetPart(line, 9, 200)
            .military_macp = GetPart(line, 209, 200)
            .military_hours = GetPart(line, 409, 200)
            .approach_primary = GetPart(line, 609, 200)
            .approach_secondary = GetPart(line, 809, 200)
            .departure_primary = GetPart(line, 1009, 200)
            .departure_secondary = GetPart(line, 1209, 200)
            .tower = GetPart(line, 1409, 200)
        End With

        Return twr
    End Function

End Class
