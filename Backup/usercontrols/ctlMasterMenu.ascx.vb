Public Partial Class ctlMasterMenu
    Inherits System.Web.UI.UserControl

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim sPageName As String, sNameLen As String, sRF As String = My.Settings.RootAppFolder.ToString
        Dim sLinkPrepend As String = "", BL As New BusinessLogic
        'sPageName = Request.Path.Substring(Request.Path.LastIndexOf("/") + 1)
        sLinkPrepend = BL.GetRootURLPrepend(Page.AppRelativeTemplateSourceDirectory.ToString)
        sPageName = Replace(Right(Request.Path.ToString, Len(Request.Path.ToString) - 1), sRF, "")
        sNameLen = Len(sPageName).ToString
        dscMenu.SelectCommand = "SELECT tblMenu.MenuText, '" & sLinkPrepend & "' + tblMenu.MenuLink AS MenuLink, " & _
                "CASE WHEN REPLACE(tblMenu.MenuLink, '/', '') = '" & sPageName & "' THEN 'flyOutSelected' ELSE 'flyOut' END AS ButtonStyle, " & _
                "CASE WHEN REPLACE(tblMenu.MenuLink, '/', '') = '" & sPageName & "' THEN 'flyOverSelected' ELSE 'flyOver' END AS HoverStyle " & _
                "FROM tblMenu ORDER BY tblMenu.MenuOrder"
    End Sub
End Class