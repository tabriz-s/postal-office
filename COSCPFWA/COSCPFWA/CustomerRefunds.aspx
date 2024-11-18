<%@ Page Title="File a Refund" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerRefunds.aspx.cs" Inherits="COSCPFWA.CustomerRefunds" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="text-center mb-4">
            <h2 class="display-4">File a Refund</h2>
            <p class="lead">Select a package and provide refund details.</p>
        </div>

        <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-info mb-4" Visible="false"></asp:Label>

        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card shadow-lg">
                    <div class="card-header text-white text-center" style="background-color: #0d47a1;">
                        <h5 class="card-title mb-0">Your Packages</h5>
                    </div>
                    <div class="card-body">
                        <asp:Repeater ID="packageRepeater" runat="server">
                            <HeaderTemplate>
                                <table class="table table-striped">
                                    <thead>
                                        <tr>
                                            <th>Package ID</th>
                                            <th>Contents</th>
                                            <th>Status</th>
                                            <th>Base Price</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("PackageID") %></td>
                                    <td><%# Eval("Contents") %></td>
                                    <td><%# Eval("CurrentStatus") %></td>
                                    <td><%# Eval("Base_Price", "{0:C}") %></td>
                                    <td>
                                        <asp:Button ID="btnFileRefund" runat="server" Text="File Refund" CssClass="btn btn-sm btn-primary" CommandArgument='<%# Eval("PackageID") %>' OnClick="btnFileRefund_Click" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>

                        <div id="refundForm" style="display: none;" class="mt-4">
                            <div class="card p-4 shadow-sm">
                                <h5 class="text-center mb-4">Refund Details</h5>
                                <div class="form-group mb-3">
                                    <label for="txtRefundAmount">Refund Amount (up to Base Price)</label>
                                    <asp:TextBox ID="txtRefundAmount" runat="server" CssClass="form-control" MaxLength="6" Placeholder="Enter refund amount" />
                                </div>
                                <div class="form-group mb-3">
                                    <label>Refund Reason</label>
                                    <asp:RadioButtonList ID="rblRefundReason" runat="server" CssClass="form-check" RepeatDirection="Vertical">
                                        <asp:ListItem Text="Delivered super late" Value="Delivered super late" />
                                        <asp:ListItem Text="Damaged contents" Value="Damaged contents" />
                                        <asp:ListItem Text="Package lost" Value="Package lost" />
                                        <asp:ListItem Text="Other, please specify" Value="Other" />
                                    </asp:RadioButtonList>
                                    <asp:TextBox ID="txtOtherReason" runat="server" CssClass="form-control mt-2" Placeholder="Specify other reason" Visible="false" />
                                </div>
                                <div class="text-center">
                                    <asp:Button ID="btnSubmitRefund" runat="server" Text="Submit Refund" CssClass="btn btn-success me-2" OnClick="btnSubmitRefund_Click" />
                                    <asp:Button ID="btnCancelRefund" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancelRefund_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        // Show refund form
        function showRefundForm() {
            document.getElementById("refundForm").style.display = "block";
        }

        // Toggle visibility of "Other" reason textbox
        document.getElementById('<%= rblRefundReason.ClientID %>').addEventListener('change', function() {
            const otherReasonText = document.getElementById('<%= txtOtherReason.ClientID %>');
            otherReasonText.style.display = this.value === 'Other' ? 'block' : 'none';
        });
    </script>
</asp:Content>
