Public Class Settings

    Public Port As Byte
    Public Server As String
    Public Username As String
    Public Password As String


    Public Sub load_settings()
        Dim cont As String() = System.IO.File.ReadAllLines("settings.txt")
        Dim IPH As System.Net.IPHostEntry
        Dim IPa() As System.Net.IPAddress
        IPH = System.Net.Dns.GetHostEntry(cont(1))
        IPa = IPH.AddressList
        Port = Byte.Parse(cont(0))
        Server = IPa(0).ToString
        Username = cont(2)
        Password = cont(3)
    End Sub

End Class
