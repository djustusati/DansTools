<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="divpopup.aspx.vb" Inherits="PPPMisc.divpopup" 
    title="Popup Div Tester" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function ShowPopup(MID, MText)
        {
//            var eTest = document.getElementById('divTester');
//            eTest.innerHTML = 'Hello'+eTest.style.visibility;
//            eTest.style.backgroundColor = 'Red';
//            eTest.style.position = 'absolute';
//            eTest.style.left = '200px';
//            eTest.style.top = '200px';
//            eTest.style.height = '50px';
//            eTest.style.width = '50px';
//            if (eTest.style.visibility == 'visible')
//            {
//                eTest.style.visibility = 'hidden';
//            }
//            else
//            {
//                eTest.style.visibility = 'visible';
//            }
            var eDiv = document.getElementById('divUpdatePopup');
            if (eDiv.style.visibility == 'visible')
            {
//                eDiv.style.visibility = 'hidden';
                return false;
            }
            else
            {
                var eMID = document.getElementById('ctl00_ContentPlaceHolder1_txtEditMenuID');
                var eMT = document.getElementById('ctl00_ContentPlaceHolder1_txtEditMenuText');
                //set div location to mouse location plus 5 pixels
                eDiv.style.position = 'absolute';
                eDiv.style.left = window.event.clientX + 10;
                eDiv.style.top = window.event.clientY + 5;
                eDiv.style.visibility = 'visible';
                eDiv.style.display = 'block';
                //set contents of textboxes in popup div
                eMID.value = MID;
                eMT.value = MText;
                eMT.focus();
            }
            return false;
        }
    </script>
    <div id="divTester"></div>
    <div id="divUpdatePopup" style="position:absolute; background-color: #cccc99; visibility: hidden;">
        <table>
            <tr style="font-size: 8pt; color: white; font-family: Arial, Sans-Serif;
                    background-color: navy">
                <td align="left" colspan="2">
                    <table style="width: 100%">
                        <tr>
                            <td align="left">Edit Menu</td>
                            <td align="right"><img alt="" src="../images/error_small.png" onclick="javascript:document.all['divUpdatePopup'].style.visibility='hidden';" style="cursor: pointer;" /></td>
                        </tr>
                    </table>                
                </td>
            </tr>
            <tr>
                <td>
                    Menu ID:</td>
                <td>
                    <asp:TextBox ID="txtEditMenuID" runat="server" CssClass="form" 
                        Width="25px" EnableViewState="False" BackColor="#CCCC99" BorderStyle="None" Font-Bold="True" />
                    </td>
            </tr>
            <tr>
                <td>
                    Menu Text:</td>
                <td>
                    <asp:TextBox ID="txtEditMenuText" runat="server" CssClass="form"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="left">
                    <input type="button" id="btnCancelUpdate" class="form" value="Cancel" onclick="javascript:document.all['divUpdatePopup'].style.visibility='hidden';" />
                    </td>
                <td align="right">
                    <asp:Button ID="btnUpdateMenu" runat="server" CssClass="form" Text="Update" /></td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
<%--    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>--%>
            <asp:GridView ID="grdMenu" runat="server" AutoGenerateColumns="False" DataKeyNames="MenuID"
                DataSourceID="dscTest">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <%--<a onclick="javascript:ShowPopup('<%# Eval("MenuID") %>','<%# Eval("MenuText") %>');" href="#">Edit</a>--%>
                            <input type="button" class="form" onclick="javascript:ShowPopup('<%# Eval("MenuID") %>','<%# Eval("MenuText") %>');" value="Edit"></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MenuID" InsertVisible="False" SortExpression="MenuID">
                        <ItemTemplate>
                            <asp:Label ID="MenuID" runat="server" Text='<%# Bind("MenuID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MenuText" SortExpression="MenuText">
                        <ItemTemplate>
                            <asp:Label ID="MenuText" runat="server" Text='<%# Bind("MenuText") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="dscTest" runat="server" ConnectionString="<%$ ConnectionStrings:PPPConnectionString %>"
                SelectCommand="SELECT [MenuID], [MenuText] FROM [tblMenu]">
            </asp:SqlDataSource>
            <asp:Label ID="lblErrMsg" runat="server" CssClass="errorLabel"></asp:Label><br />
    <br />
    <br />
    <br />
<%--        </contenttemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
