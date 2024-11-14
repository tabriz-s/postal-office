<%@ Page Title="Customer Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerDashboard.aspx.cs" Inherits="COSCPFWA.CustomerDashboard" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="~/Content/dashboard.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="dashboard-container">
        <h2>Welcome, <%= Session["Username"] %>!</h2>
        
        <section class="shipping-options">
            <h3>Shipping Options</h3>
            <ul>
                <li><a href="CreateShipment.aspx" class="dashboard-link">Create a Shipment</a></li>
                <li><a href="TrackShipment.aspx" class="dashboard-link">Track a Shipment</a></li>
            </ul>
        </section>

        <section class="additional-services">
            <h3>Services</h3>
            <ul>
                <li><a href="SchedulePickup.aspx" class="dashboard-link">Schedule a Pickup</a></li>
                <li><a href="SubscribeSmartLocker.aspx" class="dashboard-link">Subscribe to SmartLocker</a></li>
            </ul>
        </section>

    </div>
</asp:Content>
