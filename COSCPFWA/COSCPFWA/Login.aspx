<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="COSCPFWA.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Login</h2>
        <div>
            <!-- Message Label for error or status display -->
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <div>
            <!-- Username Label and Textbox -->
            <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server" Width="200px"></asp:TextBox>
        </div>
        <div>
            <!-- Password Label and Textbox -->
            <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
        </div>
        <div>
            <!-- Login Button -->
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        </div>
        <div>
            <!-- Registration Link for Customers -->
            <asp:HyperLink ID="lnkRegister" runat="server" NavigateUrl="~/RegisterCustomer.aspx">New Customer? Register Here</asp:HyperLink>
        </div>
    </form>
</body>
</html>