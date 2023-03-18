Namespace Entity

    <Schema.Table("FAA_TWR4")>
    Public Class TWR4 : Inherits rowguidkey

        <MaxLength(4)>
        Public Property icao As String
        <MaxLength(100)>
        Public Property info As String

    End Class

End Namespace

