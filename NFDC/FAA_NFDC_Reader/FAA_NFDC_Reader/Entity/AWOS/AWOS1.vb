Namespace Entity

    <Schema.Table("FAA_AWOS1")>
    Public Class AWOS1 : Inherits rowguidkey

        <MaxLength(4)>
        Public Property icao As String
        <MaxLength(10)>
        Public Property type As String
        <MaxLength(1)>
        Public Property commissioned As String
        <MaxLength(10)>
        Public Property changed_date As String
        <MaxLength(1)>
        Public Property navaid_flag As String
        <MaxLength(14)>
        Public Property latitude As String
        <MaxLength(15)>
        Public Property longitude As String
        <MaxLength(7)>
        Public Property elevation As String
        <MaxLength(1)>
        Public Property survey_code As String
        <MaxLength(7)>
        Public Property frequency_primary As String
        <MaxLength(7)>
        Public Property frequency_secondary As String
        <MaxLength(14)>
        Public Property telephone_primary As String
        <MaxLength(14)>
        Public Property telephone_secondary As String
        <MaxLength(11)>
        Public Property site_number As String
        <MaxLength(40)>
        Public Property city As String
        <MaxLength(2)>
        Public Property state_code As String
        <MaxLength(10)>
        Public Property effective As String

    End Class

End Namespace
