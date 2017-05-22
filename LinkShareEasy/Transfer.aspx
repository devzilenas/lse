<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transfer.aspx.cs" Inherits="LinkShareEasy.Transfer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <asp:AdRotator OnAdCreated="AdRotator_AdCreated" DataSourceID="SqlDataSource1" runat="server" ID="AdRotator" Width="600" Height="600" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"  ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"  SelectCommand="SELECT * FROM Banners"></asp:SqlDataSource>
    </asp:Panel>
</asp:Content>
