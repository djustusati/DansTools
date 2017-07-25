<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPages/masterA.Master" CodeBehind="listadgroup.aspx.vb" Inherits="DansTools.listadgroup" 
    title="List Active Dirctory Group Members" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Literal ID="litGroupName" runat="server">Group Name:</asp:Literal>
    <asp:DropDownList ID="ddlGroups" runat="server" AutoPostBack="True" 
        CssClass="formItem">
    </asp:DropDownList>
    <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/images/find.png" 
        CssClass="formItem" ToolTip="Filter on selected active directory group" />
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ibtnExportList" runat="server" 
        ImageUrl="~/images/table_add.png" ToolTip="Export results to Excel" />
    <asp:GridView ID="grdADUserList" runat="server" AllowSorting="False" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Underline="true">
    </asp:GridView>
</asp:Content>
