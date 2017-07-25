Imports System.Data.SqlClient
Imports Microsoft.ReportServices


Public Class BusinessLogic
    Public Function GetRootURLPrepend(ByVal sCurrentPageLocation As String) As String
        'appends a series of "../" together to return URL to the root application folder
        Dim D As String = sCurrentPageLocation
        Dim C As String() = Split(D, "/")
        Dim I = 1
        GetRootURLPrepend = ""
        While I < (C.Length - 1)
            GetRootURLPrepend += "../"
            I += 1
        End While
    End Function

    'creates a connection to the database
    Private Function CreateDBConnection(ByRef sqlConnection As SqlConnection) As Boolean
        Dim bReturn As Boolean = False

        Dim sConStr As String = ConfigurationManager.ConnectionStrings("ToolsConnectionString").ToString
        sqlConnection = New SqlConnection(sConStr)
        If Not sqlConnection Is Nothing Then bReturn = True

        Return bReturn
    End Function

    ''' <summary>
    ''' Populates a passed dropdown list from a query or stored procedure
    ''' </summary>
    ''' <param name="sStatement">Parameterized SQL Statement or Stored Procedure name</param>
    ''' <param name="iCommandType">Type of query (Text or StoredProcedure)</param>
    ''' <param name="Params">ParameterCollection of parameters for SQL statement or Stored Procedure</param>
    ''' <param name="DDL">The dropdownlist to be populated</param>
    ''' <param name="ValueField">The name of the returned field that will represent the value of the selected item</param>
    ''' <param name="DisplayField">The name of the returned field that will display in the list</param>
    ''' <remarks></remarks>
    Public Sub PopulateDDLFromDB(ByVal sStatement As String, ByVal iCommandType As System.Data.CommandType, _
                ByVal Params As ParameterCollection, ByVal DDL As DropDownList, _
                ByVal ValueField As String, ByVal DisplayField As String)
        Dim conDB As SqlConnection = Nothing
        Dim drDB As SqlDataReader
        Dim i As Integer
        Try
            CreateDBConnection(conDB)
            Dim cmd As New SqlCommand(sStatement, conDB)
            cmd.CommandType = iCommandType
            cmd.CommandTimeout = 30
            If Not Params Is Nothing Then
                For i = 0 To Params.Count - 1
                    cmd.Parameters.AddWithValue(Params(i).Name, Params(i).DefaultValue)
                Next
            End If
            conDB.Open()
            drDB = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            DDL.DataSource = drDB
            DDL.DataValueField = ValueField
            DDL.DataTextField = DisplayField
            DDL.DataBind()
        Catch ex As Exception
            Throw ex
        Finally
            If Not conDB Is Nothing Then
                conDB.Close()
                conDB.Dispose()
            End If
        End Try
    End Sub



    Public Shared Function ExpirationDateBackgroundColor(ByVal fieldValue As Date) As String
        Const warningDays As Integer = 30
        If fieldValue = Nothing Then
            Return ""
        End If

        If fieldValue < Now Then
            Return "Red"
        End If
        Dim diff As Long = DateDiff(DateInterval.Day, Now, fieldValue)
        If diff <= warningDays Then
            Return "Yellow"
        End If
    End Function



    Public Shared VarWeightQAS2124 As Decimal
    Public Shared VarWeightQAS2529 As Decimal
    Public Shared VarWeightQAS30Plus As Decimal
    Public Shared VarWeightEmail As Decimal
    Public Shared VarWeightPhone As Decimal
    Public Shared VarWeightBAEfficiency As Decimal
    Public Shared VarWeightPPPEfficiency As Decimal
    Public Shared VarGoalInteractions As Decimal
    Public Shared VarGoalInteractionPctAS2124 As Decimal
    Public Shared VarGoalInteractionPctAS2529 As Decimal
    Public Shared VarGoalInteractionPctAS30Plus As Decimal
    Public Shared VarGoalInteractionPctEmail As Decimal
    Public Shared VarGoalInteractionPctPhone As Decimal
    Public Shared VarGoalInteractionsPerBAHour As Decimal
    Public Shared VarGoalPppCpiLargeMarket As Decimal
    Public Shared VarGoalPppCpiSmallMarket As Decimal
    Public Shared VarGoalWeeklyHours1 As Decimal
    Public Shared VarGoalWeeklyHours2 As Decimal

    Public HoldMarketCount As Decimal
    Public HoldTotalMarketWeightedScore As Decimal
    Public HoldTotalAdjInteractionCountPhone As Decimal
    Public HoldTotalInterPerPppIndex As Decimal
    Public HoldYtdTotalMarketWeightedScore As Decimal
    Public HoldYtdTotalAdjInteractionCountPhone As Decimal
    Public HoldYtdTotalInterPerPppIndex As Decimal

    Public Function Initialize(ByVal WeightQAS2124 As Decimal _
            , ByVal WeightQAS2529 As Decimal _
            , ByVal WeightQAS30Plus As Decimal _
            , ByVal WeightEmail As Decimal _
            , ByVal WeightPhone As Decimal _
            , ByVal WeightBAEfficiency As Decimal _
            , ByVal WeightPPPEfficiency As Decimal _
            , ByVal GoalInteractions As Decimal _
            , ByVal GoalInteractionPctAS2124 As Decimal _
            , ByVal GoalInteractionPctAS2529 As Decimal _
            , ByVal GoalInteractionPctAS30Plus As Decimal _
            , ByVal GoalInteractionPctEmail As Decimal _
            , ByVal GoalInteractionPctPhone As Decimal _
            , ByVal GoalInteractionsPerBAHour As Decimal _
            , ByVal GoalPppCpiLargeMarket As Decimal _
            , ByVal GoalPppCpiSmallMarket As Decimal _
            , ByVal GoalWeeklyHours1 As Decimal _
            , ByVal GoalWeeklyHours2 As Decimal) As String
        VarWeightQAS2124 = WeightQAS2124
        VarWeightQAS2529 = WeightQAS2529
        VarWeightQAS30Plus = WeightQAS30Plus
        VarWeightEmail = WeightEmail
        VarWeightPhone = WeightPhone
        VarWeightBAEfficiency = WeightBAEfficiency
        VarWeightPPPEfficiency = WeightPPPEfficiency
        VarGoalInteractions = GoalInteractions
        VarGoalInteractionPctAS2124 = GoalInteractionPctAS2124
        VarGoalInteractionPctAS2529 = GoalInteractionPctAS2529
        VarGoalInteractionPctAS30Plus = GoalInteractionPctAS30Plus
        VarGoalInteractionPctEmail = GoalInteractionPctEmail
        VarGoalInteractionPctPhone = GoalInteractionPctPhone
        VarGoalInteractionsPerBAHour = GoalInteractionsPerBAHour
        VarGoalPppCpiLargeMarket = GoalPppCpiLargeMarket
        VarGoalPppCpiSmallMarket = GoalPppCpiSmallMarket
        VarGoalWeeklyHours1 = GoalWeeklyHours1
        VarGoalWeeklyHours2 = GoalWeeklyHours2
        Return ""
    End Function


    Public Function ColorCode(ByVal FieldValue As Decimal) As String

        Select Case FieldValue
            Case Is > 105
                Return "Green"
            Case 95 To 105
                Return "Yellow"
            Case Is < 80
                Return "Red"
            Case Else
                Return "Orange"
        End Select

    End Function

    Public Function MarketOverallIndex(ByVal weightedScore As Decimal, ByVal summaryWeightedScore As Decimal) As Decimal
        Dim returnValue As Decimal = 0
        ' Store a count of total number of values (to calc average)
        HoldMarketCount += 1
        If summaryWeightedScore = 0 Then Return 0
        returnValue = weightedScore / summaryWeightedScore * 100
        HoldTotalMarketWeightedScore += returnValue
        Return returnValue
    End Function

    Public Function MarketAdjustedInteractionsPhoneIndex(ByVal totalAdjInterCountPhone As Decimal, ByVal summaryAdjInterCountPhone As Decimal) As Decimal
        Dim returnValue As Decimal
        If summaryAdjInterCountPhone = 0 Then Return 0
        returnValue = (totalAdjInterCountPhone / summaryAdjInterCountPhone * 100)
        HoldTotalAdjInteractionCountPhone += returnValue
        Return returnValue
    End Function

    Public Function MarketInteractionPerPppIndex(ByVal cpiMultiplier As Decimal, ByVal goalPppCpi As Decimal) As Decimal
        Dim returnValue As Decimal
        If goalPppCpi = 0 Then Return 0
        returnValue = cpiMultiplier / goalPppCpi * 100
        HoldTotalInterPerPppIndex += returnValue
        Return returnValue
    End Function

    Public Function MarketYtdInteractionPerPppIndex(ByVal cpiMultiplier As Decimal, ByVal goalPppCpi As Decimal) As Decimal
        Dim returnValue As Decimal
        If goalPppCpi = 0 Then Return 0
        returnValue = cpiMultiplier / goalPppCpi * 100
        HoldYtdTotalInterPerPppIndex += returnValue
        Return returnValue
    End Function

    Public Function MarketTotalOverallIndex() As Decimal
        If HoldMarketCount = 0 Then Return 0
        Dim returnValue As Decimal
        returnValue = HoldTotalMarketWeightedScore / HoldMarketCount
        ' reset hold variable so they don't continue to accumulate on next run
        HoldTotalMarketWeightedScore = 0
        Return returnValue
    End Function

    Public Function MarketTotalAdjInteractionCountIndex() As Decimal
        If HoldMarketCount = 0 Then Return 0
        Dim returnValue As Decimal
        returnValue = HoldTotalAdjInteractionCountPhone / HoldMarketCount
        ' reset hold variable so it doesn't continue to accumulate on next run
        HoldTotalAdjInteractionCountPhone = 0
        Return returnValue
    End Function

    Public Function MarketTotalInteractionPerPppIndex() As Decimal
        If HoldMarketCount = 0 Then Return 0
        Dim returnValue As Decimal
        returnValue = HoldTotalInterPerPppIndex / HoldMarketCount
        ' reset hold variable so they don't continue to accumulate on next run
        HoldTotalInterPerPppIndex = 0
        Return returnValue
    End Function

    Public Function MarketTotalYtdOverallIndex() As Decimal
        If HoldMarketCount = 0 Then Return 0
        Dim returnValue As Decimal
        returnValue = HoldYtdTotalMarketWeightedScore / HoldMarketCount
        ' reset hold variable so they don't continue to accumulate on next run
        HoldYtdTotalMarketWeightedScore = 0
        Return returnValue
    End Function

    Public Function MarketTotalYtdAdjInteractionCountIndex() As Decimal
        If HoldMarketCount = 0 Then Return 0
        Dim returnValue As Decimal
        returnValue = HoldYtdTotalAdjInteractionCountPhone / HoldMarketCount
        ' reset hold variable so it doesn't continue to accumulate on next run
        HoldYtdTotalAdjInteractionCountPhone = 0
        Return returnValue
    End Function

    Public Function MarketTotalYtdInteractionPerPppIndex() As Decimal
        If HoldMarketCount = 0 Then Return 0
        Dim returnValue As Decimal
        returnValue = HoldYtdTotalInterPerPppIndex / HoldMarketCount
        ' reset hold variable so they don't continue to accumulate on next run
        HoldYtdTotalInterPerPppIndex = 0
        ' This is the last total in the report, clear the Market count
        HoldMarketCount = 0
        Return returnValue
    End Function

    Public Function YTDOverallIndex(ByVal MarketSize As String, _
                                               ByVal TotalWeeklyGoal As Decimal, _
                                               ByVal YTDTotalSurveys As Integer, _
                                               ByVal YTDTotalPayment As Decimal, _
                                               ByVal YTDTotalBAHours As Decimal, _
                                               ByVal YTDTotalAS2124 As Integer, _
                                               ByVal YTDTotalAS2529 As Integer, _
                                               ByVal YTDTotalAS30Plus As Integer, _
                                               ByVal YTDTotalEmail As Integer, _
                                               ByVal YTDTotalPhone As Integer, _
                                               ByVal WeekNumber As Integer) As Decimal
        If YTDTotalSurveys = 0 _
                OrElse YTDTotalPayment = 0 _
                OrElse TotalWeeklyGoal = 0 _
                OrElse WeekNumber = 0 _
                OrElse YTDTotalBAHours = 0 Then
            Return 0
        Else
            Dim returnValue As Decimal
            ' per Jeff Magnuson, 15hrs = 1 day
            Dim calculatedWeekHoursGoalInDays As Decimal = (TotalWeeklyGoal / WeekNumber) / 15
            Dim goalPppCpi As Decimal
            If (MarketSize = "Large") Then
                goalPppCpi = VarGoalPppCpiLargeMarket
            Else
                goalPppCpi = VarGoalPppCpiSmallMarket
            End If
            ' Put together pieces to be calculated
            Dim holdComparativeIntPerBaHour As Decimal
            Dim holdAsAdjustedInteractionCount As Decimal
            Dim holdAdjustedInteractionCountEmail As Decimal
            Dim holdAdjustedInteractionCountPhone As Decimal
            Dim holdComparativeIntPerPpp As Decimal
            Dim holdWeightedScore As Decimal
            Dim holdOverallComparativeIntPerPpp As Decimal
            Dim holdOverallComparativeIntPerBaHour As Decimal
            Dim holdOverallAsAdjustedInteractionCount As Decimal
            Dim holdOverallAsAdjustedInteractionCountEmail As Decimal
            Dim holdOverallAsAdjustedInteractionCountPhone As Decimal
            Dim holdOverallWeightedScore As Decimal

            holdComparativeIntPerBaHour = 1 + (VarWeightBAEfficiency * (((CDec(YTDTotalSurveys) / (YTDTotalBAHours))) / VarGoalInteractionsPerBAHour))
            holdAsAdjustedInteractionCount = CalculateAsAdjustedInteractionCount(YTDTotalAS2124, YTDTotalAS2529, YTDTotalAS30Plus, CDec(WeekNumber))
            holdAdjustedInteractionCountEmail = CalculateAdjustedInteractionCountEmail(holdAsAdjustedInteractionCount, YTDTotalEmail, YTDTotalSurveys, CDec(WeekNumber))
            holdAdjustedInteractionCountPhone = CalculateAdjustedInteractionCountPhone(holdAdjustedInteractionCountEmail, YTDTotalPhone, YTDTotalSurveys, CDec(WeekNumber))
            holdComparativeIntPerPpp = 1 + (VarWeightPPPEfficiency * ((YTDTotalSurveys / YTDTotalPayment) / (VarGoalInteractions / (VarGoalInteractions * goalPppCpi))))
            holdOverallComparativeIntPerPpp = 1 + (VarWeightPPPEfficiency * (VarGoalPppCpiLargeMarket / VarGoalPppCpiLargeMarket))
            holdWeightedScore = holdComparativeIntPerPpp * holdComparativeIntPerBaHour * holdAdjustedInteractionCountPhone
            holdOverallComparativeIntPerBaHour = 1 + (VarWeightBAEfficiency * (VarGoalInteractionsPerBAHour / VarGoalInteractionsPerBAHour))
            holdOverallAsAdjustedInteractionCount = ((VarGoalInteractions * VarGoalInteractionPctAS2124) * calculatedWeekHoursGoalInDays * VarWeightQAS2124) _
                    + ((VarGoalInteractions * VarGoalInteractionPctAS2529) * calculatedWeekHoursGoalInDays * VarWeightQAS2529) _
                    + ((VarGoalInteractions * VarGoalInteractionPctAS30Plus) * calculatedWeekHoursGoalInDays * VarWeightQAS30Plus)
            holdOverallAsAdjustedInteractionCountEmail = holdOverallAsAdjustedInteractionCount + (VarWeightEmail * VarGoalInteractionPctEmail)
            holdOverallAsAdjustedInteractionCountPhone = holdOverallAsAdjustedInteractionCountEmail + (VarWeightPhone * VarGoalInteractionPctPhone)
            holdOverallWeightedScore = holdOverallComparativeIntPerPpp * holdOverallComparativeIntPerBaHour * holdOverallAsAdjustedInteractionCountPhone

            If holdOverallWeightedScore = 0 Then Return 0

            returnValue = (holdWeightedScore / holdOverallWeightedScore * 100)
            HoldYtdTotalMarketWeightedScore += returnValue
            Return returnValue
        End If
    End Function

    Public Function YTDAdjInteractionCountIndex(ByVal YTDTotalSurveys As Integer, _
                                            ByVal TotalWeeklyGoal As Decimal, _
                                            ByVal YTDTotalAS2124 As Integer, _
                                            ByVal YTDTotalAS2529 As Integer, _
                                            ByVal YTDTotalAS30Plus As Integer, _
                                            ByVal YTDTotalEmail As Integer, _
                                            ByVal YTDTotalPhone As Integer, _
                                            ByVal WeekNumber As Integer) As Decimal
        If YTDTotalSurveys = 0 OrElse TotalWeeklyGoal = 0 OrElse WeekNumber = 0 Then
            Return 0
        Else
            Dim returnValue As Decimal
            ' per Jeff Magnuson, 15hrs = 1 day
            Dim calculatedWeekHoursGoalInDays As Decimal = (TotalWeeklyGoal / WeekNumber) / 15
            Dim goalPppCpi As Decimal
            ' Put together pieces to be calculated
            Dim holdAsAdjustedInteractionCount As Decimal
            Dim holdAdjustedInteractionCountEmail As Decimal
            Dim holdAdjustedInteractionCountPhone As Decimal
            Dim holdOverallAsAdjustedInteractionCount As Decimal
            Dim holdOverallAsAdjustedInteractionCountEmail As Decimal
            Dim holdOverallAsAdjustedInteractionCountPhone As Decimal

            holdAsAdjustedInteractionCount = CalculateAsAdjustedInteractionCount(YTDTotalAS2124, YTDTotalAS2529, YTDTotalAS30Plus, CDec(WeekNumber))
            holdAdjustedInteractionCountEmail = CalculateAdjustedInteractionCountEmail(holdAsAdjustedInteractionCount, YTDTotalEmail, YTDTotalSurveys, CDec(WeekNumber))
            holdAdjustedInteractionCountPhone = CalculateAdjustedInteractionCountPhone(holdAdjustedInteractionCountEmail, YTDTotalPhone, YTDTotalSurveys, CDec(WeekNumber))
            holdOverallAsAdjustedInteractionCount = ((VarGoalInteractions * VarGoalInteractionPctAS2124) * calculatedWeekHoursGoalInDays * VarWeightQAS2124) _
                    + ((VarGoalInteractions * VarGoalInteractionPctAS2529) * calculatedWeekHoursGoalInDays * VarWeightQAS2529) _
                    + ((VarGoalInteractions * VarGoalInteractionPctAS30Plus) * calculatedWeekHoursGoalInDays * VarWeightQAS30Plus)
            holdOverallAsAdjustedInteractionCountEmail = holdOverallAsAdjustedInteractionCount + (VarWeightEmail * VarGoalInteractionPctEmail)
            holdOverallAsAdjustedInteractionCountPhone = holdOverallAsAdjustedInteractionCountEmail + (VarWeightPhone * VarGoalInteractionPctPhone)

            If holdOverallAsAdjustedInteractionCountPhone = 0 Then Return 0

            returnValue = (holdAdjustedInteractionCountPhone / holdOverallAsAdjustedInteractionCountPhone * 100)
            HoldYtdTotalAdjInteractionCountPhone += returnValue
            Return returnValue
        End If
    End Function

    Private Shared Function CalculateAsAdjustedInteractionCount(ByVal totalAs2124 As Decimal, ByVal totalAs2529 As Decimal, ByVal totalAs30Plus As Decimal, ByVal weekNumber As Decimal) As Decimal
        Return ((totalAs2124 / weekNumber) * VarWeightQAS2124) + ((totalAs2529 / weekNumber) * VarWeightQAS2529) + ((totalAs30Plus / weekNumber) * VarWeightQAS30Plus)
    End Function

    Private Shared Function CalculateAdjustedInteractionCountEmail(ByVal asAdjustedInteractionCount As Decimal, ByVal totalEmail As Decimal, ByVal totalSurveys As Decimal, ByVal weekNumber As Decimal) As Decimal
        Return asAdjustedInteractionCount + (VarWeightEmail * ((totalEmail / weekNumber) / (totalSurveys / weekNumber)) * 100)
    End Function

    Private Shared Function CalculateAdjustedInteractionCountPhone(ByVal adjustedEmailCount As Decimal, ByVal totalPhone As Decimal, ByVal totalSurveys As Decimal, ByVal weekNumber As Decimal) As Decimal
        Return adjustedEmailCount + (VarWeightPhone * (((totalPhone / weekNumber) / (totalSurveys / weekNumber)) * 100))
    End Function






End Class
