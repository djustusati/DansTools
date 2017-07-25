<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="parentchildrepeater.aspx.vb" Inherits="PPPMisc.parentchildrepeater" 
    title="Parent Child Repeater" %>
<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:panel ID="pnlHolder" runat="server" Width="200px">
    <asp:Repeater ID="rptParent" runat="server">
        <ItemTemplate>
            <div id='h<%# DataBinder.Eval(Container.DataItem, "UserID") %>' class="rptrToggleHeader"
                    onclick='ToggleDisplay(<%# DataBinder.Eval(Container.DataItem, "UserID") %>);'>
                <%# DataBinder.Eval(Container.DataItem, "FormattedName")%>
            </div>
            <div id='d<%# DataBinder.Eval(Container.DataItem, "UserID") %>' class="rptrToggleDetail">
                <asp:Repeater ID="rptChild" runat="server">
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td>
                                    <span style="font-weight:bold; text-decoration: underline;">Menu Access</span>
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# DataBinder.Eval(Container.DataItem, "MenuText")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr style="background-color: #FFFFCC;">
                            <td><%# DataBinder.Eval(Container.DataItem, "MenuText")%>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div id='h<%# DataBinder.Eval(Container.DataItem, "UserID") %>' class="rptrToggleHeader" 
                    onclick='ToggleDisplay(<%# DataBinder.Eval(Container.DataItem, "UserID") %>);'
                    style="background-color: Silver;">
                <%# DataBinder.Eval(Container.DataItem, "FormattedName")%>
            </div>
            <div id='d<%# DataBinder.Eval(Container.DataItem, "UserID") %>' style="background-color: Silver;" class="rptrToggleDetail">
                <asp:Repeater ID="rptChild" runat="server">
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td>
                                    <span style="font-weight:bold; text-decoration: underline;">Menu Access</span>
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# DataBinder.Eval(Container.DataItem, "MenuText")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr style="background-color: #FFFFCC;">
                            <td><%# DataBinder.Eval(Container.DataItem, "MenuText")%>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    </asp:panel>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
