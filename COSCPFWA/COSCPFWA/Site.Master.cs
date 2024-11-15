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

            SetDashboardLink();
        }
        protected void Logout(object sender, EventArgs e)
        {
            // Clear the session and redirect to login page
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }

        private void SetDashboardLink()
        {
            var userRole = Session["RoleName"] as string;

            switch (userRole)
            {
                case "Customer":
                    navbarBrand.HRef = "~/CustomerDashboard";
                    break;
                case "Employee":
                    navbarBrand.HRef = "~/EmployeeDashboard";
                    break;
                case "Admin":
                    navbarBrand.HRef = "~/AdminDashboard";
                    break;
                default:
                    navbarBrand.HRef = "~/Home"; // Fallback to home page if role is unknown
                    break;
            }
        }
    }
}