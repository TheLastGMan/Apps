Namespace Entity

    <Schema.Table("FAA_TWR1")>
    Public Class TWR1 : Inherits rowguid

        <Key>
        <MaxLength(4)>
        Public Property icao As String
        <MaxLength(10)>
        Public Property effective As String
        <MaxLength(11)>
        Public Property site_id As String
        <MaxLength(3)>
        Public Property region_code As String
        <MaxLength(30)>
        Public Property state_name As String
        <MaxLength(2)>
        Public Property state_code As String
        <MaxLength(40)>
        Public Property city As String
        <MaxLength(50)>
        Public Property airport_name As String
        <MaxLength(15)>
        Public Property latitude As String
        <MaxLength(11)>
        Public Property latitude_seconds As String
        <MaxLength(15)>
        Public Property longitude As String
        <MaxLength(11)>
        Public Property longitude_seconds As String
        <MaxLength(4)>
        Public Property FSS_tie_in As String
        <MaxLength(30)>
        Public Property FSS_name As String
        <MaxLength(12)>
        Public Property facility_type As String
        <MaxLength(2)>
        Public Property daily_hours As String
        <MaxLength(3)>
        Public Property daily_hours_type As String
        <MaxLength(4)>
        Public Property master_aiport As String
        <MaxLength(50)>
        Public Property master_services As String
        <MaxLength(15)>
        Public Property direction_finding_type As String

        <MaxLength(50)>
        Public Property associated_facility As String
        <MaxLength(40)>
        Public Property associated_city As String
        <MaxLength(20)>
        Public Property associated_state As String
        <MaxLength(25)>
        Public Property associated_country As String
        <MaxLength(2)>
        Public Property associated_state_code As String
        <MaxLength(3)>
        Public Property associated_region_code As String

        <MaxLength(15)>
        Public Property radar_latitude As String
        <MaxLength(11)>
        Public Property radar_latitude_seconds As String
        <MaxLength(15)>
        Public Property radar_longitude As String
        <MaxLength(11)>
        Public Property radar_longitude_seconds As String
        <MaxLength(15)>
        Public Property antenna_latitude As String
        <MaxLength(11)>
        Public Property antenna_latitude_seconds As String
        <MaxLength(15)>
        Public Property antenna_longitude As String
        <MaxLength(11)>
        Public Property antenna_longitude_seconds As String

        <MaxLength(40)>
        Public Property operator_tower As String
        <MaxLength(40)>
        Public Property operator_tower_military As String
        <MaxLength(40)>
        Public Property operator_approach As String
        <MaxLength(40)>
        Public Property operator_approach_secondary As String
        <MaxLength(40)>
        Public Property operator_departure As String
        <MaxLength(40)>
        Public Property operator_departure_secondary As String

        <MaxLength(26)>
        Public Property radio_tower As String
        <MaxLength(26)>
        Public Property radio_tower_military As String
        <MaxLength(26)>
        Public Property radio_approach_primary As String
        <MaxLength(26)>
        Public Property radio_approach_secondary As String
        <MaxLength(26)>
        Public Property radio_departure_primary As String
        <MaxLength(26)>
        Public Property radio_departure_secondary As String

    End Class

End Namespace
