<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LinkShareEasy._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/setupclipboard.js" type="text/javascript"></script>
    <h2>Generate token</h2>
    <p>Link share easy service let's you share a link with anyone instantly.</p>
    <p>The token you get will last for <span runat="server" id="DefaultDuration1"></span><span runat="server" id="DefaultDurationText"></span>. After 10 minutes the token will expire. You will have to get a new one.</p>

    <div class="row">
        <div class="col-md-4">
            <div class="input-group">
                <span class="input-group-btn">
                    <asp:LinkButton ID="LinkButton1" OnClick="TextBox1_TextChanged" runat="server" CssClass="btn btn-default" CausesValidation="true" ValidationGroup="TokenRequest">1. Get token</asp:LinkButton>
                </span>
                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" AutoPostBack="true" OnTextChanged="TextBox1_TextChanged" ValidationGroup="TokenRequest" CausesValidation="true"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-4">
            <div class="input-group">
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" onclick="this.select();" ReadOnly="True" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button runat="server" ID="ClipBoardButton" CssClass="btn btn-success clipboard-btn" Text=" &larr; 2. Copy token" />
                </span>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-1">
            <a class="btn btn-link btn-m" data-toggle="collapse" href="#options" aria-expanded="false" aria-controls="options">🔧</a>
        </div>
    </div>

    <div class="collapse" id="options">
        <div class="row">
            <div class="col-md-6">
                <p>Options for token</p>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:RadioButtonList ToolTip="Choose token type" ID="RadioButtonList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="TokenTypeText" DataValueField="TokenTypeId" OnDataBound="RadioButtonList1_DataBound">
                </asp:RadioButtonList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT TokenTypes.TokenTypeId, TokenTypeText FROM [TokenTypes] JOIN TokenTypeConfiguration ON TokenTypeConfiguration.TokenTypeId = TokenTypes.TokenTypeId WHERE TokenTypeConfiguration.Enabled = 1"></asp:SqlDataSource>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <p>
                <asp:ValidationSummary HeaderText="Validation errors" runat="server" ValidationGroup="TokenRequest" DisplayMode="SingleParagraph" ShowSummary="false" />
                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TextBox1" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="TokenRequest" ValidateEmptyText="true" ErrorMessage="Uri must be in full form (include http://). Example of good: http://www.google.com ."></asp:CustomValidator>
            </p>
        </div>
    </div>

    <h3>Get link</h3>
    <div class="row">
        <div class="col-md-6">
            <div class="input-group">
                <span class="input-group-btn">
                    <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click" runat="server" CssClass="btn btn-success" ValidationGroup="LinkRequestValidation" CausesValidation="true">Get link for token (enter token here &rarr;)</asp:LinkButton>
                </span>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" ValidationGroup="LinkRequestValidation"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="LinkRequestValidation" ControlToValidate="TextBox3" runat="server" ErrorMessage="Provide token."></asp:RequiredFieldValidator>
            <asp:ValidationSummary HeaderText="Validation errors" runat="server" ValidationGroup="LinkRequestValidation" DisplayMode="SingleParagraph" ShowSummary="false" />
        </div>
    </div>

</asp:Content>
