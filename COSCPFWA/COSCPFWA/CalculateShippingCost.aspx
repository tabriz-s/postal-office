<%@ Page Title="CalculateShippingCost" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CalculateShippingCost.aspx.cs" Inherits="COSCPFWA.CalculateShippingCost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            margin: 0;
        }

        .main-container {
            display: grid;
            grid-template-columns: 1fr 1fr;
            grid-gap: 10px;
            row-gap: 2px;
            justify-content: start;
            align-items: start;
            min-height: 100vh;
            padding: 20px 0;
            width: 100%;
        }

        .shipping-form-container {
            width: 100%;
            max-width: 600px;
            background-color: #fff;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 6px 12px rgba(0, 0, 0, 0.15);
            border-top: 8px solid #3b3b3b;
            box-sizing: border-box;
            margin: 0;
        }

            .shipping-form-container h2 {
                text-align: center;
                color: #333;
                font-size: 24px;
                font-weight: bold;
                margin-bottom: 20px;
            }

        .form-group {
            display: flex;
            flex-direction: column;
            width: 100%;
            margin-bottom: 15px;
            align-items: center;
        }

            .form-group label {
                display: block;
                width: 100%;
                color: #3b3b3b;
                font-weight: bold;
                margin-bottom: 5px;
                text-align: left;
            }

            .form-group input,
            .form-group select {
                width: 100%;
                padding: 12px;
                border: 1px solid #ccc;
                border-radius: 4px;
                font-size: 15px;
            }

                .form-group input:focus,
                .form-group select:focus {
                    border-color: #ffc107;
                    outline: none;
                    box-shadow: 0 0 4px rgba(255, 193, 7, 0.5);
                }

        .submit-btn {
            width: 100%;
            max-width: 200px;
            padding: 14px;
            background-color: #ffc107;
            color: #3b3b3b;
            font-size: 16px;
            font-weight: bold;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s ease;
            margin: 20px auto 0;
            display: block;
        }

        .submit-btn:hover {
            background-color: #d39e00;
        }

        .next-btn
        {
            width: 100%;
            max-width: 200px;
            padding: 14px;
            background-color: #ffc107;
            color: #3b3b3b;
            font-size: 16px;
            font-weight: bold;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s ease;
            margin: 20px auto 0;
            display: block;

        }

         .next-btn:hover 
         {
             background-color: #d39e00;
         }

        .back-btn {
             width: 100%;
             max-width: 200px;
             padding: 14px;
             background-color: #ffc107;
             color: #3b3b3b;
             font-size: 16px;
             font-weight: bold;
             border: none;
             border-radius: 4px;
             cursor: pointer;
             transition: background-color 0.3s ease;
             margin: 20px auto 0;
             display: block;
             display: none; /* Initially hidden */
        }


        .back-btn:hover {
            background-color: #d39e00;
        }

        input, select, .form-group
        {
            box-sizing: border-box;
        }

        .input-row 
        {
            display: flex;
            gap: 10px;
            width: 100%;
        }

        .input-row .form-group 
        {
            flex: 1;
            margin-bottom: 15px;
        }

        .input-row.two-inputs .form-group
        {
            flex: 0 0 calc(50% - 5px);
        }

        .input-row.three-inputs .form-group
        {
            flex: 0 0 calc(33.33% - 6.67px);
        }

        .input-row.four-inputs .form-group
        {
            flex: 0 0 calc(25% - 7.5px);
        }

        .form-group.full-width
        {
            width: 100%;
            display: flex;
        }


        .form-group.full-width select,
        .form-group.full-width input
        {
            width: 100%;
            max-width: 600px;
            padding: 12px;
            font-size: 15px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
            flex: 1;
        }

        input, select
        {
            padding: 12px;
            height: 42px;
            font-size: 15px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        .radio-group
        {
            display: flex;
            flex-direction: column;
            gap: 10px;
            margin-top: 10px;
            width: 100%;
            align-items: flex-start;
        }

        .radio-group label
        {
            display:flex;
            align-items: center;
            font-size: 15px;
            color: #333;
            gap: 10px;
        }

        .radio-group input[type="radio"]
        {
            margin: 0;
        }

        .radio-title
        {
            text-align: center;
            font-weight: bold;
            margin-bottom: 10px;
            color: #333;
        }

        .hidden
        {
            display: none;
        }

        .submit-btn, .next-btn, .back-btn
        {
            position: relative;
            margin: 10px auto;
        }

        .cost-table
        {
            position: absolute;
            top: 50%;
            right: 0;
            transform: translateY(-50%);
            width: 350px;
            background-color: #fff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 6px 12px rgba(0, 0, 0, 0.15);
            border-top:8px solid #3b3b3b;
        }

    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class ="main-container">
        <div class="shipping-form-container">
        <h2>Shipping From</h2>
     

            <div class="form-group full-width">
                <label for="countryFromCost">Country or Territory</label>
                <asp:DropDownList ID="countryFromCost" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Select your country" Value="" />
                    <asp:ListItem Text="United States" Value="us" />
                    <asp:ListItem Text="Canada" Value="ca" />
                    <asp:ListItem Text="United Kingdom" Value="uk" />
                </asp:DropDownList>
            </div>
            
            <div class="form-group full-width">
                <label for="addressFromCost">Address</label>
                <asp:TextBox ID="addressFromCost" runat="server" CssClass="form-control" MaxLength="30" />
            </div>

            <div class="input-row three-inputs">
                <div class="form-group">
                    <label for="cityFromCost">City</label>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" />
                </div>

                <div class="form-group">
                    <label for="stateFromCost">State</label>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" MaxLength="2" />
                </div>

                <div class="form-group">
                    <label for="zipcodeFromCost">Zip Code</label>
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" />
                </div>
            </div>
        </div>

                
            <div class="shipping-form-container">
                <h2>Shipping To</h2>

                <div class="form-group full-width">
                    <label for="countryToCost">Country or Territory</label>
                    <%-- Changed to dropdown and added ALL MISSING "asp:" prefixes  --%>
                    <asp:DropDownList ID="countryToCost" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Select your country" Value="" />
                        <asp:ListItem Text="United States" Value="us" />
                        <asp:ListItem Text="Canada" Value="ca" />
                        <asp:ListItem Text="United Kingdom" Value="uk" />
                    </asp:DropDownList>
                </div>

                <div class="form-group full-width">
                    <label for="addressToCost">Address</label>
                    <asp:TextBox ID="addressToCost" runat="server" CssClass="form-control" MaxLength="30" />
                </div>

                <div class="input-row three-inputs">
                    <div class="form-group">
                        <label for="cityToCost">City</label>
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" />
                    </div>

                    <div class="form-group">
                        <label for="stateToCost">State</label>
                        <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" MaxLength="2" />
                    </div>

                    <div class="form-group">
                        <label for="zipcodeToCost">Zip Code</label>
                        <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" />
                    </div>
                </div>
            </div>

                
            <div class=" shipping-form-container">
                <h2>Packaging</h2>
                    <p> You may leave blank if you plan to drop off package at postal office.</p>
            
                <div class="input-row four-inputs">
                    <div class="form-group">
                        <label for="weightCost">Weight* in</label>
                        <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control" 
                            type="number" step="any" max="99" oninput="this.value = Math.min(99, Math.abs(this.value))" />
                    </div>

                    <div class="form-group">
                        <label for="lengthCost">Length* in</label>
                        <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control" 
                            type="number" step="any" max="99" oninput="this.value = Math.min(99, Math.abs(this.value))" />
                    </div>

                    <div class="form-group">
                        <label for="width">Width* in</label>
                        <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control" 
                            type="number" step="any" max="99" oninput="this.value = Math.min(99, Math.abs(this.value))" />
                    </div>
            
                    <div class="form-group">
                        <label for="heightCost">Height* in</label>
                        <asp:TextBox ID="TextBox12" runat="server" CssClass="form-control" 
                            type="number" step="any" max="99" oninput="this.value = Math.min(99, Math.abs(this.value))" />
                    </div>

                </div>
            </div>

            <div class="shipping-form-container">
     
                <div class ="form-group full-width">
                    <div class="form-group">
                        <label for="costDate">When are you shipping?</label>
                        <asp:TextBox ID="costDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>

                 <div class="form-group">
                     <label for="ServiceCost">Delivery or Pickup?</label>
                        <asp:DropDownList ID="ServiceCost" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Select your service" Value="" />
                            <asp:ListItem Text="I'll drop it off at the office (Delivery)" Value="Delivery" />
                            <asp:ListItem Text="Can you pick it up for me (Pickup)" Value="Pickup" />
                        </asp:DropDownList>
                     </div>  
                 </div>
                </div>


            <!-- Figure out how to display cost calculator -->
            <div class="cost-table">
            <h2>Cost Calculator</h2>
            <table class="cost-table">
                <thead>
                    <tr>
                        <th>Type of Fee</th>
                        <th>Value</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Base Price</td>
                        <td><asp:Label ID="BasePrice" runat="server" Text="$10.00"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Weight Fee</td>
                        <td><asp:Label ID="WeightFee" runat="server" Text="N/A"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Dimension Fee</td>
                        <td><asp:Label ID="DimensionFee" runat="server" Text="N/A"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Distance Fee</td>
                        <td><asp:Label ID="DistanceFee" runat="server" Text="N/A"></asp:Label></td>
                    </tr>

                    <tr>
                        <td>Estimated Total Cost</td>
                        <td><asp:Label ID="TotalCost" runat="server" Text="$0.00"></asp:Label></td>
                    </tr>
                    
                </tbody>
            </table>
            </div>
           
            <asp:Button ID="CalculateButton" runat="server" Text="Calculate Shipping Cost" CssClass="submit-btn" OnClick="CalculateCost" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
