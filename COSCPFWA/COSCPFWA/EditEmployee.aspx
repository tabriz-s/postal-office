<%@ Page Title="Edit Employee Salary" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditEmployee.aspx.cs" Inherits="COSCPFWA.EditEmployee" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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

        .form-container {
            width: 100%;
            max-width: 400px;
            background-color: #fff;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 6px 12px rgba(0, 0, 0, 0.15);
            border-top: 8px solid #007bff;
            box-sizing: border-box;
        }

        .form-container h2 {
            text-align: center;
            color: #333;
            font-size: 20px;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .form-group {
            margin-bottom: 15px;
        }

        .form-group label {
            display: block;
            color: #333;
            font-weight: bold;
            margin-bottom: 5px;
        }

        .form-group input {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 14px;
        }

        .form-group input:focus {
            border-color: #007bff;
            outline: none;
            box-shadow: 0 0 4px rgba(0, 123, 255, 0.5);
        }

        .submit-btn {
            width: 100%;
            padding: 12px;
            background-color: #007bff;
            color: #fff;
            font-size: 16px;
            font-weight: bold;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .submit-btn:hover {
            background-color: #0056b3;
        }
    </style>

    <div class="main-container">
        <div class="form-container">
            <h2>Update Employee Salary</h2>
            <asp:Panel runat="server">
                <div class="form-group">
                    <label for="employeeID">Employee ID</label>
                    <asp:TextBox ID="employeeID" runat="server" CssClass="form-control" />
                </div>
                <div class="form-group">
                    <label for="salary">Salary</label>
                    <asp:TextBox ID="salary" runat="server" CssClass="form-control" TextMode="Number" />
                </div>
                <asp:Button ID="SaveButton" runat="server" CssClass="submit-btn" Text="Save Changes" OnClick="SaveButton_Click" />
            </asp:Panel>
        </div>
    </div>
</asp:Content>
