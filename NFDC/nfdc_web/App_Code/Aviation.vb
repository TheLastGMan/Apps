Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Aviation
     Inherits System.Web.Services.WebService

    Private AFD As New AFD

    <WebMethod()> _
    Public Function Airport_Communications(ByVal ICAO As String, ByVal Direction As AFD.ArrDep, ByVal username As String, ByVal password As String) As AirportCommunication
        Return AFD.Airport_Communications(ICAO, Direction, username, password)
    End Function

    <WebMethod()> _
    Public Function Airport_LatitudeLongitude(ByVal ICAO As String, ByVal username As String, ByVal password As String) As AFD.LatLon
        Return AFD.Airport_LatLong(ICAO)
    End Function

    <WebMethod()> _
    Public Function Effective_Date() As String
        Return AFD.Effective
    End Function

    <WebMethod()> _
    Public Function Close_Airports(ByVal ICAO As String, ByVal username As String, ByVal password As String) As List(Of AFD.CloseAirports)
        Return AFD.Close_Airports(ICAO)
    End Function

    <WebMethod()> _
    Public Function Close_Navs(ByVal ICAO As String, ByVal username As String, ByVal password As String) As List(Of AFD.CloseNav)
        Return AFD.Close_Navaids(ICAO)
    End Function

    <WebMethod()> _
    Public Function Close_Navs_GPS(ByVal latitude As Decimal, ByVal longitude As Decimal, ByVal username As String, ByVal password As String) As List(Of AFD.CloseNav)
        Return AFD.Close_Navaids(latitude, longitude)
    End Function

End Class