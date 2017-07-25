Partial Public Class ctlMasterMenu
    Inherits System.Web.UI.UserControl

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim sPageName As String, sNameLen As String, sRF As String = My.Settings.RootAppFolder.ToString
        Dim sLinkPrepend As String = "", BL As New BusinessLogic
        'sPageName = Request.Path.Substring(Request.Path.LastIndexOf("/") + 1)
        sLinkPrepend = BL.GetRootURLPrepend(Page.AppRelativeTemplateSourceDirectory.ToString)
        sPageName = Replace(Right(Request.Path.ToString, Len(Request.Path.ToString) - 1), sRF, "")
        sNameLen = Len(sPageName).ToString
        dscMenu.SelectCommand = "SELECT Menu.Text, '" & sLinkPrepend & "' + Menu.UrlLink AS UrlLink, " & _
                "CASE WHEN REPLACE(Menu.UrlLink, '/', '') = '" & sPageName & "' THEN 'flyOutSelected' ELSE 'flyOut' END AS ButtonStyle, " & _
                "CASE WHEN REPLACE(Menu.UrlLink, '/', '') = '" & sPageName & "' THEN 'flyOverSelected' ELSE 'flyOver' END AS HoverStyle " & _
                "FROM Menu WHERE IsActive = 1 ORDER BY MenuOrder"
    End Sub
End Class