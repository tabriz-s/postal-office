using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Web.UI;

namespace COSCPFWA
{
    public partial class Shipping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Submit button clicked');</script>");

            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            // Retrieve Shipping From values
            string country_from = CountryFrom.SelectedValue;
            string firstName_from = firstNameFrom.Text;
            string lastName_from = lastNameFrom.Text;
            string phone_from = phoneFrom.Text;
            string email_from = emailFrom.Text;
            string zipcode_from = zipcodeFrom.Text;
            string city_from = cityFrom.Text;
            string state_from = stateFrom.Text;
            string address_from = addressFrom.Text;

            // Retrieve Shipping To values
            string country_to = countryTo.SelectedValue;
            string firstName_to = firstNameTo.Text;
            string lastName_to = lastNameTo.Text;
            string phone_to = phoneTo.Text;
            string email_to = emailTo.Text;
            string zipcode_to = zipcodeTo.Text;
            string city_to = cityTo.Text;
            string state_to = stateTo.Text;
            string address_to = addressTo.Text;

            //Retrieving Packaging Detaisl
            string Weight = weight.Text;
            string Length = length.Text;
            string Width = width.Text;
            string Height = height.Text;

            string Dimensions = $"{Weight} x {Length} x {Height}";

            //Retrieving Service Type
            string ServiceType = "";
            if(delivery.Checked)
            {
                ServiceType = "Delivery";
            }
            else if(pickup.Checked)
            {
                ServiceType = "Pickup";
            }

            //Retrieving Additional Details
            string Contents = content.Text;

            //Payment method isn't really checked or run through database. Should we though?
            //Nah man sensitive information, we can go to hell if we did that. Therefore, Professor would surely not want us to.
            //Bruh

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                //Removed empty try-catch block. Why was this here?
                try
                {
                    conn.Open();
                    // Insert Package
                    string query = @"INSERT INTO package(CustomerID, RecievedDate, ServiceType, CurrentStatus, Contents, Weight_lbs, Length_in, Width_in, Height_in) 
                                     VALUES (1, CURRENT_TIMESTAMP, @ServiceType, 'Recieved', @Contents, @Weight, @Length, @Width, @Height);";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ServiceType", ServiceType);
                        cmd.Parameters.AddWithValue("@Contents", Contents);
                        cmd.Parameters.AddWithValue("@Weight", Weight);
                        cmd.Parameters.AddWithValue("@Length", Length);
                        cmd.Parameters.AddWithValue("@Width", Width);
                        cmd.Parameters.AddWithValue("Height", Height);
                        cmd.ExecuteNonQuery();
                    }

                    // Conditional Insertion
                    if (ServiceType == "Delivery")
                    {
                        query = @"INSERT INTO shippingdetails(SenderID, SendingAddress, PackageID, RecievingAddress, RecipientFirstName, RecipientLastName)
                                  VALUES (1, @AddressFrom, LAST_INSERT_ID(), @AddressTo, @FirstNameTo, @LastNameTo);";
                    }
                    else if (ServiceType == "Pickup")
                    {
                        query = @"INSERT INTO pickupdetails(SenderID, SenderAddress, PackageID, RecipientAddress, RecipientFirstName, RecipientLastName) 
                                  VALUES (1, @AddressFrom, LAST_INSERT_ID(), @AddressTo, @FirstNameTo, @LastNameTo);";
                    }

                    if (!string.IsNullOrEmpty(query))
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@AddressFrom", address_from);
                            cmd.Parameters.AddWithValue("@AddressTo", address_to);
                            cmd.Parameters.AddWithValue("@FirstNameTo", firstName_to);
                            cmd.Parameters.AddWithValue("@LastNameTo", lastName_to);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    // Display detailed MySQL error message on the webpage for debugging
                    Response.Write("<script>alert('MySQL Error: " + ex.Message.Replace("'", "\\'") + "');</script>");
                }
                catch (Exception ex)
                {
                    // Display a generic error message for any other exception
                    Response.Write("<script>alert('An error occurred: " + ex.Message.Replace("'", "\\'") + "');</script>");
                }
            }
        }
    }
}
