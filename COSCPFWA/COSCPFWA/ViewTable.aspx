<%@ Page Title="View Table" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewTable.aspx.cs" Inherits="COSCPFWA.ViewTable" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h1>View and Manage Tables</h1>

        <!-- you can add more tables from the database into this list -->
        <div class="mt-3">
            <label for="ddlTableSelect">Select Table:</label>
            <asp:DropDownList ID="ddlTableSelect" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTableSelect_SelectedIndexChanged">
                <asp:ListItem Text="Customer" Value="customer" />
                <asp:ListItem Text="Package" Value="package" />
                <asp:ListItem Text="Employee" Value="employee" />
                <asp:ListItem Text="Notifications" Value="notifications" />
                <asp:ListItem Text="Tracking History" Value="trackinghistory" />
                <asp:ListItem Text="Incident" Value="incident" />
                <asp:ListItem Text="Money Orders" Value="money_orders" />
                <asp:ListItem Text="Shipping Details" Value="shippingdetails" />
                <asp:ListItem Text="Inventory" Value="inventory" />
                <asp:ListItem Text="Store" Value="store" />
                <asp:ListItem Text="Government Services" Value="government_services" />
            </asp:DropDownList>
        </div>

        <!--Inside the GridView tag: OnRowEditing="gvData_RowEditing" OnRowUpdating="gvData_RowUpdating" OnRowCancelingEdit="gvData_RowCancelingEdit" -->
        <div class="table-responsive mt-4" style="overflow-x: auto;">
            <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="true" CssClass="table table-striped" 
                          OnRowDeleting="gvData_RowDeleting" AllowPaging="true" PageSize="10">
                <Columns>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblPrimaryKey" runat="server" Text='<%# Eval(tablePrimaryKeys[ddlTableSelect.SelectedValue]) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:CommandField ShowEditButton="false" />
                    <asp:CommandField ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
        </div>
    </main>
</asp:Content>
