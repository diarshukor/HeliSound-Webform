<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderShipping.aspx.cs" MasterPageFile="~/Shipping/Shipping.master" Inherits="Shipping_OrderShipping" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Shipping" runat="server">
<div style=" text-align:center">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"  >  
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="selected" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
            </asp:GridView>        
    <asp:Label ID="lblMessage" runat="server" />
    <asp:Button ID="cancel" Text="Click me."  runat="server"/>
</div>
        <asp:Label ID="Label1" runat="server" />
    <asp:Button ID="Ship" Text="Ship" OnClick="Ship_Click" runat="server"/>

 
    Shipped Orders:
          <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="true" >  
                    <Columns>  
                    </Columns>
            </asp:GridView>        
</asp:Content>
