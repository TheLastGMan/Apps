Namespace Entity

    <Schema.Table("FAA_COM")>
    Public Class COM : Inherits rowguidkey

        <MaxLength(4)>
        Public Property icao As String
        <MaxLength(7)>
        Public Property type As String
        <MaxLength(4)>
        Public Property navaid_ident As String
        <MaxLength(2)>
        Public Property navaid_type As String
        <MaxLength(26)>
        Public Property navaid_city As String
        <MaxLength(20)>
        Public Property navaid_state As String
        <MaxLength(26)>
        Public Property navaid_name As String
        <MaxLength(15)>
        Public Property navaid_latitude As String
        <MaxLength(15)>
        Public Property navaid_longitude As String
        <MaxLength(26)>
        Public Property com_city As String
        <MaxLength(20)>
        Public Property com_state As String
        <MaxLength(20)>
        Public Property com_regionname As String
        <MaxLength(3)>
        Public Property com_regioncode As String
        <MaxLength(15)>
        Public Property com_latitude As String
        <MaxLength(15)>
        Public Property com_longitude As String
        <MaxLength(26)>
        Public Property com_call As String

        <MaxLength(144)>
        <Schema.Column("com_frequencies")>
        Private Property _com_frequencies As String
        <Schema.NotMapped>
        Public WriteOnly Property com_frequencies As String
            Set(value As String)
                Dim coms As New List(Of String)
                For i As Integer = 1 To value.Length Step 9
                    Dim len As Integer = IIf(value.Length + 1 - i < 9, value.Length + 1 - i, 9)
                    coms.Add(value.Substring(i - 1, len).Trim)
                Next
                _com_frequencies = String.Join(",", coms.ToArray)
            End Set
        End Property
        <Schema.NotMapped>
        Public ReadOnly Property com_frequencies_list As List(Of String)
            Get
                Return _com_frequencies.Split(",").ToList
            End Get
        End Property

        <MaxLength(4)>
        Public Property fss_ident As String
        <MaxLength(30)>
        Public Property fss_name As String
        <MaxLength(4)>
        Public Property alt_fss_ident As String
        <MaxLength(30)>
        Public Property alt_fss_name As String

        <MaxLength(60)>
        <Schema.Column("operational_hours")>
        Private Property _operational_hours As String
        <Schema.NotMapped>
        Public WriteOnly Property operational_hours As String
            Set(value As String)
                Dim hours As New List(Of String)
                For i As Integer = 1 To value.Length Step 20
                    Dim len As Integer = IIf(value.Length + 1 - i < 20, value.Length + 1 - i, 20)
                    hours.Add(value.Substring(i - 1, len))
                Next
                _operational_hours = String.Join(",", hours.ToArray)
            End Set
        End Property
        <Schema.NotMapped>
        Public ReadOnly Property operational_hours_list As List(Of String)
            Get
                Return _operational_hours.Split(",").ToList
            End Get
        End Property

        <MaxLength(1)>
        Public Property owner_code As String
        <MaxLength(69)>
        Public Property owner_name As String
        <MaxLength(1)>
        Public Property operator_code As String
        <MaxLength(69)>
        Public Property operator_name As String

        <MaxLength(8)>
        <Schema.Column("charts")>
        Private Property _charts As String
        <Schema.NotMapped>
        Public WriteOnly Property charts As String
            Set(value As String)
                Dim charts As New List(Of String)
                For i As Integer = 1 To value.Length Step 2
                    Dim len As Integer = IIf(value.Length + 1 - i < 2, value.Length + 1 - i, 2)
                    charts.Add(value.Substring(i - 1, len))
                Next
                _charts = String.Join(",", charts.ToArray)
            End Set
        End Property
        <Schema.NotMapped>
        Public ReadOnly Property charts_list As List(Of String)
            Get
                Return _charts.Split(",").ToList
            End Get
        End Property

        <MaxLength(2)>
        Public Property time_zone As String
        <MaxLength(20)>
        Public Property status As String
        <MaxLength(11)>
        Public Property status_date As String
    End Class

End Namespace
