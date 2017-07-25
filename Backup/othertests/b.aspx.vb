
Partial Class b
    Inherits System.Web.UI.Page
    Public cbCount As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Define a StringBuilder to hold messages to output.
        'Dim sb As New StringBuilder()

        '' Check if this is a postback.
        'sb.Append("No page postbacks have occurred.")
        'If (Page.IsPostBack) Then
        '    sb.Append("A page postback has occurred.")
        'End If

        '' Write out any messages.
        'MyLabel.Text = sb.ToString()

        '' Get a ClientScriptManager reference from the Page class.
        'Dim cs As ClientScriptManager = Page.ClientScript

        '' Define one of the callback script's context.
        '' The callback script will be defined in a script block on the page.
        'Dim context1 As New StringBuilder()
        'context1.Append("function ReceiveServerData1(arg, context)")
        'context1.Append("{")
        'context1.Append("Message1.innerText =  arg;")
        'context1.Append("value1 = arg;")
        'context1.Append("}")

        '' Define callback references.
        'Dim cbReference1 As String = cs.GetCallbackEventReference(Me, "arg", "ReceiveServerData1", context1.ToString())
        'Dim cbReference2 As String = cs.GetCallbackEventReference("'" & Page.UniqueID & "'", "arg", "ReceiveServerData2", "", "ProcessCallBackError", False)
        'Dim callbackScript1 As String = "function CallTheServer1(arg) {" + cbReference1 + "; }"
        'Dim callbackScript2 As String = "function CallTheServer2(arg, context) {" + cbReference2 + "; }"

        '' Register script blocks will perform call to the server.
        'cs.RegisterClientScriptBlock(Me.GetType(), "CallTheServer1", callbackScript1, True)
        'cs.RegisterClientScriptBlock(Me.GetType(), "CallTheServer2", callbackScript2, True)
    End Sub

    '' Define method that processes the callbacks on server.
    'Public Sub RaiseCallbackEvent(ByVal eventArgument As String) _
    '            Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent

    '    'Dim conDB As New System.Data.SqlClient.SqlConnection
    '    'Try
    '    '    conDB.ConnectionString = ConfigurationManager.ConnectionStrings("PPPConnectionString").ConnectionString
    '    '    Dim cmd As New System.Data.SqlClient.SqlCommand( _
    '    '            "SELECT firstname, lastname from [gmr-jupiter].dbo.tbl_user where firstname like '%" & Me.txtFirstName.Text & "%' order by lastname, firstname", conDB)
    '    '    cmd.CommandType = System.Data.CommandType.Text
    '    '    cmd.CommandTimeout = 300
    '    '    conDB.Open()
    '    '    Dim dr As System.Data.SqlClient.SqlDataReader = cmd.ExecuteReader()
    '    '    If dr.HasRows Then
    '    '        ddlUsers.Items.Clear()
    '    '        Dim newddl As New DropDownList
    '    '        newddl.ID = "ddlUserList"
    '    '        While dr.Read
    '    '            newddl.Items.Add(dr("firstname") & " " & dr("lastname"))
    '    '        End While
    '    '        'newddl.RenderControl(
    '    '    Else
    '    '        cbCount = 100
    '    '    End If

    '    'Catch ex As Exception
    '    'Finally
    '    '    conDB.Close()
    '    '    conDB.Dispose()
    '    'End Try

    '    'cbCount = Convert.ToInt32(eventArgument) + 1
    'End Sub

    '' Define method that returns callback result.
    'Public Function GetCallbackResult() As String _
    '            Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult

    '    Return cbCount.ToString()

    'End Function

    Protected Sub PWComplexityChange(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.lblComplexity.Text = CType(sender, LinkButton).Text
    End Sub

    Protected Sub btnGeneratePassword_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim conDB As New System.Data.SqlClient.SqlConnection
        Try
            conDB.ConnectionString = ConfigurationManager.ConnectionStrings("PPPConnectionString").ConnectionString
            Dim cmd As New System.Data.SqlClient.SqlCommand("spGeneratePassword", conDB)
            cmd.CommandType = System.Data.CommandType.StoredProcedure
            cmd.CommandTimeout = 300
            cmd.Parameters.AddWithValue("@len", CInt(Me.txtPassLen.Text))
            cmd.Parameters.AddWithValue("@password_type", Me.lblComplexity.Text)
            cmd.Parameters.Add("@ReturnPassword", System.Data.SqlDbType.VarChar, 25).Direction = System.Data.ParameterDirection.Output
            conDB.Open()
            cmd.ExecuteNonQuery()
            Me.txtNewPassword.Text = cmd.Parameters.Item("@ReturnPassword").Value
        Catch ex As Exception
            Response.Write("<b>Error:</b><br />" + ex.Message.ToString)
        Finally
            conDB.Close()
            conDB.Dispose()
        End Try
    End Sub
End Class
