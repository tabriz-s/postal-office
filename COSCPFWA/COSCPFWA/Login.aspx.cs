using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace COSCPFWA
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT RoleName FROM user_logins ul JOIN user_roles ur ON ul.UserID = ur.UserID JOIN roles r ON ur.RoleID = r.RoleID WHERE ul.Username = @Username AND ul.Password = @Password";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        object roleObj = cmd.ExecuteScalar();

                        if (roleObj != null)
                        {
                            string role = roleObj.ToString();
                            Session["Username"] = username;
                            Session["RoleName"] = role;

                            // Redirect based on user role
                            if (role == "Admin")
                            {
                                Response.Redirect("AdminDashboard.aspx");
                            }
                            else if (role == "Employee")
                            {
                                Response.Redirect("EmployeeDashboard.aspx");
                            }
                            else if (role == "Customer")
                            {
                                Response.Redirect("CustomerDashboard.aspx");
                            }
                            else
                            {
                                lblMessage.Text = "Unauthorized.";
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Invalid Username or Password.";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

        }

    }
}