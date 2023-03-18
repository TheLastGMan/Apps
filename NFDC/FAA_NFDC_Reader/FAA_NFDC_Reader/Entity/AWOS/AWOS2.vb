Namespace Entity

    <Schema.Table("FAA_AWOS2")>
    Public Class AWOS2 : Inherits rowguidkey

        <MaxLength(4)>
        Public Property icao As String
        <MaxLength(10)>
        Public Property type As String
        <MaxLength(236)>
        Public Property remarks As String

    End Class

End Namespace

