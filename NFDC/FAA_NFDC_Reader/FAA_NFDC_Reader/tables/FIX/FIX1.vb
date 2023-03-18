Public Class FIX1

    Public Function Process(ByRef line As String) As Entity.FIX1
        Dim FIX As New Entity.FIX1

        With FIX
            .fix_id = GetPart(line, 5, 30)
            .fix_state = GetPart(line, 35, 30)
            .icao_region = GetPart(line, 65, 2)
            .latitude = LatLong_To_Degrees(GetPart(line, 67, 14))
            .longitude = LatLong_To_Degrees(GetPart(line, 81, 14))
            .type = GetPart(line, 95, 3)
            .info1 = GetPart(line, 98, 22)
            .info2 = GetPart(line, 120, 22)
            .previous_name = GetPart(line, 142, 33)
            .chart_info = GetPart(line, 175, 38)
            .to_be_published = GetPart(line, 213, 1)
            .fix_use = GetPart(line, 214, 15)
            .nas_ident = GetPart(line, 229, 5)
            .artcc_high = GetPart(line, 234, 4)
            .artcc_low = GetPart(line, 238, 4)
            .fix_use_icao = GetPart(line, 242, 30)
            .pitch = GetPart(line, 272, 1)
            .catch = GetPart(line, 273, 1)
            .sua_atcaa = GetPart(line, 274, 1)
        End With

        Return FIX
    End Function

End Class
