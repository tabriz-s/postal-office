<%@ Page Title="Employee Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeDashboard.aspx.cs" Inherits="COSCPFWA.EmployeeDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="dashboard-container">
        <h2>Welcome, <%= Session["Username"] %></h2>
        <h4>Employee ID: <%= Session["EmployeeID"] %></h4>

        <div class="dashboard-actions">
            <asp:TextBox ID="SearchTextBox" runat="server" CssClass="form-control" Placeholder="Search packages..."></asp:TextBox>
            <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="btn btn-grey mt-2" OnClick="SearchButton_Click" />
        </div>

        <section>
            <h3>Assigned Packages</h3>
            <asp:GridView 
                ID="AssignedPackagesGridView" 
                runat="server" 
                AutoGenerateColumns="false" 
                CssClass="table table-bordered">
                <Columns>
                    <asp:BoundField DataField="PackageID" HeaderText="Package ID" />
                    <asp:BoundField DataField="Contents" HeaderText="Contents" />
                    <asp:BoundField DataField="Weight_lbs" HeaderText="Weight (lbs)" />
                    <asp:BoundField DataField="ServiceType" HeaderText="Service Type" />
                    <asp:BoundField DataField="CurrentStatus" HeaderText="Status" />
                </Columns>
            </asp:GridView>
        </section>

        <section>
            <h3>Package Statistics</h3>
            <div class="stats-grid">
                <div class="stat-item">
                    <h4>Total Packages</h4>
                    <asp:Label ID="TotalPackagesLabel" runat="server" Text="0"></asp:Label>
                </div>
                <div class="stat-item">
                    <h4>Pending Deliveries</h4>
                    <asp:Label ID="PendingDeliveriesLabel" runat="server" Text="0"></asp:Label>
                </div>
                <div class="stat-item">
                    <h4>Delivered Packages</h4>
                    <asp:Label ID="DeliveredPackagesLabel" runat="server" Text="0"></asp:Label>
                </div>
            </div>
        </section>
    </div>

    <style>
        .dashboard-container {
            padding: 20px;
        }

        .dashboard-actions {
            margin-bottom: 20px;
        }

        .stats-grid {
            display: flex;
            gap: 20px;
            margin-top: 20px;
        }

        .stat-item {
            background: #f5f5f5;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 5px;
            text-align: center;
        }

            .stat-item h4 {
                margin-bottom: 10px;
            }

        .btn-grey {
            background-color: #6c757d; /* Grey color */
            color: white;
            border: none;
        }

            .btn-grey:hover {
                background-color: #5a6268; /* Darker grey on hover */
            }

        .mt-2 {
            margin-top: 10px; /* Add space between the input and button */
        }
    </style>
</asp:Content>
