<%@ Page Title="RegisterCustomer" Language="C#" AutoEventWireup="true" CodeBehind="RegisterCustomer.aspx.cs" Inherits="COSCPFWA.RegisterCustomer" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-image: linear-gradient(to bottom right, #4a69bd, #6a89cc);
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
            font-family: 'Segoe UI', sans-serif;
        }

        .register-container {
            background-color: rgba(255, 255, 255, 0.85);
            border: 1px solid #ced4da;
            border-radius: 10px;
            padding: 2rem;
            box-shadow: 0 6px 10px rgba(0, 0, 0, 0.15);
            max-width: 500px;
            width: 100%;
            text-align: center;
        }

        .register-header {
            color: #333;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .btn-register {
            background-color: #5a82cc;
            color: #fff;
            font-weight: bold;
            border: none;
            transition: background-color 0.3s ease, transform 0.2s ease;
        }

        .btn-register:hover {
            background-color: #4a6bb5;
            transform: scale(1.03);
        }

        .form-control:focus {
            border-color: #5a82cc;
            box-shadow: 0 0 5px rgba(90, 130, 204, 0.4);
        }

        .login-link {
            font-size: 0.9rem;
            color: #5a82cc;
            text-decoration: none;
        }

        .login-link:hover {
            text-decoration: underline;
        }

        #lblMessage {
            color: #d9534f;
            font-weight: bold;
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="register-container">
        <h2 class="register-header">Register</h2>
        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
        
        <div class="mb-3">
            <asp:Label ID="lblFullName" runat="server" Text="First and Last Name:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
        </div>
        
        <div class="mb-3">
            <asp:Label ID="lblEmail" runat="server" Text="Email:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
        </div>
        
        <div class="mb-3">
            <asp:Label ID="lblUsername" runat="server" Text="Username:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
        </div>
        
        <div class="mb-3">
            <asp:Label ID="lblPassword" runat="server" Text="Password:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" Width="100%"></asp:TextBox>
        </div>
        
        <div class="mb-4">
            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control" Width="100%"></asp:TextBox>
        </div>
        
        <div class="d-grid mb-3">
            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-register btn-block" OnClick="btnRegister_Click" />
        </div>
        
        <asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="~/Login.aspx" CssClass="login-link">Already have an account? Login here</asp:HyperLink>
    </form>
</body>
</html>
