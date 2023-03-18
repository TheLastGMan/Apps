Namespace Entity

    <Schema.Table("FAA_NAV1")>
    Public Class NAV1 : Inherits rowguidkey

        <MaxLength(4)>
        Public Property icao As String
        <MaxLength(20)>
        Public Property type As String
        <MaxLength(4)>
        Public Property official_icao As String
        <MaxLength(10)>
        Public Property effective As String
        <MaxLength(30)>
        Public Property navaid_name As String
        <MaxLength(40)>
        Public Property city As String
        <MaxLength(30)>
        Public Property state As String
        <MaxLength(2)>
        Public Property state_code As String
        <MaxLength(3)>
        Public Property region_code As String
        <MaxLength(30)>
        Public Property country As String
        <MaxLength(2)>
        Public Property country_state_code As String
        <MaxLength(50)>
        Public Property owner_name As String
        <MaxLength(50)>
        Public Property operator_name As String
        <MaxLength(1)>
        Public Property common_use As String
        <MaxLength(1)>
        Public Property public_use As String
        <MaxLength(11)>
        Public Property [class] As String
        <MaxLength(11)>
        Public Property hours As String
        <MaxLength(4)>
        Public Property artcc_high As String
        <MaxLength(30)>
        Public Property artcc_high_name As String
        <MaxLength(4)>
        Public Property artcc_low As String
        <MaxLength(30)>
        Public Property artcc_low_name As String

        <MaxLength(15)>
        Public Property latitude As String
        <MaxLength(11)>
        Public Property latitude_seconds As String
        <MaxLength(15)>
        Public Property longitude As String
        <MaxLength(11)>
        Public Property longitude_seconds As String
        <MaxLength(15)>
        Public Property tacan_latitude As String
        <MaxLength(11)>
        Public Property tacan_latitude_seconds As String
        <MaxLength(15)>
        Public Property tacan_longitude As String
        <MaxLength(11)>
        Public Property tacan_longitude_seconds As String
        <MaxLength(7)>
        Public Property elevation_msl As String
        <MaxLength(5)>
        Public Property magnetic_variation As String
        <MaxLength(4)>
        Public Property magnetic_variation_epoch As String

        <MaxLength(3)>
        Public Property voice_feature As String
        <MaxLength(4)>
        Public Property power_output_watts As String
        <MaxLength(3)>
        Public Property voice_identification As String
        <MaxLength(1)>
        Public Property monitor_category As String
        <MaxLength(30)>
        Public Property radio_name As String
        <MaxLength(4)>
        Public Property tacan_channel As String
        <MaxLength(6)>
        Public Property radio As String
        <MaxLength(24)>
        Public Property fan_marker As String
        <MaxLength(10)>
        Public Property fan_marker_type As String
        <MaxLength(3)>
        Public Property fan_true_bearing As String
        <MaxLength(1)>
        Public Property tacan_type As String
        <MaxLength(3)>
        Public Property low_altitude_used As String
        <MaxLength(3)>
        Public Property z_marker_available As String
        <MaxLength(9)>
        Public Property TWEB_hours As String
        <MaxLength(20)>
        Public Property TWEB_phone As String
        <MaxLength(4)>
        Public Property FSS As String
        <MaxLength(30)>
        Public Property FSS_Name As String
        <MaxLength(100)>
        Public Property FSS_hours As String
        <MaxLength(4)>
        Public Property NOTAM_ident As String

        <MaxLength(16)>
        Public Property quadrant_ident As String
        <MaxLength(30)>
        Public Property status As String

        <MaxLength(1)>
        Public Property pitch As String
        <MaxLength(1)>
        Public Property [catch] As String
        <MaxLength(1)>
        Public Property sua_atcaa As String
        <MaxLength(1)>
        Public Property restriction_flag As String
        <MaxLength(1)>
        Public Property hiwas_flag As String
        <MaxLength(1)>
        Public Property tweb_restriction As String

    End Class

End Namespace
