Public Partial Class RSReport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    'Protected Sub ddlSelectReport_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlSelectReport.SelectedIndexChanged
    '    Me.sqlrvReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote
    '    Select Case Me.ddlSelectReport.SelectedValue
    '        Case 0
    '            Me.sqlrvReportViewer.Visible = False
    '        Case 1
    '            Me.sqlrvReportViewer.Visible = True
    '            Me.sqlrvReportViewer.ServerReport.ReportPath = "/Lowes_Promotions/Everyone's Registration Information"
    '        Case 2
    '            Me.sqlrvReportViewer.Visible = True
    '            Me.sqlrvReportViewer.ServerReport.ReportPath = "/Lowes_Promotions/List All Stores and How Many Have Registered"
    '        Case 3
    '            Me.sqlrvReportViewer.Visible = True
    '            Me.sqlrvReportViewer.ServerReport.ReportPath = "/Lowes_Promotions/Report3"
    '    End Select
    '    Me.sqlrvReportViewer.ServerReport.Refresh()
    'End Sub
End Class