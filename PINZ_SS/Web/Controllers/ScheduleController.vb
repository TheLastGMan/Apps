Imports System.Net

Namespace Web
    Public Class ScheduleController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /Schedule

        Function Index() As ActionResult
            Dim model As New ScheduleModel

            'set up yes/no values
            Dim yesno As New List(Of SelectListItem)
            yesno.Add(New SelectListItem With {.Value = False, .Text = "No"})
            yesno.Add(New SelectListItem With {.Value = True, .Text = "Yes"})
            model.YesNoCB = yesno

            'set up department
            Dim lst As New List(Of SelectListItem)
            lst.Add(New SelectListItem With {.Value = "120031722", .Text = "Bowl Desk", .Selected = True})
            lst.Add(New SelectListItem With {.Value = "120031723", .Text = "Arcade"})
            lst.Add(New SelectListItem With {.Value = "120031724", .Text = "Party Host"})
            lst.Add(New SelectListItem With {.Value = "120031725", .Text = "Event Coordinator"})
            model.Departments = lst

            Return View(model)
        End Function

        <HttpPost>
        Function Index(ByVal model As ScheduleModel) As ActionResult
            'log in using my info: TODO, ask for theirs
            LogIn("Pepse25", "HSRustydog08")

            'generate url
            Dim surl As String = GenerateURL(model)

            'download page
            Dim out As String = DownloadPage(surl)

            'return raw html from download
            Return View("StrRaw", DirectCast(out, Object))
        End Function

        <NonAction>
        Private Function DownloadPage(ByRef url As String) As String
            Dim source As String = New WebClient().DownloadString(url)
            Return source
        End Function

        <NonAction>
        Private Sub LogIn(ByRef username As String, ByRef password As String)
            'log into website (post)
            Dim loginurl As String = "http://www.hotschedules.com/hs/login.hs?srvid=14&timestamp=" & Now.AddSeconds(-30).Ticks
            Dim postdata As String = "username=" & username & "&password=" & password
            Dim postdatabytes() As Byte = System.Text.UTF8Encoding.UTF8.GetBytes(postdata)
            Dim wr As HttpWebRequest
            wr = HttpWebRequest.Create(loginurl)
            wr.Method = "POST"
            wr.ContentType = "application/x-www-form-urlencoded"
            wr.ContentLength = postdatabytes.Length
            wr.UserAgent = "Mozilla/5.0 (iPad; U; CPU OS 3_2_1 like Mac OS X; en-us) AppleWebKit/531.21.10 (KHTML, like Gecko) Mobile/7B405"
            wr.KeepAlive = False
            wr.Timeout = 5000
            wr.ProtocolVersion = HttpVersion.Version11
            wr.AllowWriteStreamBuffering = False

            Try
                Using s = wr.GetRequestStream
                    s.Write(postdatabytes, 0, postdatabytes.Length)
                End Using
                Dim result = wr.GetResponse
            Catch ex As Exception
                Dim out As String = ""
                Dim ex1 As Exception = ex
                Dim msgid As Integer = 1
                Do
                    out &= vbCrLf & vbCrLf
                    out &= "MSG " & msgid & ": " & ex1.Message
                    ex1 = ex1.InnerException
                Loop While (ex1 IsNot Nothing)
                Throw New Exception(out & vbCrLf & "Stack Trace: " & ex.StackTrace)
            End Try

        End Sub

        <NonAction>
        Private Function GenerateURL(ByRef model As ScheduleModel) As String
            Dim SB As New StringBuilder
            SB.Append("http://www.hotschedules.com/hs/report.hs")
            SB.Append(KeyValue("calDate", Now.Day, "?"))
            SB.Append(KeyValue("calYear", Now.Year))
            SB.Append(KeyValue("calMonth", Now.Month - 1))
            SB.Append(KeyValue("changeDate", "null"))
            SB.Append(KeyValue("month", 0))
            SB.Append(KeyValue("year", Now.Year))
            SB.Append(KeyValue("empColumn", ""))
            SB.Append(KeyValue("combineSchedules", ""))
            SB.Append(KeyValue("reportType", 19))
            SB.Append(KeyValue("showInTime", B2I(model.ShowInTime)))
            SB.Append(KeyValue("sortByFirstname", 1))
            SB.Append(KeyValue("showRequests", 1))
            SB.Append(KeyValue("showFirstname", B2I(model.ShowFirstNames)))
            SB.Append(KeyValue("showLastname", B2I(model.ShowLastNames)))
            SB.Append(KeyValue("showJobs", B2I(model.Jobs)))
            SB.Append(KeyValue("showTelephone", B2I(model.Telephone)))
            SB.Append(KeyValue("showAvailabilities", B2I(model.Availability)))
            SB.Append(KeyValue("sortColumn", 0))
            SB.Append(KeyValue("reportTitle", "Schedule"))
            SB.Append(KeyValue("startDate", model.StartDate.ToString("M/d/yyyy")))
            SB.Append(KeyValue("endDate", model.EndDate.ToString("M/d/yyyy")))
            SB.Append(KeyValue("showOutTime", B2I(model.ShowOutTime)))
            SB.Append(KeyValue("showLocations", 1))
            SB.Append(KeyValue("showUnscheduledEmployees", B2I(model.Unscheduled)))
            SB.Append(KeyValue("rolesCount", 1))
            SB.Append(KeyValue("trade-reason-list", 1))
            SB.Append(KeyValue("trade-reason-free", "no reason"))
            SB.Append(KeyValue("shiftsCount", 2))
            SB.Append(KeyValue("client_shift", 120031766))
            SB.Append(KeyValue("client_shift", 120038222))
            SB.Append(KeyValue("client_role", model.department))
            'SB.Append(KeyValue("JSESSIONID", ""))
            SB.Append(KeyValue("svrid", New Random().Next(1, 42)))
            SB.Append(KeyValue("timestamp", model.timestamp))

            Dim furl As String = SB.ToString

            Return furl
        End Function

        <NonAction>
        Private Function B2I(ByVal bool As Boolean) As Integer
            Return IIf(bool, 1, 0)
        End Function

        <NonAction>
        Private Function KeyValue(ByRef key As String, ByRef value As String, Optional ByVal prefix As String = "&") As String
            Dim out As String = String.Format("{0}{1}={2}", prefix, key, Url.Encode(value))
            Return out
        End Function

    End Class
End Namespace
