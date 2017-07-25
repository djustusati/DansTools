<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RSReport.aspx.vb" Inherits="PPPMisc.RSReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Reports</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="ddlSelectReport" runat="server" AutoPostBack="True">
            <asp:ListItem Value="0">-- Select A Report --</asp:ListItem>
            <asp:ListItem Value="1">Everyone's Registration Information</asp:ListItem>
            <asp:ListItem Value="2">All Stores With No Registrations</asp:ListItem>
            <asp:ListItem Value="3">All Stores and How Many Have Registered</asp:ListItem>
        </asp:DropDownList>
        <rsweb:ReportViewer ID="sqlrvReportViewer" runat="server" Font-Names="Verdana" Font-Size="8pt"
            Height="483px" ProcessingMode="Remote" Width="608px">
            <ServerReport ReportServerUrl="http://64.73.26.52/reportserver" />
        </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
