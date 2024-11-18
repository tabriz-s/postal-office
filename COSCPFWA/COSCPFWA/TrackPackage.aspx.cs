using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace COSCPFWA
{
    public partial class TrackPackage : System.Web.UI.Page
    {
        protected void TrackButton_Click(object sender, EventArgs e)
        {
            string packageID = PackageIDTextBox.Text.Trim();
            if (string.IsNullOrEmpty(packageID))
            {
                Response.Write("<script>alert('Please enter a Package ID.');</script>");
                return;
            }

            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"]?.ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "SELECT * FROM package WHERE PackageID = @PackageID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PackageID", packageID);

                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        StatusLabel.Text = reader["CurrentStatus"].ToString();
                        ServiceTypeLabel.Text = reader["ServiceType"].ToString();
                        ContentsLabel.Text = reader["Contents"].ToString();
                        WeightLabel.Text = reader["Weight_lbs"].ToString() + " lbs";
                        WidthLabel.Text = reader["Width_in"].ToString();
                        LengthLabel.Text = reader["Length_in"].ToString();
                        TrackingPanel.Visible = true;
                    }
                    else
                    {
                        Response.Write("<script>alert('Package not found!!!');</script>");
                        TrackingPanel.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('ERROR " + ex.Message.Replace("'", "\\'") + "');</script>");
                }
            }
        }
    }
}
