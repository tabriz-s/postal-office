using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace COSCPFWA
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string userId = Session["UserID"]?.ToString();
            if (string.IsNullOrEmpty(userId))
            {
                lblMessage.Text = "Unable to update credentials. Please log in.";
                lblMessage.CssClass = "alert alert-danger";
                lblMessage.Visible = true;
                return;
            }

            string currentPassword = txtCurrentPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            string newUsername = txtUsername.Text.Trim();

            if (newPassword != confirmPassword)
            {
                lblMessage.Text = "New passwords do not match.";
                lblMessage.CssClass = "alert alert-warning";
                lblMessage.Visible = true;
                return;
            }

            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                string checkPasswordQuery = "SELECT Password FROM user_logins WHERE UserID = @UserID";
                MySqlCommand checkPasswordCmd = new MySqlCommand(checkPasswordQuery, conn);
                checkPasswordCmd.Parameters.AddWithValue("@UserID", userId);
                string storedPassword = (string)checkPasswordCmd.ExecuteScalar();

                if (storedPassword != currentPassword)
                {
                    lblMessage.Text = "Current password is incorrect.";
                    lblMessage.CssClass = "alert alert-danger";
                    lblMessage.Visible = true;
                    return;
                }

                string updateQuery = "UPDATE user_logins SET Username = @Username, Password = @Password WHERE UserID = @UserID";
                MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@Username", newUsername);
                updateCmd.Parameters.AddWithValue("@Password", newPassword);
                updateCmd.Parameters.AddWithValue("@UserID", userId);

                try
                {
                    updateCmd.ExecuteNonQuery();
                    lblMessage.Text = "Credentials updated successfully!";
                    lblMessage.CssClass = "alert alert-success";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error updating credentials: " + ex.Message;
                    lblMessage.CssClass = "alert alert-danger";
                }
                lblMessage.Visible = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CustomerDashboard.aspx");
        }
    }
}