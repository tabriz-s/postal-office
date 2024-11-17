<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckPackages.aspx.cs" Inherits="COSCPFWA.CheckPackages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Manage Packages</h2>
    
    <asp:GridView 
        ID="PackagesGridView" 
        runat="server" 
        AutoGenerateColumns="false" 
        DataKeyNames="PackageID" 
        OnRowEditing="PackagesGridView_RowEditing" 
        OnRowDeleting="PackagesGridView_RowDeleting" 
        OnRowUpdating="PackagesGridView_RowUpdating" 
        OnRowCancelingEdit="PackagesGridView_RowCancelingEdit" 
        CssClass="table table-bordered">
        
        <Columns>
            <asp:BoundField DataField="PackageID" HeaderText="PackageID" ReadOnly="true" />
            
            <asp:TemplateField HeaderText="EmployeeID">
                <EditItemTemplate>
                    <asp:TextBox ID="EmployeeIDTextBox" runat="server" Text='<%# Bind("EmployeeID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelEmployeeID" runat="server" Text='<%# Eval("EmployeeID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Current Status">
                <EditItemTemplate>
                    <asp:TextBox ID="CurrentStatusTextBox" runat="server" Text='<%# Bind("CurrentStatus") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelCurrentStatus" runat="server" Text='<%# Eval("CurrentStatus") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Contents">
                <EditItemTemplate>
                    <asp:TextBox ID="ContentsTextBox" runat="server" Text='<%# Bind("Contents") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelContents" runat="server" Text='<%# Eval("Contents") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="ServiceType">
                <EditItemTemplate>
                    <asp:TextBox ID="ServiceTypeTextBox" runat="server" Text='<%# Bind("ServiceType") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelServiceType" runat="server" Text='<%# Eval("ServiceType") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Weight (lbs)">
                <EditItemTemplate>
                    <asp:TextBox ID="WeightTextBox" runat="server" Text='<%# Bind("Weight_lbs") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelWeight" runat="server" Text='<%# Eval("Weight_lbs") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>

    <script type="text/javascript">
        function confirmEdit() {
            return confirm('Are you sure you want to edit this package?');
        }
        function confirmDelete() {
            return confirm('Are you sure you want to delete this package?');
        }
    </script>
</asp:Content>
