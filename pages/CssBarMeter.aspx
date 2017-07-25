<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPages/masterA.Master" CodeBehind="CssBarMeter.aspx.vb" Inherits="DansTools.CssBarMeter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .meter
        {
            height: 50px; /* Can be anything */
            width: 200px;
            position: relative;
            background: #808080;
            /*-moz-border-radius: 25px;
            -webkit-border-radius: 25px;
            border-radius: 25px;*/
            padding: 2px;
            /*-webkit-box-shadow: inset 0 -1px 1px rgba(255,255,255,0.3);
            -moz-box-shadow: inset 0 -1px 1px rgba(255,255,255,0.3);
            box-shadow: inset 0 -1px 1px rgba(255,255,255,0.3);*/
        }
        .wrapper{background: url("") 0 12px repeat-y;}
            .meter > span
            {
                display: block;
                height: 10px;
                margin-top: 5px;
                /*-webkit-border-top-right-radius: 8px;
                -webkit-border-bottom-right-radius: 8px;
                -moz-border-radius-topright: 8px;
                -moz-border-radius-bottomright: 8px;
                border-top-right-radius: 8px;
                border-bottom-right-radius: 8px;
                -webkit-border-top-left-radius: 20px;
                -webkit-border-bottom-left-radius: 20px;
                -moz-border-radius-topleft: 20px;
                -moz-border-radius-bottomleft: 20px;
                border-top-left-radius: 20px;
                border-bottom-left-radius: 20px;*/
                /*background-color: rgb(43,194,83);*/
                /*background-image: -webkit-gradient( linear, left bottom, left top, color-stop(0, rgb(43,194,83)), color-stop(1, rgb(84,240,84)) );
                background-image: -webkit-linear-gradient( center bottom, rgb(43,194,83) 37%, rgb(84,240,84) 69% );
                background-image: -moz-linear-gradient( center bottom, rgb(43,194,83) 37%, rgb(84,240,84) 69% );
                background-image: -ms-linear-gradient( center bottom, rgb(43,194,83) 37%, rgb(84,240,84) 69% );
                background-image: -o-linear-gradient( center bottom, rgb(43,194,83) 37%, rgb(84,240,84) 69% );*/
                /*-webkit-box-shadow: inset 0 2px 9px rgba(255,255,255,0.3), inset 0 -2px 6px rgba(0,0,0,0.4);
                -moz-box-shadow: inset 0 2px 9px rgba(255,255,255,0.3), inset 0 -2px 6px rgba(0,0,0,0.4);*/
                position: relative;
                overflow: hidden;
            }

        .green
        {
            background-color: rgb(43,194,83);
            /*background-image: -webkit-gradient(linear,left top,left bottom,color-stop(0, #f1a165),color-stop(1, #f36d0a));
            background-image: -webkit-linear-gradient(top, #f1a165, #f36d0a);
            background-image: -moz-linear-gradient(top, #f1a165, #f36d0a);
            background-image: -ms-linear-gradient(top, #f1a165, #f36d0a);
            background-image: -o-linear-gradient(top, #f1a165, #f36d0a);*/
        }

        .orange
        {
            background-color: #f1a165;
            /*background-image: -webkit-gradient(linear,left top,left bottom,color-stop(0, #f1a165),color-stop(1, #f36d0a));
            background-image: -webkit-linear-gradient(top, #f1a165, #f36d0a);
            background-image: -moz-linear-gradient(top, #f1a165, #f36d0a);
            background-image: -ms-linear-gradient(top, #f1a165, #f36d0a);
            background-image: -o-linear-gradient(top, #f1a165, #f36d0a);*/
        }

        .red
        {
            background-color: #f0a3a3;
            background-image: -webkit-gradient(linear,left top,left bottom,color-stop(0, #f0a3a3),color-stop(1, #f42323));
            background-image: -webkit-linear-gradient(top, #f0a3a3, #f42323);
            background-image: -moz-linear-gradient(top, #f0a3a3, #f42323);
            background-image: -ms-linear-gradient(top, #f0a3a3, #f42323);
            background-image: -o-linear-gradient(top, #f0a3a3, #f42323);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="txtMeterPercent" runat="server"></asp:TextBox><asp:Button ID="btnUpdateMeterPercent" runat="server" Text="Update" />
    <div align="left" style="float: right;">
        <div class="meter">
            <span class="green" style="width: <%=_meterPercent %>%; text-align: right;">$600</span>
            <span class="orange" style="width: <%=_meterPercent2 %>%; text-align: right;">$400</span>
        </div>
    </div>
    <div class="wrapper">
        <div>Float this one left</div>
        <div>float this one right</div>
</div>
</asp:Content>
