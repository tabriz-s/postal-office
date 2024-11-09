using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Web.UI;

namespace COSCPFWA
{
    public partial class Employee1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve connection string from the configuration
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            // Local variables for CustomerID and LoginPassword
            int customerID = 69; // Set this to the desired CustomerID for testing
            string loginPassword = "RyanTest"; // Set this to the desired password for testing

            // Establish a connection to the database
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                try
                {
                    con.Open();
                    Response.Write("Connection successful!<br>");

                    // Insert CustomerID and LoginPassword using local variables
                    string insertQuery = "INSERT INTO user_logins (CustomerID, LoginPassword) VALUES (@CustomerID, @LoginPassword)";
                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, con))
                    {
                        // Add parameters to the insert command
                        insertCmd.Parameters.AddWithValue("@CustomerID", customerID);
                        insertCmd.Parameters.AddWithValue("@LoginPassword", loginPassword);

                        // Execute the insert command
                        insertCmd.ExecuteNonQuery();
                        Response.Write("CustomerID and LoginPassword inserted successfully!<br>");
                    }

                    // Define the SQL query to retrieve all data from  table
                    string selectQuery = "SELECT CustomerID, LoginPassword FROM user_logins";
                    MySqlCommand selectCmd = new MySqlCommand(selectQuery, con);

                    // Execute the select query
                    using (MySqlDataReader reader = selectCmd.ExecuteReader())
                    {
                        // Display each row of data
                        while (reader.Read())
                        {
                            Response.Write("CustomerID: " + reader["CustomerID"].ToString() + "<br>");
                            Response.Write("LoginPassword: " + reader["LoginPassword"].ToString() + "<br><br>");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors
                    Response.Write("Error: " + ex.Message);
                }
            }
        }
    }
}