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
    public partial class Refunds : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRefunds("All");  // Load all refunds by default
                CalculateTotalRefund();
            }
        }

        protected void LoadRefunds(string statusFilter)
        {
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT r.RefundID, CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName, " +
                               "r.PackageID, r.RefundAmount, r.RefundReason, r.RefundDate, r.RefundStatus " +
                               "FROM refunds r JOIN customer c ON r.CustomerID = c.CustomerID";

                if (statusFilter != "All")
                {
                    query += " WHERE r.RefundStatus = @StatusFilter";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (statusFilter != "All")
                    {
                        cmd.Parameters.AddWithValue("@StatusFilter", statusFilter);
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        refundRepeater.DataSource = dt;
                        refundRepeater.DataBind();
                    }
                }
            }
        }

        protected void ddlStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStatus = ddlStatusFilter.SelectedValue;
            LoadRefunds(selectedStatus);
            CalculateTotalRefund();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            Button btnApprove = (Button)sender;
            string refundID = btnApprove.CommandArgument;

            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE refunds SET RefundStatus = 'Approved' WHERE RefundID = @RefundID";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RefundID", refundID);
                        cmd.ExecuteNonQuery();
                    }

                    LoadRefunds(ddlStatusFilter.SelectedValue); // Reload refunds to reflect changes
                    CalculateTotalRefund(); // Recalculate total refund amount
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error approving refund: " + ex.Message + "');</script>");
                }
            }
        }

        protected void CalculateTotalRefund()
        {
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT SUM(RefundAmount) FROM refunds";

                if (ddlStatusFilter.SelectedValue != "All")
                {
                    query += " WHERE RefundStatus = @StatusFilter";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (ddlStatusFilter.SelectedValue != "All")
                    {
                        cmd.Parameters.AddWithValue("@StatusFilter", ddlStatusFilter.SelectedValue);
                    }

                    object result = cmd.ExecuteScalar();
                    decimal totalRefund = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    lblRefundSum.Text = $"{totalRefund:C}";
                }
            }
        }
    }
}
