    <%@ Page Title="Refunds" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Refunds.aspx.cs" Inherits="COSCPFWA.Refunds" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h1>Refunds</h1>

        <!-- Refund Status filter -->
        <div class="mt-3">
            <label for="statusFilter" runat="server">Filter by Status:</label>
            <asp:DropDownList ID="ddlStatusFilter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStatusFilter_SelectedIndexChanged">
                <asp:ListItem Text="All" Value="All" />
                <asp:ListItem Text="Pending" Value="Pending" />
                <asp:ListItem Text="Approved" Value="Approved" />
            </asp:DropDownList>
        </div>

        <asp:Repeater ID="refundRepeater" runat="server">
            <HeaderTemplate>
                <table class="table table-striped mt-4">
                    <thead>
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
                        <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="btn btn-sm btn-success" CommandArgument='<%# Eval("RefundID") %>' OnClick="btnApprove_Click" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
        </table>
   
            </FooterTemplate>
        </asp:Repeater>

        <!-- Total refunds  -->
        <div class="mt-4">
            <asp:Label ID="lblTotalRefund" runat="server" Text="Total Refund Amount: " CssClass="font-weight-bold"></asp:Label>
            <asp:Label ID="lblRefundSum" runat="server" CssClass="font-weight-bold"></asp:Label>
        </div>
    </main>
</asp:Content>
