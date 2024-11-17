<%@ Page Title="Track Customer Package" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrackCustomerPackage.aspx.cs" Inherits="COSCPFWA.TrackCustomerPackage" %>

<asp:Content ID="HeadContent" ContentPlaceholderID="HeadContent" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <!-- Title Section -->
        <div class="text-center mb-4">
            <h2 class="display-4">Track Your Package</h2>
            <p class="lead">Enter your Package ID below to check its status.</p>
        </div>

        <!-- Message Label -->
        <asp:Label ID="lblMessage" runat="server" CssClass="message-label alert alert-info mb-4" Visible="false"></asp:Label>

        <!-- Search Form Section -->
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow-lg">
                    <div class="card-header text-white text-center" style="background-color:#0d47a1;">
                        <h5 class="card-title mb-0">Package Tracking</h5>
                    </div>
                    <div class="card-body">
                        <!-- Package ID Input Form -->
                        <div class="form-group">
                            <label for="PackageIDTextBox" class="form-label">Enter Package ID</label>
                            <asp:TextBox ID="PackageIDTextBox" runat="server" CssClass="form-control" Placeholder="Enter Package ID..." />
                        </div>
                        <div class="form-group text-center mt-3">
                            <asp:Button ID="TrackButton" runat="server" Text="Track Package" CssClass="btn btn-primary btn-lg" OnClick="TrackButton_Click" style="background-color:#0d47a1;" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Package Details Section -->
        <div id="PackageDetails" runat="server" style="display:none; margin-top: 30px;">
            <div class="card shadow-lg">
                <div class="card-header text-white text-center" style="background-color:#0d47a1;">
                    <h5 class="card-title mb-0">Package Details</h5>
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <p><strong>Package ID:</strong> <asp:Literal ID="lblPackageID" runat="server" Text=""></asp:Literal></p>
                        <p><strong>Contents:</strong> <asp:Literal ID="lblContents" runat="server" Text=""></asp:Literal></p>
                        <p><strong>Status:</strong> <asp:Literal ID="lblStatus" runat="server" Text=""></asp:Literal></p>
                        <p><strong>Weight:</strong> <asp:Literal ID="lblWeight" runat="server" Text=""></asp:Literal> lbs</p>
                        <p><strong>Service Type:</strong> <asp:Literal ID="lblServiceType" runat="server" Text=""></asp:Literal></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
