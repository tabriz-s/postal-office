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
            if (!IsPostBack)
            {
                // Only clear session on first load
                Session.Clear();
            }
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
                    string query = @"
                        SELECT ul.UserID, r.RoleName, 
                               CASE 
                                   WHEN r.RoleName = 'Employee' THEN e.EmployeeID
                                   WHEN r.RoleName = 'Customer' THEN c.CustomerID
                                   ELSE NULL
                               END AS RoleSpecificID
                        FROM user_logins ul
                        JOIN user_roles ur ON ul.UserID = ur.UserID
                        JOIN roles r ON ur.RoleID = r.RoleID
                        LEFT JOIN employee e ON ul.UserID = e.UserID
                        LEFT JOIN customer c ON ul.UserID = c.UserID
                        WHERE ul.Username = @Username AND ul.Password = @Password";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string userID = reader["UserID"].ToString();
                                string role = reader["RoleName"].ToString();
                                string roleSpecificID = reader["RoleSpecificID"]?.ToString();

                                Session["UserID"] = userID;
                                Session["Username"] = username;
                                Session["RoleName"] = role;


                                if (role == "Admin")
                                {
                                    Session["EmployeeID"] = roleSpecificID;
                                    Response.Redirect("AdminDashboard.aspx");
                                }
                                else if (role == "Employee")
                                {
                                    Session["EmployeeID"] = roleSpecificID;
                                    Response.Redirect("EmployeeDashboard.aspx");
                                }
                                else if (role == "Customer")
                                {
                                    Session["CustomerID"] = roleSpecificID;
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
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}