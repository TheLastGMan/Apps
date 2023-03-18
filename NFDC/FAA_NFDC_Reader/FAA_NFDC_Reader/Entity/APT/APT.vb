Namespace Entity

    <Schema.Table("FAA_APT")>
    Public Class APT : Inherits rowguid

        <MaxLength(11)>
        Public Property site_code As String
        <MaxLength(13)>
        Public Property type As String
        <Key>
        <MaxLength(4)>
        Public Property icao As String
        <MaxLength(10)>
        Public Property effective As String
        <MaxLength(3)>
        Public Property region_code As String
        <MaxLength(4)>
        Public Property fsdo As String
        <MaxLength(2)>
        Public Property state_code As String
        <MaxLength(20)>
        Public Property state As String
        <MaxLength(21)>
        Public Property county As String
        <MaxLength(2)>
        Public Property county_state_code As String
        <MaxLength(40)>
        Public Property city As String
        <MaxLength(50)>
        Public Property airport_name As String

        <MaxLength(2)>
        Public Property owner_type As String
        <MaxLength(2)>
        Public Property airport_use_type As String
        <MaxLength(35)>
        Public Property owner_name As String
        <MaxLength(72)>
        Public Property owner_address As String
        <MaxLength(45)>
        Public Property owner_address_line2 As String
        <MaxLength(16)>
        Public Property owner_phone As String
        <MaxLength(35)>
        Public Property manager_name As String
        <MaxLength(72)>
        Public Property manager_address As String
        <MaxLength(45)>
        Public Property manager_address_line2 As String
        <MaxLength(16)>
        Public Property manager_phone As String

        <MaxLength(15)>
        Public Property latitude As String
        <MaxLength(12)>
        Public Property latitude_seconds As String
        <MaxLength(15)>
        Public Property longitude As String
        <MaxLength(12)>
        Public Property longitude_seconds As String
        <MaxLength(1)>
        Public Property geo_determination As String
        <MaxLength(7)>
        Public Property elevation_msl As String
        <MaxLength(1)>
        Public Property elevation_determination As String
        <MaxLength(3)>
        Public Property magnetic_variation As String
        <MaxLength(4)>
        Public Property magnetic_variation_epoch As String
        <MaxLength(4)>
        Public Property tpa_agl As String
        <MaxLength(30)>
        Public Property sectional As String
        <MaxLength(2)>
        Public Property distance_from_town As String
        <MaxLength(3)>
        Public Property distance_direction As String
        <MaxLength(5)>
        Public Property acres As String

        <MaxLength(4)>
        Public Property artcc_ident As String
        <MaxLength(3)>
        Public Property artcc_computer_ident As String
        <MaxLength(30)>
        Public Property artcc_name As String
        <MaxLength(4)>
        Public Property artcc_responsible_ident As String
        <MaxLength(3)>
        Public Property artcc_responsible_computer_ident As String
        <MaxLength(30)>
        Public Property artcc_responsible_name As String
        <MaxLength(1)>
        Public Property fss_tiein_available As String
        <MaxLength(4)>
        Public Property fss_tiein_ident As String
        <MaxLength(30)>
        Public Property fss_tiein_name As String
        <MaxLength(16)>
        Public Property fss_phone As String
        <MaxLength(16)>
        Public Property fss_phone_free As String
        <MaxLength(4)>
        Public Property fss_alternate_ident As String
        <MaxLength(30)>
        Public Property fss_alternate_name As String
        <MaxLength(16)>
        Public Property fss_alternate_phone_free As String
        <MaxLength(4)>
        Public Property fss_notam_ident As String
        <MaxLength(1)>
        Public Property notam_d_available As String

        <MaxLength(7)>
        Public Property activation_date As String
        <MaxLength(2)>
        Public Property airport_status As String
        <MaxLength(15)>
        Public Property airport_arff_type As String
        <MaxLength(7)>
        Public Property npias_code As String
        <MaxLength(13)>
        Public Property airspace_analysis As String
        <MaxLength(1)>
        Public Property AOE As String
        <MaxLength(1)>
        Public Property Landing_Rights As String
        <MaxLength(1)>
        Public Property mil_civil_agreement As String
        <MaxLength(1)>
        Public Property mil_landing_rights As String

        <MaxLength(2)>
        Public Property inspection_method As String
        <MaxLength(1)>
        Public Property inspection_group As String
        <MaxLength(8)>
        Public Property last_inspection As String
        <MaxLength(8)>
        Public Property last_inspection_request As String

        <Schema.Column("fuel")>
        <MaxLength(40)>
        Private Property _fuel As String
        <Schema.NotMapped>
        Public WriteOnly Property fuel As String
            Set(value As String)
                Dim lst As New List(Of String)
                For i As Integer = 1 To value.Length Step 5
                    Dim len As Integer = IIf(value.Length + 1 - i < 5, value.Length + 1 - i, 5)
                    lst.Add(value.Substring(i - 1, len).Trim(" "))
                Next
                _fuel = String.Join(",", lst.ToArray)
            End Set
        End Property
        <Schema.NotMapped>
        Public ReadOnly Property fuel_list As List(Of String)
            Get
                Return _fuel.Split(",").ToList
            End Get
        End Property

        <MaxLength(5)>
        Public Property airframe_repair_service As String
        <MaxLength(5)>
        Public Property powerplant_repair_service As String
        <MaxLength(8)>
        Public Property oxygen_bottle_service As String
        <MaxLength(8)>
        Public Property oxygen_bulk_service As String

        <MaxLength(7)>
        Public Property light_schedule As String
        <MaxLength(7)>
        Public Property beacon_schedule As String
        <MaxLength(1)>
        Public Property has_tower As String
        <MaxLength(7)>
        Public Property radio_unicom As String
        <MaxLength(7)>
        Public Property radio_common As String
        <MaxLength(4)>
        Public Property segmented_circle As String
        <MaxLength(3)>
        Public Property beacon_color As String
        <MaxLength(1)>
        Public Property non_commericial_landing_fee As String
        <MaxLength(1)>
        Public Property medical_use As String

        <MaxLength(3)>
        Public Property single_engine_GA_based As String
        <MaxLength(3)>
        Public Property multi_engine_GA_based As String
        <MaxLength(3)>
        Public Property jet_engine_based As String
        <MaxLength(3)>
        Public Property helicopter_GA_based As String
        <MaxLength(3)>
        Public Property gliders_based As String
        <MaxLength(3)>
        Public Property military_based As String
        <MaxLength(3)>
        Public Property ultralight_based As String

        <MaxLength(6)>
        Public Property commerical_services As String
        <MaxLength(6)>
        Public Property commuter_services As String
        <MaxLength(6)>
        Public Property air_taxi As String
        <MaxLength(6)>
        Public Property GA_local As String
        <MaxLength(6)>
        Public Property GA_itinerant As String
        <MaxLength(6)>
        Public Property military_ops As String
        <MaxLength(10)>
        Public Property annual_ops As String

        <MaxLength(16)>
        Public Property position_source As String
        <MaxLength(10)>
        Public Property position_source_date As String
        <MaxLength(16)>
        Public Property elevation_source As String
        <MaxLength(10)>
        Public Property elevation_source_date As String
        <MaxLength(1)>
        Public Property contract_fuel As String

        <MaxLength(12)>
        Public Property storage_available As String
        <Schema.NotMapped>
        Public ReadOnly Property storage_available_list As List(Of String)
            Get
                Dim lst As New List(Of String)
                For i As Integer = 1 To storage_available.Length Step 4
                    lst.Add(storage_available.Substring(i - 1, 4).Trim())
                Next
                Return lst
            End Get
        End Property

        <MaxLength(71)>
        Public Property available_services As String
        <Schema.NotMapped>
        Public ReadOnly Property available_services_list As List(Of String)
            Get
                Return available_services.Split(",").ToList
            End Get
        End Property

        <MaxLength(3)>
        Public Property wind_indicator As String
        <MaxLength(7)>
        Public Property icao_ident

    End Class

End Namespace
