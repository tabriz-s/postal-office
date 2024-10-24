<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="COSCPFWA.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Developers Contact Information</h3>
        <address>
            University of Houston<br />
            Adress<br />
            <abbr title="Phone">P:</abbr>
            555.555.5555
        </address>

        <address>
            <strong> For support email any of the developers:</strong>   <a href="mailto:sjgamboa@my.cougarnet.uh.edu">sjgamboa@my.cougarnet.uh.edu</a><br />
            <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
        </address>
    </main>
</asp:Content>
