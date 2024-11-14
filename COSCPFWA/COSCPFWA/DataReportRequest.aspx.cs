using MySql.Data.MySqlClient;
using System;
using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Data;
using System.Web.Configuration;
using System.Web.UI;
using System.Collections.Generic;
using System.Data.SqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using Newtonsoft.Json;
using System.Web.UI.WebControls;
using Mysqlx.Crud;

//I made some changes to the code, if you can see this that means you can see all the changes I made
namespace COSCPFWA
{

    public partial class DataReportRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateOrderByDropdown();
            }
        }

        // Event handler for Generate Chart button
        protected void btnGenerateChart_Click(object sender, EventArgs e)
        {
            GenerateChart();
        }

        private void PopulateOrderByDropdown()
        {
            orderByDropdown.Items.Add(new ListItem("CustomerID", "CustomerID"));
        }

        private void GenerateChart()
        {
            //Attaches the HTML form values to temporary varaibles
            string firstName = customerFirstName.Text;
            string lastName = customerLastName.Text;
            string table = reportType.SelectedValue;
            string type = packageType.SelectedValue;
            string dateFrom = activityDateFrom.Text;
            string dateTo = activityDateTo.Text;

            //Retrieves user selection for the graph's x & y axis
            string xAxisSelected = xAxis.SelectedValue;
            string yAxisSelected = yAxis.SelectedValue;

            //This stores query results to a chart
            List<string> labels = new List<string>();
            List<int> values = new List<int>();

            string connString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;


            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                //Figure dynamic query queue
                string query = @"SELECT p.ServiceType, COUNT(p.PackageID) AS NumPackages
                                    FROM package as p
                                    JOIN customer as c ON p.CustomerID = c.CustomerID
                                    LEFT JOIN shippingdetails as sd ON sd.PackageID = p.PackageID
                                    LEFT JOIN smartlocker as sl ON sl.PackageID = p.PackageID
                                    WHERE 1=1";

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;


                    //Add parameters later
                    if (!string.IsNullOrEmpty(type))
                    {
                        query+= " AND p.ServiceType = @PackageType";
                        cmd.Parameters.AddWithValue("@PackageType", type);
                    }

                    if (!string.IsNullOrEmpty(firstName))
                    {
                        query+= " AND c.FirstName = @CustomerFirstName";
                        cmd.Parameters.AddWithValue("@CustomerFirstName", firstName);
                    }

                    if (!string.IsNullOrEmpty(lastName))
                    {
                        query+= " AND c.LastName = @CustomerLastName";
                        cmd.Parameters.AddWithValue("@CustomerLastName", lastName);
                    }

                    if (!string.IsNullOrEmpty(dateFrom) && !string.IsNullOrEmpty(dateTo))
                    {
                        query+= " AND p.CreatedAt > @FromDate";
                        query+= " AND p.CreatedAt < @ToDate";
                        cmd.Parameters.AddWithValue("@FromDate", dateFrom);
                        cmd.Parameters.AddWithValue("ToDate", dateTo);
                    }

                    query+= " GROUP BY p.ServiceType";
                    cmd.CommandText = query;
                    //System.Diagnostics.Debug.WriteLine("Final Query: " + query);

                    //Executes query
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            labels.Add(reader["ServiceType"].ToString());
                            values.Add(int.Parse(reader["NumPackages"].ToString()));
                        }
                    }
                }
            }

            // Convert chart data to JSON format for rendering in JavaScript
            var jsonData = new
            {
                labels = labels,
                values = values
            };
            chartData.Value = JsonConvert.SerializeObject(jsonData); // Set JSON data for hidden field
        }

        protected void ViewReport_Click(object sender, EventArgs e)
        {
            //Attaches the HTML form values to temporary variables
            string firstName = customerFirstName.Text;
            string lastName = customerLastName.Text;
            string table = reportType.SelectedValue;
            string type = packageType.SelectedValue;
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
                    string query = @"SELECT c.FirstName, c.LastName, c.CustomerID, p.PackageID, p.ServiceType, p.CreatedAt
                    FROM package as P
                    JOIN customer as c ON p.CustomerID = c.CustomerID
                    LEFT JOIN shippingdetails as sd ON sd.PackageID = p.PackageID
                    LEFT JOIN smartlocker as sl ON sl.packageID = p.PackageID
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

                        if (!string.IsNullOrEmpty(type))
                        {
                            query+= " AND p.ServiceType = @PackageType";
                            cmd.Parameters.AddWithValue("@PackageType", type);
                        }

                        if (!string.IsNullOrEmpty(firstName))
                        {
                            query+= " AND c.FirstName = @CustomerFirstName";
                            cmd.Parameters.AddWithValue("@CustomerFirstName", firstName);
                        }

                        if (!string.IsNullOrEmpty(lastName))
                        {
                            query+= " AND c.LastName = @CustomerLastName";
                            cmd.Parameters.AddWithValue("@CustomerLastName", lastName);
                        }

                        if (!string.IsNullOrEmpty(dateFrom) && !string.IsNullOrEmpty(dateTo))
                        {
                            query+= " AND p.CreatedAt > @FromDate";
                            query+= " AND p.CreatedAt < @ToDate";
                            cmd.Parameters.AddWithValue("@FromDate", dateFrom);
                            cmd.Parameters.AddWithValue("ToDate", dateTo);
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
