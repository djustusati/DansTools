Imports System.Data
Imports System.Data.SqlClient

Partial Public Class parentchildrepeater
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PopulateList()
        End If
    End Sub

    Private Sub PopulateList()
        Dim sSql As String = "SELECT UserID, FirstName, LastName, FirstName + ' ' + LastName AS FullName, LastName + ', ' + FirstName AS FormattedName " _
                & "FROM [gmr-jupiter].dbo.tbl_User WHERE UserID IN (SELECT UserID FROM tblUserMenu) " _
                & "ORDER BY LastName, FirstName"
        Dim cnConn As New SqlConnection(ConfigurationManager.ConnectionStrings("PPPConnectionString").ToString)
        Dim drData As New SqlDataAdapter(sSql, cnConn)
        Dim dsData As New DataSet

        drData.Fill(dsData, "Users")
        sSql = "SELECT     UM.UserID, UM.MenuID, M.MenuText, M.MenuOrder " _
                & "FROM         tblUserMenu AS UM INNER JOIN " _
                & "tblMenu AS M ON UM.MenuID = M.MenuID " _
                & "ORDER BY UM.UserID, M.MenuOrder"
        Dim drData2 As New SqlDataAdapter(sSql, cnConn)
        drData2.Fill(dsData, "UserMenu")
        dsData.Relations.Add("relUserMenu", dsData.Tables("Users").Columns("UserID"), dsData.Tables("UserMenu").Columns("UserID"))
        Me.rptParent.DataSource = dsData.Tables("Users")
        Me.rptParent.DataBind()
        'Me.rptChild.DataSource = dsData.Tables("UserMenu")
        'Me.rptChild.DataBind()
        cnConn.Close()
    End Sub

    Private Sub rptParent_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptParent.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim drv As DataRowView = CType(e.Item.DataItem, DataRowView)
            Dim nUID As Integer = CInt(drv("UserID"))
            Dim rChild As Repeater = CType(e.Item.FindControl("rptChild"), Repeater)
            rChild.DataSource = drv.CreateChildView("relUserMenu")
            rChild.DataBind()
        End If
    End Sub
End Class