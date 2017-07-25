<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPages/masterA.Master" CodeBehind="menueditor.aspx.vb" Inherits="DansTools.menueditor"
    Title="Menu Editor" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=1.0.10123.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h6>Menu Editor
    </h6>
    <asp:UpdatePanel ID="upnlMenuEditor" runat="server">
        <ContentTemplate>
            <asp:Accordion ID="accdAccordianMenuEdit" runat="server" HeaderCssClass="accordionHeader"
                ContentCssClass="accordianContent" FadeTransitions="true" FramesPerSecond="20"
                TransitionDuration="250" AutoSize="None" Width="100%">
                <Panes>
                    <asp:AccordionPane ID="AccordionPane1" runat="server">
                        <Header>
                            <a href="" onclick="return false;" class="accordionLink">Menu Administration</a>
                        </Header>
                        <Content>
                            <div>
                                <asp:GridView ID="grdMenuItems" CssClass="gridviewTable" runat="server" AutoGenerateColumns="True" DataKeyNames="Id"
                                    DataSourceID="dscMenuList">
                                    <Columns>
                                        <asp:CommandField ShowDeleteButton="False" ShowEditButton="True" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </Content>
                    </asp:AccordionPane>
                    <asp:AccordionPane ID="AccordionPane2" runat="server">
                        <Header>
                            <a href="" onclick="return false;" class="accordionLink">Add Menu Item</a>
                        </Header>
                        <Content>
                            <div>
                                <table>
                                    <tr>
                                        <td>Menu Text:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNewMenuText" CssClass="formItem" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Menu Link:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNewMenuLink" CssClass="formItem" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Menu Order:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNewMenuOrder" CssClass="formItem" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                        <td>
                                            <asp:Button ID="btnAddNewMenu" CssClass="formItem" runat="server" Text="Add Menu Item" />
                                            <asp:ConfirmButtonExtender ID="confirmeAddMenuItem" runat="server" TargetControlID="btnAddNewMenu"
                                                ConfirmText="Add new menu item?" Enabled="true">
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
                DeleteCommand="DELETE FROM [Menu] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Menu] ([Text], [UrlLink], [MenuOrder], [IsActive]) VALUES (@Text, @UrlLink, @MenuOrder, @IsActive)"
                SelectCommand="SELECT * FROM [Menu] ORDER BY [MenuOrder]"
                UpdateCommand="UPDATE [Menu] SET [Text] = @Text, [UrlLink] = @UrlLink, [MenuOrder] = @MenuOrder, [IsActive] = @IsActive WHERE [Id] = @Id">
                <DeleteParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Text" Type="String" />
                    <asp:Parameter Name="UrlLink" Type="String" />
                    <asp:Parameter Name="MenuOrder" Type="Int32" />
                    <asp:Parameter Name="IsActive" Type="Boolean" />
                    <asp:Parameter Name="Id" Type="Int32" />
                </UpdateParameters>
                <InsertParameters>
                    <asp:Parameter Name="Text" Type="String" />
                    <asp:Parameter Name="UrlLink" Type="String" />
                    <asp:Parameter Name="MenuOrder" Type="Int32" />
                    <asp:Parameter Name="IsActive" Type="Boolean" />
                </InsertParameters>
            </asp:SqlDataSource>
            <asp:UpdateProgress ID="upnlprogUpdateProgress" runat="server" AssociatedUpdatePanelID="upnlMenuEditor">
                <ProgressTemplate>
                    <div id="divProcessing" class="divHourglass">
                        Processing...<img alt="Processing..."
                            src="images/Spinner.gif" /><br />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
