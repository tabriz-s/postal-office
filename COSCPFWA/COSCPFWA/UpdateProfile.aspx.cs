using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace COSCPFWA
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProfile();
            }
        }

        private void LoadProfile()
        {
            string customerId = Session["CustomerID"]?.ToString();
            if (string.IsNullOrEmpty(customerId))
            {
                lblMessage.Text = "Unable to load profile. Please log in.";
                lblMessage.CssClass = "alert alert-danger";
                lblMessage.Visible = true;
                return;
            }

            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "SELECT FirstName, LastName, Address, City, State, ZipCode, PhoneNumber, Email FROM customer WHERE CustomerID = @CustomerID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);

                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtFirstName.Text = reader["FirstName"].ToString();
                        txtLastName.Text = reader["LastName"].ToString();
                        txtAddress.Text = reader["Address"].ToString();
                        txtCity.Text = reader["City"].ToString();
                        txtState.Text = reader["State"].ToString();
                        txtZipCode.Text = reader["ZipCode"].ToString();
                        txtPhoneNumber.Text = reader["PhoneNumber"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error loading profile: " + ex.Message;
                    lblMessage.CssClass = "alert alert-danger";
                    lblMessage.Visible = true;
                }
            }
        }

        protected void EnableEditing(object sender, EventArgs e)
        {
            // Enable all textboxes for editing
            txtFirstName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            txtAddress.ReadOnly = false;
            txtCity.ReadOnly = false;
            txtState.ReadOnly = false;
            txtZipCode.ReadOnly = false;
            txtPhoneNumber.ReadOnly = false;
            txtEmail.ReadOnly = false;

            // Add a visual cue for editable fields
            txtFirstName.CssClass = "form-control w-50 border border-warning";
            txtLastName.CssClass = "form-control w-50 border border-warning";
            txtAddress.CssClass = "form-control w-50 border border-warning";
            txtCity.CssClass = "form-control w-50 border border-warning";
            txtState.CssClass = "form-control w-50 border border-warning";
            txtZipCode.CssClass = "form-control w-50 border border-warning";
            txtPhoneNumber.CssClass = "form-control w-50 border border-warning";
            txtEmail.CssClass = "form-control w-50 border border-warning";
        }

        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            string customerId = Session["CustomerID"]?.ToString();
            if (string.IsNullOrEmpty(customerId))
            {
                lblMessage.Text = "Unable to update profile. Please log in.";
                lblMessage.CssClass = "alert alert-danger";
                lblMessage.Visible = true;
                return;
            }

            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                string query = "UPDATE customer SET ";
                var fieldsToUpdate = new List<string>();
                var parameters = new List<MySqlParameter>();

                void AddFieldIfEdited(TextBox textBox, string columnName, string paramName)
                {
                    if (!textBox.ReadOnly)
                    {
                        fieldsToUpdate.Add($"{columnName} = {paramName}");
                        parameters.Add(new MySqlParameter(paramName, textBox.Text.Trim()));
                    }
                }

                AddFieldIfEdited(txtFirstName, "FirstName", "@FirstName");
                AddFieldIfEdited(txtLastName, "LastName", "@LastName");
                AddFieldIfEdited(txtAddress, "Address", "@Address");
                AddFieldIfEdited(txtCity, "City", "@City");
                AddFieldIfEdited(txtState, "State", "@State");
                AddFieldIfEdited(txtZipCode, "ZipCode", "@ZipCode");
                AddFieldIfEdited(txtPhoneNumber, "PhoneNumber", "@PhoneNumber");
                AddFieldIfEdited(txtEmail, "Email", "@Email");

                if (fieldsToUpdate.Count == 0)
                {
                    lblMessage.Text = "No changes detected.";
                    lblMessage.CssClass = "alert alert-warning";
                    lblMessage.Visible = true;
                    return;
                }

                query += string.Join(", ", fieldsToUpdate) + " WHERE CustomerID = @CustomerID";
                parameters.Add(new MySqlParameter("@CustomerID", customerId));

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters.ToArray());

                // Also update the user_logins table
                string updateUserLoginsQuery = "UPDATE user_logins SET Email = @Email, FirstName = @FirstName, LastName = @LastName WHERE UserID = (SELECT UserID FROM customer WHERE CustomerID = @CustomerID)";
                MySqlCommand userLoginsCmd = new MySqlCommand(updateUserLoginsQuery, conn);
                userLoginsCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                userLoginsCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                userLoginsCmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                userLoginsCmd.Parameters.AddWithValue("@CustomerID", customerId);


                try
                {

                    cmd.ExecuteNonQuery();
                    userLoginsCmd.ExecuteNonQuery();
                    lblMessage.Text = "Profile updated successfully!";
                    lblMessage.CssClass = "alert alert-success";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error updating profile: " + ex.Message;
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
