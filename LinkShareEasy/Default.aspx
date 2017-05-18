<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LinkShareEasy._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">Is a free service (sponsored by <a href="Sponsoring.aspx">sponsors</a>) to share a link instantly.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-large">It doesn't solve problems and doesn't add new problems either.</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                Link share easy service let's you share a link with anyone instantly.
            </p>
            <p>
                              <asp:Label ID="Label1" runat="server" Text="Put link here" AssociatedControlID="TextBox1"></asp:Label>
<asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox> 
                
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="" AssociatedControlID="TextBox2"></asp:Label>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
