<%@ Page Title="MetrixWeb Employee Lookup" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPages/masterA.Master" CodeBehind="EmployeeLookup.aspx.vb" Inherits="DansTools.MetrixStuff.EmployeeLookup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .noWrapGridview
        {
            text-align: center;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr>
                <td>First Name: 
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
                <td>Last Name:
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
                <td>Employee Id:
                    <asp:TextBox ID="txtEmployeeId" runat="server"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" />
                </td>
            </tr>
        </table>
    </div>
    <h3>Employees</h3>
    <div class="container">
        <asp:GridView ID="grdEmployeeList" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" AllowSorting="False" CssClass="noWrapGridview" Visible="False"
            EmptyDataText="No records found">
            <AlternatingRowStyle CssClass="noWrap_AlternatingRowStyle"></AlternatingRowStyle>
            <Columns>
                <asp:TemplateField HeaderText="PersonId" SortExpression="PersonId">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="LinkButtonPersonId" Text='<%# Bind("PersonId")%>'
                            CommandName="DisplayEmployee" CommandArgument='<%# Bind("PersonId")%>'>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="GMREmployeeID" HeaderText="GMREmployeeID" SortExpression="GMREmployeeID" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                <asp:BoundField DataField="MiddleName" HeaderText="MI" SortExpression="MiddleName" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="lastName" />
                <asp:TemplateField HeaderText="Active" SortExpression="IsActive">
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chkIsActive" Checked='<%# Bind("IsActive") %>' Enabled="False"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="GMREmployeeId" HeaderText="GMR Emp Id" SortExpression="GMREmployeeId" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" />
                <asp:BoundField DataField="DCDBAId" HeaderText="DCD BA Id" SortExpression="DCDBAId" />
                <asp:BoundField DataField="BA.PersonId" HeaderText="BA.PersonId" SortExpression="BA.PersonId" />
                <asp:BoundField DataField="ClearedToWork" HeaderText="ClearedToWork" SortExpression="ClearedToWork" />
                <asp:BoundField DataField="LastUpdateFromAdapt" HeaderText="LastUpdateFromAdapt" SortExpression="LastUpdateFromAdapt" />
            </Columns>
        </asp:GridView>
    </div>
    <br/>
    <asp:Panel ID="pnlAvailableRoles" runat="server" class="alternatingItem container" Visible="False">
        <span class="containerTitle">Role:</span>
        <asp:GridView ID="grdEmployeeRoles" runat="server" AutoGenerateColumns="True" EnableModelValidation="True" AllowSorting="False" CssClass="noWrapGridview" Visible="False"
            EmptyDataText="No roles found. Employee is set up as a Brand Ambassador.">
            <AlternatingRowStyle CssClass="noWrap_AlternatingRowStyle"></AlternatingRowStyle>
        </asp:GridView>
    </asp:Panel>
    <br/>
    <asp:Panel ID="pnlAvailablePrograms" runat="server" class="container" Visible="False">
        <span class="containerTitle">Available Programs:</span>
        <asp:GridView ID="grdEmployeePrograms" runat="server" AutoGenerateColumns="True" EnableModelValidation="True" AllowSorting="False" CssClass="noWrapGridview" Visible="False"
            EmptyDataText="No records found">
            <AlternatingRowStyle CssClass="noWrap_AlternatingRowStyle"></AlternatingRowStyle>
        </asp:GridView>
    </asp:Panel>
    <br/>
    <asp:Panel ID="pnlAvailableMarkets" runat="server"  class="alternatingItem container" Visible="False">
        <span class="containerTitle">Available Markets:</span>
        <asp:GridView ID="grdEmployeeMarkets" runat="server" AutoGenerateColumns="True" EnableModelValidation="True" AllowSorting="False" CssClass="noWrapGridview" Visible="False"
            EmptyDataText="No records found">
            <AlternatingRowStyle CssClass="noWrap_AlternatingRowStyle"></AlternatingRowStyle>
        </asp:GridView>
    </asp:Panel>
    <br/>
<%--    <asp:Panel ID="pnlAvailablePhones" runat="server" class="container" Visible="False">
        <span class="containerTitle">Employee Phones:</span>
        <asp:GridView ID="grdEmployeePhones" runat="server" AutoGenerateColumns="True" EnableModelValidation="True" AllowSorting="False" CssClass="noWrapGridview" Visible="False"
            EmptyDataText="No records found">
            <AlternatingRowStyle CssClass="noWrap_AlternatingRowStyle"></AlternatingRowStyle>
        </asp:GridView>
    </asp:Panel>
    <br/>--%>
    <asp:Panel ID="pnlEmployeePrebook" runat="server" class="alternatingItem container" Visible="False">
        <span class="containerTitle">Employee Prebook (recent):</span>
        <asp:GridView ID="grdEmployeePrebook" runat="server" AutoGenerateColumns="True" EnableModelValidation="True" AllowSorting="False" CssClass="noWrapGridview" Visible="False"
            EmptyDataText="No records found">
            <AlternatingRowStyle CssClass="noWrap_AlternatingRowStyle"></AlternatingRowStyle>
        </asp:GridView>
    </asp:Panel>
    <br/>
    <asp:Panel ID="pnlEmployeeSchedules" runat="server" class="container" Visible="False">
        <span class="containerTitle">Employee Schedules (most recent 10):</span>
        <asp:GridView ID="grdEmployeeSchedules" runat="server" AutoGenerateColumns="True" EnableModelValidation="True" AllowSorting="False" CssClass="noWrapGridview" Visible="False"
            EmptyDataText="No Schedules found">
            <AlternatingRowStyle CssClass="noWrap_AlternatingRowStyle"></AlternatingRowStyle>
        </asp:GridView>
    </asp:Panel>
    <br/>
    <asp:Panel ID="pnlEmployeeRecaps" runat="server" class="alternatingItem container" Visible="False">
        <span class="containerTitle">Employee Recaps (most recent 10):</span>
        <asp:GridView ID="grdEmployeeRecaps" runat="server" AutoGenerateColumns="True" EnableModelValidation="True" AllowSorting="False" CssClass="noWrapGridview" Visible="False"
            EmptyDataText="No Recaps found">
            <AlternatingRowStyle CssClass="noWrap_AlternatingRowStyle"></AlternatingRowStyle>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
