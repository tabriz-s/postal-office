using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COSCPFWA
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EmployeeID"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    LoadAssignedPackages();
                    UpdateStatistics();
                }
            }
        }

        private void LoadAssignedPackages(string searchQuery = null)
        {
            string employeeID = Session["EmployeeID"].ToString();
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "SELECT PackageID, Contents, CurrentStatus, ServiceType, Weight_lbs FROM package WHERE EmployeeID = 3";

                if (!string.IsNullOrEmpty(searchQuery))
                {
                    query += " AND (Contents LIKE @SearchQuery OR ServiceType LIKE @SearchQuery)";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                    if (!string.IsNullOrEmpty(searchQuery))
                    {
                        cmd.Parameters.AddWithValue("@SearchQuery", $"%{searchQuery}%");
                    }

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        AssignedPackagesGridView.DataSource = dt;
                        AssignedPackagesGridView.DataBind();
                    }
                }
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string searchQuery = SearchTextBox.Text.Trim();
            LoadAssignedPackages(searchQuery);
        }

        private void UpdateStatistics()
        {
            string employeeID = Session["EmployeeID"].ToString();
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = @"
            SELECT 
                COUNT(*) AS TotalPackages,
                SUM(CASE WHEN CurrentStatus = 'In Transit' THEN 1 ELSE 0 END) AS PendingDeliveries,
                SUM(CASE WHEN CurrentStatus = 'Delivered' THEN 1 ELSE 0 END) AS DeliveredPackages
            FROM package
            WHERE EmployeeID = 3";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TotalPackagesLabel.Text = reader["TotalPackages"].ToString();
                            PendingDeliveriesLabel.Text = reader["PendingDeliveries"].ToString();
                            DeliveredPackagesLabel.Text = reader["DeliveredPackages"].ToString();
                        }
                    }
                    conn.Close();
                }
            }
        }
    }
}