using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COSCPFWA
{
    public partial class SchedulePickup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSchedulePickup_Click(object sender, EventArgs e)
        {
            string pickupDate = txtPickupDate.Text.Trim();
            string pickupTime = txtPickupTime.Text.Trim();
            string location = txtLocation.Text.Trim();

            // Save or process the pickup schedule here, with any necessary database interaction

            lblMessage.Text = "Your pickup has been scheduled!";
        }

    }
}