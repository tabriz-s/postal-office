<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataReportRequest.aspx.cs" Inherits="COSCPFWA.DataReportRequest" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Data Report Request</title>
    <style>
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

        .report-form-container {
            width: 100%;
            max-width: 700px;
            background-color: #ffffff;
            border: 1px solid #ddd;
            border-radius: 8px;
            box-shadow: 0 6px 12px rgba(0, 0, 0, 0.1);
            padding: 30px;
            margin: 20px;
            color: #333;
        }

        .report-form-container h2 {
            text-align: center;
            font-size: 26px;
            color: #333;
            font-weight: 700;
            margin-bottom: 20px;
            border-bottom: 2px solid #d3a037;
            padding-bottom: 10px;
        }

        .form-group {
            margin-bottom: 18px;
        }
        .form-group label {
            display: block;
            font-weight: bold;
            color: #333;
            margin-bottom: 5px;
        }

        .form-group input, .form-group select {
            width: 100%;
            padding: 10px;
            font-size: 15px;
            border: 1px solid #d3a037;
            border-radius: 4px;
            outline: none;
        }
        .form-group input:focus, .form-group select:focus {
            border-color: #d3a037;
            box-shadow: 0 0 4px rgba(211, 160, 55, 0.4);
        }

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
    <form id="form1" runat="server" action="QueryDatabase" method="post">
        <div class="report-form-container">
            <h2>Employee/Customer Report Request</h2>
            <!-- Been thinking of switch forms to dropdown lists ->-
            
            <!-- Group By -->
            <div class="form-group">
                <label for="groupBy">Group By</label>
                <asp:TextBox ID="groupBy" runat="server" CssClass="form-control" required="required"></asp:TextBox>
            </div>
            
            <!-- Employee/Customer Name -->
            <div class="form-group">
                <label for="employeeName">Employee Name:</label>
                <select id="employeeName" name="employeeName" runat="server" CssClass="form-control" TextMode="Date" required="required">
                    <option value="Ryan Araula">Ryan Araula</option>
                    <option value="Santiago Gamboa">Santiago Gamboa</option>
                    <option value="Huy Nguyen">Huy Nguyen</option>
                    <option value="Tabriz Sadredinov">Tabriz Sadredinov</option>
                    <option value="Abubakar Memon">Abubakar Memon</option>
                </select>
            </div>
            
            <!-- Additional Investigator -->
            <div class="form-group">
                <label for="additionalPersonnel">Additional Personnel</label>
                <asp:TextBox ID="additionalPersonnel" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            
            <!-- Projects (Customer & Employee) -->
            <div class="form-group">
                <label for="projectSource">Projects (Customer & Employee)</label>
                <asp:DropDownList ID="projectSource" runat="server" CssClass="form-control" required="required">
                    <asp:ListItem Value="" Text="Select Project Source" Disabled="true" Selected="true"></asp:ListItem>
                    <asp:ListItem Value="Customer" Text="Customer"></asp:ListItem>
                    <asp:ListItem Value="Employee" Text="Employee"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <!-- Selecting Delivery Type -->
            <div class="form-group">
                <label for="deliveryType">Delivery Type:</label>
                <select id="deliveryType" name="deliveryType" runat="server" CssClass="form-control" required="required">
                    <option value="Delivery">Delivery</option>
                    <option value="SmartLocker">SmartLocker</option>
                </select>
            </div>
            
            <!-- Activity Date From -->
            <div class="form-group">
                <label for="activityDateFrom">Activity Date From</label>
                <asp:TextBox ID="activityDateFrom" runat="server" CssClass="form-control" TextMode="Date" required="required"></asp:TextBox>
            </div>
            
            <!-- Activity Date To -->
            <div class="form-group">
                <label for="activityDateTo">Activity Date To</label>
                <asp:TextBox ID="activityDateTo" runat="server" CssClass="form-control" TextMode="Date" required="required"></asp:TextBox>
            </div>

            <!-- View Report Button -->
            <asp:Button ID="ViewReportBtn" runat="server" Text="View Report" CssClass="submit-btn" OnClick="ViewReport_Click" />

            <!-- Grid View -->
            <asp:GridView ID="ResultGrid" runat="server" AutoGenerateColumns="true" />
            

        </div>
    </form>
</body>
</html> 