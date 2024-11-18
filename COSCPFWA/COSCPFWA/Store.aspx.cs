using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace COSCPFWA
{
    public partial class Store : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string itemType = Request.Form["selectedItem"];
                string quantitySoldStr = Request.Form["quantity"];
                string lastUpdated = Request.Form["submitTime"];

                if (string.IsNullOrEmpty(itemType) || string.IsNullOrEmpty(quantitySoldStr) || string.IsNullOrEmpty(lastUpdated))
                {
                    // Log or print which fields are empty
                    Response.Write($"ItemType: {itemType ?? "null"}, QuantitySold: {quantitySoldStr ?? "null"}, LastUpdated: {lastUpdated ?? "null"}");
                    Response.Write("One or more fields are empty. Please fill out the form correctly.");
                    return;
                }

                // Convert the quantitySold to int
                if (!int.TryParse(quantitySoldStr, out int quantitySold))
                {
                    // Handle invalid quantity format
                    Response.Write("Invalid quantity format.");
                    return;
                }

                // Convert the lastUpdated to DateTime
                if (!DateTime.TryParse(lastUpdated, out DateTime lastUpdatedDateTime))
                {
                    // Handle invalid datetime format
                    Response.Write("Invalid submit time format.");
                    return;
                }

                // Save the data to the MySQL database
                SaveToDatabase(itemType, quantitySold, lastUpdatedDateTime);
            }
        }

        private void SaveToDatabase(string itemType, int quantitySold, DateTime lastUpdated)
        {
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"]?.ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Store (ItemType, QuantitySold, LastUpdated) VALUES (@ItemType, @QuantitySold, @LastUpdated)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ItemType", itemType);
                    cmd.Parameters.AddWithValue("@QuantitySold", quantitySold);
                    cmd.Parameters.AddWithValue("@LastUpdated", lastUpdated);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Handle the exception
                    Console.WriteLine("An error occurred: " + ex.Message);
                    Response.Write("An error occurred while saving data: " + ex.Message);
                }
            }
        }
    }
}
