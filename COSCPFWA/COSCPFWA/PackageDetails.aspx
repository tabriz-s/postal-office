<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PackageDetails.aspx.cs" Inherits="COSCPFWA.PackageDetails" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Package Details</title>
    <style>
        /* Basic styling setup */
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
        .package-form-container {
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
        .package-form-container h2 {
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

        /* Input styling */
        .form-group input, .form-group textarea {
            width: 100%;
            padding: 12px;
            font-size: 15px;
            border: 1px solid #d3a037;
            border-radius: 4px;
            outline: none;
        }
        .form-group input:focus, .form-group textarea:focus {
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
        <div class="package-form-container">
            <h2>Package Details</h2>
            <div class="form-group">
                <label for="contents">Contents</label>
                <asp:TextBox ID="contents" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" required="required"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="weightLbs">Weight (lbs)</label>
                <asp:TextBox ID="weightLbs" runat="server" CssClass="form-control" TextMode="Number" required="required"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="dimensions">Dimensions (L x W x H)</label>
                <asp:TextBox ID="dimensions" runat="server" CssClass="form-control" required="required"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="material">Material</label>
                <asp:TextBox ID="material" runat="server" CssClass="form-control" required="required"></asp:TextBox>
            </div>
            <asp:Button ID="submitBtn" runat="server" Text="Submit" CssClass="submit-btn" OnClick="SubmitPackageDetails_Click" />
        </div>
    </form>
</body>
</html>
