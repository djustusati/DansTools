Imports System.Web.Services
Imports System.DirectoryServices
Imports System.Data
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class adfunctions
    Inherits System.Web.Services.WebService
    '====================================== 
    'This function returns all the group names in an OU to a dataset, handy for drop-downs..etc 
    'Our Main OU has a structure like MAINOU/GROUPS/GROUPTYPE/groupname 

    <WebMethod()> Public Function LoadGroupNames(ByVal inGroupName As String) As DataSet
        Dim vds As New DataSet()
        Dim workTable As New DataTable()
        Dim GroupName As String = inGroupName

        Dim de As DirectoryEntry = New DirectoryEntry("LDAP://DC03/" & GroupName & "OU=Information Technology,DC=gmrmarketing,DC=priv")
        'Dim de As DirectoryEntry = New DirectoryEntry("LDAP://DC03/OU=Information Technology,DC=gmrmarketing,DC=priv")
        Dim dsearcher As DirectorySearcher = New DirectorySearcher(de)
        Dim results As SearchResultCollection
        Dim result As SearchResult
        Dim dsorter As New SortOption()

        dsorter.PropertyName = "name"
        dsearcher.Sort = dsorter

        results = dsearcher.FindAll
        'results = dsearcher.FindAll()

        Dim pkCol As DataColumn = workTable.Columns.Add("Name", Type.GetType("System.String"))
        workTable.Columns.Add("Description", Type.GetType("System.String"))
        workTable.Columns.Add("Display Name", Type.GetType("System.String"))
        workTable.Columns.Add("Member Of", Type.GetType("System.String"))
        workTable.Columns.Add("ADS Path", Type.GetType("System.String"))


        For Each result In results
            If result.Properties("Name")(0).ToString <> GroupName Then
                If Not IsNothing(result.Properties("name")) Then
                    Dim newRecord As DataRow = workTable.NewRow()
                    Dim sPropertyList As String = "|"
                    For i As Integer = 0 To result.Properties.PropertyNames.Count - 1
                        sPropertyList += result.Properties.PropertyNames(i).ToString & "|"
                    Next
                    newRecord(0) = result.Properties("Name")(0).ToString
                    If 0 < InStr(sPropertyList, "|description|") Then newRecord(1) = result.Properties("Description")(0).ToString Else newRecord(1) = ""
                    If 0 < InStr(sPropertyList, "|displayname|") Then newRecord(2) = result.Properties("DisplayName")(0).ToString Else newRecord(2) = ""
                    If 0 < InStr(sPropertyList, "|memberof|") Then newRecord(3) = result.Properties("MemberOf")(0).ToString Else newRecord(3) = ""
                    If 0 < InStr(sPropertyList, "|adspath|") Then newRecord(4) = result.Properties("ADSPath")(0).ToString Else newRecord(4) = ""
                    workTable.Rows.Add(newRecord)
                End If
            End If

        Next

        vds.Tables.Add(workTable)
        Return vds

    End Function


    '====================================== 
    'This function returns all the group users in a named group in an OU to a dataset, 
    'handy for drop-downs..etc. I pass in the GROUPTYPE and the groupname. 
    'Our Main OU has a structure like MAINOU/GROUPS/GROUPTYPE/groupname 

    <WebMethod()> Public Function LoadGroupUsers(ByVal inOUName As String, ByVal inGroupName As String) As DataSet
        Dim vds As New DataSet()
        Dim workTable As New DataTable()
        Dim GroupName As String = inGroupName

        Dim de As DirectoryEntry = New DirectoryEntry("LDAP://DC03/CN=" & inGroupName & ",OU=" & inOUName & ",OU=Information Technology,DC=gmrmarketing,DC=priv")
        'Dim de As DirectoryEntry = New DirectoryEntry("LDAP://DC03/CN=" & inGroupName & ",OU=Information Technology,DC=gmrmarketing,DC=priv")
        Dim dsearcher As DirectorySearcher = New DirectorySearcher(de)
        Dim result As SearchResult
        Dim myResultPropColl As ResultPropertyCollection
        Dim dsorter As New SortOption()

        dsorter.PropertyName = "Member"

        result = dsearcher.FindOne()

        Dim pkCol As DataColumn = workTable.Columns.Add("Name", Type.GetType("System.String"))
        pkCol = workTable.Columns.Add("OU", Type.GetType("System.String"))

        If Not IsNothing(result.Properties("member")) Then
            Dim propertyCount As Integer = result.Properties("member").Count
            Dim propertyCounter As Integer
            Dim tstring1 As String = ""
            Dim tstring2 As String = ""
            Dim tstring3 As String = ""

            If propertyCount > 0 Then
                For propertyCounter = 0 To propertyCount - 1
                    tstring1 = result.Properties("member")(propertyCounter).ToString

                    '***The member is returned with the groupname/username so i split em. 
                    Dim temparray As Array
                    temparray = Split(tstring1, ",")

                    If Left(temparray(0), 2) = "CN" Then
                        tstring2 = Right(temparray(0), (Len(temparray(0)) - 3))
                    End If


                    tstring3 = Right(temparray(1), (Len(temparray(1)) - 3))


                    Dim newRecord As DataRow = workTable.NewRow()
                    newRecord(0) = tstring2
                    newRecord(1) = tstring3
                    workTable.Rows.Add(newRecord)

                Next
            End If
        End If
        vds.Tables.Add(workTable)
        Return vds

    End Function

    '====================================== 
    'This function will mirror another account to the existing account 
    'varads is a string populated by the "adspath" property of the user receiving the mirror 
    'varcn is a string populated by the "cn" property of the user receiving the mirror 
    'inLUID is the userid of the user that is donating the mirror 
    'Our Main OU has a structure like MAINOU/GROUPS/GROUPTYPE/groupname 

    '<WebMethod()> Public Function ApplyMirror(ByVal invarcn As String, ByVal invarads As String, ByVal inLUID As String) As Integer
    '    Dim de2 As DirectoryEntry = New DirectoryEntry("LDAP://elservo/OU=X,OU=X,DC=X,DC=X,DC=X,DC=X")
    '    Dim dsearcher2 As DirectorySearcher = New DirectorySearcher(de2)
    '    Dim results2 As SearchResultCollection
    '    Dim result2 As SearchResult
    '    Dim myResultPropColl2 As ResultPropertyCollection

    '    dsearcher2.Filter = "(samaccountname=" & Trim(inLUID) & ")"
    '    dsearcher2.PropertiesToLoad.Add("memberOf")
    '    dsearcher2.PropertiesToLoad.Add("scriptPath")
    '    dsearcher2.PropertiesToLoad.Add("cn")
    '    result2 = dsearcher2.FindOne()

    '    If Not IsNothing(result2) Then
    '    Else
    '        Return 1
    '    End If

    '    If Not IsNothing(result2.Properties("memberOf")) Then
    '        Dim propertyCount As Integer = result2.Properties("memberOf").Count
    '        Dim dn As String ' dn of group in AD 
    '        Dim dn2 As String
    '        Dim dn3 As String

    '        Dim propertyCounter As Integer

    '        If propertyCount > 0 Then
    '            For propertyCounter = 0 To propertyCount - 1

    '                dn = result2.Properties("memberOf")(propertyCounter).ToString

    '                Dim temparray As Array
    '                temparray = Split(dn, ",")

    '                If Left(temparray(0), 2) = "CN" Then
    '                    dn2 = Right(temparray(0), (Len(temparray(0)) - 3))
    '                End If

    '                dn3 = Right(temparray(1), (Len(temparray(1)) - 3))

    '                Dim de As DirectoryEntry = New DirectoryEntry("LDAP://elservo/CN=" & dn2 & ",OU=" & dn3 & ",OU=Groups,OU=x,OU=x,DC=x,DC=x,DC=x,DC=x")

    '                Dim temparray2 As Array
    '                temparray2 = Split(invarads, "/")

    '                de.Properties("member").Add(temparray2(3))

    '                Try
    '                    de.CommitChanges()
    '                Catch
    '                    Return 1
    '                End Try


    '            Next

    '            Return 0
    '        End If
    '    Else
    '        Return 1
    '    End If

    'End Function


    '====================================== 
    'This function will remove a group from a user 
    'inCID is the GROUPTYPE 
    'inGID is the groupname 
    'varads is a string populated by the "adspath" property of the user who we are manipulating 
    'Our Main OU has a structure like MAINOU/GROUPS/GROUPTYPE/groupname 

    <WebMethod()> Public Function RemoveGroup(ByVal inGID As String, ByVal inCID As String, ByVal invarads As String) As Integer
        Dim de As DirectoryEntry = New DirectoryEntry("LDAP://elservo/CN=" & inGID & ",OU=" & inCID & ",OU=Groups,OU=x,OU=x,DC=x,DC=x,DC=x,DC=x")

        Dim temparray As Array
        temparray = Split(invarads, "/")

        de.Properties("member").Remove(temparray(3))

        Try
            de.CommitChanges()
            Return 0
        Catch
            Return 1
        End Try

    End Function

    '====================================== 
    'This function will remove all groups from a user. It will list through all member 
    'groups and then call the RemoveGroup function listed above. 

    'insamid is the acccountid of the user who we are manipulating 
    'varads is a string populated by the "adspath" property of the user 
    'who we are manipulating 


    <WebMethod()> Public Function RemoveAllGroups(ByVal insamid As String, ByVal invarads As String) As Integer
        Dim de As DirectoryEntry = New DirectoryEntry("LDAP://elservo/OU=x,OU=x,DC=x,DC=x,DC=x,DC=x")
        Dim dsearcher As DirectorySearcher = New DirectorySearcher(de)
        Dim results As SearchResultCollection
        Dim result As SearchResult
        Dim myResultPropColl As ResultPropertyCollection
        Dim echeck As Boolean
        Dim tint As Integer

        echeck = False

        dsearcher.Filter = "(samaccountname=" & insamid & ")"
        dsearcher.PropertiesToLoad.Add("memberOf")
        result = dsearcher.FindOne()

        If Not IsNothing(result.Properties("memberOf")) Then
            Dim propertyCount As Integer = result.Properties("memberOf").Count
            Dim dn As String = "" ' dn of group in AD 
            Dim dn2 As String = ""
            Dim dn3 As String = ""

            Dim propertyCounter As Integer


            If propertyCount > 0 Then
                For propertyCounter = 0 To propertyCount - 1

                    dn = result.Properties("memberOf")(propertyCounter).ToString

                    Dim temparray As Array
                    temparray = Split(dn, ",")

                    If Left(temparray(0), 2) = "CN" Then
                        dn2 = Right(temparray(0), (Len(temparray(0)) - 3))
                    End If

                    dn3 = Right(temparray(1), (Len(temparray(1)) - 3))


                    tint = RemoveGroup(dn2, dn3, invarads)
                Next
            End If
        End If

        If echeck = False Then
            Return 0
        Else
            Return 1
        End If
    End Function

    '====================================== 
    'This function will populate a dataset with a users member groups 

    'insamaccountid is the acccountid of the user who we are manipulating 


    <WebMethod()> Public Function ListMemberships(ByVal insamaccountname As String) As DataSet
        Dim vds As New DataSet()
        Dim workTable As New DataTable()
        Dim de As DirectoryEntry = New DirectoryEntry("LDAP://elservo/OU=x,OU=xDC=xDC=x,DC=x,DC=x")
        Dim dsearcher As DirectorySearcher = New DirectorySearcher(de)
        Dim results As SearchResultCollection
        Dim result As SearchResult
        Dim myResultPropColl As ResultPropertyCollection

        dsearcher.Filter = "(samaccountname=" & insamaccountname & ")"
        dsearcher.PropertiesToLoad.Add("memberOf")
        result = dsearcher.FindOne()

        Dim pkCol As DataColumn = workTable.Columns.Add("dn2", Type.GetType("System.String"))
        pkCol = workTable.Columns.Add("dn3", Type.GetType("System.String"))

        If Not IsNothing(result.Properties("memberOf")) Then
            Dim propertyCount As Integer = result.Properties("memberOf").Count
            Dim propertyCounter As Integer
            Dim tstring1, tstring2, tstring3 As String

            If propertyCount > 0 Then

                For propertyCounter = 0 To propertyCount - 1
                    tstring1 = result.Properties("memberOf")(propertyCounter).ToString

                    Dim temparray As Array
                    temparray = Split(tstring1, ",")

                    If Left(temparray(0), 2) = "CN" Then
                        tstring2 = Right(temparray(0), (Len(temparray(0)) - 3))
                    End If


                    tstring3 = Right(temparray(1), (Len(temparray(1)) - 3))


                    Dim newRecord As DataRow = workTable.NewRow()
                    newRecord(0) = tstring2
                    newRecord(1) = tstring3
                    workTable.Rows.Add(newRecord)

                Next
            End If


        End If
        vds.Tables.Add(workTable)
        Return vds

    End Function
End Class
