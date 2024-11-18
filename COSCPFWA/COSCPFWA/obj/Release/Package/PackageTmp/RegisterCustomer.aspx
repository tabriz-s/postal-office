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
            align-items: flex-start;
            min-height: 100vh;
            margin: 0;
            font-family: 'Segoe UI', sans-serif;
            overflow-y: auto;
        }

        .register-container {
            background-color: rgba(255, 255, 255, 0.95);
            border: 1px solid #ced4da;
            border-radius: 10px;
            padding: 2rem;
            box-shadow: 0 6px 10px rgba(0, 0, 0, 0.15);
            max-width: 500px;
            width: 100%;
            margin: 20px auto;
            text-align: center;
        }

        .register-header {
            color: #333;
            font-weight: bold;
            margin-bottom: 20px;
            font-size: 1.5rem;
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

        @media (max-height: 600px) {
            .register-container {
                margin: 10px auto;
                height: auto;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="register-container">
    <h2 class="register-header">Register</h2>
    <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>

    <div class="mb-3">
        <asp:Label ID="lblFirstName" runat="server" Text="First Name:" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
    </div>

    <div class="mb-3">
        <asp:Label ID="lblMiddleInitial" runat="server" Text="Middle Initial:" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="txtMiddleInitial" runat="server" MaxLength="1" CssClass="form-control" Width="100%"></asp:TextBox>
    </div>

    <div class="mb-3">
        <asp:Label ID="lblLastName" runat="server" Text="Last Name:" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
    </div>

    <div class="mb-3">
        <asp:Label ID="lblAddress" runat="server" Text="Address:" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
    </div>

    <div class="mb-3">
        <asp:Label ID="lblCity" runat="server" Text="City:" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
    </div>

    <div class="mb-3">
        <asp:Label ID="lblState" runat="server" Text="State:" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="txtState" runat="server" MaxLength="2" CssClass="form-control" Width="100%"></asp:TextBox>
    </div>

    <div class="mb-3">
        <asp:Label ID="lblZipCode" runat="server" Text="Zip Code:" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="txtZipCode" runat="server" MaxLength="5" CssClass="form-control" Width="100%"></asp:TextBox>
    </div>

    <div class="mb-3">
        <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number:" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
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
