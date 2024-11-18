<%@ Page Title="Store" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Store.aspx.cs" Inherits="COSCPFWA.Store" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Welcome to the Store</h1>

    <div class="item-container">
        <div class="item" onclick="selectItem('Paper')">
            <img src="https://th.bing.com/th/id/R.893c1c34d013f0425e52d72a7f4ed633?rik=RPXJKF3AFVxt8Q&pid=ImgRaw&r=0" alt="Paper">
            <p>Paper</p>
        </div>
        <div class="item" onclick="selectItem('Bubble Wrap')">
            <img src="https://www.parrs.co.uk/images/bubble-wrap-large-p12862-31671_medium.jpg" alt="Bubble Wrap">
            <p>Bubble Wrap</p>
        </div>
        <div class="item" onclick="selectItem('Envelope')">
            <img src="https://th.bing.com/th/id/R.c36d2c583561fe94e8ce69b68c000691?rik=3HEgITkDHw%2bgYA&pid=ImgRaw&r=0" alt="Envelope">
            <p>Envelope</p>
        </div>
        <div class="item" onclick="selectItem('Box')">
            <img src="https://th.bing.com/th/id/OIP.qC7cLlom17N5BlvS_JcM7wHaFu?rs=1&pid=ImgDetMain" alt="Box">
            <p>Box</p>
        </div>
        <div class="item" onclick="selectItem('Stamps')">
            <img src="https://static.vecteezy.com/system/resources/previews/009/384/430/original/post-stamps-clipart-design-illustration-free-png.png" alt="Stamps">
            <p>Stamps</p>
        </div>
        <div class="item" onclick="selectItem('Tape')">
            <img src="https://th.bing.com/th/id/OIP.eioYsF-8ahC9MOGpMlzcPQHaHa?rs=1&pid=ImgDetMain" alt="Tape">
            <p>Tape</p>
        </div>
    </div>

    <br /><br />
    <label for="quantity">Enter Quantity:</label>
    <input type="number" id="quantity" name="quantity" min="1" max="100" />
    <br /><br />
    <input type="hidden" id="selectedItem" name="selectedItem" />
    <input type="hidden" id="submitTime" name="submitTime" />
    <input type="submit" value="Submit" onclick="setSubmitTime()" />

    <style type="text/css">
        .item-container {
            display: flex;
            flex-wrap: wrap;
            gap: 15px;
        }
        .item {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            height: 150px;
            width: 100px;
            border: 1px solid #ccc;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s;
            padding: 10px;
        }
        .item:hover {
            background-color: #f0f0f0;
        }
        .item img {
            height: 80px;
            width: 80px;
            margin-bottom: 5px;
        }
        .item p {
            margin: 0;
        }
    </style>

    <script type="text/javascript">
        function selectItem(item) {
            document.getElementById('selectedItem').value = item;
            // Deselect all items
            var items = document.getElementsByClassName('item');
            for (var i = 0; i < items.length; i++) {
                items[i].style.backgroundColor = "";
            }
            // Highlight selected item
            event.target.closest('.item').style.backgroundColor = "#d1e7dd";
        }

        function setSubmitTime() {
            document.getElementById('submitTime').value = new Date().toISOString();
        }
    </script>
</asp:Content>
