<%@ Page Title="Customer Notifications" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerNotifications.aspx.cs" Inherits="COSCPFWA.CustomerNotifications" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="text-center mb-4">
            <h2 class="display-4">Your Notifications</h2>
            <p class="lead">Stay updated with the latest package notifications.</p>
        </div>

        <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-info mb-4" Visible="false"></asp:Label>

        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card shadow-lg">
                    <div class="card-header text-white text-center" style="background-color: #0d47a1;">
                        <h5 class="card-title mb-0">Notifications</h5>
                    </div>
                    <div class="card-body">
                        <%-- Notifications --%>
                        <asp:Repeater ID="rptNotifications" runat="server">
                            <ItemTemplate>
                                <div class="notification-item mb-3 p-3 border rounded" style="background-color: #f8f9fa;">
                                    <h6 class="mb-1"><%# Eval("Message") %></h6>
                                    <p class="text-muted small mb-0">
                                        Package ID: <%# Eval("PackageID") %> | Date: <%# Eval("NotificationDate", "{0:MM/dd/yyyy hh:mm tt}") %>
                                    </p>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
