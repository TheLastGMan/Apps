Public Class NAV2

    Public Function Process(ByRef line As String) As Entity.NAV2
        Dim nav As New Entity.NAV2

        With nav
            .icao = GetPart(line, 5, 4)
            .type = GetPart(line, 9, 20)
            .Remarks = GetPart(line, 29, 600)
        End With

        Return nav
    End Function

End Class
