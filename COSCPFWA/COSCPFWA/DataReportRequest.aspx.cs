using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.Configuration;
using System.Web.UI;

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
            string name = Name.Text;
            string table = projectSource.SelectedValue;
            string dateFrom = activityDateFrom.Text;
            string dateTo = activityDateTo.Text;

            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    // Replace groupByValue with PackageID
                    string query = $@"
                SELECT PackageID, COUNT(*) AS RecordCount
                FROM {table}
                WHERE CreatedDate >= @DateFrom AND CreatedDate <= @DateTo
                GROUP BY PackageID
                ORDER BY PackageID;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                        cmd.Parameters.AddWithValue("@DateTo", dateTo);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable report = new DataTable();
                            adapter.Fill(report);

                            // Bind the DataTable to the GridView
                            ReportGridView.DataSource = report;
                            ReportGridView.DataBind();
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
