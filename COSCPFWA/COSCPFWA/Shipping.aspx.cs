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
            // Retrieve form values
            string country = Request.Form["country"];
            string firstName = Request.Form["firstName"];
            string lastName = Request.Form["lastName"];
            string phoneNumber = Request.Form["phone"];
            string email = Request.Form["email"];
            string zipcode = Request.Form["zipcode"];
            string city = Request.Form["city"];
            string state = Request.Form["state"];
            string address = Request.Form["address"];

            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO customer (FirstName, LastName, City, State, PhoneNumber, Email, Address, ZipCode) VALUES (@FirstName, @LastName, @City, @State, @PhoneNumber, @Email, @Address, @ZipCode)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Define parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@City", city);
                        cmd.Parameters.AddWithValue("@State", state);
                        cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Address", address);
                        cmd.Parameters.AddWithValue("@ZipCode", zipcode);

                        // Execute the command
                        cmd.ExecuteNonQuery();
                        Response.Write("<script>alert('Customer information saved successfully.');</script>");
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
