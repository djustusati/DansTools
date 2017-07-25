<%@ Page Title="DCR Check" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPages/masterA.Master" CodeBehind="RecapDcrResearch.aspx.vb" Inherits="DansTools.RecapDcrResearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Research Data Correct Request</h2>
    <div>
        Old Recap Id:
        <asp:TextBox ID="TextboxOldRecapId" runat="server" CssClass="formItem"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        New Recap Id:
        <asp:TextBox ID="TextboxNewRecapId" runat="server" CssClass="formItem"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonSearch" runat="server" Text="Search" />
    </div>
    <div>
        <hr />
    </div>
    <div style="border: black 2pt solid; margin-top: 10px; padding: 2px;">
        <div>
            <h6 style="margin-bottom: 2px;">Old Recap</h6>
            <asp:GridView ID="GridViewOldDcdData" runat="server" CellPadding="4" EnableModelValidation="True" CssClass="gridviewTable"
                ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
                <AlternatingRowStyle CssClass="grd_AlternatingRowStyle" />
                <FooterStyle CssClass="grd_FooterStyle" />
                <HeaderStyle CssClass="grd_HeaderStyle" />
                <RowStyle CssClass="grd_RowStyle" />
            </asp:GridView>
        </div>
        <div>
            <h6 style="margin-bottom: 2px;">New Recap</h6>
            <asp:GridView ID="GridViewNewDcdData" runat="server" CellPadding="4" EnableModelValidation="True" CssClass="gridviewTable"
                ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
                OnRowCommand="GridViewNewDcdData_OnRowCommand">
                <AlternatingRowStyle CssClass="grd_AlternatingRowStyle" />
                <FooterStyle CssClass="grd_FooterStyle" />
                <HeaderStyle CssClass="grd_HeaderStyle" />
                <RowStyle CssClass="grd_RowStyle" />
                <Columns>
                    <asp:ButtonField ButtonType="Link" CommandName="select" Text="Select" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div style="border: black 2pt solid; margin-top: 10px; padding: 2px;">
        <h6 style="margin-bottom: 2px;">DCRs</h6>
        <asp:GridView ID="GridViewDcrRecapDcd" runat="server" CellPadding="4" EnableModelValidation="True" CssClass="gridviewTable"
            ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
            OnRowDataBound="GridViewDcrRecapDcd_OnRowDataBound"
            OnRowCommand="GridViewDcrRecapDcd_OnRowCommand">
            <AlternatingRowStyle CssClass="grd_AlternatingRowStyle" />
            <FooterStyle CssClass="grd_FooterStyle" />
            <HeaderStyle CssClass="grd_HeaderStyle" />
            <RowStyle CssClass="grd_RowStyle" />
            <Columns>
                <asp:ButtonField ButtonType="Link" CommandName="select" Text="Select" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:GridView ID="GridViewDcrRequest" runat="server" CellPadding="4" EnableModelValidation="True" CssClass="gridviewTable"
            ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
            <AlternatingRowStyle CssClass="grd_AlternatingRowStyle" />
            <FooterStyle CssClass="grd_FooterStyle" />
            <HeaderStyle CssClass="grd_HeaderStyle" />
            <RowStyle CssClass="grd_RowStyle" />
        </asp:GridView>
        <br />
        <asp:GridView ID="GridViewDcrRequestItems" runat="server" CellPadding="4" EnableModelValidation="True" CssClass="gridviewTable"
            ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
            <AlternatingRowStyle CssClass="grd_AlternatingRowStyle" />
            <FooterStyle CssClass="grd_FooterStyle" />
            <HeaderStyle CssClass="grd_HeaderStyle" />
            <RowStyle CssClass="grd_RowStyle" />
        </asp:GridView>
    </div>
    <div style="border: black 2pt solid; margin-top: 10px; padding: 2px; visibility: hidden;">
        <h6 style="margin-bottom: 2px;">Interactions</h6>
        <asp:GridView ID="GridViewInteractions" runat="server" CellPadding="4" EnableModelValidation="True" CssClass="gridviewTable"
            ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
            <AlternatingRowStyle CssClass="grd_AlternatingRowStyle" />
            <FooterStyle CssClass="grd_FooterStyle" />
            <HeaderStyle CssClass="grd_HeaderStyle" />
            <RowStyle CssClass="grd_RowStyle" />
        </asp:GridView>
    </div>
    <div id="UpdateQueryDiv" style="border: black 2pt solid; margin-top: 10px; padding: 2px;" runat="server" visible="False">
        <h6 style="margin-bottom: 2px;">Update Script</h6>
        <asp:HiddenField ID="SelectedDcrId" runat="server" />
        <asp:HiddenField ID="SelectedDcrInteractionCount" runat="server" />
        <asp:HiddenField ID="SelectedToActivityId" runat="server" />

        <asp:TextBox ID="UpdateQueryTextbox" runat="server" Height="365px" TextMode="MultiLine" Width="745px" ReadOnly="True"></asp:TextBox>

    </div>
</asp:Content>
