<%@ Page Language="VB" MasterPageFile="~/masterPages/masterA.master" AutoEventWireup="true" Inherits="DansTools.geocode" Title="Geocoder" CodeBehind="geocode.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h6>
    Geocoder</h6>
    <table style="border: none 0 white; padding: 8px;">
        <tr>
            <td class="style4">
                <asp:TextBox ID="txtAddZip" runat="server" Width="67px" CssClass="formItem"></asp:TextBox>
                <asp:Button ID="btnAddZip" runat="server" Text="Find Missing Zip" UseSubmitBehavior="False" CssClass="formItem" />
            </td>
            <td rowspan="5" style="width: 10px; background-color: blue">
            </td>
            <td style="width: 328px">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" rowspan="3">
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
            <td class="style4">
                <asp:Label ID="lblErrorMessage" runat="server" CssClass="errorLabel"></asp:Label></td>
            <td style="width: 328px">
                &nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="grdVenues" runat="server" AutoGenerateColumns="False">
    <HeaderStyle CssClass="grd_HeaderStyle" />
    <RowStyle CssClass="grd_RowStyle" />
    <AlternatingRowStyle CssClass="grd_AlternatingRowStyle" />
        <Columns>
            <asp:BoundField DataField="VenueID" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="VenueNumber" HeaderText="Venue #" ReadOnly="True" />
            <asp:BoundField DataField="VenueName" HeaderText="Venue" ReadOnly="True" />
            <asp:BoundField DataField="Address1" HeaderText="Address" ReadOnly="True" />
            <asp:BoundField DataField="City" HeaderText="City" ReadOnly="True" />
            <asp:BoundField DataField="State" HeaderText="St" ReadOnly="True" />
            <asp:BoundField DataField="Zip" HeaderText="Zip" ReadOnly="True" />
            <asp:BoundField DataField="LocLatitude" HeaderText="Lat" ReadOnly="True" ItemStyle-Wrap="false" />
            <asp:BoundField DataField="LocLongitude" HeaderText="Lon" ReadOnly="True" ItemStyle-Wrap="false" />
            <asp:BoundField DataField="Message" HeaderText="Message" />
        </Columns>
    </asp:GridView>
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style3
        {
            width: 328px;
        }
        .style4
        {
            width: 300px;
        }
    </style>

</asp:Content>


