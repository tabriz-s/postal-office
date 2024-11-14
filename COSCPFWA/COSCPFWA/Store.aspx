<%@ Page Title="Store" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Store.aspx.cs" Inherits="COSCPFWA.Store" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Welcome to the Store</h1> 
    <label for="item">Select an Item:</label>
    <select id="item" name="item">
        <option value="paper">Paper</option>
        <option value="Bubble Wrap">Bubble Wrap</option>
        <option value="Envelope">Envelope</option>
        <option value="Box">Box</option>
        <option value="Stamps">Stamps</option> 
        <option value="Tape">Tape</option> 
    </select>
    <br /><br /> 
    <label for="quantity">Enter Quantity:</label>
    <input type="number" id="quantity" name="quantity" min="1" max="100" />
    <br /><br /> 
    <input type="hidden" id="submitTime" name="submitTime" />
    <input type="submit" value="Submit" onclick="setSubmitTime()" />
&nbsp;<style type="text/css">
        #item {
            height: 23px;
            width: 133px;
        }
    </style>
    <script type="text/javascript"> function setSubmitTime() { document.getElementById('submitTime').value = new Date().toISOString(); } </script>
</asp:Content>
