<%@ Page Title="Change Username & Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="COSCPFWA.ChangePassword" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="text-center mb-4">
            <h2 class="display-4">Change Username & Password</h2>
            <p class="lead">Update your login credentials below.</p>
        </div>

        <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-info mb-4" Visible="false"></asp:Label>

        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow-lg">
                    <div class="card-header text-white text-center" style="background-color: #0d47a1;">
                        <h5 class="card-title mb-0">Update Credentials</h5>
                    </div>
                    <div class="card-body">
                        <%-- Username --%>
                        <div class="form-group mb-3 text-center">
                            <label for="txtUsername" class="form-label">Username</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control w-50" Placeholder="Enter new username" />
                            </div>
                        </div>

                        <%-- Current Password --%>
                        <div class="form-group mb-3 text-center">
                            <label for="txtCurrentPassword" class="form-label">Current Password</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtCurrentPassword" runat="server" CssClass="form-control w-50" TextMode="Password" Placeholder="Enter current password" />
                            </div>
                        </div>

                        <%-- New Password --%>
                        <div class="form-group mb-3 text-center">
                            <label for="txtNewPassword" class="form-label">New Password</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control w-50" TextMode="Password" Placeholder="Enter new password" />
                            </div>
                        </div>

                        <%-- Confirm New Password --%>
                        <div class="form-group mb-4 text-center">
                            <label for="txtConfirmPassword" class="form-label">Confirm New Password</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control w-50" TextMode="Password" Placeholder="Confirm new password" />
                            </div>
                        </div>

                        <%-- Action Buttons --%>
                        <div class="text-center">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary me-2" OnClick="btnUpdate_Click" Style="background-color: #0d47a1;" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
