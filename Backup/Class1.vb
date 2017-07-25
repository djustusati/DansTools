
Imports Microsoft.VisualBasic

Public Class Class1

    Public Shared Function fnGetTransactionType(ByVal oldStatus As String, ByVal newStatus As String, _
                                                ByVal oldUser As String, ByVal newUser As String, _
                                                ByVal oldProg As String, ByVal newProg As String, _
                                                ByVal transferFrom As String, ByVal transferTo As String) As String
        'create holding variables
        Dim sReturn As String = ""
        Dim holdOldStatus As String = oldStatus, holdNewStatus As String = newStatus, _
                    holdUserVal As String = "", holdProgVal As String = "", holdTranVal As String = ""
        Dim sTempA As String = "", sTempB As String = ""
        Dim sUserXStat As String = "", sProgXStat As String = "", sTranXStat As String = ""

        'make sure all holding variables have values
        If holdOldStatus Is Nothing Then holdOldStatus = ""
        If holdNewStatus Is Nothing Then holdNewStatus = ""

        If (oldUser Is Nothing) Or (oldUser = "") Then sTempA = " " Else sTempA = "A"
        If ((newUser Is Nothing) Or (newUser = "")) Then
            sTempB = " "
        ElseIf newUser = oldUser Then
            sTempB = "A"
        Else
            sTempB = "B"
        End If
        holdUserVal = sTempA & "|" & sTempB

        If (oldProg Is Nothing) Or (oldProg = "") Then sTempA = " " Else sTempA = "A"
        If (newProg Is Nothing) Or (newProg = "") Then
            sTempB = " "
        ElseIf newProg = oldProg Then
            sTempB = "A"
        Else
            sTempB = "B"
        End If
        holdProgVal = sTempA & "|" & sTempB

        If (transferFrom Is Nothing) Or (transferFrom = "") Then sTempA = " " Else sTempA = "A"
        If (transferTo Is Nothing) Or (transferTo = "") Then
            sTempB = " "
        ElseIf transferTo = transferFrom Then
            sTempB = "A"
        Else
            sTempB = "B"
        End If
        holdTranVal = sTempA & "|" & sTempB

        'evaluate changes
        If holdOldStatus = holdNewStatus Then
            sUserXStat = UserAction(holdUserVal)
            sProgXStat = ProgramAction(holdProgVal)
            sTranXStat = TransferAction(holdTranVal)
            'sReturn = sUserXStat & "|" & sProgXStat & "|" & sTranXStat
            sReturn = DetermineAction(sUserXStat, sProgXStat, sTranXStat)
        Else
            sReturn = DetermineActionFromStatusChange(holdOldStatus, holdNewStatus)
        End If

        Return sReturn
    End Function

    Shared Function UserAction(ByVal UserValue As String) As String
        Dim sReturn As String = ""
        Select Case UserValue
            Case "A|A"  'no change in user or program
                sReturn = "Unchanged"
            Case "A|B" 'User changed
                sReturn = "Transferred"
            Case "A| "
                sReturn = "Returned"
            Case " |B"
                sReturn = "Assigned"
            Case " | "
                sReturn = "Unassigned"
            Case Else
                sReturn = "Dont know"
        End Select
        Return sReturn
    End Function

    Shared Function ProgramAction(ByVal ProgramValue As String) As String
        Dim sReturn As String = ""
        Select Case ProgramValue
            Case "A|A", " | "  'no change in user or program
                sReturn = "Unchanged"
            Case "A|B" 'User changed
                sReturn = "Program Change"
            Case "A| "
                sReturn = "Returned"
            Case " |B"
                sReturn = "Assigned"
            Case Else
                sReturn = "Dont know"
        End Select
        Return sReturn
    End Function

    Shared Function TransferAction(ByVal TransferValue As String) As String
        Dim sReturn As String = ""
        Select Case TransferValue
            Case "A|A", " | "  'no change in user or program
                sReturn = "Unchanged"
            Case "A|B" 'User changed
                sReturn = "Transferred"
            Case Else
                sReturn = "Dont know"
        End Select
        Return sReturn
    End Function

    Shared Function DetermineAction(ByVal statusXUser As String, ByVal statusXProgram As String, ByVal statusXTransf As String) As String
        Dim sReturn As String = ""

        'determine an overall action from actions on 3 status changes
        If statusXUser = statusXProgram And statusXProgram = statusXTransf Then
            sReturn = "Unchanged" 'nothing has changed
        ElseIf (statusXUser = "Transferred") Or (statusXProgram = "Program Change") Or (statusXTransf = "Transferred") Then
            sReturn = "Transferred"
        ElseIf (statusXUser = "Returned") Or (statusXProgram = "Returned") Then
            sReturn = "Returned"
        ElseIf (statusXUser = "Assigned") Or (statusXProgram = "Assigned") Then
            sReturn = "Assigned"
        Else
            sReturn = "Dont know"
        End If

        Return sReturn
    End Function

    Shared Function DetermineActionFromStatusChange(ByVal oldStatus As String, ByVal newStatus As String) As String
        Dim sReturn As String = ""

        'determine the action from the new and old status
        If oldStatus = "" Then
            Select Case newStatus
                Case "Deleted", "RIP"
                    sReturn = "RIP"
                Case "Issued", "Reissued", "Transferred"
                    sReturn = "Assigned"
                Case "Lost", "Stolen"
                    sReturn = "Lost/Stolen"
                Case Else
                    sReturn = newStatus
            End Select
        ElseIf newStatus = "" Then
            sReturn = "Status Error"
        Else
            Select Case oldStatus
                Case "Assigned"
                    Select Case newStatus
                        Case "Available"
                            sReturn = "Returned"
                        Case Else
                            sReturn = newStatus
                    End Select
                Case "Available"
                    Select Case newStatus
                        Case "Issued", "Assigned"
                            sReturn = "Assigned"
                        Case Else
                            sReturn = newStatus
                    End Select
                Case Else
                    sReturn = newStatus
            End Select
        End If

        Return sReturn
    End Function
End Class
