<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="LinkShareEasy.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Error</h2>
    <asp:Label ID="FriendlyErrorMsg" runat="server" Text="Label"></asp:Label>

    <asp:Panel ID="DetailedErrorPanel" runat="server" Visible="false">
        <h4>Detailed error message:</h4>
        <p><asp:Label ID="ErrorDetailedMsg" runat="server"></asp:Label></p>

        <h4>Error handler</h4>
        <p><asp:Label ID="ErrorHandler" runat="server"></asp:Label></p>

        <h4>Detailed error message</h4>
        <p><asp:Label ID="InnerMessage" runat="server"></asp:Label></p>
        <p><asp:Label ID="InnerTrace" runat="server"></asp:Label></p>
    </asp:Panel>
</asp:Content>
