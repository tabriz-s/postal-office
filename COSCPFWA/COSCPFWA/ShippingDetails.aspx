<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShippingDetails.aspx.cs" Inherits="COSCPFWA.ShippingDetails" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Shipping Details</title>
    <style>
        /* Basic reset and font setup */
        body, html {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        /* Container styling */
        .shipping-form-container {
            width: 100%;
            max-width: 600px;
            background-color: #ffffff;
            border: 1px solid #ddd;
            border-radius: 8px;
            box-shadow: 0 6px 12px rgba(0, 0, 0, 0.1);
            padding: 30px;
            margin: 20px;
            color: #333;
        }

        /* Header styling */
        .shipping-form-container h2 {
            text-align: center;
            font-size: 26px;
            color: #333;
            font-weight: 700;
            margin-bottom: 15px;
            border-bottom: 2px solid #d3a037;
            padding-bottom: 10px;
        }

        /* Form group styling */
        .form-group {
            margin-bottom: 18px;
        }
        .form-group label {
            display: block;
            font-weight: bold;
            color: #333;
            margin-bottom: 5px;
        }

        /* Input and select styling */
        .form-group input, .form-group select {
            width: 100%;
            padding: 12px;
            font-size: 15px;
            border: 1px solid #d3a037;
            border-radius: 4px;
            outline: none;
        }
        .form-group input:focus, .form-group select:focus {
            border-color: #d3a037;
            box-shadow: 0 0 4px rgba(211, 160, 55, 0.4);
        }

        /* Button styling */
        .submit-btn {
            width: 100%;
            padding: 14px;
            font-size: 16px;
            font-weight: bold;
            color: #ffffff;
            background-color: #d3a037;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }
        .submit-btn:hover {
            background-color: #b58428;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="shipping-form-container">
            <h2>Shipping Details</h2>
            <div class="form-group">
                <label for="senderAddress">Sending Address</label>
                <asp:TextBox ID="senderAddress" runat="server" CssClass="form-control" placeholder="Enter sending address"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="shippingMethod">Shipping Method</label>
                <asp:DropDownList ID="shippingMethod" runat="server" CssClass="form-control">
                    <asp:ListItem Value="" Text="Select a method" Disabled="true" Selected="true"></asp:ListItem>
                    <asp:ListItem Value="Standard" Text="Standard"></asp:ListItem>
                    <asp:ListItem Value="Express" Text="Express"></asp:ListItem>
                    <asp:ListItem Value="Overnight" Text="Overnight"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="receivingAddress">Receiving Address</label>
                <asp:TextBox ID="receivingAddress" runat="server" CssClass="form-control" placeholder="Enter receiving address"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="receiverName">Receiver Name</label>
                <asp:TextBox ID="receiverName" runat="server" CssClass="form-control" placeholder="Enter receiver name"></asp:TextBox>
            </div>
            <asp:Button ID="submitBtn" runat="server" Text="Submit" CssClass="submit-btn" OnClick="SubmitShippingDetails_Click" />
        </div>
    </form>
</body>
</html>
