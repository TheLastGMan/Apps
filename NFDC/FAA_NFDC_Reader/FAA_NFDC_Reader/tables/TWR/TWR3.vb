Public Class TWR3

    Public Function Process(ByRef line As String) As Entity.TWR3
        Dim twr As New Entity.TWR3

        With twr
            .icao = GetPart(line, 5, 4)
            .radio_1 = GetPart(line, 9, 44)
            .radio_use_1 = GetPart(line, 53, 50)
            .radio_2 = GetPart(line, 103, 44)
            .radio_use_2 = GetPart(line, 147, 50)
            .radio_3 = GetPart(line, 197, 44)
            .radio_use_3 = GetPart(line, 241, 50)
            .radio_4 = GetPart(line, 291, 44)
            .radio_use_4 = GetPart(line, 335, 50)
            .radio_5 = GetPart(line, 385, 44)
            .radio_use_5 = GetPart(line, 429, 50)
            .radio_6 = GetPart(line, 479, 44)
            .radio_use_6 = GetPart(line, 523, 50)
            .radio_7 = GetPart(line, 573, 44)
            .radio_use_7 = GetPart(line, 617, 50)
            .radio_8 = GetPart(line, 667, 44)
            .radio_use_8 = GetPart(line, 711, 50)
            .radio_9 = GetPart(line, 761, 44)
            .radio_use_9 = GetPart(line, 805, 50)
            .special_use_1 = GetPart(line, 855, 60)
            .special_use_2 = GetPart(line, 915, 60)
            .special_use_3 = GetPart(line, 975, 60)
            .special_use_4 = GetPart(line, 1035, 60)
            .special_use_5 = GetPart(line, 1095, 60)
            .special_use_6 = GetPart(line, 1155, 60)
            .special_use_7 = GetPart(line, 1215, 60)
            .special_use_8 = GetPart(line, 1275, 60)
            .special_use_9 = GetPart(line, 1335, 60)
        End With

        Return twr
    End Function

End Class
