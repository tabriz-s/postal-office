using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COSCPFWA
{
    public partial class Refunds : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRefunds("All");
            }
        }

        protected void ddlStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStatus = ddlStatusFilter.SelectedValue;
            LoadRefunds(selectedStatus);
        }

        private void LoadRefunds(string status)
        {
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = @"SELECT r.RefundID, CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName, r.PackageID, 
                                 r.RefundAmount, r.RefundReason, r.RefundDate, r.RefundStatus
                                 FROM refunds r
                                 JOIN customer c ON r.CustomerID = c.CustomerID";

                if (status != "All")
                {
                    query += " WHERE r.RefundStatus = @Status";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (status != "All")
                    {
                        cmd.Parameters.AddWithValue("@Status", status);
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        refundRepeater.DataSource = reader;
                        refundRepeater.DataBind();
                    }
                }

                // Calculate total refund amount
                query = "SELECT SUM(RefundAmount) FROM refunds WHERE RefundStatus = 'Approved'";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    lblRefundSum.Text = result != DBNull.Value ? $"{Convert.ToDecimal(result):C}" : "$0.00";
                }
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            int refundId = Convert.ToInt32((sender as Button).CommandArgument);
            UpdateRefundStatus(refundId, "Approved");
        }

        protected void btnDeny_Click(object sender, EventArgs e)
        {
            int refundId = Convert.ToInt32((sender as Button).CommandArgument);
            UpdateRefundStatus(refundId, "Denied");
        }

        private void UpdateRefundStatus(int refundId, string status)
        {
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = "UPDATE refunds SET RefundStatus = @Status, LastUpdated = NOW() WHERE RefundID = @RefundID";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@RefundID", refundId);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadRefunds(ddlStatusFilter.SelectedValue);
        }
    }
}
