using MySql.Data.MySqlClient;
using System;
using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Data;
using System.Web.Configuration;
using System.Web.UI;
using System.Collections.Generic;
using Org.BouncyCastle.Asn1.Ocsp;

//I made some changes to the code, if you can see this that means you can see all the changes I made
namespace COSCPFWA
{

    public partial class DataReportRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Page load logic if needed
        }

        protected void ViewReport_Click(object sender, EventArgs e)
        {
            string name = employeeName.TagName; //Will add more variables soon
            string table = projectSource.SelectedValue;
            string dateFrom = activityDateFrom.Text;
            string dateTo = activityDateTo.Text;

            //FIxed connection string
            string connString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    // Right now query just returns employee info with the packageID and its recipients info based on if its a delivery
                    string query = @"
                    SELECT e.Name, e.EmployeeID, p.PackageID, s.RecipientFirstName, s.RecipientLastName, p.ServiceType, s.RecievingAddress
                    FROM package as p
                    JOIN employee as e ON p.EmployeeID = e.EmployeeID
                    JOIN shippingdetails as s ON s.PackageID = p.PackageID
                    JOIN customer as c ON p.CustomerID = c.CustomerID
                    WHERE e.Name = @EmployeeName AND p.ServiceType = @DeliveryType;";


                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeName", employeeName);
                        cmd.Parameters.AddWithValue("@DeliveryType", deliveryType);
                        cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                        cmd.Parameters.AddWithValue("@DateTo", dateTo);

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
