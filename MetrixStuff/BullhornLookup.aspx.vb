Imports System.Drawing
Imports System.Data.SqlClient

Namespace MetrixStuff

    Public Class BullhornLookup
        Inherits System.Web.UI.Page
        Private RowColors = New List(Of Color) From {{Color.Bisque}, {Color.Orange}, {Color.SkyBlue}, {Color.Aqua}}
        Private CurrentRowColorNumberBase As Integer = 2
        Private LastEmpId As String = ""

        Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
            BullhornDB.DataBind()
            grdvwBullhornData.Visible = True
            grdvwBudgetCodeData.DataSource = Nothing
            grdvwBudgetCodeData.DataBind()
        End Sub

        Private Sub grdvwBullhornData_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdvwBullhornData.RowCommand
            Dim budgetCode As String = ""

            If (e.CommandName = "DisplayProgram") Then
                If (Not String.IsNullOrEmpty(e.CommandArgument.ToString())) Then
                    PopulateBudgetCodeData(e.CommandArgument.ToString())
                End If
            End If
        End Sub

        Private Sub grdvwBullhornData_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdvwBullhornData.RowDataBound
            If (e.Row.RowType = DataControlRowType.DataRow) Then
                Dim drv As DataRowView = e.Row.DataItem
                If (drv("GMREmployeeID").ToString() <> LastEmpId) Then
                    If CurrentRowColorNumberBase = 2 Then
                        CurrentRowColorNumberBase = 0
                    Else
                        CurrentRowColorNumberBase = 2
                    End If
                    LastEmpId = drv("GMREmployeeID").ToString()
                End If
                e.Row.BackColor = RowColors(CurrentRowColorNumberBase + e.Row.RowIndex Mod 2)

                'Grey out inactive rows
                If (drv("StartDate1") > DateTime.Now OrElse drv("EndDate1") < DateTime.Now) Then
                    e.Row.ForeColor = Drawing.Color.Gray
                End If
            End If
        End Sub

        Private Sub PopulateBudgetCodeData(ByVal budgetCode As String)
            Dim connString = ConfigurationManager.ConnectionStrings("MetrixWeb").ConnectionString
            If (connString = String.Empty) Then
                Throw New ConfigurationErrorsException("Connection String error")
            End If
            Dim sqlConn As New SqlConnection(connString)
            Dim dataSet = New DataSet
            Dim dataAdapter As SqlDataAdapter = New SqlDataAdapter(LoadQueryBudgetCodeData(budgetCode), sqlConn)
            dataAdapter.Fill(dataSet)
            If (dataSet IsNot Nothing AndAlso dataSet.Tables.Count > 0) Then
                grdvwBudgetCodeData.DataSource = dataSet.Tables(0)
                grdvwBudgetCodeData.DataBind()
                grdvwBudgetCodeData.Visible = True
            Else 
                grdvwBudgetCodeData.DataSource = Nothing
                grdvwBudgetCodeData.DataBind()
            End If
        End Sub

        Protected Function LoadQueryBudgetCodeData(ByVal budgetCode As String) As String
            Return String.Format("SELECT BC.Id, BC.Code, BC.Name, BC.ProgramId, P.ShortName, BC.IsActive, BC.IsPending, BC.CreatedDateTime, BC.ModifiedDateTime, BC.[Version] " & _
                                 "FROM BudgetCode BC JOIN Program P ON BC.ProgramId = P.Id " & _
                                 "WHERE Code = '{0}'", budgetCode)
        End Function

    End Class
End Namespace