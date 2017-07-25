Imports System.Data.SqlClient

Namespace MetrixStuff

    Public Class EmployeeLookup
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
            PopulateEmployeeList()
        End Sub

        Private Sub grdEmployeeList_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdEmployeeList.RowCommand
            Dim personId As Integer

            If (e.CommandName = "DisplayEmployee") Then
                If (Not String.IsNullOrEmpty(e.CommandArgument.ToString())) Then
                    personId = CInt(e.CommandArgument.ToString())
                    PopulateEmployeeInfo(personId)
                End If
            End If
        End Sub

        Private Sub PopulateEmployeeList()
            Dim connString = ConfigurationManager.ConnectionStrings("MetrixWeb").ConnectionString
            If (connString = String.Empty) Then
                Throw New ConfigurationErrorsException("Connection String error")
            End If
            Dim sqlConn As New SqlConnection(connString)
            Dim dataSet = New DataSet
            Dim dataAdapter As SqlDataAdapter = New SqlDataAdapter(LoadQueryEmployeeList( _
                txtFirstName.Text, _
                txtLastName.Text, _
                txtEmployeeId.Text, _
                0), sqlConn)
            dataAdapter.Fill(dataSet)
            If (dataSet IsNot Nothing AndAlso dataSet.Tables.Count > 0) Then
                grdEmployeeList.DataSource = dataSet.Tables(0)
                grdEmployeeList.DataBind()
                grdEmployeeList.Visible = True
                pnlAvailableRoles.Visible = False
                pnlAvailablePrograms.Visible = False
                pnlAvailableMarkets.Visible = False
                'pnlAvailablePhones.Visible = False
                pnlEmployeePrebook.Visible = False
                pnlEmployeeSchedules.Visible = False
                pnlEmployeeRecaps.Visible = False
            End If
        End Sub

        Private Sub PopulateEmployeeInfo(ByVal personId As Integer)
            Dim connString = ConfigurationManager.ConnectionStrings("MetrixWeb").ConnectionString
            If (connString = String.Empty) Then
                Throw New ConfigurationErrorsException("Connection String error")
            End If
            Dim sqlConn As New SqlConnection(connString)
            Dim dataSet = New DataSet
            Dim dataAdapter As SqlDataAdapter = New SqlDataAdapter(LoadQueryEmployeeRoleInfo(personId), sqlConn)
            dataAdapter.Fill(dataSet)
            If (dataSet IsNot Nothing AndAlso dataSet.Tables.Count > 0) Then
                grdEmployeeRoles.DataSource = dataSet.Tables(0)
                grdEmployeeRoles.DataBind()
                grdEmployeeRoles.Visible = True
                pnlAvailableRoles.Visible = True
            Else 
                pnlAvailableRoles.Visible = False
            End If

            dataSet = New DataSet
            dataAdapter = New SqlDataAdapter(LoadQueryEmployeeProgramInfo(personId), sqlConn)
            dataAdapter.Fill(dataSet)
            If (dataSet IsNot Nothing AndAlso dataSet.Tables.Count > 0) Then
                grdEmployeePrograms.DataSource = dataSet.Tables(0)
                grdEmployeePrograms.DataBind()
                grdEmployeePrograms.Visible = True
                pnlAvailablePrograms.Visible = True
            Else 
                pnlAvailablePrograms.Visible = False
            End If

            dataSet = New DataSet
            dataAdapter = New SqlDataAdapter(LoadQueryEmployeeMarketInfo(personId), sqlConn)
            dataAdapter.Fill(dataSet)
            If (dataSet IsNot Nothing AndAlso dataSet.Tables.Count > 0) Then
                grdEmployeeMarkets.DataSource = dataSet.Tables(0)
                grdEmployeeMarkets.DataBind()
                grdEmployeeMarkets.Visible = True
                pnlAvailableMarkets.Visible = True
            Else 
                pnlAvailableMarkets.Visible = False
            End If

            'dataSet = New DataSet
            'dataAdapter = New SqlDataAdapter(LoadQueryEmployeePhoneInfo(personId), sqlConn)
            'dataAdapter.Fill(dataSet)
            'If (dataSet IsNot Nothing AndAlso dataSet.Tables.Count > 0) Then
            '    grdEmployeePhones.DataSource = dataSet.Tables(0)
            '    grdEmployeePhones.DataBind()
            '    grdEmployeePhones.Visible = True
            '    pnlAvailablePhones.Visible = True
            'Else 
            '    pnlAvailablePhones.Visible = False
            'End If

            dataSet = New DataSet
            dataAdapter = New  SqlDataAdapter(LoadQuerySchedulePrebook(personId), sqlConn)
            dataAdapter.Fill(dataSet)
            If (dataSet IsNot Nothing AndAlso  dataSet.Tables.Count > 0) Then
                grdEmployeePrebook.DataSource = dataSet.Tables(0)
                grdEmployeePrebook.DataBind()
                grdEmployeePrebook.Visible = True
                pnlEmployeePrebook.Visible = True
            Else 
                pnlEmployeePrebook.Visible = False
            End If

            dataSet = New DataSet
            dataAdapter = New SqlDataAdapter(LoadQueryEmployeeScheduledInfo(personId), sqlConn)
            dataAdapter.Fill(dataSet)
            If (dataSet IsNot Nothing AndAlso dataSet.Tables.Count > 0) Then
                grdEmployeeSchedules.DataSource = dataSet.Tables(0)
                grdEmployeeSchedules.DataBind()
                grdEmployeeSchedules.Visible = True
                pnlEmployeeSchedules.Visible = True
            Else
                pnlEmployeeSchedules.Visible = False
            End If

            dataSet = New DataSet
            dataAdapter = New SqlDataAdapter(LoadQueryEmployeeRecappedInfo(personId), sqlConn)
            dataAdapter.Fill(dataSet)
            If (dataSet IsNot Nothing AndAlso dataSet.Tables.Count > 0) Then
                grdEmployeeRecaps.DataSource = dataSet.Tables(0)
                grdEmployeeRecaps.DataBind()
                grdEmployeeRecaps.Visible = True
                pnlEmployeeRecaps.Visible = True
            Else
                pnlEmployeeRecaps.Visible = False
            End If
            sqlConn.Close()
            sqlConn.Dispose()
        End Sub

        Private Function LoadQueryEmployeeList(ByVal firstName As String, ByVal lastName As String, ByVal employeeId As String, ByVal activeOnly As Integer) As String
            Return String.Format("SELECT P.Id AS PersonId, P.FirstName, P.MiddleName, P.LastName, P.IsActive, P.Email, E.GMREmployeeId, E.Title, E.UserName, E.UserId, DCDBAId, BA.PersonId AS [BA.PersonId], BA.ClearedToWork, BA.LastUpdateFromAdapt " & _
                                 "FROM Person P " & _
                                 "	INNER JOIN Employee E ON P.Id = E.PersonId " & _
                                 "   LEFT JOIN BrandAmbassador BA ON P.Id = BA.PersonId " & _
                                 "WHERE ((P.FirstName LIKE '%{0}%' " & _
                                 "	AND P.LastName LIKE '%{1}%') " & _
                                 "	AND ('{2}' = '' " & _
                                 "       OR E.GMREmployeeId = '{2}')) " & _
                                 "	AND ({3} = 0  " & _
                                 "		OR P.IsActive = 1) " & _
                                 "ORDER BY P.LastName, P.FirstName, P.MiddleName, P.Id",
                                 firstName, lastName, employeeId, activeOnly)
        End Function

        Private Function LoadQueryEmployeeRoleInfo(ByVal personId As Integer) As String
            Return String.Format("SELECT PersonId, ER.RoleId, R.Name AS Role FROM EmployeeRole ER LEFT JOIN Role R ON ER.RoleId = R.Id WHERE PersonId = {0} ORDER BY RoleId", personId)
        End Function

        Private Function LoadQueryEmployeeProgramInfo(ByVal personId As Integer) As String
            Return String.Format("SELECT PersonId, ProgramId, P.Name AS Program " & _
                                 "FROM EmployeeProgram EP LEFT JOIN Program P ON EP.ProgramId = P.Id " & _
                                 "WHERE PersonId = {0} And EP.DeactivationDate Is NULL ORDER BY ProgramId", personId)
        End Function

        Private Function LoadQueryEmployeeMarketInfo(ByVal personId As Integer) As String
            Return String.Format("SELECT PersonId, MarketId, M.ShortName AS Market " & _
                                 "FROM EmployeeMarket EM JOIN Market M ON EM.MarketId = M.Id " & _
                                 "WHERE PersonId = {0} AND EM.DeactivationDate IS NULL ORDER BY M.ShortName", personId)
        End Function

        Private Function LoadQueryEmployeePhoneInfo(ByVal personId As Integer) As String
            Return String.Format("SELECT PersonId, Id, PhoneNumberNumber, PhoneNumberPhoneNumberType, PhoneNumberMobileProviderType, PhoneNumberIsPrimary FROM PersonPhoneNumber WHERE PersonId = {0} ORDER BY 1", personId)
        End Function

        Private Function LoadQuerySchedulePrebook(ByVal personId As Integer) As String
            Dim lookbackDays As String = My.MySettings.Default.PrebookLookbackDays
            Return String.Format("SELECT VSP.EmployeeId, VSP.EmployeeName, VSP.ProgramNumber, CONVERT(CHAR(10), VSP.ScheduleDate, 101) AS ScheduleDate, CAST(VSP.ScheduleHours AS decimal(18,2)) AS ScheduleHours, VSP.ScheduleId, " &
                                 "ISNULL(CAST(VSP.PlacementId AS varchar(10)), '<missing>') AS PlacementId " &
                                 "FROM Employee AS E " &
                                 "	LEFT JOIN vw_SchedulePrebook AS VSP ON E.GMREmployeeId = VSP.EmployeeId " &
                                 "WHERE E.PersonId = {0} " &
                                 "	AND VSP.ScheduleDate > DATEADD(DAY, -{1}, GETDATE()) " &
                                 "ORDER BY VSP.ScheduleDate DESC", personId, lookbackDays)
        End Function

        Private Function LoadQueryEmployeeScheduledInfo(ByVal personId As Integer) As String
            Return String.Format("SELECT Type, Employee, Market, ActivityId, Event, BudgetCode, CAST(EventDate AS date) EventDate, Created " &
                                "FROM (SELECT DISTINCT TOP 10 'Scheduled' AS Type, P.FirstName + ' ' + P.LastName AS Employee, M.ShortName AS Market, A.Id AS ActivityId, ISNULL(E.Name, '') AS Event, BC.Code AS BudgetCode, A.StartDateTime AS EventDate, A.CreatedDateTime AS Created " &
                                "   FROM Activity AS A " &
                                "	    JOIN Activation AS A1 ON A.ActivationId = A1.Id" &
                                "	    JOIN ActivityEmployee AS AE ON A.Id = AE.ActivityId" &
                                "	    JOIN Market AS M ON A1.MarketId = M.Id" &
                                "	    JOIN Person AS P ON AE.PersonId = P.Id" &
                                "      JOIN BudgetCode BC ON A.BudgetCodeId = BC.Id" &
                                "	    LEFT JOIN Event AS E ON A.EventId = E.Id " &
                                "  WHERE AE.PersonId = {0} " &
                                "	    AND A.Status <> 5 " &
                                "  ORDER BY A.StartDateTime DESC) qry", personId)
        End Function

        Private Function LoadQueryEmployeeRecappedInfo(ByVal personId As Integer) As String
            Return String.Format("SELECT Type, Employee, Market, Event, BudgetCode, CONVERT(CHAR(10), EventDate, 101) EventDate, Status " &
                                "FROM (SELECT DISTINCT TOP 10 'Recapped' AS Type, P.FirstName + ' ' + P.LastName AS Employee, M.ShortName AS Market, ISNULL(E.Name, '') AS Event, BC.Code AS BudgetCode, A.StartDateTime AS EventDate, " & 
                                "   CASE WHEN R.Status = 4 THEN 'Approved' ELSE 'Pending' END AS Status " &
                                 "  FROM Activity As A " &
                                 "	    JOIN Activation AS A1 ON A.ActivationId = A1.Id " &
                                 "	    JOIN Market As M On A1.MarketId = M.Id " &
                                 "  	JOIN Recap AS R ON A.Id = R.ActivityId " &
                                 "	    JOIN RecapStaff As RS On R.Id = RS.RecapId " &
                                 "  	JOIN Person AS P ON RS.EmployeeId = P.Id " &
                                 "      JOIN BudgetCode BC ON A.BudgetCodeId = BC.Id" &
                                 "	    LEFT Join Event As E ON A.EventId = E.Id " &
                                 "  WHERE RS.EmployeeId = {0} " &
                                 "	    And A.Status <> 5 " &
                                 "  	And R.IsRemoved = 0 " &
                                 "	    And RS.Worked = 1 " &
                                 "  ORDER BY A.StartDateTime DESC) qry", personId)
        End Function

    End Class
End NameSpace