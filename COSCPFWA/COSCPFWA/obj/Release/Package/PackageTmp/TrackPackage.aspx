<%@ Page Title="Package Tracking" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrackPackage.aspx.cs" Inherits="COSCPFWA.TrackPackage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
        }

        .tracking-container {
            width: 100%;
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
            background-color: #f9f9f9;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        .tracking-header {
            text-align: center;
            margin-bottom: 20px;
        }

        .tracking-header h2 {
            font-size: 24px;
            color: #333;
        }

        .search-bar {
            display: flex;
            justify-content: center;
            margin-bottom: 20px;
        }

        .search-bar input[type="text"] {
            width: 70%;
            padding: 10px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .search-bar button {
            padding: 10px 20px;
            font-size: 16px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            margin-left: 10px;
        }

        .search-bar button:hover {
            background-color: #0056b3;
        }

        .tracking-details {
            margin-top: 20px;
        }

        .tracking-details h3 {
            font-size: 20px;
            color: #555;
            margin-bottom: 10px;
        }

        .tracking-progress {
            display: flex;
            align-items: center;
            margin-bottom: 20px;
        }

        .tracking-progress div {
            flex: 1;
            height: 8px;
            background-color: #ccc;
            position: relative;
        }

        .tracking-progress div.completed {
            background-color: #28a745;
        }

        .tracking-progress div::after {
            content: '';
            position: absolute;
            top: -5px;
            left: 50%;
            transform: translateX(-50%);
            width: 16px;
            height: 16px;
            background-color: #fff;
            border: 2px solid #28a745;
            border-radius: 50%;
        }

        .tracking-progress div:not(.completed)::after {
            border-color: #ccc;
        }

        .tracking-info {
            text-align: center;
        }

        .tracking-info p {
            font-size: 16px;
            margin: 5px 0;
        }

        .tracking-info strong {
            color: #333;
        }
    </style>

    <div class="tracking-container">
        <div class="tracking-header">
            <h2>Track Your Package</h2>
        </div>

        <div class="search-bar">
            <asp:TextBox ID="PackageIDTextBox" runat="server" placeholder="Enter Package ID"></asp:TextBox>
            <asp:Button ID="TrackButton" runat="server" Text="Track" OnClick="TrackButton_Click" />
        </div>

        <div class="tracking-details">
            <asp:Panel ID="TrackingPanel" runat="server" Visible="false">
                <h3>Package Status</h3>
                <div class="tracking-progress">
                    <div class="completed"></div>
                    <div class="completed"></div>
                    <div></div>
                </div>
                <div class="tracking-info">
                    <p><strong>Current Status:</strong> <asp:Label ID="StatusLabel" runat="server"></asp:Label></p>
                    <p><strong>Service Type:</strong> <asp:Label ID="ServiceTypeLabel" runat="server"></asp:Label></p>
                    <p><strong>Contents:</strong> <asp:Label ID="ContentsLabel" runat="server"></asp:Label></p>
                    <p><strong>Weight_lbs:</strong> <asp:Label ID="WeightLabel" runat="server"></asp:Label></p>
                    <p><strong>Length_in:</strong> <asp:Label ID="LengthLabel" runat="server"></asp:Label></p>
                    <p><strong>Width_in:</strong> <asp:Label ID="WidthLabel" runat="server"></asp:Label></p>
                    <p><strong>Received Date:</strong> <asp:Label ID="ReceivedDateLabel" runat="server"></asp:Label></p>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
