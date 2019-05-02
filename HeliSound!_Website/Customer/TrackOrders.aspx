<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Customer/Customer.master" CodeFile="TrackOrders.aspx.cs" Inherits="Customer_TrackOrders" %>

<asp:Content ContentPlaceHolderID="Customer"  runat="server">
<div style=" text-align:center">
                          <asp:GridView ID="GridView1" runat="server" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting">  
                               <Columns>                     
                        <asp:CommandField ShowDeleteButton="true" /> </Columns>  
                </asp:GridView>        
    <asp:Label ID="lblMessage" runat="server" />
</div>
</asp:Content>
