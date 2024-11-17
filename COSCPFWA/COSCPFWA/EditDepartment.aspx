<%@ Page Title="Manage Departments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditDepartment.aspx.cs" Inherits="COSCPFWA.EditDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="LoadAllDepartmentsButton" runat="server" Text="Load All Departments" OnClick="LoadAllDepartmentsButton_Click" />
    <asp:GridView ID="DepartmentGridView" runat="server" AutoGenerateColumns="false" DataKeyNames="DepartmentNum"
        OnRowEditing="DepartmentGridView_RowEditing"
        OnRowUpdating="DepartmentGridView_RowUpdating"
        OnRowDeleting="DepartmentGridView_RowDeleting"
        OnRowCancelingEdit="DepartmentGridView_RowCancelingEdit">
        <Columns>
            <asp:BoundField DataField="DepartmentNum" HeaderText="Department Number" ReadOnly="true" />
            <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" />
            <asp:BoundField DataField="ManagerID" HeaderText="Manager ID" />
            <asp:BoundField DataField="ManagerStart" HeaderText="Manager Start Date" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="NumOfEmployees" HeaderText="Number of Employees" />
            <asp:BoundField DataField="PostOfficeID" HeaderText="Post Office ID" />
            <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
</asp:Content>
