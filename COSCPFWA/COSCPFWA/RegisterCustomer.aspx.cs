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
    public partial class RegisterCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Retrieve user inputs
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            // Split full name into first and last
            string[] nameParts = fullName.Split(' ');
            string firstName = nameParts[0];
            string lastName = nameParts.Length > 1 ? string.Join(" ", nameParts, 1, nameParts.Length - 1) : "";

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please fill in all fields.";
                return;
            }

            if (password != confirmPassword)
            {
                lblMessage.Text = "Passwords do not match!";
                return;
            }

            try
            {
                // check for duplicate usernames or emails
                string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    // Check if the username or email already exists
                    string checkUserQuery = "SELECT COUNT(*) FROM user_logins WHERE Username = @Username OR Email = @Email";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkUserQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", username);
                        checkCmd.Parameters.AddWithValue("@Email", email);

                        int existingUserCount = (int)checkCmd.ExecuteScalar();
                        if (existingUserCount > 0)
                        {
                            lblMessage.Text = "Username or Email already exists. Please choose another.";
                            return;
                        }
                    }

                    // insert new user
                    string insertUserQuery = @"INSERT INTO user_logins (FirstName, LastName, Email, Username, Password) 
                                               VALUES (@FirstName, @LastName, @Email, @Username, @Password)";
                    using (MySqlCommand insertCmd = new MySqlCommand(insertUserQuery, conn))
                    {

                        insertCmd.Parameters.AddWithValue("@FirstName", firstName);
                        insertCmd.Parameters.AddWithValue("@LastName", lastName);
                        insertCmd.Parameters.AddWithValue("@Email", email);
                        insertCmd.Parameters.AddWithValue("@Username", username);
                        insertCmd.Parameters.AddWithValue("@Password", password);

                        int rowsAffected = insertCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            long newUserId = insertCmd.LastInsertedId;
                            string insertRoleQuery = "INSERT INTO user_roles (UserID, RoleID) VALUES (@UserID, @RoleID)";

                            using (MySqlCommand roleCmd = new MySqlCommand(insertRoleQuery, conn))
                            {
                                roleCmd.Parameters.AddWithValue("@UserID", newUserId);
                                roleCmd.Parameters.AddWithValue("@RoleID", 1); // 1 represents the "Customer" role

                                int roleRowsAffected = roleCmd.ExecuteNonQuery();
                                if (roleRowsAffected > 0)
                                {
                                    lblMessage.ForeColor = System.Drawing.Color.Green;
                                    lblMessage.Text = "Registration successful! You can now log in.";
                                    Response.Redirect("~/Login.aspx");
                                }
                                else
                                {
                                    lblMessage.Text = "Error assigning role to user. Please try again.";
                                }
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Registration failed. Please try again.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred during registration." + ex.Message;
            }
        }
    }
}