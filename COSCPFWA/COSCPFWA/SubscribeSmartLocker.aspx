<%@ Page Title="Subscribe to SmartLocker" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SubscribeSmartLocker.aspx.cs" Inherits="COSCPFWA.SubscribeSmartLocker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="locker-container">
        <h2>Subscribe to SmartLocker</h2>
        <asp:Label ID="lblMessage" runat="server" CssClass="message-label"></asp:Label>
        
        <asp:TextBox ID="txtLockerLocation" runat="server" Placeholder="Locker Location" CssClass="form-control"></asp:TextBox>
        
        <asp:Button ID="btnSubscribe" runat="server" Text="Subscribe" CssClass="btn btn-primary" OnClick="btnSubscribe_Click" />
    </div>
</asp:Content>
