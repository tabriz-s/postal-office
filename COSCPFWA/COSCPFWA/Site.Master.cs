using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COSCPFWA
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userRole = Session["RoleName"] as string;

                phCustomerNav.Visible = false;
                phEmployeeNav.Visible = false;
                phAdminNav.Visible = false;

                if (userRole == "Customer")
                {
                    phCustomerNav.Visible = true;
                }
                else if (userRole == "Employee")
                {
                    phEmployeeNav.Visible = true;
                }
                else if (userRole == "Admin")
                {
                    phAdminNav.Visible = true;
                }
                else
                {
                    // optional: Redirect to login if role is undefined
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
        protected void Logout(object sender, EventArgs e)
        {
            // Clear the session and redirect to login page
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}