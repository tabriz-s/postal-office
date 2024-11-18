<%@ Page Title="Subscribe to SmartLocker" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SubscribeSmartLocker.aspx.cs" Inherits="COSCPFWA.SubscribeSmartLocker" %>

<asp:Content ID="HeadContent" ContentPlaceholderID="HeadContent" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="text-center mb-4">
            <h2 class="display-4">Subscribe to Smart Locker</h2>
            <p class="lead">Select a locker location and get access to 24/7 package retrieval.</p>
        </div>

        <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-info mb-4" Visible="false"></asp:Label>

        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow-lg">
                    <div class="card-header text-white text-center" style="background-color: #0d47a1;">
                        <h5 class="card-title mb-0">SmartLocker Subscription</h5>
                    </div>
                    <div class="card-body">
                        <div class="form-group mb-3 text-center">
                            <label for="ddlLockerLocation" class="form-label">Locker Location</label>
                            <div class="d-flex justify-content-center">
                                <asp:DropDownList ID="ddlLockerLocation" runat="server" CssClass="form-control w-75" OnChange="displayPaymentForm()">
                                    <asp:ListItem Text="-- Select a Location --" Value="" />
                                    <asp:ListItem Text="Location 1" Value="1" />
                                    <asp:ListItem Text="Location 2" Value="2" />
                                    <asp:ListItem Text="Location 3" Value="3" />
                                    <asp:ListItem Text="Location 4" Value="4" />
                                    <asp:ListItem Text="Location 5" Value="5" />
                                </asp:DropDownList>
                            </div>
                        </div>

                        <!-- Payment Form (Initially Hidden) -->
                        <div id="paymentForm" style="display: none;">
                            <div class="card p-4 shadow-sm w-75 mx-auto">
                                <h5 class="text-center mb-3">Payment Details</h5>

                                <div class="form-group mb-3 text-center">
                                    <label for="creditCardNumber" class="form-label">Credit Card Number</label>
                                    <input type="text" class="form-control" id="creditCardNumber" placeholder="1234 5678 9876 5432" />
                                </div>

                                <div class="form-group mb-3 text-center">
                                    <label for="expiryDate" class="form-label">Expiry Date</label>
                                    <input type="text" class="form-control" id="expiryDate" placeholder="MM/YY" />
                                </div>

                                <div class="form-group mb-3 text-center">
                                    <label for="cvv" class="form-label">CVV</label>
                                    <input type="text" class="form-control" id="cvv" placeholder="123" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group text-center mt-4">
                            <asp:Button ID="btnSubscribe" runat="server" Text="Subscribe" CssClass="btn btn-primary btn-lg" OnClick="btnSubscribe_Click" Style="background-color: #0d47a1;" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Scripts" ContentPlaceHolderID="ScriptsContent" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" defer></script>
    <script>
        function displayPaymentForm() {
            const lockerLocation = document.getElementById('<%= ddlLockerLocation.ClientID %>').value;
            document.getElementById('paymentForm').style.display = lockerLocation ? 'block' : 'none';
        }
    </script>
</asp:Content>
