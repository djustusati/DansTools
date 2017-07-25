Public Partial Class listadgroup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim svcAD As New adfunctions
            Dim ds As DataSet = svcAD.LoadGroupNames("")
            ddlGroups.DataSource = ds
            ddlGroups.DataValueField = "Name"
            ddlGroups.DataTextField = "Name"
            ddlGroups.DataBind()
            grdADUserList.DataSource = ds
            grdADUserList.DataBind()
        End If
    End Sub

    Protected Sub ibtnSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnSearch.Click
        Dim svcAD As New adfunctions
        Dim strSearch As String = ddlGroups.Text.ToString
        Dim ds As DataSet = svcAD.LoadGroupUsers("Security Groups", strSearch)
        grdADUserList.DataSource = ds
        grdADUserList.DataBind()
    End Sub

    Protected Sub ddlGroups_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlGroups.SelectedIndexChanged
        Dim svcAD As New adfunctions
        Dim strSearch As String = ddlGroups.SelectedValue.ToString
        Dim ds As DataSet = svcAD.LoadGroupUsers("Security Groups", strSearch)
        grdADUserList.DataSource = ds
        grdADUserList.DataBind()
    End Sub

    Protected Sub ibtnExportList_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnExportList.Click
        ExportGridviewToExcel()
    End Sub

    Protected Sub ExportGridviewToExcel()
        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=Report.xls")
        Response.Charset = ""
        'If you want the option to open the Excel file without saving then
        'comment out the line below
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.xls"
        Dim sWrite As New System.IO.StringWriter
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(sWrite)
        grdADUserList.RenderControl(htmlWrite)
        Response.Write(sWrite.ToString)
        Response.End()
    End Sub

    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        '/* Confirms that an HtmlForm control is rendered for the specified ASP.NET
        'server control at run time. */
    End Sub
End Class