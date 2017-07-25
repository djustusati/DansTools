<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctlMasterMenu.ascx.vb" Inherits="DansTools.ctlMasterMenu" %>
<asp:DataList ID="dlstMenu" runat="server" DataSourceID="dscMenu" Width="100%">
    <HeaderTemplate>
        <table border="0" cellspacing="2" cellpadding="2" width="100%">
            <tr>
                <td class="menuTitle">M e n u
                </td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td style="border: solid; border-color: #999999; border-width: thin" class="<%# Eval("ButtonStyle") %>"
                onmouseover="this.className='<%# Eval("HoverStyle") %>'" onmouseout="this.className='<%# Eval("ButtonStyle") %>'"
                onclick="javascript:location.href='<%# Eval("UrlLink") %>';">
                <%# Eval("Text") %>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
    <AlternatingItemStyle CssClass="form" HorizontalAlign="Left" VerticalAlign="Middle" />
    <ItemStyle CssClass="form" HorizontalAlign="Left" VerticalAlign="Middle" />
    <HeaderStyle CssClass="form" HorizontalAlign="Center" VerticalAlign="Middle" />
</asp:DataList>
<asp:SqlDataSource ID="dscMenu" runat="server" ConnectionString="<%$ ConnectionStrings:ToolsConnectionString %>"
    SelectCommand="Select command is set in the code behind."></asp:SqlDataSource>
