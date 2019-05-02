<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductManagement.aspx.cs" Inherits="Administration_ProductManagement" MasterPageFile="~/Administration/Admin.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Admin" runat="server">
<div style=" text-align:center">
                <asp:GridView ID="thegrid" runat="server" AutoGenerateColumns="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" >  
                    <Columns>  

                        <asp:CommandField ShowEditButton="true" />  
                        <asp:CommandField ShowDeleteButton="true" /> </Columns>  
                </asp:GridView>        
</div>
    <div>
        
        Name: <asp:TextBox ID="Name" runat="server" /><br/>
                                                                    <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="Name"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>

        Supplier: <asp:TextBox ID="Supplier" runat="server" /><br/>
                                                                    <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="Supplier"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>

        Category: <asp:TextBox ID="Category" runat="server" /><br/>
                                                            <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="Category"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>
        
        Price: <asp:TextBox ID="Price" runat="server" /><br/>
                                                            <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="Price"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>
        
        Status: <asp:TextBox ID="Status" runat="server" /><br/>
                                                            <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="Status"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>
        
        Description: <asp:TextBox ID="Description" runat="server" /><br/>
                                                                    <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="Description"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>

        <asp:Button runat="server" Text="Save" OnClick="saveitem_Click" /><br/>
    </div>
</asp:Content>
