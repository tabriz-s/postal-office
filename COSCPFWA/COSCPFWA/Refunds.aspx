<%@ Page Title="Refunds" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Refunds.aspx.cs" Inherits="COSCPFWA.Refunds" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="text-center mb-4">
            <h2 class="display-4">Refunds Management</h2>
            <p class="lead">process refund requests from customers.</p>
        </div>

        <div class="mb-4">
            <label for="statusFilter" class="form-label">Filter by Status:</label>
            <asp:DropDownList ID="ddlStatusFilter" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlStatusFilter_SelectedIndexChanged">
                <asp:ListItem Text="All" Value="All" />
                <asp:ListItem Text="Pending" Value="Pending" />
                <asp:ListItem Text="Approved" Value="Approved" />
                <asp:ListItem Text="Denied" Value="Denied" />
            </asp:DropDownList>
        </div>

        <asp:Repeater ID="refundRepeater" runat="server">
            <HeaderTemplate>
                <table class="table table-hover mt-4">
                    <thead class="table-dark">
                        <tr>
                            <th>Refund ID</th>
                            <th>Customer Name</th>
                            <th>Package ID</th>
                            <th>Refund Amount</th>
                            <th>Refund Reason</th>
                            <th>Refund Date</th>
                            <th>Refund Status</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("RefundID") %></td>
                    <td><%# Eval("CustomerName") %></td>
                    <td><%# Eval("PackageID") %></td>
                    <td><%# Eval("RefundAmount", "{0:C}") %></td>
                    <td><%# Eval("RefundReason") %></td>
                    <td><%# Eval("RefundDate", "{0:yyyy-MM-dd}") %></td>
                    <td><%# Eval("RefundStatus") %></td>
                    <td>
                        <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="btn btn-sm btn-success me-2" CommandArgument='<%# Eval("RefundID") %>' OnClick="btnApprove_Click" />
                        <asp:Button ID="btnDeny" runat="server" Text="Deny" CssClass="btn btn-sm btn-danger" CommandArgument='<%# Eval("RefundID") %>' OnClick="btnDeny_Click" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>

        <div class="mt-4 text-end">
            <asp:Label ID="lblTotalRefund" runat="server" Text="Total Refund Amount: " CssClass="fw-bold"></asp:Label>
            <asp:Label ID="lblRefundSum" runat="server" CssClass="fw-bold"></asp:Label>
        </div>
    </div>
</asp:Content>
