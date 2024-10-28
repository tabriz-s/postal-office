using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COSCPFWA
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Login click button
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Replace with actual authentication logic
            if (username == "admin" && password == "password") // Sample credentials
            {
                Session["Username"] = username;
                Response.Redirect("About.aspx"); // Redirect to About page after successful login
            }
            else
            {
                lblMessage.Text = "Invalid Username or Password!";
            }
        }
    }
}
