<%@ Page Language="C#" EnableViewState="true" MasterPageFile="~/Customer/Customer.master"   AutoEventWireup="true" CodeFile="OrderProduct.aspx.cs" Inherits="Customer_OrderProduct" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Customer" runat="server">

    <div style="position:relative;left:30%;"><asp:DropDownList runat="server" ID="suppliers" AutoPostBack="true"  />
    <asp:DropDownList runat="server" ID="category" AutoPostBack="true"  />
    <asp:DropDownList runat="server" ID="products"  AutoPostBack="true"  />
        </div>
<div id="gridview" style="top:20rem;"><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" >                     
    <Columns>  
    </Columns>
</asp:GridView></div>
        <p class="orderproductlabels">Billing<br /></p>
        <p class="orderproductlabels">Name</p> <div class="cast"><asp:TextBox  id="name" runat="server"/><br /></div>
     <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="name"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>
    
    <p class="orderproductlabels">Type of Credit Card:</p> <div class="cast"><asp:TextBox  id="type" runat="server"/><br /></div>
     <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="type"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>

    <p class="orderproductlabels">CC Number:</p> <div class="cast"><asp:TextBox id="CCNumber" runat="server"/><br /></div>
  <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" 
 ControlToValidate="CCNumber" ErrorMessage="Value must be a whole number" />

    <p class="orderproductlabels">Security Code:</p> <div class="cast"><asp:TextBox  id="securitycode" runat="server"/><br /></div>
     <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" 
 ControlToValidate="securitycode" ErrorMessage="Value must be a whole number" />

    <p class="orderproductlabels">Month:</p> <div class="cast"><asp:DropDownList id="month" runat="server"/><br /></div>
     <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="month"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>

    <p class="orderproductlabels">Year:</p> <div class="cast"> <asp:DropDownList  id="year" runat="server"><asp:ListItem Text="2019"/><asp:ListItem Text="2020"/><asp:ListItem Text="2021"/><asp:ListItem Text="2022"/><asp:ListItem Text="2023"/></asp:DropDownList><br /></div>
     <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="year"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>

    <div id="delivery"><p class="orderproductlabels">Delivery</p>
            <p class="orderproductlabels">House Number:</p> <div class="cast"><asp:TextBox  id="housenumber" runat="server"/><br /></div>
<asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" 
 ControlToValidate="housenumber" ErrorMessage="Value must be a whole number" />
        <p class="orderproductlabels">Street:</p><div class="cast"> <asp:TextBox  id="street" runat="server"/><br /></div>
        
         <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="street"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>
        <p class="orderproductlabels">Apartment Unit:</p><div class="cast"> <asp:TextBox id="apt" runat="server"/><br /></div>
        <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" 
 ControlToValidate="apt" ErrorMessage="Value must be a whole number" />
        <p class="orderproductlabels">City:</p><div class="cast"> <asp:TextBox  id="city" runat="server"/><br /></div>
         <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="city"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>
        <p class="orderproductlabels">Province:</p><div class="cast"> <asp:DropDownList  id="province" runat="server"/><br /></div>
         <asp:RequiredFieldValidator runat="server"
                                                        ErrorMessage="Required." ControlToValidate="province"
                                                        ToolTip="This is required." ></asp:RequiredFieldValidator>
    <asp:Button OnClick="saveitem_Clicks" Text="ORDER" runat="server" id="save" CssClass="bg-light alert-success btn-lg" style="width:100px;height:80px; position:absolute;left:-10rem;top:37rem;" /><br />
    <br /><br /></div>
        <div class="cast">Total: <asp:Label runat="server" ID="total" /><br /></div>
<asp:Label Visible="false" ID="odrplaced" runat="server" /><br /></div>
</asp:Content>