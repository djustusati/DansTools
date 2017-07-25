Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Net
Imports System.Xml

Partial Public Class geocoding
    Inherits System.Web.UI.Page

    Dim _geoXLSAddress1 As String = ""
    Dim _geoXLSAddress2 As String = ""
    Dim _geoXLSCity As String = ""
    Dim _geoXLSState As String = ""
    Dim _geoXLSZip As String = ""

    'loads the datagrids with latitude longitude and result messages
    Protected Sub btnGetLoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetLocations.Click
        Dim gRow As GridViewRow
        Dim sLat As String = "", sLon As String = "", sReturn As String = ""
        Dim sA As String = "", sC As String = "", sS As String = "", sZ As String = "", sN As String = ""

        For Each gRow In grdAddressList.Rows
            If gRow.RowType = DataControlRowType.DataRow Then
                'call function to get lat/lon info from Yahoo! web service
                sReturn = fGeoCodeAddress(sLat, sLon, sA, sC, sS, sZ, sN, gRow.Cells.Item(3).Text, gRow.Cells.Item(4).Text, gRow.Cells.Item(5).Text, gRow.Cells.Item(6).Text)
                If sReturn = "address" Then
                    gRow.Cells.Item(7).Text = sLat
                    gRow.Cells.Item(8).Text = sLon
                    gRow.Cells.Item(9).Text = "Address Found"
                Else
                    gRow.Cells.Item(9).Text = sReturn
                End If
            End If
        Next
    End Sub

    'function to call Yahoo! geocoding web service passing through address info. Param1 and Param2 return Lat and Lon, function returns status message
    Private Function fGeoCodeAddress(ByRef retLatitude As String, ByRef retLongitude As String, _
                                ByRef retAddress As String, ByRef retCity As String, _
                                ByRef retState As String, ByRef retZip As String, ByRef retCountry As String, _
                                Optional ByVal sStreet As String = "", Optional ByVal sCity As String = "", _
                                Optional ByVal sState As String = "", Optional ByVal sZip As String = "", _
                                Optional ByVal sAddress As String = "") As String

        Dim myWriter As StreamWriter = Nothing
        Dim geoRequest As HttpWebRequest
        'Dim googResponse As String
        Dim sr As XmlTextReader
        Dim sURLAddress As String = ""
        Dim lat As String = ""
        Dim lon As String = ""
        Dim warn As String = ""
        Dim retA As String = "", retC As String = "", retS As String = "", retZ As String = "", RetCn As String = ""

        'build address for url
        If sStreet <> "" Then
            sStreet = Replace(sStreet, " ", "+")
            sURLAddress += "&street=" & sStreet
        End If
        If sCity <> "" Then
            sCity = Replace(sCity, " ", "+")
            sURLAddress += "&city=" & sCity
        End If
        If sState <> "" Then
            sState = Replace(sState, " ", "+")
            sURLAddress += "&city=" & sState
        End If
        If sZip <> "" Then
            sZip = Replace(sZip, " ", "+")
            sURLAddress += "&zip=" & sZip
        End If
        If sAddress <> "" Then
            sAddress = Replace(sAddress, " ", "+")
            sURLAddress += "&address=" & sAddress
        End If
        If sURLAddress = "" Then
            fGeoCodeAddress = "No Address Passed"
            retLatitude = ""
            retLongitude = ""
        End If

        Try
            'Use Yahoo! Geocoding Web Service to search for address
            Dim strRequestURL As String = "http://api.local.yahoo.com/MapsService/V1/"
            strRequestURL += "geocode?appid=justusdj" & sURLAddress
            geoRequest = CType(WebRequest.Create(strRequestURL), HttpWebRequest)
            Dim context As System.Web.HttpContext = System.Web.HttpContext.Current
            geoRequest.Referer = context.Request.ServerVariables.Item("HTTP_REFERER")
            geoRequest.Method = "POST"
            geoRequest.ContentLength = strRequestURL.Length()
            myWriter = New StreamWriter(geoRequest.GetRequestStream())

            Dim geoResponse As HttpWebResponse
            myWriter.Write(strRequestURL)
            myWriter.Close()
            geoResponse = CType(geoRequest.GetResponse(), HttpWebResponse)
            sr = New XmlTextReader(geoResponse.GetResponseStream)

            'Read through returned XML
            While sr.Read()
                If sr.Name = "Result" Then
                    While sr.MoveToNextAttribute
                        warn = sr.Value
                    End While
                End If
                'Extract all location information from returned address
                Select Case sr.Name
                    Case "Latitude"
                        lat = sr.ReadString
                    Case "Longitude"
                        lon = sr.ReadString
                    Case "Address"
                        retA = sr.ReadString
                    Case "City"
                        retC = sr.ReadString
                    Case "State"
                        retS = sr.ReadString
                    Case "Zip"
                        retZ = sr.ReadString
                    Case "Country"
                        RetCn = sr.ReadString
                End Select
            End While
            sr.Close()

        Catch ex As Exception
            warn += "The service is unavailable at this time.  Please try back later."
        End Try

        'If lat <> "" Then
        '    If warn = "street" Then
        '        warn = "Exact Address Not Found."
        '        warn += "Precision only to the Street Level."
        '    End If
        '    If warn = "city" Then
        '        warn = "Exact Address Not Found."
        '        warn += "Precision only to the City Level."
        '        warn += "Make sure the zip code is correct."
        '    End If
        '    If warn = "address" Then
        '        warn = "Exact Address Found!"
        '    End If
        'End If

        'set return values
        fGeoCodeAddress = warn
        retLatitude = lat
        retLongitude = lon
        retAddress = retA
        retCity = retC
        retState = retS
        retZip = retZ
        retCountry = RetCn
    End Function

    'BUTTON to look up a zip code using the Yahoo geocoding service and update the Zips table if it finds the zip location
    Protected Sub btnAddZip_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddZip.Click
        Dim sLat As String = "", sLon As String = "", sRet As String = ""
        Dim sAddr As String = "", sCity As String = "", sState As String = "", sZip As String = "", sCn As String = ""

        lblErrorMessage.Text = ""
        lblZipRet.Text = ""
        sRet = fGeoCodeAddress(sLat, sLon, sAddr, sCity, sState, sZip, sCn, , , , Me.txtAddZip.Text, )
        'Either find the city, state and location that was found or display an error.
        If sLat <> "" Then
            Me.lblZipRet.Text = "<b>City:</b>" & sCity & "<br /><b>State:</b>" & sState & _
                            "<br /><b>Lat:</b>" & sLat & "<br /><b>Lon:</b>" & sLon
        Else
            Me.lblErrorMessage.Text = sRet
        End If
        If sLat <> "" Then
            Dim conDB As New System.Data.SqlClient.SqlConnection
            Try
                'Call stored procedure that checks for existing zip and adds if not already found
                conDB.ConnectionString = ConfigurationManager.ConnectionStrings("GeocodeConnectionString").ToString
                Dim cmd As New System.Data.SqlClient.SqlCommand("spAddZipLocation", conDB)
                cmd.CommandType = System.Data.CommandType.StoredProcedure
                cmd.CommandTimeout = 300
                cmd.Parameters.AddWithValue("@Zip", sZip)
                cmd.Parameters.AddWithValue("@City", sCity)
                cmd.Parameters.AddWithValue("@State", sState)
                cmd.Parameters.AddWithValue("@Lat", sLat)
                cmd.Parameters.AddWithValue("@Lon", sLon)
                conDB.Open()
                Dim dr As System.Data.SqlClient.SqlDataReader = cmd.ExecuteReader()
                'Display results
                If dr.HasRows Then
                    dr.Read()
                    Me.lblZipRet.Text += "<br /><br />" & dr.Item("Message").ToString
                End If
            Catch ex As Exception
                lblErrorMessage.Text = "<b>Error:</b><br />" + ex.Message.ToString
            Finally
                conDB.Close()
                conDB.Dispose()
            End Try

        End If
    End Sub

    Private Sub geocoding_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        grdAddressList.DataSource = GetExcelData("C:\ExcelFiles\test.xls", "test", True)
    End Sub

    'Just call it like this:


    'And the function:
    Private Function GetExcelData(ByVal path As String, ByVal tableName As String, _
        ByVal bFirstRowIsHeader As Boolean) _
        As DataTable

        Dim connectionString As String = _
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & _
                path & "';Extended Properties='Excel 8.0;HDR=" & _
                bFirstRowIsHeader & ";IMEX=1'"

        If TableExists(connectionString, tableName) = False Then
            lblErrorMessage.Text = "Table '" & tableName & _
                "' does not exist in the file.  <br /><br />" & _
                "Please see the Output window for a list of tables in file."

            Return Nothing
        End If

        Dim table As New DataTable(IO.Path.GetFileNameWithoutExtension(path))

        Dim adapter As New OleDb.OleDbDataAdapter( _
            "SELECT * FROM [" & tableName & "$]", connectionString)

        adapter.Fill(table)
        adapter.Dispose()

        Return table

    End Function


    'Check for the existence of the table in the file
    Private Function TableExists(ByVal connectionString As String, ByVal tableName As String)
        Dim bExists As Boolean = False
        Dim table As DataTable
        Dim cn As New OleDb.OleDbConnection(connectionString)

        Try
            cn.Open()
            table = cn.GetSchema("Tables")

            For Each row As DataRow In table.Rows
                Debug.WriteLine(row("TABLE_NAME"))  'write to Output window

                If row("TABLE_NAME").ToString().ToLower() = _
                    (tableName & "$").ToLower() Then

                    bExists = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            lblErrorMessage.Text = "Error connecting to database"
        Finally
            cn.Close()
        End Try

        Return bExists

    End Function
End Class