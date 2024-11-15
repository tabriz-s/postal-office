using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COSCPFWA
{
    public partial class SchedulePickup : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // initialization code 
        }

        protected void btnSchedulePickup_Click(object sender, EventArgs e)
        {
            // get the pickup date, time, and location from the form
            string pickupDate = txtPickupDate.Text;
            string pickupTime = txtPickupTime.Text;
            string location = ddlLocation.SelectedValue;

            if (string.IsNullOrEmpty(pickupDate) || string.IsNullOrEmpty(pickupTime) || string.IsNullOrEmpty(location))
            {
                lblMessage.Text = "Please fill out all fields.";
                lblMessage.Visible = true;
                return;
            }

            DateTime parsedDate;
            if (!DateTime.TryParseExact(pickupDate, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.None, out parsedDate))
            {
                lblMessage.Text = "Invalid date format. Please use yyyy/mm/dd.";
                lblMessage.Visible = true;
                return;
            }

            // check the time is within the allowed range
            DateTime parsedTime;
            if (!DateTime.TryParseExact(pickupTime, "HH:mm", null, System.Globalization.DateTimeStyles.None, out parsedTime))
            {
                lblMessage.Text = "Invalid time format. Please use HH:mm (e.g., 14:00).";
                lblMessage.Visible = true;
                return;
            }

            // validation for valid pickup times based on the day of the week
            var dayOfWeek = parsedDate.DayOfWeek;

            // check if the time is valid for the selected day
            if (dayOfWeek == DayOfWeek.Sunday)
            {
                lblMessage.Text = "Pickup is not available on Sundays.";
                lblMessage.Visible = true;
                return;
            }
            else if (dayOfWeek == DayOfWeek.Saturday)
            {
                // Saturday: 9am to 3pm
                if (parsedTime.Hour < 9 || parsedTime.Hour >= 15)
                {
                    lblMessage.Text = "Pickup time on Saturday must be between 9:00 AM and 3:00 PM.";
                    lblMessage.Visible = true;
                    return;
                }
            }
            else
            {
                // Weekdays: 8am to 7pm
                if (parsedTime.Hour < 8 || parsedTime.Hour >= 19)
                {
                    lblMessage.Text = "Pickup time on weekdays must be between 8:00 AM and 7:00 PM.";
                    lblMessage.Visible = true;
                    return;
                }
            }
            /*
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string query = "INSERT INTO PickupSchedules (CustomerID, PickupDate, PickupTime, Location) VALUES (@CustomerID, @PickupDate, @PickupTime, @Location)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // parameters to the query
                        cmd.Parameters.AddWithValue("@CustomerID", 1);  // Replace with actual customer ID
                        cmd.Parameters.AddWithValue("@PickupDate", parsedDate);
                        cmd.Parameters.AddWithValue("@PickupTime", parsedTime);
                        cmd.Parameters.AddWithValue("@Location", location)
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            */

            lblMessage.Text = "Pickup successfully scheduled!";
            lblMessage.CssClass = "alert alert-success";
            lblMessage.Visible = true;

            // optional: clear inputs after successful scheduling
            txtPickupDate.Text = "";
            txtPickupTime.Text = "";
            ddlLocation.SelectedIndex = 0;
        }
    }
}