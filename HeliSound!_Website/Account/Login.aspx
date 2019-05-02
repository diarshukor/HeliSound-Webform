<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1"  runat="server">
 <div>


            <div style="position:relative;width:20%;left:5%;right:75%;">
                <table>
        <tr>
 <asp:Login ID="Login1" runat="server" Height="100%" Width="100%">
                        <LayoutTemplate>
                            <table cellpadding="1" cellspacing="0" style="border-collapse:collapse; width:100%;">
                                <tr>
                                    <td>
                                        <table align="left" border="0" cellpadding="0" style="width:100%">
                                            <tr>
                                                <td align="center" colspan="3">
                                                  </td>
                                            </tr>

                                            <tr>
                                                <td align="left">
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server"
                                                        ControlToValidate="UserName" ErrorMessage="User Name is required."
                                                        ToolTip="User Id is required." ValidationGroup="Login1"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server"
                                                        ControlToValidate="Password" ErrorMessage="Password is required."
                                                        ToolTip="Password is required." ValidationGroup="Login1"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" style="color:Red;">
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2">
                                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In"
                                                        ValidationGroup="Login1" onclick="LoginButton_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                    </asp:Login>
        </tr>
    <tr>
        <td>
            <asp:LinkButton ID="lnkForgotPassword" runat="server" 
                PostBackUrl="~/Account/ChangePassword.aspx">Forgot Password</asp:LinkButton></td>
        <td><br />
            <asp:LinkButton ID="lnkCreateProfile" runat="server" 
                PostBackUrl="~/Account/Register.aspx">Create Account</asp:LinkButton></td>
        
        </tr>
</table>
                                </div>

</div>
<div style="text-align:center;">
    <asp:Label ID="lblMsg" runat="server" Text="Label" Visible="False" 
        Font-Bold="True" ForeColor="#CC0000"></asp:Label>
</div>
</asp:Content>
