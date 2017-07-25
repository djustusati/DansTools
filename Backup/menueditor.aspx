<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPages/masterA.Master" CodeBehind="menueditor.aspx.vb" Inherits="DansTools.menueditor" 
    title="Menu Editor" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h6>
        Menu Editor
    </h6>
    <asp:UpdatePanel ID="upnlMenuEditor" runat="server">
        <ContentTemplate>
            <asp:Accordion ID="accdAccordianMenuEdit" runat="server" HeaderCssClass="accordionHeader"
                ContentCssClass="accordianContent" FadeTransitions="true" FramesPerSecond="20"
                TransitionDuration="250" AutoSize="None" Width="100%">
                <Panes>
                    <asp:AccordionPane ID="AccordionPane1" runat="server">
                        <Header>
                            <a href="" onclick="return false;" class="accordionLink">Menu Administration</a></Header>
                        <Content>
                        <div>
                            <asp:GridView ID="grdMenuItems" CssClass="gridviewTable" runat="server" AutoGenerateColumns="False" DataKeyNames="MenuID" 
                                DataSourceID="dscMenuList">
                                <Columns>
                                    <asp:CommandField ShowDeleteButton="False" ShowEditButton="True" />
                                    <asp:TemplateField HeaderText="Menu Text" SortExpression="MenuText">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtMenuText" runat="server" Text='<%# Bind("MenuText") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMenuText" runat="server" Text='<%# Bind("MenuText") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Menu Link" SortExpression="MenuLink">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtMenuLink" runat="server" Text='<%# Bind("MenuLink") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMenuLink" runat="server" Text='<%# Bind("MenuLink") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order" SortExpression="MenuOrder">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtMenuOrder" CssClass="formItem" runat="server" Text='<%# Bind("MenuOrder") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMenuID" runat="server" Text='<%# Bind("MenuID") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblMenuOrder" runat="server" Text='<%# Bind("MenuOrder") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        </Content>
                    </asp:AccordionPane>
                    <asp:AccordionPane ID="AccordionPane2" runat="server">
                        <Header>
                            <a href="" onclick="return false;" class="accordionLink">Add Menu Item</a></Header>
                        <Content>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        Menu Text:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNewMenuText" CssClass="formItem" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Menu Link:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNewMenuLink" CssClass="formItem" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Menu Order:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNewMenuOrder" CssClass="formItem" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAddNewMenu" CssClass="formItem" runat="server" Text="Add Menu Item" />
                                        <asp:ConfirmButtonExtender ID="confirmeAddMenuItem" runat="server" TargetControlID="btnAddNewMenu"
                                                    ConfirmText="Add new menu item?" Enabled="true" >
                                        </asp:ConfirmButtonExtender>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        </Content>
                    </asp:AccordionPane>
                </Panes>
            </asp:Accordion>
            <asp:SqlDataSource ID="dscMenuList" runat="server" ConnectionString="<%$ ConnectionStrings:ToolsConnectionString %>"
                DeleteCommand="DELETE FROM [tblMenu] WHERE [MenuID] = @MenuID" InsertCommand="INSERT INTO [tblMenu] ([MenuText], [MenuLink], [MenuOrder]) VALUES (@MenuText, @MenuLink, @MenuOrder)"
                SelectCommand="SELECT [MenuID], [MenuText], [MenuLink], [MenuOrder] FROM [tblMenu] ORDER BY [MenuOrder]"
                UpdateCommand="UPDATE [tblMenu] SET [MenuText] = @MenuText, [MenuLink] = @MenuLink, [MenuOrder] = @MenuOrder WHERE [MenuID] = @MenuID">
                <DeleteParameters>
                    <asp:Parameter Name="MenuID" Type="Int32" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="MenuText" Type="String" />
                    <asp:Parameter Name="MenuLink" Type="String" />
                    <asp:Parameter Name="MenuOrder" Type="Int32" />
                    <asp:Parameter Name="MenuID" Type="Int32" />
                </UpdateParameters>
                <InsertParameters>
                    <asp:Parameter Name="MenuText" Type="String" />
                    <asp:Parameter Name="MenuLink" Type="String" />
                    <asp:Parameter Name="MenuOrder" Type="Int32" />
                </InsertParameters>
            </asp:SqlDataSource>
            <asp:UpdateProgress ID="upnlprogUpdateProgress" runat="server" AssociatedUpdatePanelID="upnlMenuEditor">
                <ProgressTemplate>
                    <div id="divProcessing" class="divHourglass">Processing...<img alt="Processing..." 
                            src="images/Spinner.gif" /><br /></div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
