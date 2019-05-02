<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Administration/Admin.master" CodeFile="Category.aspx.cs" Inherits="Administration_Category" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Admin" runat="server">
    <div>

                          <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing">  
                    <Columns>  
                        <asp:CommandField ShowEditButton="true"  />  
                        <asp:CommandField ShowDeleteButton="true" /> </Columns>  
                </asp:GridView>
</div>
    <asp:Label ID="lblMessage" runat="server">Message here.</asp:Label>
    <div>
    Name: <asp:TextBox id="Name" runat="server"/><br/>
                                                            <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="Name"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>

    Supplier: <asp:TextBox id="Supplier" runat="server"/><br/>
                                                                    <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="Supplier"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>

    Category: <asp:TextBox id="Category1" runat="server"/><br/>
                                                            <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="Category1"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>

    Price: <asp:TextBox id="Price" runat="server"/><br/>
                                                            <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="Price"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>

    Status: <asp:TextBox id="Status" runat="server"/><br/>
                                                            <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="Status"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>

    Description: <asp:TextBox  id="Description" runat="server"/><br/>
                                                            <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="Description"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>

        <asp:Button  id="saveitem" Text="Save" OnClick="saveitem_Click" runat="server" />
    </div>
    <div>
        Use this form to update(Hint: use the same description to update a cell):
            Name: <asp:TextBox id="nameupdate" runat="server"/><br/>
            Category: <asp:TextBox id="categoryupdate" runat="server"/><br/>
            Description: <asp:TextBox  id="descriptionupdate" runat="server"/><br/>
                <asp:Button  id="update" Text="Save" OnClick="SaveUpdate" runat="server" />

    </div>
</asp:Content>