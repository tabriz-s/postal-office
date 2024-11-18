<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShippingHistory.aspx.cs" Inherits="COSCPFWA.ShippingHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            margin: 0;
        }

        .main-container {
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            padding: 20px;
        }

        .shipping-history-container {
            width: 100%;
            max-width: 600px;
            background-color: #fff;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 6px 12px rgba(0, 0, 0, 0.15);
            border-top: 8px solid #3b3b3b;
            box-sizing: border-box;
        }

        .shipping-history-container h2 {
            text-align: center;
            color: #333;
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .form-group {
            display: flex;
            flex-direction: column;
            width: 100%;
            margin-bottom: 15px;
            align-items: center;
        }

        .form-group label {
            display: block;
            width: 100%;
            color: #3b3b3b;
            font-weight: bold;
            margin-bottom: 5px;
            text-align: center;
        }

        .form-control {
            width: 100%;
            padding: 12px;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 15px;
            box-sizing: border-box;
        }

        .form-control:focus {
            border-color: #ffc107;
            outline: none;
            box-shadow: 0 0 4px rgba(255, 193, 7, 0.5);
        }

        .submit-btn {
            width: 100%;
            max-width: 300px;
            padding: 14px;
            background-color: #ffc107;
            color: #3b3b3b;
            font-size: 16px;
            font-weight: bold;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s ease;
            box-sizing: border-box;
            margin: 0 auto;
            display: block;
        }

        .submit-btn:hover {
            background-color: #d39e00;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main-container">
        <div class="shipping-history-container">
            <h2>Shipping History</h2>
            
            <asp:Panel ID="form1" runat="server">
                <div class="form-group">
                    <label for="customerID">Enter Customer ID</label>
                    <asp:TextBox ID="customerID" runat="server" CssClass="form-control" placeholder="Enter Customer ID"></asp:TextBox>
                </div>

                <asp:Button ID="submitButton" runat="server" CssClass="submit-btn" Text="View History" OnClick="ViewReport_Click"/>

                <asp:GridView ID="ResultGrid" runat="server" AutoGenerateColumns="true" CssClass="table table-striped table-hover mt-4" />
            </asp:Panel>
        </div>
    </div>
</asp:Content>
