<%@ Page Language="C#" MasterPageFile="~/Customer/Customer.master" AutoEventWireup="true" CodeFile="ViewHistory.aspx.cs" Inherits="Customer_ViewHistory" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Customer" runat="server">
<div style=" text-align:center">
                          <asp:GridView ID="GridView1" runat="server">  
    <Columns>  

    </Columns>
                </asp:GridView>        
    <asp:Label ID="lblMessage" runat="server" />
    <asp:Button ID="cancel" Text="Cancel" OnClick="cancel_Click"  runat="server"/>
</div>
    <asp:Label ID="lblerror" runat="server"/>
</asp:Content>
