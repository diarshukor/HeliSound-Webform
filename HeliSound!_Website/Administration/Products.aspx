<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Administration/Admin.master" CodeFile="Products.aspx.cs" Inherits="Administration_Products" %>

    <asp:Content ID="Content2" ContentPlaceHolderID="Admin" runat="server">
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true">  
                    <Columns>  
                        <asp:CommandField ShowEditButton="true" />  
                        <asp:CommandField ShowDeleteButton="true" /> </Columns>  
                </asp:GridView>        
        <br />
        Name: <asp:TextBox  id="addfirstname" runat="server"/><br/>
         <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="addfirstname"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>
        Supplier: <asp:TextBox id="addaddress" runat="server"/><br/>
         <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="addaddress"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>
        Category: <asp:TextBox id="addcontact" runat="server"/><br/>
         <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="addcontact"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>
        Price: <asp:TextBox id="addtelephone" runat="server"/><br/>
         <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="addtelephone"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>
    Status: <asp:TextBox id="addstatus" runat="server"/><br/>
         <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="addstatus"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>
    Description: <asp:TextBox id="addrole_id" runat="server"/><br/>
         <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="addrole_id"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>
        <asp:Button  Text="Save" id="Button1" runat="server" OnClick="saveitem_Click" />
</asp:Content>
