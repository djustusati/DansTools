Imports System.Data.SqlClient

Namespace MetrixStuff
    Public Class MissingSurveySessionLookup
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not (Page.IsPostBack) Then
                'Me.TextboxSearchDate.Text = Now.Date
                'CalculateStartEndSearchDates(TextboxSearchDate.Text)
            End If
        End Sub

        Private Sub CalculateStartEndSearchDates(ByVal searchDate As Date)
            Me.TextboxSearchFromDate.Text = searchDate.AddDays(-2).ToString("MM/dd/yyyy hh:mm")
            Me.TextboxSearchToDate.Text = searchDate.AddDays(2).AddHours(8).ToString("MM/dd/yyyy hh:mm")
        End Sub

        Protected Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
            PopulateJupiterMobileData()
        End Sub

        Private Sub PopulateJupiterMobileData()
            Dim connString = ConfigurationManager.ConnectionStrings("JupiterMobile").ConnectionString
            If (connString = String.Empty) Then
                Throw New ConfigurationErrorsException("Connection String error")
            End If
            Dim sqlConn As New SqlConnection(connString)
            Dim dataSet = New DataSet
            Dim dataAdapter As SqlDataAdapter = New SqlDataAdapter(LoadQueryJupiterMobileData(), sqlConn)
            dataAdapter.Fill(dataSet)
            GridViewJupiterMobileData.DataSource = dataSet
            GridViewJupiterMobileData.DataBind()
            GridViewRecapDcdData.DataSource = Nothing
            GridViewRecapDcdData.DataBind()
            GridViewSurveySessionTotals.DataSource = Nothing
            GridViewSurveySessionTotals.DataBind()
        End Sub

        Private Sub PopulateRecapDcdData(ByVal recapId As Integer)
            Dim connString = ConfigurationManager.ConnectionStrings("MetrixWeb").ConnectionString
            If (connString = String.Empty) Then
                Throw New ConfigurationErrorsException("Connection String error")
            End If
            Dim sqlConn As New SqlConnection(connString)
            Dim dataSet = New DataSet
            Dim dataAdapter As SqlDataAdapter = New SqlDataAdapter(LoadQueryRecapDcdData(recapId), sqlConn)
            dataAdapter.Fill(dataSet)
            If (dataSet IsNot Nothing AndAlso dataSet.Tables.Count > 0) Then
                GridViewRecapDcdData.DataSource = dataSet.Tables(0)
                GridViewRecapDcdData.DataBind()
            End If
        End Sub

        Private Sub PopulateSurveySessionTotalData(ByVal surveySessionId As String)
            Dim connString = ConfigurationManager.ConnectionStrings("JupiterMobile").ConnectionString
            If (connString = String.Empty) Then
                Throw New ConfigurationErrorsException("Connection String error")
            End If
            Dim sqlConn As New SqlConnection(connString)
            Dim dataSet = New DataSet
            Dim dataAdapter As SqlDataAdapter = New SqlDataAdapter(LoadQuerySurveySessionTotals(surveySessionId), sqlConn)
            dataAdapter.Fill(dataSet)
            If (dataSet IsNot Nothing AndAlso dataSet.Tables.Count > 0) Then
                GridViewSurveySessionTotals.DataSource = dataSet.Tables(0)
                GridViewSurveySessionTotals.DataBind()
            End If
        End Sub

        Protected Sub ButtonUpdateSearchDates_Click(sender As Object, e As EventArgs) Handles ButtonUpdateSearchDates.Click
            CalculateStartEndSearchDates(TextboxSearchDate.Text)
        End Sub

        Protected Function LoadQueryJupiterMobileData() As String
            Return String.Format("SELECT DCD.RecapId, DCD.TotalSurveys, COUNT(1) TotalInteractions, MIN(I.StartTime) AS StartTime, I.ActivityId, I.AccountName, I.InterviewerId, DCD.DCDNumber, I.SurveySessionId " & _
                                 "FROM Interaction I LEFT JOIN [MetrixWeb].dbo.RecapDCD DCD ON I.SurveySessionId = DCD.SurveySessionId " & _
                                 "WHERE I.InterviewerId LIKE '%{0}%' AND I.StartTime BETWEEN '{1}' and '{2}' AND ProductionCategory = 1 " & _
                                 "GROUP BY DCD.RecapId, DCD.TotalSurveys, I.ActivityId, I.AccountName, I.InterviewerId, I.SurveySessionId, DCD.DCDNumber " & _
                                 "ORDER BY MIN(I.StartTime)", TextboxSearchBaId.Text, TextboxSearchFromDate.Text, TextboxSearchToDate.Text)
        End Function

        Protected Function LoadQueryRecapDcdData(ByVal recapId As Integer) As String
            Return String.Format("SELECT R.ActivityId, DCD.Id AS [Id], DCD.RecapId, DCD.DCDNumber, DCD.TotalSurveys, DCD.AS2124, DCD.AS2529, DCD.AS30Plus, DCD.Email, DCD.Phone, " & _
                                 "DCD.TotalCheckIns, DCD.BAId, DCD.SurveySessionId, DCD.EmployeeId, DCD.Status, DCD.IsRemoved " & _
                                 "FROM RecapDCD DCD JOIN Recap R ON DCD.RecapId = R.Id WHERE RecapId = {0}", recapId.ToString())
        End Function

        Protected Function LoadQuerySurveySessionTotals(ByVal surveySessionId As String) As String
            Return string.Format("EXEC GetMetrixWebRecapDCD '{0}'", surveySessionId)
        End Function

        Private Sub GridViewJupiterMobileData_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridViewJupiterMobileData.RowCommand
            Dim recapId As Integer = 0

            If (e.CommandName = "DisplaySessionTotals") Then
                If (Not String.IsNullOrEmpty(e.CommandArgument.ToString())) Then
                    PopulateSurveySessionTotalData(e.CommandArgument.ToString())
                End If
            Else
                Integer.TryParse(e.CommandArgument, recapId)

                If (recapId > 0) Then
                    PopulateRecapDcdData(recapId)
                End If
            End If
        End Sub

        Protected Sub TextboxSearchDate_TextChanged(sender As Object, e As EventArgs) Handles TextboxSearchDate.TextChanged
            CalculateStartEndSearchDates(TextboxSearchDate.Text)
        End Sub

    End Class
End Namespace