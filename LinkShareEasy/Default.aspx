<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LinkShareEasy._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Getting started</h2>
    <p>
        Link share easy service let's you share a link with anyone instantly.
    </p>
        <div class="row">
            <div class="col-lg-6">
                    <asp:Label runat="server" ID="Label3" Text="Put link here" AssociatedControlID="TextBox1"></asp:Label>
                <div class="input-group"> 
                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" AutoPostBack="true" OnTextChanged="TextBox1_TextChanged"></asp:TextBox> 
                    <span class="input-group-btn">
                        <asp:LinkButton ID="LinkButton1" OnClick="TextBox1_TextChanged" runat="server" CssClass="btn btn-secondary">Get token</asp:LinkButton>
                        <a class="btn btn-secondary" data-toggle="collapse" href="#options" aria-expanded="false" aria-controls="options">Options</a>
                    </span>
                </div>
            </div>
        </div>
    <div class="row">
        <div class="col-lg-6"> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
            <div class="collapse" id="options">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="TokenTypeText" DataValueField="TokenTypeId" OnDataBound="RadioButtonList1_DataBound">
                </asp:RadioButtonList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [TokenTypeId], [TokenTypeText] FROM [TokenType]"></asp:SqlDataSource> 
            </div> 
        </div>
    </div>
 
    <div class="form-group">
        <asp:Label runat="server" ID="Label2" Text="Here's your token" AssociatedControlID="TextBox2"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

</asp:Content>
