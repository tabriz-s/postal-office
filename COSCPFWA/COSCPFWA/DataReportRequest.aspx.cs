using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
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
            string groupNameValue = groupName.Text;
            string investigator = investigatorName.Text;
            string table = projectSource.SelectedValue; // this is the table name
            string dateFrom = activityDateFrom.Text; // CreatedDate
            string dateTo = activityDateTo.Text; // LastUpdated Date

            // Connection string from web.config
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                        cmd.Parameters.AddWithValue("@DateTo", dateTo);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable report = new DataTable();
                            adapter.Fill(report);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Error handling if database connection or query execution fails
                    Response.Write("<script>alert('Failed to connect to the database: " + ex.Message + "');</script>");
                }
            }
        }
    }
}
