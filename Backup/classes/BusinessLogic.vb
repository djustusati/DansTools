Imports System.Data.SqlClient

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

End Class
