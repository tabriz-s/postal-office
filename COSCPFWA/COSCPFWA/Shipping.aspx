<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shipping.aspx.cs" Inherits="COSCPFWA.Shipping" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Shipping Information</title>
  <style>
    body {
      font-family: Arial, sans-serif;
      display: flex;
      justify-content: center;
      align-items: center;
      height: 100vh;
      margin: 0;
      background-color: #f2f2f2;
    }
    .shipping-form-container {
      width: 100%;
      max-width: 600px;
      background-color: #fff;
      padding: 30px;
      border-radius: 10px;
      box-shadow: 0 6px 12px rgba(0, 0, 0, 0.15);
      border-top: 8px solid #3b3b3b;
    }
    .shipping-form-container h2 {
      text-align: center;
      color: #333;
      font-size: 24px;
      font-weight: bold;
      margin-bottom: 20px;
    }
    .form-group {
      margin-bottom: 15px;
    }
    .form-group label {
      display: block;
      margin-bottom: 5px;
      color: #3b3b3b;
      font-weight: bold;
    }
    .form-group input,
    .form-group select {
      width: 100%;
      padding: 12px;
      border: 1px solid #ccc;
      border-radius: 4px;
      font-size: 15px;
    }
    .form-group input:focus,
    .form-group select:focus {
      border-color: #ffc107;
      outline: none;
      box-shadow: 0 0 4px rgba(255, 193, 7, 0.5);
    }
    .submit-btn {
      width: 100%;
      padding: 14px;
      background-color: #ffc107;
      color: #3b3b3b;
      font-size: 16px;
      font-weight: bold;
      border: none;
      border-radius: 4px;
      cursor: pointer;
      transition: background-color 0.3s ease;
    }
    .submit-btn:hover {
      background-color: #d39e00;
    }
  </style>
</head>
<body>

  <div class="shipping-form-container">
    <h2>Shipping Information</h2>
    <form runat="server">
      <div class="form-group">
        <label for="country">Country or Territory</label>
          <%-- Changed to dropdown and added ALL MISSING "asp:" prefixes  --%>
        <asp:DropDownList ID="country" runat="server" CssClass="form-control">
          <asp:ListItem Text="Select your country" Value="" />
          <asp:ListItem Text="United States" Value="us" />
          <asp:ListItem Text="Canada" Value="ca" />
          <asp:ListItem Text="United Kingdom" Value="uk" />
        </asp:DropDownList>
      </div>
      <div class="form-group">
          <%-- Also all "id" have to be capitalized to ID --%>
        <label for="firstName">First Name</label>
        <asp:TextBox ID="firstName" name="firstName" required runat="server" /> 
          <%-- Missing runat ="server" statements for each input --%>
      <div class="form-group">
        <label for="lastName">Last Name</label>
        <asp:TextBox ID="lastName" runat="server" CssClass="form-control" />
      </div>
      <div class="form-group">
        <label for="phone">Phone Number</label>
        <asp:TextBox ID="phone" runat="server" CssClass="form-control" TextMode="Phone" />
      </div>
      <div class="form-group">
        <label for="email">Email</label>
        <asp:TextBox ID="email" runat="server" CssClass="form-control" TextMode="Email" />
      </div>
      <div class="form-group">
        <label for="address">Address</label>
        <asp:TextBox ID="address" runat="server" CssClass="form-control" MaxLength="30" />
      </div>
      <div class="form-group">
        <label for="zipcode">Zip Code</label>
        <asp:TextBox ID="zipcode" runat="server" CssClass="form-control" />
      </div>
      <div class="form-group">
        <label for="city">City</label>
        <asp:TextBox ID="city" runat="server" CssClass="form-control" />
      </div>
      <div class="form-group">
        <label for="state">State</label>
        <asp:TextBox ID="state" runat="server" CssClass="form-control" MaxLength="2" />
      </div>
      <asp:Button ID="SubmitButton" runat="server" CssClass="submit-btn" Text="Submit" OnClick="SubmitButton_Click" /> 
      <%-- Forgot to associate the submit button to the C# function AND changed "onserverclick" to "OnClick" --%>
    </form>
  </div>
  <%-- Missing runat="server" statement to allow ASP.NET to manage form submission at line 79 --%>
</body>
</html>