<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Administration/Admin.master" CodeFile="UserMaintenance.aspx.cs" Inherits="Administration_UserMaintenance" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Admin" runat="server">
<div style=" text-align:center">
                          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"  >  
                    <Columns>  

                        <asp:CommandField ShowEditButton="true" />  
                        <asp:CommandField ShowDeleteButton="true" /> </Columns>  
                </asp:GridView>        

        <asp:CreateUserWizard ID="RegisterUser" runat="server">
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUser" runat="server" />
        </WizardSteps>
    </asp:CreateUserWizard>
</div>
</asp:Content>
