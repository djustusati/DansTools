<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="gridviewupdate.aspx.vb" Inherits="PPPMisc.gridviewupdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PPPConnectionString %>"
            DeleteCommand="DELETE FROM [tblPPPSettings] WHERE [SID] = @SID"
            InsertCommand="INSERT INTO [tblPPPSettings] ([Active], [CheckFileAccountNo], [CheckFileOrg], [CheckFileProgramNo], [CheckDate], [InvoiceDate], [Description]) VALUES (@Active, @CheckFileAccountNo, @CheckFileOrg, @CheckFileProgramNo, @CheckDate, @InvoiceDate, @Description)"
            SelectCommand="SELECT * FROM [tblPPPSettings]"
            UpdateCommand="UPDATE [tblPPPSettings] SET [Active] = @Active, [CheckFileAccountNo] = @CheckFileAccountNo, [CheckFileOrg] = @CheckFileOrg, [CheckFileProgramNo] = @CheckFileProgramNo, [CheckDate] = @CheckDate, [InvoiceDate] = @InvoiceDate, [Description] = @Description WHERE [SID] = @SID">
            <DeleteParameters>
                <asp:Parameter Name="SID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Active" Type="Boolean" />
                <asp:Parameter Name="CheckFileAccountNo" Type="String" />
                <asp:Parameter Name="CheckFileOrg" Type="String" />
                <asp:Parameter Name="CheckFileProgramNo" Type="String" />
                <asp:Parameter Name="CheckDate" Type="String" />
                <asp:Parameter Name="InvoiceDate" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="SID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="Active" Type="Boolean" />
                <asp:Parameter Name="CheckFileAccountNo" Type="String" />
                <asp:Parameter Name="CheckFileOrg" Type="String" />
                <asp:Parameter Name="CheckFileProgramNo" Type="String" />
                <asp:Parameter Name="CheckDate" Type="String" />
                <asp:Parameter Name="InvoiceDate" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="SID" HeaderText="SID" InsertVisible="False" ReadOnly="True"
                    SortExpression="SID" />
                <asp:BoundField DataField="Active" HeaderText="Active" SortExpression="Active" />
                <asp:BoundField DataField="CheckFileAccountNo" HeaderText="CheckFileAccountNo" SortExpression="CheckFileAccountNo" />
                <asp:BoundField DataField="CheckFileOrg" HeaderText="CheckFileOrg" SortExpression="CheckFileOrg" />
                <asp:BoundField DataField="CheckFileProgramNo" HeaderText="CheckFileProgramNo" SortExpression="CheckFileProgramNo" />
                <asp:TemplateField HeaderText="CheckDate" SortExpression="CheckDate">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CheckDate") %>' Width="75px"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox1" 
                        Format="MM/dd/yyyy">
                        </asp:CalendarExtender>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("CheckDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="InvoiceDate" SortExpression="InvoiceDate">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtInvoiceDate" runat="server" Text='<%# Bind("InvoiceDate") %>' Width="70px"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="txtInvoiceDate" 
                        PopupButtonID="txtInvoiceDate"
                        Format="MM/dd/yyyy">
                        </asp:CalendarExtender>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("InvoiceDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
