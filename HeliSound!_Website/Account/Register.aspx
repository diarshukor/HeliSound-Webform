<%@ Page Title="Register" Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
    <asp:CreateUserWizard ID="RegisterUser" runat="server">
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUser" runat="server" />
            <asp:CompleteWizardStep ID="Complete" runat="server" />
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>
