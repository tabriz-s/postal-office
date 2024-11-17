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
            // get selected locker location from the dropdown
            if (!int.TryParse(ddlLockerLocation.SelectedValue, out int locationId))
            {
                DisplayMessage("Please select a locker location.", "alert-danger");
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
                        int lockerId = -1;

                        // stored procedure to get the first available locker
                        using (MySqlCommand cmd = new MySqlCommand("GetAvailableLocker", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@SelectedLocationID", locationId);
                            cmd.Parameters.Add(new MySqlParameter("@AvailableLockerID", MySqlDbType.Int32)
                            {
                                Direction = ParameterDirection.Output
                            });

                            cmd.ExecuteNonQuery();

                            // retrieve the locker ID from the output parameter
                            object lockerIdObj = cmd.Parameters["@AvailableLockerID"].Value;
                            if (lockerIdObj == DBNull.Value || lockerIdObj == null)
                            {
                                return false; // No available lockers
                            }

                            lockerId = Convert.ToInt32(lockerIdObj);
                        }

                        // create a new assignment in the lockerassignment table
                        string insertAssignmentQuery = @"
                            INSERT INTO lockerassignment (LockerID, CustomerID, AssignedAt) 
                            VALUES (@LockerID, @CustomerID, NOW())";

                        using (MySqlCommand cmd = new MySqlCommand(insertAssignmentQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@LockerID", lockerId);
                            cmd.Parameters.AddWithValue("@CustomerID", customerId);
                            cmd.ExecuteNonQuery();
                        }

                        // commit the transaction
                        transaction.Commit();
                        success = true;
                    }
                    catch
                    {
                        // Rollback the transaction on error
                        transaction.Rollback();
                        throw;
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
