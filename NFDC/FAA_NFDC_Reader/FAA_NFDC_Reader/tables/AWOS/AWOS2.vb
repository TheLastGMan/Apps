Public Class AWOS2

    Public Function Process(ByRef line As String) As Entity.AWOS2
        Dim awos As New Entity.AWOS2

        With awos
            .icao = GetPart(line, 6, 4)
            .type = GetPart(line, 10, 10)
            .remarks = GetPart(line, 20, 236)
        End With

        Return awos
    End Function

End Class
