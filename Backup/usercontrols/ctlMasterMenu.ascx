<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctlMasterMenu.ascx.vb" Inherits="DansTools.ctlMasterMenu" %>
<asp:DataList ID="dlstMenu" runat="server" DataSourceID="dscMenu" Width="100%">
    <HeaderTemplate>
        <table border="0" cellspacing="2" cellpadding="2" width="100%">
            <tr>
                <td class="menuTitle">
                    M e n u
                </td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td style="border: 1; border-color: #999999; border-width: thin" class="<%# Eval("ButtonStyle") %>"
                onmouseover="this.className='<%# Eval("HoverStyle") %>'" onmouseout="this.className='<%# Eval("ButtonStyle") %>'"
                onclick="javascript:location.href='<%# Eval("MenuLink") %>';">
                <%# Eval("MenuText") %>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table></FooterTemplate>
    <AlternatingItemStyle CssClass="form" HorizontalAlign="Left" VerticalAlign="Middle" />
    <ItemStyle CssClass="form" HorizontalAlign="Left" VerticalAlign="Middle" />
    <HeaderStyle CssClass="form" HorizontalAlign="Center" VerticalAlign="Middle" />
</asp:DataList>
<asp:SqlDataSource ID="dscMenu" runat="server" ConnectionString="<%$ ConnectionStrings:ToolsConnectionString %>"
    SelectCommand="SELECT tblMenu.MenuText, tblMenu.MenuLink, 'flyOut' AS ButtonStyle FROM tblMenu ORDER BY tblMenu.MenuOrder">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="0" Name="UserID" SessionField="UserID" />
    </SelectParameters>
</asp:SqlDataSource>
