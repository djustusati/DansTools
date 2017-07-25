<%@ Page Language="VB" MasterPageFile="~/masterPages/masterA.master" AutoEventWireup="true" Inherits="DansTools.Geocode.Geocode" Title="Geocoder" CodeBehind="geocode.aspx.vb" %>
<asp:Content runat="server" ID="HeadContent" ContentPlaceHolderID="head">
    <title>Simple Map</title>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no">
    <meta charset="utf-8">
    <style>
      html, body, #map-canvas {
        margin: 0;
        padding: 0;
        height: 100%;
      }
    </style>
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
    <script>
        var map;
        function initialize() {
            var mapOptions = {
                zoom: 8,
                center: new google.maps.LatLng(41.850033, -87.65005229999997),
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            map = new google.maps.Map(document.getElementById('map-canvas'),
                mapOptions);
        }

        google.maps.event.addDomListener(window, 'load', initialize);

    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h6>
    Geocoder</h6>
    <div id="map-canvas" style="border: solid 2px black; height: 800px; width: 95%;"></div>

</asp:Content>


