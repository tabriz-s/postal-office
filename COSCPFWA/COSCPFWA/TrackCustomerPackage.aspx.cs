using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COSCPFWA
{
    public partial class TrackCustomerPackage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string customerID = Session["CustomerID"].ToString();
            }
            PackageDetails.Visible = false;
        }

        protected void TrackButton_Click(object sender, EventArgs e)
        {
            string packageID = PackageIDTextBox.Text.Trim();

            if (string.IsNullOrEmpty(packageID))
            {
                // error message if the package ID is empty
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Please enter a Package ID.');", true);
                return;
            }

            // get package details from the database
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "SELECT PackageID, Contents, CurrentStatus, Weight_lbs, ServiceType FROM package WHERE PackageID = @PackageID";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PackageID", packageID);

                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read(); 

                            lblPackageID.Text = reader["PackageID"].ToString();
                            lblContents.Text = reader["Contents"].ToString();
                            lblStatus.Text = reader["CurrentStatus"].ToString();
                            lblWeight.Text = reader["Weight_lbs"].ToString();
                            lblServiceType.Text = reader["ServiceType"].ToString();

                            PackageDetails.Visible = true;
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Package not found. Please check the Package ID and try again.');", true);
                        }
                    }
                }
            }
        }
    }
}