<%@ Page Language="C#" MasterPageFile="~/Administration/Admin.master" AutoEventWireup="true" CodeFile="Reporting.aspx.cs" Inherits="Administration_Reporting" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Admin" runat="server">
<div style=" text-align:center;">
                          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"  >  
                    <Columns>  
</Columns>
                </asp:GridView>        
    <asp:Label ID="lblMessage" runat="server" />
    <asp:Label ID="lblTotal" runat="server" />
</div>
</asp:Content>
