using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COSCPFWA
{
    public partial class PackageDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }

    using System;
using System.Configuration;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace COSCPFWA
    {
        public partial class PackageDetails : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                // Page load logic, if necessary
            }

            //Check trigger and everything
            protected void SubmitPackageDetails_Click(object sender, EventArgs e)
            {
                // Retrieve form values
                string packageContents = contents.Text;
                string weightLbs = weightLbs.Text;
                string packageDimensions = dimensions.Text;
                string packageMaterial = material.Text;

                // Retrieve connection string from web.config
                string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

                // Insert data into the database
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        string query = @"INSERT INTO package_details (Contents, WeightLbs, Dimensions, Material)
                                     VALUES (@Contents, @WeightLbs, @Dimensions, @Material)";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            // Set parameters to avoid SQL injection
                            cmd.Parameters.AddWithValue("@Contents", packageContents);
                            cmd.Parameters.AddWithValue("@WeightLbs", weightLbs);
                            cmd.Parameters.AddWithValue("@Dimensions", packageDimensions);
                            cmd.Parameters.AddWithValue("@Material", packageMaterial);

                            // Execute the command
                            cmd.ExecuteNonQuery();
                        }

                        // Display success message
                        Response.Write("<script>alert('Package details saved successfully.');</script>");
                    }
                    catch (Exception ex)
                    {
                        // Log or display an error message
                        Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
                    }
                }
            }
        }
    }

}