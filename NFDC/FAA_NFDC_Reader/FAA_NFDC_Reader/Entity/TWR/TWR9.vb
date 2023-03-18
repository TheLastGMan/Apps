Namespace Entity

    <Schema.Table("FAA_TWR9")>
    Public Class TWR9 : Inherits rowguidkey

        <MaxLength(4)>
        Public Property icao As String
        <MaxLength(4)>
        Public Property atis_serial As String
        <MaxLength(200)>
        Public Property hours As String
        <MaxLength(100)>
        Public Property info As String
        <MaxLength(18)>
        Public Property phone As String

    End Class

End Namespace
