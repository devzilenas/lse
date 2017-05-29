<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TokenExpired.aspx.cs" Inherits="LinkShareEasy.TokenExpired" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>This token has expired.</h1>
    <asp:Button runat="server" ID="Button1" OnClick="Button1_Click" CssClass="btn btn-default" Text="Get a token" />
</asp:Content>
