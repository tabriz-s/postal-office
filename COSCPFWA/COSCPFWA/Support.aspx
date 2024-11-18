<%@ Page Title="Support" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Support.aspx.cs" Inherits="COSCPFWA.Support" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="text-center">
            <h2 class="display-4">Help & Support</h2>
            <p class="lead">We're committed to serving you... just not at this exact moment.</p>
        </div>

        <div class="row justify-content-center mt-4">
            <div class="col-md-8">
                <div class="card shadow-lg border-0">
                    <div class="card-header text-white text-center" style="background-color: #dc3545;">
                        <h5 class="card-title mb-0">Page Under Maintenance</h5>
                    </div>
                    <div class="card-body text-center">
                        <img src="https://via.placeholder.com/150?text=Under+Maintenance" alt="Under Maintenance" class="mb-4" />

                        <p class="mb-3">
                            Our support page is currently undergoing scheduled maintenance to ensure we can continue to provide
                            the best possible service. We appreciate your patience as we make improvements.
                        </p>

                        <p>
                            In the meantime, feel free to explore our other services or check back later for assistance. We
                            remain committed to delivering exceptional service, even when our help page needs a bit of help itself.
                        </p>

                        <p class="text-muted mt-3">
                            Thank you for choosing us as your trusted federal postal service. We look forward to assisting you soon.
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="ScriptsContent" ContentPlaceHolderID="ScriptsContent" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" defer></script>
</asp:Content>
