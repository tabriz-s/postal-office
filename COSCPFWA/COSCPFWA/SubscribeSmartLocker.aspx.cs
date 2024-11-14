using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COSCPFWA
{
    public partial class SubscribeSmartLocker : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubscribe_Click(object sender, EventArgs e)
        {
            
            string lockerLocation = txtLockerLocation.Text.Trim();


            lblMessage.Text = "You subscribed to SmartLocker!";
        }

    }
}