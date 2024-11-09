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
    <form>
      <div class="form-group">
        <label for="country">Country or Territory</label>
        <select id="country" name="country" required>
          <option value="" disabled selected>Select your country</option>
          <option value="us">United States</option>
          <option value="ca">Canada</option>
          <option value="uk">United Kingdom</option>
        </select>
      </div>
      <div class="form-group">
        <label for="firstName">First Name</label>
        <input type="text" id="firstName" name="firstName" required>
      </div>
      <div class="form-group">
        <label for="lastName">Last Name</label>
        <input type="text" id="lastName" name="lastName" required>
      </div>
      <div class="form-group">
        <label for="phone">Phone Number</label>
        <input type="tel" id="phone" name="phone" required>
      </div>
      <div class="form-group">
        <label for="email">Email</label>
        <input type="email" id="email" name="email" required>
      </div>
      <div class="form-group">
        <label for="address">Address</label>
        <input type="text" id="address" name="address" maxlength="30" required>
      </div>
      <div class="form-group">
        <label for="zipcode">Zip Code</label>
        <input type="text" id="zipcode" name="zipcode" required>
      </div>
      <div class="form-group">
        <label for="city">City</label>
        <input type="text" id="city" name="city" required>
      </div>
      <div class="form-group">
        <label for="state">State</label>
        <input type="text" id="state" name="state" required>
      </div>
      <button type="submit" class="submit-btn">Submit</button>
    </form>
  </div>

</body>
</html>
