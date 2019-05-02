<%@ Page Title="About" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>HeliSound</h1>
        <h2>HeliSound sells a variety of products.</h2>
    </hgroup>

    <article>
        <p>        
            From Televisions to Computers!
        </p>

        <p>        
            Fridges to other appliances        </p>

        <p>        
            Tell us what you want at info@helisound.com
        </p>
    </article>

    <aside>
        <h3>Consider it shipped</h3>
        <p>        
Shipping guarantee.
        </p>
        <ul>
            <li><a runat="server" href="~/">Home</a></li>
            <li><a runat="server" href="~/About">About</a></li>
            <li><a runat="server" href="~/Contact">Contact</a></li>
        </ul>
    </aside>
</asp:Content>