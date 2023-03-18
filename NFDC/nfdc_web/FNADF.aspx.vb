
Partial Class FNADF
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim FP As String = Server.MapPath("FlightNavADF.apk")
        Dim FI As New IO.FileInfo(FP)

        Response.ClearContent()
        Response.AddHeader("Content-Disposition", "attachement; filename=" & FI.Name)
        Response.AddHeader("Content-Length", FP.Length)
        Response.ContentType = "application/vnd.android.package-archive"
        Response.Flush()
        Response.End()
    End Sub
End Class
