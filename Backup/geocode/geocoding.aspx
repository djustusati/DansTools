<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPages/masterA.Master" CodeBehind="geocoding.aspx.vb" Inherits="DansTools.geocoding" 
    title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 300px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h6>
        Geocoder</h6>
    <table style="border: none 0 white; padding: 8px;">
        <tr>
            <td class="style2">
                <asp:TextBox ID="txtAddZip" runat="server" Width="67px" CssClass="formItem"></asp:TextBox>
                <asp:Button ID="btnAddZip" runat="server" Text="Find Missing Zip" UseSubmitBehavior="False"
                    CssClass="formItem" />
            </td>
            <td rowspan="5" style="width: 10px; background-color: blue">
            </td>
            <td style="width: 328px">
                <asp:FileUpload ID="fuplUploadExcelAddressList" runat="server" 
                    CssClass="formItem" />
                <asp:Button ID="btnLoadSpreadsheet" runat="server" CssClass="formItem" 
                    Text="Load Spreadsheet" UseSubmitBehavior="False" />
            </td>
        </tr>
        <tr>
            <td class="style2" rowspan="3">
                <asp:Label ID="lblZipRet" runat="server" CssClass="formItem"></asp:Label>
            </td>
            <td style="width: 328px">
            </td>
        </tr>
        <tr>
            <td class="style3">
            </td>
        </tr>
        <tr>
            <td style="width: 328px">
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="lblErrorMessage" runat="server" CssClass="errorLabel"></asp:Label>
            </td>
            <td style="width: 328px">
                <asp:Button ID="btnGetLocations" runat="server" CssClass="formItem" 
                    Text="Get Lat/Lng" UseSubmitBehavior="False" Visible="False" />
            </td>
        </tr>
        <asp:GridView ID="grdAddressList" runat="server">
        </asp:GridView>
    </table>
    </asp:Content>
