using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COSCPFWA
{
    public partial class SubscribeSmartLocker : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
        }

        protected void btnSubscribe_Click(object sender, EventArgs e)
        {
            // Get selected locker location from the dropdown
            string lockerLocation = ddlLockerLocation.SelectedValue;

            // Validate input
            if (string.IsNullOrEmpty(lockerLocation))
            {
                lblMessage.Text = "Please select a locker location.";
                lblMessage.CssClass = "alert alert-danger mb-4";
                lblMessage.Visible = true;
                return;
            }

            // Store the locker location in ViewState to access it after payment confirmation
            ViewState["LockerLocation"] = lockerLocation;

            // Show the payment modal for the user to enter payment details
            ScriptManager.RegisterStartupScript(this, this.GetType(), "openPaymentModal", "$('#paymentModal').modal('show');", true);
        }

        // This method is called when the payment is confirmed
        protected void ConfirmPayment()
        {
            // Retrieve the locker location from ViewState
            string lockerLocation = ViewState["LockerLocation"] as string;

            if (string.IsNullOrEmpty(lockerLocation))
            {
                lblMessage.Text = "Failed to retrieve locker location. Please try again.";
                lblMessage.CssClass = "alert alert-danger mb-4";
                lblMessage.Visible = true;
                return;
            }

            // Simulate the subscription process
            bool isSubscribed = SubscribeCustomerToLocker(lockerLocation);

            // Show the result to the user
            if (isSubscribed)
            {
                lblMessage.Text = "You have successfully subscribed to the SmartLocker at Location " + lockerLocation + ".";
                lblMessage.CssClass = "alert alert-success mb-4";
            }
            else
            {
                lblMessage.Text = "Failed to subscribe. Please try again later.";
                lblMessage.CssClass = "alert alert-danger mb-4";
            }

            lblMessage.Visible = true;
        }

        private bool SubscribeCustomerToLocker(string lockerLocation)
        {
            // This method simulates the logic of subscribing a customer to a smart locker.
            // You would implement database insertion logic here.

            try
            {
                // Example: Insert the customer's subscription into the database
                // (Code for database insertion goes here)

                // For now, simulate success:
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception and return false
                // (Code for logging the exception goes here)
                return false;
            }
        }
    }
}
