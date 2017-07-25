Imports System.Data.SqlClient
Imports System.Drawing

Public Class RecapDcrResearch
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ButtonSearch_OnClick(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        Dim oldRecapId As Integer = 0
        Dim newRecapId As Integer = 0
        If (Not String.IsNullOrWhiteSpace(TextboxOldRecapId.Text)) Then
            oldRecapId = TextboxOldRecapId.Text
        End If
        If (Not String.IsNullOrWhiteSpace(TextboxNewRecapId.Text)) Then
            newRecapId = TextboxNewRecapId.Text
        End If

        PopulateGrids(oldRecapId, newRecapId)
    End Sub

    Protected Sub PopulateGrids(ByVal oldRecapId As Integer, ByVal newRecapId As Integer)
        Dim oldDcdDataset As DataSet = GetRecapDcdData(oldRecapId)
        Dim newDcdDataset As DataSet = GetRecapDcdData(newRecapId)

        GridViewOldDcdData.DataSource = oldDcdDataset
        GridViewNewDcdData.DataSource = newDcdDataset

        GridViewOldDcdData.DataBind()
        GridViewNewDcdData.DataBind()

        Dim checkDcrData As DataSet = GetDcrCheckData(oldRecapId)
        If checkDcrData.Tables.Count > 0 Then
            GridViewDcrRecapDcd.DataSource = checkDcrData.Tables(0)
            GridViewDcrRecapDcd.DataBind()

            If (Not IsNothing(checkDcrData.Tables(1))) Then
                GridViewDcrRequest.DataSource = checkDcrData.Tables(1)
                GridViewDcrRequest.DataBind()
            End If

            If (Not IsNothing(checkDcrData.Tables(2))) Then
                GridViewDcrRequestItems.DataSource = checkDcrData.Tables(2)
                GridViewDcrRequestItems.DataBind()
            End If

        End If
    End Sub

    Private Function GetRecapDcdData(ByVal recapId As Integer) As DataSet
        Dim connString = ConfigurationManager.ConnectionStrings("MetrixWeb").ConnectionString
        If (connString = String.Empty) Then
            Throw New ConfigurationErrorsException("Connection String error")
        End If
        Dim sqlConn As New SqlConnection(connString)
        Dim dataSet = New DataSet
        Dim dataAdapter As SqlDataAdapter = New SqlDataAdapter(GetRecapDcdQuery(recapId), sqlConn)
        dataAdapter.Fill(dataSet)

        Return dataSet
    End Function

    Private Function GetDcrCheckData(ByVal recapId As Integer) As DataSet
        Dim connString = ConfigurationManager.ConnectionStrings("MetrixWeb").ConnectionString
        If (connString = String.Empty) Then
            Throw New ConfigurationErrorsException("Connection String error")
        End If
        Dim sqlConn As New SqlConnection(connString)
        Dim dataSet = New DataSet
        Dim dataAdapter As SqlDataAdapter = New SqlDataAdapter(GetDcrCheckQuery(recapId), sqlConn)
        dataAdapter.Fill(dataSet)

        Return dataSet
    End Function

    Private Function GetRecapDcdQuery(ByVal recapId As Integer) As String
        Dim query As New StringBuilder()
        query.Append("SELECT V.Name, R.ActivityId, R.StartDateTime, DCD.Id, DCD.RecapId, DCD.DCDNumber, DCD.TotalSurveys, DCD.AS2124, DCD.AS2529, DCD.AS30Plus, DCD.Email, DCD.Phone, DCD.CreatedDateTime, DCD.BAId, DCD.SurveySessionId, DCD.EmployeeId, DCD.Status, DCD.IsRemoved, DCD.TotalCheckIns ")
        query.Append("FROM Recap R ")
        query.Append("JOIN Venue V ON R.VenueId = V.Id ")
        query.Append("LEFT JOIN RecapDCD DCD  ON DCD.RecapId = R.Id ")
        query.AppendFormat("WHERE R.Id = {0}", recapId)
        Return query.ToString()
    End Function

    Private Function GetDcrCheckQuery(ByVal recapId As Integer) As String
        Dim query As New StringBuilder
        query.AppendFormat("SELECT 'RecapDCD' AS [--table--], R.ActivityId, D.Id, RecapId, DCDNumber, TotalSurveys, SurveySessionId, BAId, EmployeeId, D.Status, D.IsRemoved INTO #RecapDCD FROM RecapDCD D JOIN Recap R ON D.RecapId = R.Id WHERE RecapId = {0}", recapId)
        query.AppendLine("SELECT 'DCR' AS [--table--], Id, RecapDCDId, Status, FieldCommentText, FieldCommentName, FieldCommentDate, (SELECT COUNT(1) FROM RecapDataCorrectionRequestItem WHERE RecapDataCorrectionRequestId = RecapDataCorrectionRequest.Id) AS Interactions, ApproveRejectCommentText, ApproveRejectCommentName, ApproveRejectCommentDate, ApprovedById, ApprovedDateTime ")
        query.AppendLine("INTO #DCRequest FROM RecapDataCorrectionRequest WHERE RecapDCDId IN (SELECT Id FROM #RecapDCD) ")
        query.AppendLine("SELECT 'DCR Item' AS [--table--], Id, RecapDataCorrectionRequestId, InteractionId, OriginalBAId, OriginalActivityId, CorrectedEmployeeId, CorrectedActivityId, SurveyStartTime ")
        query.AppendLine("INTO #DCRequestItem FROM RecapDataCorrectionRequestItem I WHERE I.RecapDataCorrectionRequestId IN (SELECT Id FROM #DCRequest) ")
        query.AppendLine("SELECT DCD.*, ISNULL(DCR.Id, 0) AS DCRId FROM #RecapDCD DCD LEFT JOIN #DCRequest DCR ON DCD.Id = DCR.RecapDCDId;")
        query.AppendLine("SELECT * FROM #DCRequest ORDER BY RecapDCDId; SELECT * FROM #DCRequestItem ORDER BY RecapDataCorrectionRequestId; ")
        query.AppendLine("DROP TABLE #RecapDCD; DROP TABLE #DCRequest; DROP TABLE #DCRequestItem")

        Return query.ToString()
    End Function

    Protected Sub GridViewDcrRecapDcd_OnRowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim rowData As DataRowView = e.Row.DataItem
            If (rowData("DCRId") > 0) Then
                e.Row.ForeColor = Color.Red
            End If
            End If

    End Sub

    Protected Sub GridViewDcrRecapDcd_OnRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        If (e.CommandName = "select") Then
            Dim rowIndex As Integer = Integer.Parse(e.CommandArgument)
            Dim dcrId As String = GridViewDcrRecapDcd.Rows(rowIndex).Cells(12).Text
            If (Not String.IsNullOrEmpty(dcrId)) Then
                SelectedDcrId.Value = dcrId
            End If

            Dim dcrIntCount As String = GridViewDcrRecapDcd.Rows(rowIndex).Cells(6).Text
            If (Not String.IsNullOrEmpty(dcrIntCount)) Then
                SelectedDcrInteractionCount.Value = dcrIntCount
            End If

            GenerateSqlUpdateQuery()
        End If
    End Sub

    Protected Sub GridViewNewDcdData_OnRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        If (e.CommandName = "select") Then
            Dim activityId As String = GridViewNewDcdData.Rows(Integer.Parse(e.CommandArgument.ToString())).Cells(2).Text
            If (Not String.IsNullOrEmpty(activityId)) Then
                SelectedToActivityId.Value = activityId
            End If

            GenerateSqlUpdateQuery()
        End If
    End Sub

    Private Sub GenerateSqlUpdateQuery()
        If (Not String.IsNullOrEmpty(SelectedDcrId.Value) AndAlso Not String.IsNullOrEmpty(SelectedDcrInteractionCount.Value) AndAlso Not String.IsNullOrEmpty(SelectedToActivityId.Value)) Then
            Dim qry As StringBuilder = New StringBuilder()
            qry.AppendLine("USE MetrixWeb")
            qry.AppendLine()
            qry.AppendLine("BEGIN TRAN")
            qry.AppendLine("SET XACT_ABORT ON")
            qry.AppendLine()
            qry.AppendLine("	DECLARE @UID varchar(50)")
            qry.AppendLine("	SELECT @UID = UserId FROM Employee WHERE UserName = 'djustus'")
            qry.AppendLine()
            qry.AppendFormat("	-- should update a total of {0} records", SelectedDcrInteractionCount.Value)
            qry.AppendLine()
            qry.AppendLine("	UPDATE RecapDataCorrectionRequestItem")
            qry.AppendFormat("	SET CorrectedActivityId = {0},", SelectedToActivityId.Value)
            qry.AppendLine()
            qry.AppendLine("		ModifiedByUserId = @UID,")
            qry.AppendLine("		ModifiedDateTime = GETDATE()")
            qry.AppendFormat("	WHERE RecapDataCorrectionRequestId = {0}", SelectedDcrId.Value)
            qry.AppendLine()
            qry.AppendLine()
            qry.AppendLine("COMMIT TRAN")

            UpdateQueryTextbox.Text = qry.ToString()
            UpdateQueryDiv.Visible = True
        Else
            UpdateQueryTextbox.Text = String.Empty
            UpdateQueryDiv.Visible = False
        End If
    End Sub
End Class