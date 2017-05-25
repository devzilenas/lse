<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transfer.aspx.cs" Inherits="LinkShareEasy.Transfer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>You will be redirected in <span id="timer">5</span> seconds... please take a look at our sponsoring add.</h1>
    <asp:Panel ID="Panel1" runat="server">
        <asp:AdRotator OnAdCreated="AdRotator_AdCreated" DataSourceID="SqlDataSource1" runat="server" ID="AdRotator" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"  ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"  SelectCommand="SELECT * FROM Banners"></asp:SqlDataSource>
    </asp:Panel>

    <script src="Scripts/countdown.js" type="text/javascript"></script>
</asp:Content>
