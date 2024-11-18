using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI;

namespace COSCPFWA
{
    public partial class CustomerNotifications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadNotifications();
            }
        }

        private void LoadNotifications()
        {
            string customerId = Session["CustomerID"]?.ToString();
            if (string.IsNullOrEmpty(customerId))
            {
                lblMessage.Text = "Unable to load notifications. Please log in.";
                lblMessage.CssClass = "alert alert-danger";
                lblMessage.Visible = true;
                return;
            }

            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "SELECT NotificationID, PackageID, Message, NotificationDate FROM notifications WHERE CustomerID = @CustomerID ORDER BY NotificationDate DESC";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);

                try
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        rptNotifications.DataSource = dt;
                        rptNotifications.DataBind();

                        if (dt.Rows.Count == 0)
                        {
                            lblMessage.Text = "You have no notifications at this time.";
                            lblMessage.CssClass = "alert alert-info";
                            lblMessage.Visible = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error loading notifications: " + ex.Message;
                    lblMessage.CssClass = "alert alert-danger";
                    lblMessage.Visible = true;
                }
            }
        }
    }
}