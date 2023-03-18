Public Class TWR1

    Public Function Process(ByRef line As String) As Entity.TWR1
        Dim TWR As New Entity.TWR1

        With TWR
            .icao = GetPart(line, 5, 4)
            .effective = GetPart(line, 9, 10)
            .site_id = GetPart(line, 19, 11)
            .region_code = GetPart(line, 30, 3)
            .associated_state = GetPart(line, 33, 30)
            .associated_state_code = GetPart(line, 63, 2)
            .associated_state = GetPart(line, 65, 40)
            .airport_name = GetPart(line, 105, 50)
            .latitude = LatLong_To_Degrees(GetPart(line, 155, 14))
            .latitude_seconds = GetPart(line, 169, 11)
            .longitude = LatLong_To_Degrees(GetPart(line, 180, 14))
            .longitude_seconds = GetPart(line, 194, 11)
            .FSS_tie_in = GetPart(line, 205, 4)
            .FSS_name = GetPart(line, 209, 12)

            .facility_type = GetPart(line, 239, 12)
            .daily_hours = GetPart(line, 251, 2)
            .daily_hours_type = GetPart(line, 253, 3)
            .master_aiport = GetPart(line, 256, 4)
            .master_services = GetPart(line, 260, 50)
            .direction_finding_type = GetPart(line, 310, 15)

            .associated_facility = GetPart(line, 325, 50)
            .associated_city = GetPart(line, 375, 40)
            .associated_state = GetPart(line, 415, 20)
            .associated_country = GetPart(line, 435, 25)
            .associated_state_code = GetPart(line, 460, 2)
            .associated_region_code = GetPart(line, 462, 3)

            .radar_latitude = LatLong_To_Degrees(GetPart(line, 465, 14))
            .radar_latitude_seconds = GetPart(line, 479, 11)
            .radar_longitude = LatLong_To_Degrees(GetPart(line, 490, 14))
            .radar_longitude_seconds = GetPart(line, 504, 11)
            .antenna_latitude = LatLong_To_Degrees(GetPart(line, 515, 14))
            .antenna_latitude_seconds = GetPart(line, 529, 11)
            .antenna_longitude = LatLong_To_Degrees(GetPart(line, 540, 14))
            .antenna_longitude_seconds = GetPart(line, 554, 11)

            .operator_tower = GetPart(line, 565, 40)
            .operator_tower_military = GetPart(line, 605, 40)
            .operator_approach = GetPart(line, 645, 40)
            .operator_approach_secondary = GetPart(line, 685, 40)
            .operator_departure = GetPart(line, 725, 40)
            .operator_departure_secondary = GetPart(line, 765, 40)

            .radio_tower = GetPart(line, 805, 26)
            .radio_tower_military = GetPart(line, 831, 26)
            .radio_approach_primary = GetPart(line, 857, 26)
            .radio_approach_secondary = GetPart(line, 883, 26)
            .radio_departure_primary = GetPart(line, 909, 26)
            .radio_departure_secondary = GetPart(line, 935, 26)
        End With

        Return TWR
    End Function

End Class
