using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace COSCPFWA
{
    public partial class EditInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInventory();
            }
        }

        private void LoadInventory()
        {
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT ItemID, Itemname, Quantity FROM inventory";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        GridViewInventory.DataSource = dataTable;
                        GridViewInventory.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('An error occurred while loading inventory: " + ex.Message.Replace("'", "\\'") + "');</script>");
                }
            }
        }

        protected void GridViewInventory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Increment")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewInventory.Rows[index];
                int itemId = Convert.ToInt32(GridViewInventory.DataKeys[index].Value);

                // Access the Quantity field
                int currentQuantity = Convert.ToInt32((row.FindControl("lblQuantity") as Label).Text);

                string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        string query = @"UPDATE inventory SET Quantity = @Quantity WHERE ItemID = @ItemID";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ItemID", itemId);
                            cmd.Parameters.AddWithValue("@Quantity", currentQuantity + 10);

                            cmd.ExecuteNonQuery();
                        }

                        LoadInventory();
                        Response.Write("<script>alert('Quantity incremented successfully!');</script>");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('An error occurred while incrementing quantity: " + ex.Message.Replace("'", "\\'") + "');</script>");
                    }
                }
            }
        }
    }
}
