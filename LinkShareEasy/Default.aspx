<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LinkShareEasy._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/setupclipboard.js" type="text/javascript"></script>
    <h2><span style="padding-right: 0.2em; float: left">&#9758;</span>Generate token</h2>
    <div class="row">
        <div class="col-md-4">
            <span style="font-size: 2em; padding-right: 0.2em; float: left">&#9758;</span>
            <p class="small" style="padding-top: 0.40em;">The token you get will last for <span runat="server" id="DefaultDuration1"></span><span runat="server" id="DefaultDurationText"></span>s. After 10 minutes the token will expire. You will have to get a new one.</p>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <div class="input-group">
                <span style="font-size: 2em; padding-right: 0.2em; float: left">&#9758;</span>
                <span class="input-group-btn">
                    <asp:LinkButton ID="LinkButton1" OnClick="TextBox1_TextChanged" runat="server" CssClass="btn btn-default" CausesValidation="true" ValidationGroup="TokenRequest">Get token</asp:LinkButton>
                </span>
                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" AutoPostBack="true" OnTextChanged="TextBox1_TextChanged" ValidationGroup="TokenRequest" CausesValidation="true"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:LinkButton CssClass="un btn  btn-default" ID="OptionsButton" runat="server" href="#options" Text='<span class="un">🔧</span>' />
                </span>
            </div>
        </div>
        <div class="col-md-4" runat="server" id="CopyToken">
            <div class="input-group">
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" onclick="this.select();" ReadOnly="True" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button runat="server" ID="ClipBoardButton" CssClass="btn btn-success clipboard-btn" Text=" &larr; Copy token" />
                </span>
            </div>
        </div>
    </div>

    <div class="collapse" id="options">
        <div class="row">
            <div class="col-md-4">
                <p>Options for token</p>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:RadioButtonList ToolTip="Choose token type" ID="RadioButtonList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="TokenTypeText" DataValueField="TokenTypeId" OnDataBound="RadioButtonList1_DataBound">
                </asp:RadioButtonList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT TokenTypes.TokenTypeId, TokenTypeText FROM [TokenTypes] JOIN TokenTypeConfiguration ON TokenTypeConfiguration.TokenTypeId = TokenTypes.TokenTypeId WHERE TokenTypeConfiguration.Enabled = 1"></asp:SqlDataSource>

                <div class="form-check">
                    <asp:Label runat="server" AssociatedControlID="CheckBox1" CssClass="form-check-label">
                        <input runat="server" type="checkbox" class="form-check-input" id="CheckBox1" value="" title="If checked: token can be used only once during link validity period." />Single-use</asp:Label>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <asp:ValidationSummary HeaderText="Validation errors" runat="server" ValidationGroup="TokenRequest" DisplayMode="SingleParagraph" ShowSummary="false" />
            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TextBox1" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="TokenRequest" ValidateEmptyText="true" ErrorMessage="Uri must be in full form (include http://). Example of good: http://www.google.com ." CssClass="bg-danger"></asp:CustomValidator>
        </div>
    </div>

    <h3><span style="padding-right: 0.2em; float: left">&#9758;</span>Get link</h3>
    <div class="row">
        <div class="col-md-4">
            <div class="input-group">
                <span style="font-size: 2em; float: left">&#9758;</span>
                <span class="input-group-btn">
                    <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click" runat="server" CssClass="btn btn-success" ValidationGroup="LinkRequestValidation" CausesValidation="true">Get link</asp:LinkButton>
                </span>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" ValidationGroup="LinkRequestValidation"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:LinkButton CssClass="btn btn-success" ID="WhatIsIt1" OnClick="WhatIsIt1_Click" runat="server" Text="&nbsp;?&nbsp;" />
                </span>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="LinkRequestValidation" ControlToValidate="TextBox3" runat="server" ErrorMessage="Provide token." CssClass="bg-danger"></asp:RequiredFieldValidator>
            <asp:ValidationSummary HeaderText="Validation errors" runat="server" ValidationGroup="LinkRequestValidation" DisplayMode="SingleParagraph" ShowSummary="false" />
        </div>
    </div>
</asp:Content>
