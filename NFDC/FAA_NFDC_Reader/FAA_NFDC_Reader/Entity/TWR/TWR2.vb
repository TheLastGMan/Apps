Namespace Entity

    <Schema.Table("FAA_TWR2")>
    Public Class TWR2 : Inherits rowguid

        <Key>
        <MaxLength(4)>
        Public Property icao As String
        <MaxLength(200)>
        Public Property military_pmsv As String
        <MaxLength(200)>
        Public Property military_macp As String
        <MaxLength(200)>
        Public Property military_hours As String
        <MaxLength(200)>
        Public Property approach_primary As String
        <MaxLength(200)>
        Public Property approach_secondary As String
        <MaxLength(200)>
        Public Property departure_primary As String
        <MaxLength(200)>
        Public Property departure_secondary As String
        <MaxLength(200)>
        Public Property tower As String

    End Class

End Namespace
