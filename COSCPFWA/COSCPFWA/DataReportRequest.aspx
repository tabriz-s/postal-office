<%@ Page Title="DataReportRequest" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataReportRequest.aspx.cs" Inherits="COSCPFWA.DataReportRequest" %>

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

        .report-form-container {
            width: 100%;
            max-width: 600px;
            background-color: #fff;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 6px 12px rgba(0, 0, 0, 0.15);
            border-top: 8px solid #3b3b3b;
            box-sizing: border-box;
        }

            .report-form-container h2 {
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
                margin-left: 260px;
            }

            .form-group input,
            .form-group select,
            .form-group asp\\:TextBox,
            .form-group asp\\:DropDownList {
                width: 100%;
                padding: 12px;
                border: 1px solid #ccc;
                border-radius: 4px;
                font-size: 15px;
                box-sizing: border-box;
            }

                .form-group input:focus,
                .form-group select:focus,
                .form-group asp\\:TextBox:focus {
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
            margin-left: 120px;
        }

            .submit-btn:hover {
                background-color: #d39e00;
            }
    </style>

    
    <div class="main-container">
        <div class="report-form-container">
            <h2>Employee/Customer Report Request</h2>
            
            <form id="form1">
                <div class="form-group">
                    <label for="groupBy">Group By</label>
                    <asp:TextBox ID="groupBy" runat="server" CssClass="form-control" placeholder="Enter grouping criteria" required="required"></asp:TextBox>
                </div>
                
                <div class="form-group">
                    <label for="employeeName">Employee Name</label>
                    <asp:DropDownList ID="employeeName" runat="server" CssClass="form-select">
                        <asp:ListItem value="Ryan Araula">Ryan Araula</asp:ListItem>
                        <asp:ListItem value="Santiago Gamboa">Santiago Gamboa</asp:ListItem>
                        <asp:ListItem value="Huy Nguyen">Huy Nguyen</asp:ListItem>
                        <asp:ListItem value="Tabriz Sadredinov">Tabriz Sadredinov</asp:ListItem>
                        <asp:ListItem value="Abubakar Memon">Abubakar Memon</asp:ListItem>
                    </asp:DropDownList>
                </div>
                
                <div class="form-group">
                    <label for="additionalPersonnel">Additional Personnel</label>
                    <asp:TextBox ID="additionalPersonnel" runat="server" CssClass="form-control" placeholder="Optional"></asp:TextBox>
                </div>
                
                <div class="form-group">
                    <label for="projectSource">Projects (Customer & Employee)</label>
                    <asp:DropDownList ID="projectSource" runat="server" CssClass="form-select" required="required">
                        <asp:ListItem Value="" Text="Select Project Source" Disabled="true" Selected="true"></asp:ListItem>
                        <asp:ListItem Value="Customer" Text="Customer"></asp:ListItem>
                        <asp:ListItem Value="Employee" Text="Employee"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <label for="deliveryType">Delivery Type</label>
                    <asp:DropDownList ID="deliveryType" runat="server" CssClass="form-select">
                        <asp:ListItem value="Delivery">Delivery</asp:ListItem>
                        <asp:ListItem value="SmartLocker">SmartLocker</asp:ListItem>
                    </asp:DropDownList>
                </div>
                
                <div class="form-group">
                    <label for="activityDateFrom">Activity Date From</label>
                    <asp:TextBox ID="activityDateFrom" runat="server" CssClass="form-control" TextMode="Date" required="required"></asp:TextBox>
                </div>
                
                <div class="form-group">
                    <label for="activityDateTo">Activity Date To</label>
                    <asp:TextBox ID="activityDateTo" runat="server" CssClass="form-control" TextMode="Date" required="required"></asp:TextBox>
                </div>

                <asp:Button ID="ViewReportBtn" runat="server" Text="View Report" CssClass="submit-btn" OnClick="ViewReport_Click" />

                <!-- NEW form for selecting CustomerID and package count for chart generation -->
                <h2>Generate Customer/Package Reports</h2>

                <label for="orderByDropdown">Order By:</label> <!-- Updated label to "Order By" -->
                <asp:DropDownList ID="orderByDropdown" runat="server"></asp:DropDownList> <!-- Renamed to "orderByDropdown" -->

                <!-- Generate Chart button -->
                <asp:Button ID="btnGenerateChart" runat="server" Text="Generate Chart" OnClick="btnGenerateChart_Click" CssClass="btnStacked" />

                <!-- Canvas element to display the generated chart -->
                <div>
                    <canvas id="myChart" width="400" height="200"></canvas>
                </div>

                <!-- Hidden field to store JSON data for chart rendering -->
                <asp:HiddenField ID="chartData" runat="server" />

                <!-- Added Chart.js library for data visualization -->
                <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>

                <script type="text/javascript">
                    // Function to render chart using Chart.js and JSON data from server
                    function renderChart(data) {
                        var ctx = document.getElementById('myChart').getContext('2d');
                        var chartData = JSON.parse(data);
                        new Chart(ctx, {
                            type: 'bar',
                            data: {
                                labels: chartData.labels,
                                datasets: [{
                                    label: '# of Packages',
                                    data: chartData.values,
                                    backgroundColor: 'rgba(75, 192, 192, 0.2)',
                                    borderColor: 'rgba(75, 192, 192, 1)',
                                    borderWidth: 1
                                }]
                            },
                            options: {
                                scales: {
                                    y: {
                                        beginAtZero: true
                                    }
                                }
                            }
                        });
                    }

                    // Automatically call renderChart on page load if chartData is present - [New]
                    window.onload = function () {
                        var chartData = document.getElementById('<%= chartData.ClientID %>').value;
                        if (chartData) {
                            renderChart(chartData);
                        }
                    };
                </script>
                
                <asp:GridView ID="ResultGrid" runat="server" AutoGenerateColumns="true" CssClass="table table-striped table-hover mt-4" />
            </form>
        </div>
    </div>
</asp:Content>


