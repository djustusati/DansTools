<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPages/masterA.Master" CodeBehind="FmrYtdTest.aspx.vb" Inherits="DansTools.FmrYtdTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Market Size:
        <asp:TextBox ID="TextBox1" runat="server">Large</asp:TextBox>
        <br/>
        Week Hours Goal:
        <asp:TextBox ID="TextBox2" runat="server">45</asp:TextBox>
        <br/>
        YTD Surveys:
        <asp:TextBox ID="TextBox3" runat="server">294</asp:TextBox>
        <br/>
        YTD Payment:
        <asp:TextBox ID="TextBox4" runat="server">1320</asp:TextBox>
        <br/>
        YTD BA Hours:
        <asp:TextBox ID="TextBox5" runat="server">46</asp:TextBox>
        <br/>
        YTD AS 2124:
        <asp:TextBox ID="TextBox6" runat="server">134</asp:TextBox>
        <br/>
        YTD AS 2529:
        <asp:TextBox ID="TextBox7" runat="server">109</asp:TextBox>
        <br/>
        YTD AS 30Plus:
        <asp:TextBox ID="TextBox8" runat="server">51</asp:TextBox>
        <br/>
        YTD Email:
        <asp:TextBox ID="TextBox9" runat="server">294</asp:TextBox>
        <br/>
        YTD Phone:
        <asp:TextBox ID="TextBox10" runat="server">294</asp:TextBox>
        <br/>
        Week Number :
        <asp:TextBox ID="TextBox11" runat="server">1</asp:TextBox>
        <br/>
        <br/>
        <asp:Button ID="Button1" runat="server" Text="Go" />
        <br/>
        <br/>
        Return Value: <asp:Label ID="lblReturnValue" runat="server"></asp:Label>
    </p>
</asp:Content>
