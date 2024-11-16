<%@ Page Title="Edit Employee" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditEmployee.aspx.cs" Inherits="COSCPFWA.EditEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Employee ID:"></asp:Label>
    <asp:TextBox ID="EmployeeIDTextBox" runat="server"></asp:TextBox>
    <asp:Button ID="CheckEmployeeButton" runat="server" Text="Check Employee" OnClick="CheckEmployeeButton_Click" />

    <asp:GridView ID="EmployeeGridView" runat="server" AutoGenerateColumns="false" DataKeyNames="EmployeeID"
        OnRowEditing="EmployeeGridView_RowEditing"
        OnRowUpdating="EmployeeGridView_RowUpdating"
        OnRowDeleting="EmployeeGridView_RowDeleting"
        OnRowCancelingEdit="EmployeeGridView_RowCancelingEdit">
        <Columns>
            <asp:BoundField DataField="EmployeeID" HeaderText="Employee ID" ReadOnly="true" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Address" HeaderText="Address" />
            <asp:BoundField DataField="Role" HeaderText="Role" />
            <asp:BoundField DataField="Salary" HeaderText="Salary" />
            <asp:BoundField DataField="HoursWorked" HeaderText="Hours Worked" />
            <asp:BoundField DataField="IncidentCount" HeaderText="Incident Count" />
            <asp:BoundField DataField="PackagesDelivered" HeaderText="Packages Delivered" />
            <asp:BoundField DataField="HourlyDeliveryRate" HeaderText="Hourly Delivery Rate" />
            <asp:BoundField DataField="ManagerID" HeaderText="Manager ID" />
            <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
</asp:Content>
