<%@ Page Title="Register Employee" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterEmployee.aspx.cs" Inherits="COSCPFWA.RegisterEmployee" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="text-center mb-4">
            <h2 class="display-4">Register Employee</h2>
            <p class="lead">Fill in the details below to add a new employee.</p>
        </div>

        <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-info mb-4" Visible="false"></asp:Label>

        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card shadow-lg">
                    <div class="card-header text-white text-center" style="background-color: #0d47a1;">
                        <h5 class="card-title mb-0">Employee Information</h5>
                    </div>
                    <div class="card-body">
                        <%-- Name --%>
                        <div class="form-group mb-3 text-center">
                            <label for="txtName" class="form-label">Name</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control w-50" Placeholder="Enter name" />
                            </div>
                        </div>

                        <%-- Department Number --%>
                        <div class="form-group mb-3 text-center">
                            <label for="txtDepartmentNum" class="form-label">Department Number</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtDepartmentNum" runat="server" CssClass="form-control w-50" Placeholder="Enter department number" />
                            </div>
                        </div>

                        <%-- Phone Number --%>
                        <div class="form-group mb-3 text-center">
                            <label for="txtPhoneNumber" class="form-label">Phone Number</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control w-50" Placeholder="Enter phone number" />
                            </div>
                        </div>

                        <%-- Email --%>
                        <div class="form-group mb-3 text-center">
                            <label for="txtEmail" class="form-label">Email</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control w-50" Placeholder="Enter email" />
                            </div>
                        </div>

                        <%-- Address --%>
                        <div class="form-group mb-3 text-center">
                            <label for="txtAddress" class="form-label">Address</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control w-50" Placeholder="Enter address" />
                            </div>
                        </div>

                        <%-- Role --%>
                        <div class="form-group mb-3 text-center">
                            <label for="txtRole" class="form-label">Role</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtRole" runat="server" CssClass="form-control w-50" Placeholder="Enter role" />
                            </div>
                        </div>

                        <%-- Salary --%>
                        <div class="form-group mb-3 text-center">
                            <label for="txtSalary" class="form-label">Salary</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control w-50" Placeholder="Enter salary" />
                            </div>
                        </div>

                        <%-- Manager ID --%>
                        <div class="form-group mb-3 text-center">
                            <label for="txtManagerID" class="form-label">Manager ID</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtManagerID" runat="server" CssClass="form-control w-50" Placeholder="Enter manager ID" />
                            </div>
                        </div>
                        <%-- NEW EmployeeID --%>
                        <div class="form-group mb-3 text-center">
                            <label for="txtEmployeeID" class="form-label">EmployeeID</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtEmployeeID" runat="server" CssClass="form-control w-50" Placeholder="Enter new employee ID" />
                            </div>
                        </div>

                        <%-- Username --%>
                        <div class="form-group mb-3 text-center">
                            <label for="txtUsername" class="form-label">Username</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control w-50" Placeholder="Enter username" />
                            </div>
                        </div>

                        <%-- Password --%>
                        <div class="form-group mb-3 text-center">
                            <label for="txtPassword" class="form-label">Password</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control w-50" Placeholder="Enter password" />
                            </div>
                        </div>

                        <%-- Confirm Password --%>
                        <div class="form-group mb-4 text-center">
                            <label for="txtConfirmPassword" class="form-label">Confirm Password</label>
                            <div class="input-group justify-content-center">
                                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control w-50" Placeholder="Confirm password" />
                            </div>
                        </div>

                        <%-- Action Buttons --%>
                        <div class="text-center">
                            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-primary me-2" OnClick="btnRegister_Click" Style="background-color: #0d47a1;" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
