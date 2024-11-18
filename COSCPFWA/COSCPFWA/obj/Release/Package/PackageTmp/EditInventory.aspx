<%@ Page Title="Edit Inventory" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditInventory.aspx.cs" Inherits="COSCPFWA.EditInventory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .main-container {
            display: flex;
            flex-direction: column;
            align-items: center;
            margin-top: 50px;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            background-color: rgba(255, 255, 255, 0.9);
        }

        .table-container {
            margin-top: 30px;
            width: 100%;
            max-width: 800px;
            background-color: rgba(255, 255, 255, 0.9);
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .table {
            width: 100%;
            border-collapse: collapse;
        }

        .table th, .table td {
            padding: 12px;
            border: 1px solid #ddd;
            text-align: left;
            background-color: #f8f9fa;
        }

        .table th {
            background-color: #007bff;
            color: white;
        }

        .increment-btn {
            background-color: #28a745;
            color: #fff;
            border: none;
            border-radius: 3px;
            cursor: pointer;
            padding: 5px 10px;
        }

        h2 {
            color: #000;
        }
    </style>

    <div class="main-container">
        <h2>Edit Inventory</h2>
        <div class="table-container">
            <asp:GridView ID="GridViewInventory" runat="server" AutoGenerateColumns="false" DataKeyNames="ItemID" CssClass="table" OnRowCommand="GridViewInventory_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ItemID" HeaderText="Item ID" ReadOnly="True" />
                    <asp:BoundField DataField="Itemname" HeaderText="Item Name" ReadOnly="True" />
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnIncrement" runat="server" Text="+ 10" CssClass="increment-btn" CommandName="Increment" CommandArgument="<%# Container.DataItemIndex %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
