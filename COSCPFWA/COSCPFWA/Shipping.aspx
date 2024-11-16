<%@ Page Title="Shipping" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shipping.aspx.cs" Inherits="COSCPFWA.Shipping" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            margin: 0;
        }

        .main-container {
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            padding: 20px;
            flex-direction: column;
            gap: 100px;
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
            margin-bottom: 100px;
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
            margin-top 10px;
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

    </style>
    <div class="main-container">
        <form id ="multiStepForm">
            <div id="step1">
                <div class="shipping-form-container">
                    <h2>Shipping From</h2>
         

                        <div class="form-group full-width">
                            <label for="countryFrom">Country or Territory</label>
                            <%-- Changed to dropdown and added ALL MISSING "asp:" prefixes  --%>
                            <asp:DropDownList ID="CountryFrom" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Select your country" Value="" />
                                <asp:ListItem Text="United States" Value="us" />
                                <asp:ListItem Text="Canada" Value="ca" />
                                <asp:ListItem Text="United Kingdom" Value="uk" />
                            </asp:DropDownList>
                        </div>
                            <div class="input-row">
                                <div class="form-group">
                                <%-- Also all "id" have to be capitalized to ID --%>
                                <label for="firstNameFrom">First Name</label>
                                <asp:TextBox ID="firstNameFrom" name="firstName" required runat="server" />
                                </div>

                                <%-- Missing runat ="server" statements for each input --%>
                                <div class="form-group">
                                    <label for="lastNameFrom">Last Name</label>
                                    <asp:TextBox ID="lastNameFrom" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="input-row two-inputs">
                                <div class="form-group">
                                    <label for="phoneFrom">Phone Number</label>
                                    <asp:TextBox ID="phoneFrom" runat="server" CssClass="form-control" TextMode="Phone" />
                                </div>

                                <div class="form-group">
                                    <label for="emailFrom">Email</label>
                                    <asp:TextBox ID="emailFrom" runat="server" CssClass="form-control" TextMode="Email" />
                                </div>
                            </div>

                            <div class="form-group full-width">
                                <label for="addressFrom">Address</label>
                                <asp:TextBox ID="addressFrom" runat="server" CssClass="form-control" MaxLength="30" />
                            </div>

                            <div class="input-row three-inputs">
                                <div class="form-group">
                                    <label for="cityFrom">City</label>
                                    <asp:TextBox ID="cityFrom" runat="server" CssClass="form-control" />
                                </div>

                                <div class="form-group">
                                    <label for="stateFrom">State</label>
                                    <asp:TextBox ID="stateFrom" runat="server" CssClass="form-control" MaxLength="2" />
                                </div>

                                <div class="form-group">
                                    <label for="zipcodeFrom">Zip Code</label>
                                    <asp:TextBox ID="zipcodeFrom" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                        </div>

                   
                            <%-- Forgot to associate the submit button to the C# function AND changed "onserverclick" to "OnClick" --%>
             
        <%-- Missing runat="server" statement to allow ASP.NET to manage form submission at line 79 --%>

        <!-- Ship To Section -->
        
            <div class="shipping-form-container">
                <h2>Shipping To</h2>

                        <div class="form-group full-width">
                            <label for="countryTo">Country or Territory</label>
                            <%-- Changed to dropdown and added ALL MISSING "asp:" prefixes  --%>
                            <asp:DropDownList ID="countryTo" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Select your country" Value="" />
                                <asp:ListItem Text="United States" Value="us" />
                                <asp:ListItem Text="Canada" Value="ca" />
                                <asp:ListItem Text="United Kingdom" Value="uk" />
                            </asp:DropDownList>
                        </div>
                        <div class="input-row two-inputs">
                            <div class="form-group">
                            <%-- Also all "id" have to be capitalized to ID --%>
                            <label for="firstNameTo">First Name</label>
                            <asp:TextBox ID="firstNameTo" name="firstName" required runat="server" />
                            </div>

                            <%-- Missing runat ="server" statements for each input --%>
                            <div class="form-group">
                                <label for="lastNameTo">Last Name</label>
                                <asp:TextBox ID="lastNameTo" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="input-row two-inputs">
                            <div class="form-group">
                                <label for="phoneTo">Phone Number</label>
                                <asp:TextBox ID="phoneTo" runat="server" CssClass="form-control" TextMode="Phone" />
                            </div>

                            <div class="form-group">
                                <label for="emailTo">Email</label>
                                <asp:TextBox ID="emailTo" runat="server" CssClass="form-control" TextMode="Email" />
                            </div>
                        </div>

                        <div class="form-group full-width">
                            <label for="addressTo">Address</label>
                            <asp:TextBox ID="addressTo" runat="server" CssClass="form-control" MaxLength="30" />
                        </div>

                        <div class="input-row three-inputs">
                            <div class="form-group">
                                <label for="cityTo">City</label>
                                <asp:TextBox ID="cityTo" runat="server" CssClass="form-control" />
                            </div>

                            <div class="form-group">
                                <label for="stateTo">State</label>
                                <asp:TextBox ID="stateTo" runat="server" CssClass="form-control" MaxLength="2" />
                            </div>

                            <div class="form-group">
                                <label for="zipcodeTo">Zip Code</label>
                                <asp:TextBox ID="zipcodeTo" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                    </div> <!-- Ending form container -->
                    
                    <%-- Forgot to associate the submit button to the C# function AND changed "onserverclick" to "OnClick" --%>
          
        

                    <div class=" shipping-form-container">
                        <h2>Packaging</h2>
                            <p> You may leave blank if you plan to drop off package at postal office.</p>
                
                        <div class="input-row four-inputs">
                            <div class="form-group">
                                <label for="weight">Weight* in</label>
                                <asp:TextBox ID="weight" runat="server" CssClass="form-control" />
                            </div>

                            <div class="form-group">
                                <label for="length">Length* in</label>
                                <asp:TextBox ID="length" runat="server" CssClass="form-control" />
                            </div>

                            <div class="form-group">
                                <label for="width">Width* in</label>
                                <asp:TextBox ID="width" runat="server" CssClass="form-control" />
                            </div>
                
                            <div class="form-group">
                                <label for="height">Height* in</label>
                                <asp:TextBox ID="height" runat="server" CssClass="form-control" />
                            </div>

                        </div>

                    </div> <!-- Ending form container -->
                
        </div>



<!-- STEP 2 asddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd -->

            <div id ="step2" class="shipping-form-container hidden">
                <h2>Pickup or Drop-off</h2>
                <div class="form-group">
                    <p class="radio-title">Please select a service type</p>
                    <div class="radio-group">
                        <label>
                        <asp:RadioButton ID="delivery" runat="server" GroupName="serviceType" Text="I'm going to drop it off" />
                        </label>
                        <label>
                        <asp:RadioButton ID="pickup" runat="server" GroupName="serviceType" Text="I need to schedule a pickup." />
                        </label>
                    </div>  
                </div>
          
                <div class="form-group">
                    <h2>Additional Details</h2>
                    <label for="content">General Description</label>
                    <p> Just give us a general description of what is inside your package.</p>
                    <asp:TextBox ID="content" runat="server" CssClass="form-control" />
                </div>
            </div>
<!-- STEP 3333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333 -->
            <div id="step3" class="shipping-form-container hidden">
                <h2>Payment Method</h2>

                    <div class="form-group full-width hidden">
                        <label for="cardType">Card Type</label>
                        <asp:DropDownList ID="cardType" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Select your card type" Value="" />
                            <asp:ListItem Text="Visa" Value="visa" />
                            <asp:ListItem Text="MasterCard" Value="mastercard" />
                            <asp:ListItem Text="American Express" Value="americanexpress" />
                        </asp:DropDownList>
                    </div>
                    
                    <div class="input-row three-inputs">
                        <div class="form-group">
                            <label for="cardNum">Card Number</label>
                            <asp:TextBox ID="cardNum" runat="server" CssClass="form-control" />
                        </div>

                        <div class="form-group">
                            <label for="expDate">Expiration Date</label>
                            <asp:TextBox ID="expDate" runat="server" CssClass="form-control" MaxLength="2" />
                        </div>

                        <div class="form-group">
                            <label for="cvv">CVV</label>
                            <asp:TextBox ID="cvv" runat="server" CssClass="form-control" />
                        </div>
                    </div>

                    <div class="form-group full-width hidden">
                        <label for ="cardName">Cardholder name</label>
                        <asp:TextBox ID ="cardName" runat="server" CssClass="form-control"/>
                    </div>

            </div>

            <asp:Button ID ="nextBtn" runat="server" CssClass="next-btn" Text="Next" OnClientClick="toggleForms(); return false;" />
            <asp:Button ID ="backBtn" runat="server" CssClass="back-btn" Text="Back" OnClientClick="goBack(); return false;" />

            <asp:Button ID="submitBtn" runat="server" CssClass="submit-btn" Text="Submit" OnClick="SubmitButton_Click" />
        </form>
        
    </div>

     <script type="text/javascript">
         let currentStep = 1;
         const totalSteps = 3;
         const nextButton = document.getElementById('<%= nextBtn.ClientID %>');
         const submitButton = document.getElementById('<%= submitBtn.ClientID %>');
         const backButton = document.getElementById('<%= backBtn.ClientID %>');


         document.getElementById('step1').classList.remove('hidden');
         submitButton.style.display = 'none';
         backButton.style.display = 'none';

     // Toggle visibility of form sections based on report type
     function toggleForms()
     {
         //var userStep = document.getElementById('<= nextBtn.ClientID %>').value;

         //Stack overflow
         document.getElementById(`step${currentStep}`).classList.add('hidden');
        
         //Increment to see which "step" they are on
         currentStep++;


         //Shows next page
         if (currentStep <= totalSteps) {
             document.getElementById(`step${currentStep}`).classList.remove('hidden');
         }
         
         // Show relevant section based on report type
         /* if (currentStep === 2)
         {
             customerReport.style.display = "block";
         }
         else if (currentStep == 3)
         {
             employeeReport.style.display = "block";
         } */

         if (currentStep > 1) {
             backButton.style.display = 'block'; // Show Back button
         }

         //Hides the next button
         if (currentStep == totalSteps)
         {
             nextButton.style.display = "none";
             submitButton.style.display = 'block';
         }
     }

    function goBack() {
        document.getElementById(`step${currentStep}`).classList.add('hidden');
        currentStep--;

        if (currentStep > 0) {
            document.getElementById(`step${currentStep}`).classList.remove('hidden');
        }

        if (currentStep < totalSteps) {
            nextButton.style.display = 'block';
            submitButton.style.display = 'none';
        }

        if (currentStep === 1) {
            backButton.style.display = 'none';
        }
    }

     </script>

</asp:Content>