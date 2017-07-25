<%@ Page Language="VB" AutoEventWireup="false" Inherits="PPPMisc.b" StylesheetTheme="DropDownTheme" Codebehind="b.aspx.vb" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script type="text/javascript">
var value1 = 0;
var value2 = 0;
function ReceiveServerData2(arg, context)
{
    Message2.innerText = arg;
    value2 = arg;
}
function ProcessCallBackError(arg, context)
{
    Message2.innerText = 'An error has occurred.';
}
function fChangeList()
{
    listData.innerHTML = '<IFRAME src="subList.aspx?t=v&mid='
         + document.form1.ddlMarketList.value 
         + '" width="100%" height="150" frameborder="0"></IFRAME>';
}
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ajax Test</title>
    <link type="text/css" href="Styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" style="width:100%">
      Callback 1 result: <span id="Message1">0</span>
      <br />
      Callback 2 result: <span id="Message2">0</span>
      <br /> <br />
      <input type="button" 
             value="ClientCallBack1" 
             onclick="CallTheServer1(value1)"/>    
      <input type="button" 
             value="ClientCallBack2" 
             onclick="CallTheServer2(value2, alert('Increment value'))"/>
      <br /> <br />
      <asp:Label id="MyLabel" 
                 runat="server"></asp:Label>
        <br />
        
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="false" EnablePartialRendering="true">
        </asp:ScriptManager>
        Venue:&nbsp;<br />
        &nbsp;
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                Venue:
                <asp:TextBox ID="txtFirstName" runat="server" Width="250px"></asp:TextBox>
                <asp:Panel ID="Panel1" runat="server" Height="50px" Width="125px" Visible="true">
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        &nbsp;&nbsp;
        <br />
        <select name="ddlMarketList" onchange="fChangeList()">
            <option value="135" selected="selected">Albequerque</option>
            <option value="71">Chicago</option>
            <option value="86">Indianapolis</option>
            <option value="97">Milwaukee</option>
        </select><br />
        <div id="listData"></div>
    <asp:Panel ID="pnlEncryptionHeader" style="cursor:pointer;" runat="server">
        <div class="panelHideHeading">
            <asp:Image ID="imgEncryptionToggle" runat="server" ImageUrl="~/images/collapse.jpg" />
            Password Encryption
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlEncryptionContent" runat="server" CssClass="panelHideContent">
        Password Encrypter<br />
            User:
            <asp:TextBox ID="txtUser" runat="server"></asp:TextBox><br />
        Pass:
        <asp:TextBox ID="txtPass" runat="server" Width="462px"></asp:TextBox>&nbsp;<asp:Button ID="btnEncryptPass"
            runat="server" Text="Encrypt" />
            <br />
            Encryption:
            <asp:TextBox ID="txtEncryption" runat="server" Width="425px"></asp:TextBox>
        <asp:Button ID="btnDecrypt" runat="server" Text="Decrypt" /><br />
            Result:
        <asp:TextBox ID="txtPassEncr" runat="server" Width="462px"></asp:TextBox><br />
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlPassGenHeader" runat="server" Style="cursor: pointer;">
        <div class="panelHideHeading">
            <asp:Image ID="imgPassGenToggleImage" runat="server" ImageUrl="~/images/expand.jpg" />
            Password Generator
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlPassGenContent" runat="server" CssClass="panelHideContent">
        <div>
        <div style="float:left; width:175px"><asp:label ID="lblComplexitySelect" runat="server" Text="Complexity:" Width="76px" Style="display: block; padding:2px; padding-right: 50px;" />
        </div>
        <div style="float:right; width:100%">
        <asp:UpdatePanel runat="server" ID="upnlPassGen" RenderMode="Inline">
            <ContentTemplate>
                <asp:Label ID="lblComplexity" runat="server" Text="Simple" Width="108px"></asp:Label><br />
                <asp:Label ID="lblLen" runat="server" CssClass="form" Text="Length"></asp:Label>
                <asp:TextBox ID="txtPassLen" runat="server" MaxLength="2" Width="30px" Wrap="False">8</asp:TextBox>
                <asp:FilteredTextBoxExtender runat="server" ID="ftePassLen" TargetControlID="txtPassLen" FilterType="numbers" />
                <asp:Button ID="btnGeneratePassword" runat="server" Text="Generate" OnClick="btnGeneratePassword_Click" />
                <asp:TextBox ID="txtNewPassword" runat="server" Width="313px" Wrap="False"></asp:TextBox>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lnkPWSimple" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="lnkPWMedium" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="lnkPWComplex" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        &nbsp;
        <asp:UpdatePanelAnimationExtender ID="UpdateAnimation" runat="server" TargetControlID="upnlPassGen" BehaviorID="Highlight">
            <Animations>
                <OnUpdated>
                    <Sequence>
                        <ScriptAction Script="$find('Highlight')._onUpdated._animation._animations[1].set_target($get('ctl00_ContentPlaceHolder1_upnlPassGen'));" />
                        <Color Duration=".5" StartValue="#FFFF90" EndValue="#FFFFFF" Property="style" PropertyKey="backgroundColor" />
                    </Sequence>
                </OnUpdated>
            </Animations>
        </asp:UpdatePanelAnimationExtender>
        <asp:Panel ID="pnlPWDropDown" runat="server" CssClass="ContextMenuPanel" style="display:none;visibility:hidden;">
            <asp:LinkButton ID="lnkPWSimple" CssClass="ContextMenuItem" runat="server" OnClick="PWComplexityChange">Simple</asp:LinkButton>
            <asp:LinkButton ID="lnkPWMedium" CssClass="ContextMenuItem" runat="server" OnClick="PWComplexityChange">Medium</asp:LinkButton>
            <asp:LinkButton ID="lnkPWComplex" CssClass="ContextMenuItem" runat="server" OnClick="PWComplexityChange">Complex</asp:LinkButton>
        </asp:Panel>
        <asp:DropDownExtender runat="server" ID="DDE" TargetControlID="lblComplexitySelect" DropDownControlID="pnlPWDropDown" />
        </div>
        </div>
    </asp:Panel>
    <asp:CollapsiblePanelExtender ID="cpeEncryption" runat="Server" TargetControlID="pnlEncryptionContent"
        ExpandControlID="pnlEncryptionHeader" CollapseControlID="pnlEncryptionHeader"
        Collapsed="true" ExpandDirection="Vertical" ImageControlID="imgEncryptionToggle"
        ExpandedImage="~/images/collapse.jpg" ExpandedText="Collapse" CollapsedImage="~/images/expand.jpg"
        CollapsedText="Expand" SuppressPostBack="true" />
    <asp:CollapsiblePanelExtender ID="cpePassGen" runat="Server" TargetControlID="pnlPassGenContent"
        ExpandControlID="pnlPassGenHeader" CollapseControlID="pnlPassGenHeader"
        Collapsed="True" ExpandDirection="Vertical" ImageControlID="imgPassGenToggleImage"
        ExpandedImage="~/images/collapse.jpg" ExpandedText="Collapse" CollapsedImage="~/images/expand.jpg"
        CollapsedText="Expand" SuppressPostBack="true" />

    </form>
</body>
</html>
