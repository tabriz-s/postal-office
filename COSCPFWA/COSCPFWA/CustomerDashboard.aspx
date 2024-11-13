<%@ Page Title="Customer Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerDashboard.aspx.cs" Inherits="COSCPFWA.CustomerDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Welcome, <%= Session["Username"] %></h2>
    
    <section>
        <h3>Shipping Options</h3>
        <ul>
            <li><a href="CreateShipment.aspx">Create a Shipment</a></li>
            <li><a href="TrackShipment.aspx">Track a Shipment</a></li>
        </ul>
    </section>

    <section>
        <h3>Available Services</h3>
        <p>Explore our shipping, tracking, and store services.</p>
    </section>
</asp:Content>