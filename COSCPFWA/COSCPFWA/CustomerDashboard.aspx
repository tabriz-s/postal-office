<%@ Page Title="Customer Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerDashboard.aspx.cs" Inherits="COSCPFWA.CustomerDashboard" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/dashboard.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="text-center mb-4">
            <h2 class="display-5">Welcome, <%= Session["Username"] %>!</h2>
            <h1> Your customer ID: <%= Session["CustomerID"] %>, and user ID: <%= Session["UserID"] %></h1>
        </div>
        
        <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
            <!-- Shipping Options  -->
            <div class="col">
                <div class="card shadow-sm h-100 border-0" style="background-color: #0d47a1; color: #ffffff;">
                    <div class="card-body">
                        <h5 class="card-title text-light"><i class="fas fa-box-open me-2"></i>Shipping Options</h5>
                        <p class="card-text">Create, manage, and track your shipments with ease.</p>
                        <div class="list-group list-group-flush">
                            <a href="Shipping.aspx" class="list-group-item list-group-item-action" style="color: #0d47a1;">
                                <i class="fas fa-shipping-fast me-2"></i> Create a Shipment
                            </a>
                            <a href="TrackPackage.aspx" class="list-group-item list-group-item-action" style="color: #0d47a1;">
                                <i class="fas fa-map-marker-alt me-2"></i> Track a Shipment
                            </a>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Additional Services  -->
            <div class="col">
                <div class="card shadow-sm h-100 border-0" style="background-color: #0d47a1; color: #ffffff;">
                    <div class="card-body">
                        <h5 class="card-title text-light"><i class="fas fa-tools me-2"></i>Additional Services</h5>
                        <p class="card-text">Enjoy more features tailored to your needs.</p>
                        <div class="list-group list-group-flush">
                            <a href="SchedulePickup.aspx" class="list-group-item list-group-item-action" style="color: #0d47a1;">
                                <i class="fas fa-calendar-check me-2"></i> Schedule a Pickup
                            </a>
                            <a href="SubscribeSmartLocker.aspx" class="list-group-item list-group-item-action" style="color: #0d47a1;">
                                <i class="fas fa-lock me-2"></i> Subscribe to SmartLocker
                            </a>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Recent Activity  -->
            <div class="col">
                <div class="card shadow-sm h-100 border-0" style="background-color: #0d47a1; color: #ffffff;">
                    <div class="card-body">
                        <h5 class="card-title text-light"><i class="fas fa-history me-2"></i>Recent Activity</h5>
                        <p class="card-text">See your latest shipments, pickups, and locker usage.</p>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">
                                <i class="fas fa-box me-2"></i> Package delivered - Locker #3
                            </li>
                            <li class="list-group-item">
                                <i class="fas fa-calendar-alt me-2"></i> Pickup scheduled for Nov 15, 2023
                            </li>
                            <li class="list-group-item">
                                <i class="fas fa-map-marker-alt me-2"></i> Shipment in transit
                            </li>
                        </ul>
                    </div>
                </div>
            </div>

            <!-- Account Settings -->
            <div class="col">
                <div class="card shadow-sm h-100 border-0" style="background-color: #0d47a1; color: #ffffff;">
                    <div class="card-body">
                        <h5 class="card-title text-light"><i class="fas fa-user-cog me-2"></i>Account Settings</h5>
                        <p class="card-text">Manage your profile, password, and notifications.</p>
                        <div class="list-group list-group-flush">
                            <a href="UpdateProfile.aspx" class="list-group-item list-group-item-action" style="color: #0d47a1;">
                                <i class="fas fa-user-edit me-2"></i> Edit Profile
                            </a>
                            <a href="ChangePassword.aspx" class="list-group-item list-group-item-action" style="color: #0d47a1;">
                                <i class="fas fa-key me-2"></i> Change Password
                            </a>
                            <a href="NotificationSettings.aspx" class="list-group-item list-group-item-action" style="color: #0d47a1;">
                                <i class="fas fa-bell me-2"></i> Notification Settings
                            </a>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Help & Support-->
            <div class="col">
                <div class="card shadow-sm h-100 border-0" style="background-color: #0d47a1; color: #ffffff;">
                    <div class="card-body">
                        <h5 class="card-title text-light"><i class="fas fa-question-circle me-2"></i>Help & Support</h5>
                        <p class="card-text">Need assistance? We’re here to help!</p>
                        <a href="Support.aspx" class="btn btn-outline-light w-100">
                            <i class="fas fa-life-ring me-2"></i> Contact Support
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
