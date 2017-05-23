<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LinkShareEasy._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <script src="Scripts/setupclipboard.js" type="text/javascript"></script> 
    <h2>Generate token</h2>
    <p>
        Link share easy service let's you share a link with anyone instantly.
    </p>

<div class="row">
  <div class="col-lg-3">
    <div class="input-group">
      <span class="input-group-btn">
        <asp:LinkButton ID="LinkButton1" OnClick="TextBox1_TextChanged" runat="server" CssClass="btn btn-default">Get token</asp:LinkButton>
      </span>
        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" AutoPostBack="true" OnTextChanged="TextBox1_TextChanged" ValidationGroup="TokenRequest"></asp:TextBox> 
    </div><!-- /input-group -->
  </div><!-- /.col-lg-6 -->
        <a class="btn btn-secondary" data-toggle="collapse" href="#options" aria-expanded="false" aria-controls="options">Options</a>
    </div>

<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox1" ValidationGroup="TokenRequest"></asp:RequiredFieldValidator> 
    
    <div class="row">
        <div class="col-lg-3"> 
            <div class="collapse" id="options">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="TokenTypeText" DataValueField="TokenTypeId" OnDataBound="RadioButtonList1_DataBound">
                </asp:RadioButtonList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT TokenTypes.TokenTypeId, TokenTypeText FROM [TokenTypes] JOIN TokenTypesConfiguration ON TokenTypesConfiguration.TokenTypeId = TokenTypes.TokenTypeId WHERE TokenTypesConfiguration.Enabled = 1"></asp:SqlDataSource> 
            </div> 
        </div>
    </div>
 
    <div class="row">
        <div class="col-lg-3">
            <div class="input-group">
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" onclick="this.select();" ReadOnly="True"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button runat="server" ID="ClipBoardButton" CssClass="btn btn-default clipboard-btn" Text="copy" />
                </span>
            </div>
        </div>
    </div>

    <h3>Get link</h3>
    <div class="row">
        <div class="col-md-6">
            <div class="input-group">
                <span class="input-group-btn">
                    <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click" runat="server" CssClass="btn btn-default">Get link for token (enter token here &rarr;)</asp:LinkButton>
                </span>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>

</asp:Content>
