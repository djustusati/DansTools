<%@ Page Title="Bullhorn Search" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPages/masterA.Master" CodeBehind="TestBullhornLookup.aspx.vb" Inherits="DansTools.MetrixStuff.TestBullhornLookup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <h3>Test Bullhorn Data</h3>
    <div>
        <asp:GridView ID="grdvwBullhornData" runat="server" AutoGenerateColumns="False" DataSourceID="BullhornDB" EnableModelValidation="True" AllowSorting="True" CssClass="noWrapGridview" Visible="False"
            EmptyDataText="No records found" >
            <AlternatingRowStyle CssClass="noWrap_AlternatingRowStyle"></AlternatingRowStyle>
            <Columns>
                <asp:BoundField DataField="GMREmployeeID" HeaderText="GMREmployeeID" SortExpression="GMREmployeeID" />
                <asp:BoundField DataField="FullName" HeaderText="FullName" SortExpression="FullName" />
                <asp:BoundField DataField="firstName" HeaderText="First Name" SortExpression="firstName" />
                <asp:BoundField DataField="middleName" HeaderText="Middle Name" SortExpression="middleName" />
                <asp:BoundField DataField="lastName" HeaderText="Last Name" SortExpression="lastName" />
                <asp:BoundField DataField="address1" HeaderText="Address1" SortExpression="address1" />
                <asp:BoundField DataField="address2" HeaderText="Address2" SortExpression="address2" />
                <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                <asp:BoundField DataField="zip" HeaderText="Zip" SortExpression="zip" />
                <asp:BoundField DataField="country" HeaderText="Country" SortExpression="country" />
                <asp:BoundField DataField="EmailAddress" HeaderText="Email Address" SortExpression="EmailAddress" />
                <asp:BoundField DataField="PhoneNumber1" HeaderText="Phone Number1" ReadOnly="True" SortExpression="PhoneNumber1" />
                <asp:BoundField DataField="PhoneNumber2" HeaderText="Phone Number2" ReadOnly="True" SortExpression="PhoneNumber2" />
                <asp:TemplateField HeaderText="Program Number" SortExpression="ProgramNumber">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="LinkButtonProgramInfo" Text='<%# Bind("ProgramNumber")%>'
                            CommandName="DisplayProgram" CommandArgument='<%# Bind("ProgramNumber")%>'>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
                <asp:BoundField DataField="AssignmentStatus" HeaderText="AssignmentStatus" SortExpression="AssignmentStatus" />
                <asp:BoundField DataField="StartDate1" HeaderText="StartDate1" SortExpression="StartDate1" />
                <asp:BoundField DataField="EndDate1" HeaderText="EndDate1" SortExpression="EndDate1" />
                <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                <asp:BoundField DataField="EmployeeStatus" HeaderText="EmployeeStatus" SortExpression="EmployeeStatus" />
                <asp:BoundField DataField="gender" HeaderText="gender" SortExpression="gender" />
                <asp:BoundField DataField="GIIDDate" HeaderText="GIIDDate" ReadOnly="True" SortExpression="GIIDDate" />
                <asp:BoundField DataField="HireType" HeaderText="HireType" SortExpression="HireType" />
                <asp:BoundField DataField="Agency" HeaderText="Agency" SortExpression="Agency" />
                <asp:BoundField DataField="LastUpdate" HeaderText="LastUpdate" SortExpression="LastUpdate" />
                <asp:BoundField DataField="placementID" HeaderText="placementID" SortExpression="placementID" />
                <asp:BoundField DataField="userID" HeaderText="userID" SortExpression="userID" />
                <asp:BoundField DataField="jobOrderID" HeaderText="jobOrderID" SortExpression="jobOrderID" />
                <asp:BoundField DataField="ALTRIAID" HeaderText="ALTRIAID" ReadOnly="True" SortExpression="ALTRIAID" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="BullhornDB" runat="server" ConnectionString="<%$ ConnectionStrings:TestBullhornCustom %>" SelectCommand="SELECT GMREmployeeID, FullName, firstName, middleName, lastName, address1, address2, city, state, zip, country, EmailAddress, PhoneNumber1, PhoneNumber2, ProgramNumber, Region, AssignmentStatus, StartDate1, EndDate1, title, EmployeeStatus, gender, GIIDDate, HireType, Agency, LastUpdate, placementID, userID, jobOrderID, ALTRIAID
FROM [Placements]
WHERE (@FirstName = ' '
            OR firstName like '%' + @FirstName + '%')
    AND (@LastName = ' '
            OR lastName LIKE '%' + @LastName + '%')
    AND (@EmpId = ' '
            OR GMREmployeeID LIKE @EmpId)
ORDER BY lastName, firstName, GMREmployeeID">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtFirstName" DefaultValue=" " Name="FirstName" PropertyName="Text" DbType="String" />
                <asp:ControlParameter ControlID="txtLastName" DefaultValue=" " Name="LastName" PropertyName="Text" DbType="String" />
                <asp:ControlParameter ControlID="txtEmployeeId" DefaultValue=" " Name="EmpId" PropertyName="Text" DbType="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:GridView ID="grdvwBudgetCodeData" runat="server" AutoGenerateColumns="True" CssClass="gridviewTable" GridLines="Vertical" EmptyDataText="Budget Code not found." >
            <FooterStyle CssClass="grd_FooterStyle" />
            <HeaderStyle CssClass="grd_HeaderStyle" />
            <RowStyle CssClass="grd_RowStyle" />
        </asp:GridView>
    </div>
</asp:Content>
