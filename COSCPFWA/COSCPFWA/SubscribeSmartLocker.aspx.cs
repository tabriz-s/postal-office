using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COSCPFWA
{
    public partial class SubscribeSmartLocker : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Visible = false;
                LoadLockerLocations();
            }
        }

        private void LoadLockerLocations()
        {
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT LocationID, LocationName FROM lockerlocations";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        ddlLockerLocation.DataSource = reader;
                        ddlLockerLocation.DataTextField = "LocationName";
                        ddlLockerLocation.DataValueField = "LocationID";
                        ddlLockerLocation.DataBind();
                    }
                }
            }

            ddlLockerLocation.Items.Insert(0, new ListItem("-- Select a Location --", ""));
        }

        protected void btnSubscribe_Click(object sender, EventArgs e)
        {
            // Get selected locker location from the dropdown
            if (string.IsNullOrEmpty(ddlLockerLocation.SelectedValue) || !int.TryParse(ddlLockerLocation.SelectedValue, out int locationId))
            {
                DisplayMessage("Please select a valid locker location.", "alert-danger");
                return;
            }

            if (Session["CustomerID"] == null)
            {
                DisplayMessage("Customer session not found. Please log in again.", "alert-danger");
                return;
            }

            int customerId = Convert.ToInt32(Session["CustomerID"]);

            if (SubscribeCustomerToLocker(customerId, locationId))
            {
                DisplayMessage($"You have successfully subscribed to a SmartLocker at location {ddlLockerLocation.SelectedItem.Text}.", "alert-success");
            }
            else
            {
                DisplayMessage("Failed to subscribe. No lockers are available at the selected location.", "alert-danger");
            }
        }

        private bool SubscribeCustomerToLocker(int customerId, int locationId)
        {
            bool success = false;
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        int lockerId;

                        // Call stored procedure to get the first available locker
                        using (MySqlCommand cmd = new MySqlCommand("GetAvailableLocker", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@SelectedLocationID", locationId);

                            // Define output parameter
                            MySqlParameter outputParam = new MySqlParameter("@AvailableLockerID", MySqlDbType.Int32)
                            {
                                Direction = ParameterDirection.Output
                            };
                            cmd.Parameters.Add(outputParam);

                            cmd.ExecuteNonQuery();

                            // Retrieve the locker ID from the output parameter
                            lockerId = Convert.IsDBNull(outputParam.Value) ? -1 : Convert.ToInt32(outputParam.Value);
                            if (lockerId == -1)
                            {
                                return false; // No available lockers
                            }
                        }

                        // Create a new assignment in the lockerassignment table
                        string insertAssignmentQuery = @"
                            INSERT INTO lockerassignment (LockerID, CustomerID, AssignedAt) 
                            VALUES (@LockerID, @CustomerID, NOW())";

                        using (MySqlCommand cmd = new MySqlCommand(insertAssignmentQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@LockerID", lockerId);
                            cmd.Parameters.AddWithValue("@CustomerID", customerId);
                            cmd.ExecuteNonQuery();
                        }

                        // Commit the transaction
                        transaction.Commit();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        // Rollback the transaction on error
                        transaction.Rollback();
                        DisplayMessage($"Error: {ex.Message}", "alert-danger");
                    }
                }
            }

            return success;
        }

        private void DisplayMessage(string message, string cssClass)
        {
            lblMessage.Text = message;
            lblMessage.CssClass = $"alert {cssClass} mb-4";
            lblMessage.Visible = true;
        }
    }
}