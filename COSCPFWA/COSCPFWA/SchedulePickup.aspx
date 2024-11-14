<%@ Page Title="Schedule Pickup" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SchedulePickup.aspx.cs" Inherits="COSCPFWA.SchedulePickup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pickup-container">
        <h2>Schedule a Pickup</h2>
        <asp:Label ID="lblMessage" runat="server" CssClass="message-label"></asp:Label>
        
        <asp:TextBox ID="txtPickupDate" runat="server" Placeholder="Pickup Date" CssClass="form-control"></asp:TextBox>
        <asp:TextBox ID="txtPickupTime" runat="server" Placeholder="Pickup Time" CssClass="form-control"></asp:TextBox>
        <asp:TextBox ID="txtLocation" runat="server" Placeholder="Pickup Location" CssClass="form-control"></asp:TextBox>
        
        <asp:Button ID="btnSchedulePickup" runat="server" Text="Schedule Pickup" CssClass="btn btn-primary" OnClick="btnSchedulePickup_Click" />
    </div>
</asp:Content>