Namespace Entity

    <Schema.Table("FAA_TWR7")>
    Public Class TWR7 : Inherits rowguidkey

        <MaxLength(4)>
        Public Property icao As String
        <MaxLength(44)>
        Public Property radio As String
        <MaxLength(50)>
        Public Property radio_use As String
        <MaxLength(11)>
        Public Property site_code As String
        <MaxLength(4)>
        Public Property site_identifier As String
        <MaxLength(3)>
        Public Property region_code As String
        <MaxLength(30)>
        Public Property state As String
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
        Public Property FSS As String
        <MaxLength(30)>
        Public Property FSS_Name As String
        <MaxLength(11)>
        Public Property master_site_code As String
        <MaxLength(3)>
        Public Property master_region_code As String
        <MaxLength(30)>
        Public Property master_state As String
        <MaxLength(2)>
        Public Property master_state_code As String
        <MaxLength(40)>
        Public Property master_city As String
        <MaxLength(50)>
        Public Property master_airport_name As String
        <MaxLength(60)>
        Public Property master_radio As String

    End Class

End Namespace
