Public Partial Class divpopup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'add functionality to the "close" image in the popup div
            Me.btnUpdateMenu.Attributes.Add("onClick", "document.all['divUpdatePopup'].style.visibility='hidden';")
            'use the code below to disable editing of the menu id field in the popup div
            Me.txtEditMenuID.Attributes.Add("onKeyPress", "javascript:return false;")
        End If
    End Sub

    Protected Sub btnUpdateMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateMenu.Click
        Dim conDB As New System.Data.SqlClient.SqlConnection
        Try
            lblErrMsg.Text = ""
            conDB.ConnectionString = ConfigurationManager.ConnectionStrings("PPPConnectionString").ConnectionString
            Dim cmd As New System.Data.SqlClient.SqlCommand("UPDATE tblMenu SET MenuText=@MenuText WHERE MenuID=@MenuID", conDB)
            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandTimeout = 300
            cmd.Parameters.AddWithValue("@MenuID", Me.txtEditMenuID.Text)
            cmd.Parameters.AddWithValue("@MenuText", Me.txtEditMenuText.Text)
            conDB.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            lblErrMsg.Text = "<b>Error:</b><br />" + ex.Message.ToString
        Finally
            dscTest.DataBind()
            grdMenu.DataBind()
            conDB.Close()
            conDB.Dispose()
        End Try

    End Sub
End Class