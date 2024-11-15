using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COSCPFWA
{
    public partial class ShippingHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ViewReport_Click(object sender, EventArgs e)
        {
            //Attaches the HTML form values to temporary variables
            string customer = customerID.Text;

            //FIxed connection string
            string connString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    // Right now query just returns employee info with the packageID and its recipients info based on if its a delivery
                    string query = @"SELECT c.FirstName, c.LastName, c.CustomerID, p.PackageID, p.ServiceType, p.CreatedAt
                    FROM package as P
                    JOIN customer as c ON p.CustomerID = c.CustomerID
                    LEFT JOIN shippingdetails as sd ON sd.PackageID = p.PackageID
                    WHERE 1=1";
                    //JOIN smartlocker as l ON l.PackageID = p.PackageID


                    /* @"
                SELECT c.FirstName, c.LastName, c.CustomerID, p.PackageID, p.ServiceType,
                FROM package as p, customer as c, shippingdetails as s
                WHERE p.CustomerID = c.CustomerID AND p.ServiceType = @PackageType AND s.PackageID = p.PackageID
                AND p.Name=@CustomerName;"; */


                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;

                        if (!string.IsNullOrEmpty(customer))
                        {
                            query+= " AND c.CustomerID = @CustomerID";
                            cmd.Parameters.AddWithValue("@CustomerID", customer);
                        }
                        cmd.CommandText = query;
                        //System.Diagnostics.Debug.WriteLine("Final Query: " + query);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable report = new DataTable();
                            adapter.Fill(report);

                            // Bind the DataTable to the GridView
                            ResultGrid.DataSource = report;
                            ResultGrid.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Failed to connect to the database: " + ex.Message + "');</script>");
                }
            }
        }
    }
}