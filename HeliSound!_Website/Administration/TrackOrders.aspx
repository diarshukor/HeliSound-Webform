<%@ Page Language="C#" MasterPageFile="~/Administration/Admin.master" AutoEventWireup="true" CodeFile="TrackOrders.aspx.cs" Inherits="Administration_TrackOrders" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Admin" runat="server">
    <asp:TextBox ID="enterinvoice" runat="server" Text="" />
    <asp:Button ID="Button1" text="search Invoices" runat="server" OnClick="searchinvoice_Click" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"  OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting1" >  
                    <Columns>  
                        <asp:CommandField ShowDeleteButton="true" /> </Columns>  
                </asp:GridView>      
    <asp:Label ID="lblmessage" runat="server" />
</asp:Content>