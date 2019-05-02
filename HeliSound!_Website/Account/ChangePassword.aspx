<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" MasterPageFile="~/Account/Account.Master" Inherits="Account_ChangePassword" %>

<asp:Content id="content" ContentPlaceHolderID="ContentPlaceHolder1"  runat="server">
<asp:TextBox runat="server" id="UserName" Text="Username" />
    <asp:TextBox runat="server" TextMode="Password" id="Password" Text="Password" />
    <asp:TextBox runat="server" TextMode="Password" id="newPassword" Text="new Password" />
    <asp:Button runat="server" id="changePass" OnClick="change" Text="Submit" />
</asp:Content>