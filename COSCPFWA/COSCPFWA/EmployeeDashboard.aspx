<%@ Page Title="Employee Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeDashboard.aspx.cs" Inherits="COSCPFWA.EmployeeDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Welcome, <%= Session["Username"] %></h2>
 
    <section>
        <h3>Available Services</h3>
        <p>Explore our shipping, tracking, and store services.</p>
    </section>
</asp:Content>