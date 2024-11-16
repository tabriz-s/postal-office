<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="COSCPFWA.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-image: linear-gradient(to bottom right, #4a69bd, #6a89cc);
            display: flex;
            justify-content: center;
            align-items: center;
            flex-direction: column;
            height: 100vh;
            margin: 0;
            font-family: 'Segoe UI', sans-serif;
        }

        .login-container {
            background-color: rgba(255, 255, 255, 0.85);
            border: 1px solid #ced4da;
            border-radius: 10px;
            padding: 2rem;
            box-shadow: 0 6px 10px rgba(0, 0, 0, 0.15);
            max-width: 400px;
            width: 100%;
            text-align: center;
        }

        .login-header {
            color: #333;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .login-logo {
            max-width: 500px;
            height: auto;
            margin-bottom: 20px;
        }

        .btn-postal {
            background-color: #5a82cc;
            color: #fff;
            font-weight: bold;
            border: none;
            transition: background-color 0.3s ease, transform 0.2s ease;
        }

        .btn-postal:hover {
            background-color: #4a6bb5;
            transform: scale(1.03);
        }

        .form-control:focus {
            border-color: #5a82cc;
            box-shadow: 0 0 5px rgba(90, 130, 204, 0.4);
        }

        .register-link {
            font-size: 0.9rem;
            color: #5a82cc;
            text-decoration: none;
        }

        .register-link:hover {
            text-decoration: underline;
        }

        #lblMessage {
            color: #d9534f;
            font-weight: bold;
            margin-bottom: 10px;
        }
    </style>
</head>
<!-- heheheh... he'll never find me -->
    <img src="Images/PostOfficeLogo.png" alt="Logo" class="login-logo" />

<body>
    <form id="form1" runat="server" class="login-container">

        <h2 class="login-header">Post Office Portal Login</h2>

        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
        
        <!-- Username -->
        <div class="mb-3">
            <asp:Label ID="lblUsername" runat="server" Text="Username:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
        </div>
        
        <!-- Password -->
        <div class="mb-4">
            <asp:Label ID="lblPassword" runat="server" Text="Password:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" Width="100%"></asp:TextBox>
        </div>
        
        <!-- Login Button -->
        <div class="d-grid mb-3">
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-postal btn-block" OnClick="btnLogin_Click" />
        </div>
        
        <asp:HyperLink ID="lnkRegister" runat="server" NavigateUrl="~/RegisterCustomer.aspx" CssClass="register-link">New Customer? Register Here</asp:HyperLink>
    </form>
</body>
</html>
