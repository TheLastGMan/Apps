<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" MasterPageFile="~/master/Main.master" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="Header">       
    <p>
        FlightNav - Applications
    </p>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="Bodyx">
        <b><font size="+1">FlightNav ADF</font></b><br />
        <asp:ImageButton ID="ImageButton1" ImageUrl="~/images/ic_launcher.png" runat="server" Width="64px"/><br />
        (GPS based naviagation android app)<br />
        <a href="https://play.google.com/store/apps/details?id=com.rpgcor.aeronav.flightnavadf&feature=search_result#?t=W251bGwsMSwyLDEsImNvbS5ycGdjb3IuYWVyb25hdi5mbGlnaHRuYXZhZGYiXQ.." target="_blank">FNADF</a><br />
    <br />
    <hr />
    <b><font size="+1">FlightNav PlanFiler</font></b><br />
        <asp:ImageButton ID="ImageButton2" ImageUrl="~/images/FNS_small.png" runat="server" Width="64px" /><br />
        (Flight Filing service utilizing DUATS)<br />
        <a href="https://play.google.com/store/apps/details?id=com.rpgcor.aeronav.flightnavplanfiler&feature=search_result#?t=W251bGwsMSwyLDEsImNvbS5ycGdjb3IuYWVyb25hdi5mbGlnaHRuYXZwbGFuZmlsZXIiXQ.." target="_blank">
        FNPF</a><br />
    <br />
    <hr />
        <b><font size="+1">FlightNav Naviagation Log</font></b><br />
        (Excel Navigation Log w/ auto weather, coms)<br />
        <a href="http://apps.rpgcor.com/4-FNL_NL/download.html" target="_self">FNNL</a><br />
    <br />
    <hr />
        <b><font size="+1">FlightNav WebService</font></b><br />
        (SOAP service providing generic information)<br />
        <i>[username/password not required at moment]</i><br />
        <a href="Aviation.asmx" target="_self">FNWS</a><br />
    <br />
    <hr />
        <br />
</asp:Content>

