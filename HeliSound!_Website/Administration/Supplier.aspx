<%@ Page Language="C#" MasterPageFile="~/Administration/Admin.master" AutoEventWireup="true" CodeFile="Supplier.aspx.cs" Inherits="Administration_Supplier" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Admin" runat="server">

                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"  OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">  
                    <Columns>  
                        <asp:BoundField DataField="Name" HeaderText="ID"/>
                        <asp:BoundField DataField="Address" HeaderText="Description"/>
                        <asp:BoundField DataField="Contact" HeaderText="Description"/>
                        <asp:BoundField DataField="Telephone" HeaderText="Description"/>
                        <asp:BoundField DataField="Status" HeaderText="Description"/>
                        <asp:CommandField ShowEditButton="true" />  
                        <asp:CommandField ShowDeleteButton="true" /> </Columns>  
                </asp:GridView>        
    
    Name: <asp:TextBox id="addname" runat="server"/><br/>
    <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="addname"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>
    Address: <asp:TextBox  id="addaddress" runat="server"/><br/>
    <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="addaddress"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>
    Contact: <asp:TextBox  id="addcontact" runat="server"/><br/>
    <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="addcontact"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>
    Phone: <asp:TextBox  id="addtelephone" runat="server"/><br/>
    <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="addtelephone"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>
    Status: <asp:TextBox  id="addstatus" runat="server"/><br/>
    <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="addstatus"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>
    Role: <asp:TextBox  id="addrole_id" runat="server"/><br/>
    <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="addrole_id"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>
    Category: <asp:TextBox  id="addcategory" runat="server"/><br/>
    <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="addcategory"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>
        <asp:Button Text="Add" id="saveitem" OnClick="saveitem_Click" runat="server" />

</asp:Content>