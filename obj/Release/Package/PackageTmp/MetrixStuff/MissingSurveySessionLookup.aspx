<%@ Page Title="JupiterMobile BA Survey Session Lookup" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPages/masterA.Master" CodeBehind="MissingSurveySessionLookup.aspx.vb" Inherits="DansTools.MetrixStuff.MissingSurveySessionLookup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#TextboxSearchDate").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server" ID="MainPanel" UpdateMode="Always">
        <ContentTemplate>
            <div></div>
            <p>
                BA Id:
        <asp:TextBox ID="TextboxSearchBaId" runat="server" Width="69px" CssClass="formItem"></asp:TextBox>
                &nbsp;Event Date:
        <asp:TextBox ID="TextboxSearchDate" runat="server" Width="86px" CssClass="formItem"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="SearchDateCalendarExtender" runat="server" TargetControlID="TextboxSearchDate" />
                &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/find.png" />
&nbsp;<asp:Button ID="ButtonUpdateSearchDates" runat="server" Text=">>" />
                &nbsp; Search From:
        <asp:TextBox ID="TextboxSearchFromDate" runat="server" Width="120px" CssClass="formItem"></asp:TextBox>
                <ajaxToolkit:CalendarExtender runat="server" ID="FromDateCalendarExtender" TargetControlID="TextboxSearchFromDate"/>
                &nbsp;To:
        <asp:TextBox ID="TextboxSearchToDate" runat="server" Width="120px" CssClass="formItem"></asp:TextBox>
                &nbsp;<asp:Button ID="ButtonSearch" runat="server" Text="Search" />
            </p>
            <p>
                <h2>Jupiter Mobile Interaction Data</h2>
                <asp:GridView ID="GridViewJupiterMobileData" runat="server" CellPadding="4" EnableModelValidation="True" CssClass="gridviewTable"
                    ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
                    <AlternatingRowStyle CssClass="grd_AlternatingRowStyle" />
                    <Columns>
                        <asp:TemplateField HeaderText="RecapId" SortExpression="RecapId">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkbuttonRecapId" runat="server" Text='<%# Bind("RecapId") %>'
                                    CommandName="DisplayRecap" CommandArgument='<%# Bind("RecapId") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="TotalSurveys" HeaderText="TotalSurveys" SortExpression="TotalSurveys" />
                        <asp:BoundField DataField="TotalInteractions" HeaderText="TotalInteractions" ReadOnly="True" SortExpression="TotalInteractions" />
                        <asp:BoundField DataField="StartTime" HeaderText="StartTime" ReadOnly="True" SortExpression="StartTime" />
                        <asp:BoundField DataField="ActivityId" HeaderText="ActivityId" SortExpression="ActivityId" />
                        <asp:BoundField DataField="AccountName" HeaderText="AccountName" SortExpression="AccountName" />
                        <asp:BoundField DataField="InterviewerId" HeaderText="InterviewerId" SortExpression="InterviewerId" />
                        <asp:BoundField DataField="DCDNumber" HeaderText="DCDNumber" SortExpression="DCDNumber" />
                        <asp:TemplateField HeaderText="SurveySessionId" SortExpression="SurveySessionId">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButtonSurveySessionTotals" runat="server" Text='<%# Bind("SurveySessionId")%>'
                                    CommandName="DisplaySessionTotals" CommandArgument='<%# Bind("SurveySessionId") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle CssClass="grd_FooterStyle" />
                    <HeaderStyle CssClass="grd_HeaderStyle" />
                    <RowStyle CssClass="grd_RowStyle" />
                </asp:GridView>
                <p>
                </p>
                <p>
                    <h2>Recap DCD Data</h2>
                    <asp:GridView ID="GridViewRecapDcdData" runat="server" AutoGenerateColumns="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="gridviewTable" EmptyDataText="Select a Recap Id" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle CssClass="grd_AlternatingRowStyle" />
                        <FooterStyle CssClass="grd_FooterStyle" />
                        <HeaderStyle CssClass="grd_HeaderStyle" />
                        <RowStyle CssClass="grd_RowStyle" />
                    </asp:GridView>
                    <p>
                    </p>
                    <p>
                        <h2>Survey Session Totals</h2>
                        <asp:GridView ID="GridViewSurveySessionTotals" runat="server" AutoGenerateColumns="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="gridviewTable" EmptyDataText="Select a Survey Session" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical">
                            <AlternatingRowStyle CssClass="grd_AlternatingRowStyle" />
                            <FooterStyle CssClass="grd_FooterStyle" />
                            <HeaderStyle CssClass="grd_HeaderStyle" />
                            <RowStyle CssClass="grd_RowStyle" />
                        </asp:GridView>
                        <p>
                        </p>
                    </p>
                </p>
            </p>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
