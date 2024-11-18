using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COSCPFWA
{
    public partial class CustomerRefunds : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Visible = false;
                LoadCustomerPackages();
            }
        }

        private void LoadCustomerPackages()
        {
            if (Session["CustomerID"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            int customerId = Convert.ToInt32(Session["CustomerID"]);
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT PackageID, Contents, CurrentStatus, Base_Price FROM package WHERE CustomerID = @CustomerID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);

                MySqlDataReader reader = cmd.ExecuteReader();
                packageRepeater.DataSource = reader;
                packageRepeater.DataBind();
            }
        }

        protected void btnFileRefund_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int packageId = Convert.ToInt32(button.CommandArgument);

            // Retrieve Base_Price for the selected package
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT Base_Price FROM package WHERE PackageID = @PackageID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PackageID", packageId);

                object basePriceObj = cmd.ExecuteScalar();
                if (basePriceObj != null)
                {
                    decimal basePrice = Convert.ToDecimal(basePriceObj);
                    ViewState["SelectedPackageID"] = packageId;
                    ViewState["BasePrice"] = basePrice;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showRefundForm", "showRefundForm();", true);
                }
            }
        }

        protected void btnSubmitRefund_Click(object sender, EventArgs e)
        {
            if (Session["CustomerID"] == null)
            {
                lblMessage.Text = "Customer session not found. Please log in again.";
                lblMessage.CssClass = "alert alert-danger mb-4";
                lblMessage.Visible = true;
                return;
            }

            if (!decimal.TryParse(txtRefundAmount.Text, out decimal refundAmount))
            {
                lblMessage.Text = "Please enter a valid refund amount.";
                lblMessage.CssClass = "alert alert-danger mb-4";
                lblMessage.Visible = true;
                return;
            }

            decimal basePrice = Convert.ToDecimal(ViewState["BasePrice"]);
            if (refundAmount > basePrice)
            {
                lblMessage.Text = $"Refund amount cannot exceed the base price of {basePrice:C}.";
                lblMessage.CssClass = "alert alert-danger mb-4";
                lblMessage.Visible = true;
                return;
            }

            string refundReason = rblRefundReason.SelectedValue;
            if (refundReason == "Other")
            {
                refundReason = txtOtherReason.Text.Trim();
            }

            int customerId = Convert.ToInt32(Session["CustomerID"]);
            int packageId = Convert.ToInt32(ViewState["SelectedPackageID"]);
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = @"
                    INSERT INTO refunds (CustomerID, PackageID, RefundAmount, RefundReason, RefundDate, RefundStatus, CreatedAt) 
                    VALUES (@CustomerID, @PackageID, @RefundAmount, @RefundReason, NOW(), 'Pending', NOW())";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                cmd.Parameters.AddWithValue("@PackageID", packageId);
                cmd.Parameters.AddWithValue("@RefundAmount", refundAmount);
                cmd.Parameters.AddWithValue("@RefundReason", refundReason);

                cmd.ExecuteNonQuery();
                lblMessage.Text = "Refund request submitted successfully.";
                lblMessage.CssClass = "alert alert-success mb-4";
                lblMessage.Visible = true;
                LoadCustomerPackages(); // Refresh packages
            }
        }

        protected void btnCancelRefund_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerDashboard.aspx");
        }
    }
}
