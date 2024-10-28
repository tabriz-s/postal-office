using System;
using System.Configuration;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace COSCPFWA
{
    public partial class ShippingDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Page load logic, if needed
        }

        protected void SubmitShippingDetails_Click(object sender, EventArgs e)
        {
            // Retrieve values from the form fields
            string senderAddress = senderAddress.Text;
            string shippingMethod = shippingMethod.SelectedValue;
            string receivingAddress = receivingAddress.Text;
            string receiverName = receiverName.Text;

            // Retrieve the connection string from web.config
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            // Insert data into the database
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO shipping_details (SenderAddress, ShippingMethod, ReceivingAddress, ReceiverName)
                                     VALUES (@SenderAddress, @ShippingMethod, @ReceivingAddress, @ReceiverName)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Set parameters to avoid SQL injection
                        cmd.Parameters.AddWithValue("@SenderAddress", senderAddress);
                        cmd.Parameters.AddWithValue("@ShippingMethod", shippingMethod);
                        cmd.Parameters.AddWithValue("@ReceivingAddress", receivingAddress);
                        cmd.Parameters.AddWithValue("@ReceiverName", receiverName);

                        // Execute the command
                        cmd.ExecuteNonQuery();
                    }

                    // Display success message or handle further actions
                    Response.Write("<script>alert('Shipping details saved successfully.');</script>");
                }
                catch (Exception ex)
                {
                    // Log error or display a friendly message
                    Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
                }
            }
        }
    }
}
