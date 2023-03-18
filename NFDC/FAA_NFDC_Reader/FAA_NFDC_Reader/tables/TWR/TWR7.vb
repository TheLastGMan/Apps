Public Class TWR7

    Public Function Process(ByRef line As String) As Entity.TWR7
        Dim twr As New Entity.TWR7

        With twr
            .icao = GetPart(line, 5, 4)
            .radio = GetPart(line, 9, 44)
            .radio_use = GetPart(line, 53, 50)
            .site_code = GetPart(line, 103, 11)
            .site_identifier = GetPart(line, 114, 4)
            .region_code = GetPart(line, 118, 3)
            .state = GetPart(line, 121, 30)
            .state_code = GetPart(line, 151, 2)
            .city = GetPart(line, 153, 40)
            .airport_name = GetPart(line, 193, 50)
            .latitude = LatLong_To_Degrees(GetPart(line, 243, 14))
            .latitude_seconds = GetPart(line, 257, 11)
            .longitude = LatLong_To_Degrees(GetPart(line, 268, 14))
            .longitude_seconds = GetPart(line, 282, 11)
            .FSS = GetPart(line, 293, 4)
            .FSS_Name = GetPart(line, 297, 30)
            .master_site_code = GetPart(line, 327, 11)
            .master_region_code = GetPart(line, 338, 3)
            .master_state = GetPart(line, 341, 30)
            .master_state_code = GetPart(line, 371, 2)
            .master_city = GetPart(line, 373, 40)
            .master_airport_name = GetPart(line, 416, 50)
            .master_radio = GetPart(line, 463, 60)
        End With

        Return twr
    End Function

End Class
