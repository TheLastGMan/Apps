Public Class AWOS1

    Public Function Process(ByRef line As String) As Entity.AWOS1
        Dim AWOS As New Entity.AWOS1
        With AWOS
            .icao = GetPart(line, 6, 4)
            .type = GetPart(line, 10, 10)
            .commissioned = GetPart(line, 20, 1)
            .changed_date = GetPart(line, 21, 10)
            .navaid_flag = GetPart(line, 31, 1)
            .latitude = LatLong_To_Degrees(GetPart(line, 32, 14))
            .longitude = LatLong_To_Degrees(GetPart(line, 46, 15))
            .elevation = GetPart(line, 61, 7)
            .survey_code = GetPart(line, 68, 1)
            .frequency_primary = GetPart(line, 69, 7)
            .frequency_secondary = GetPart(line, 76, 7)
            .telephone_primary = GetPart(line, 83, 14)
            .telephone_secondary = GetPart(line, 97, 14)
            .site_number = GetPart(line, 111, 11)
            .city = GetPart(line, 122, 40)
            .state_code = GetPart(line, 162, 2)
            .effective = GetPart(line, 164, 10)
        End With
        Return AWOS
    End Function

End Class
