Imports System.Data.SqlClient

Partial Public Class menueditor
    Inherits System.Web.UI.Page

    Private Sub btnAddNewMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNewMenu.Click

        Dim adoConn As New SqlConnection(ConfigurationManager.ConnectionStrings("ToolsConnectionString").ToString)
        Try
            Dim adoCmd As New SqlCommand()
            adoCmd.Connection = adoConn
            adoCmd.CommandType = CommandType.StoredProcedure
            adoCmd.CommandText = "spAddMenuItem"
            adoConn.Open()
            ' Create a SqlParameter for each parameter in the stored procedure.
            adoCmd.Parameters.AddWithValue("@pMenuText", txtNewMenuText.Text.ToString)
            adoCmd.Parameters.AddWithValue("@pMenuLink", txtNewMenuLink.Text.ToString)
            adoCmd.Parameters.AddWithValue("@pMenuOrder", CType(txtNewMenuOrder.Text, Integer))
            adoCmd.ExecuteNonQuery()
        Catch ex As Exception

        Finally
            adoConn.Close()
            adoConn.Dispose()
            txtNewMenuLink.Text = ""
            txtNewMenuOrder.Text = ""
            txtNewMenuText.Text = ""
            dscMenuList.DataBind()
            grdMenuItems.DataBind()
        End Try

    End Sub
End Class