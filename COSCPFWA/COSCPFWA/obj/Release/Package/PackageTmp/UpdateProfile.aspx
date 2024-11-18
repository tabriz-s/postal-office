<%@ Page Title="Update Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="COSCPFWA.UpdateProfile" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="text-center mb-4">
            <h2 class="display-4">Update Profile</h2>
            <p class="lead">Click Edit to modify your profile. Save changes when done or cancel to exit.</p>
        </div>

        <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-info mb-4" Visible="false"></asp:Label>

        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card shadow-lg">
                    <div class="card-header text-white" style="background-color: #0d47a1;">
                        <h5 class="card-title mb-0 text-center">Profile Information</h5>
                    </div>
                    <div class="card-body">
                        <%-- First Name --%>
                        <div class="form-group mb-3 text-center">
                            <label for="txtFirstName" class="form-label">First Name</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control w-50" ReadOnly="true" />
                            </div>
                        </div>

                        <%-- Last Name --%>
                        <div class="form-group mb-3 text-center">
                            <label for="txtLastName" class="form-label">Last Name</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control w-50" ReadOnly="true" />
                            </div>
                        </div>

                        <%-- Address --%>
                        <div class="form-group mb-3 text-center">
                            <label for="txtAddress" class="form-label">Address</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control w-50" ReadOnly="true" />
                            </div>
                        </div>

                        <%-- City --%>
                        <div class="form-group mb-3 text-center">
                            <label for="txtCity" class="form-label">City</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control w-50" ReadOnly="true" />
                            </div>
                        </div>

                        <%-- State --%>
                        <div class="form-group mb-3 text-center">
                            <label for="txtState" class="form-label">State</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtState" runat="server" CssClass="form-control w-50" ReadOnly="true" />
                            </div>
                        </div>

                        <%-- Zip Code --%>
                        <div class="form-group mb-3 text-center">
                            <label for="txtZipCode" class="form-label">Zip Code</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control w-50" ReadOnly="true" />
                            </div>
                        </div>

                        <%-- Phone Number --%>
                        <div class="form-group mb-3 text-center">
                            <label for="txtPhoneNumber" class="form-label">Phone Number</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control w-50" ReadOnly="true" />
                            </div>
                        </div>

                        <%-- Email --%>
                        <div class="form-group mb-4 text-center">
                            <label for="txtEmail" class="form-label">Email</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control w-50" ReadOnly="true" />
                            </div>
                        </div>

                        <%-- Action Buttons --%>
                        <div class="text-center mt-4">
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-secondary me-2" OnClick="EnableEditing" />
                            <asp:Button ID="btnUpdateProfile" runat="server" Text="Save Changes" CssClass="btn btn-primary me-2" OnClick="btnUpdateProfile_Click" Style="background-color: #0d47a1;" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

