using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.UI;

namespace COSCPFWA
{
    public partial class RegisterCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Get user inputs
            string email = txtEmail.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            string firstName = txtFirstName.Text;
            string middleInitial = txtMiddleInitial.Text;
            string lastName = txtLastName.Text;
            string address = txtAddress.Text;
            string city = txtCity.Text;
            string state = txtState.Text;
            string zipCode = txtZipCode.Text;
            string phoneNumber = txtPhoneNumber.Text;


            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)
                || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(state) || string.IsNullOrEmpty(zipCode)
                || string.IsNullOrEmpty(phoneNumber))
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
                string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        // Check if the username or email already exists
                        string checkUserQuery = "SELECT COUNT(*) FROM user_logins WHERE Username = @Username OR Email = @Email";
                        using (MySqlCommand checkCmd = new MySqlCommand(checkUserQuery, conn, transaction))
                        {
                            checkCmd.Parameters.AddWithValue("@Username", username);
                            checkCmd.Parameters.AddWithValue("@Email", email);

                            long existingUserCount = Convert.ToInt64(checkCmd.ExecuteScalar());
                            if (existingUserCount > 0)
                            {
                                lblMessage.Text = "Username or Email already exists. Please choose another.";
                                return;
                            }
                        }

                        string insertUserQuery = @"INSERT INTO user_logins (FirstName, LastName, Email, Username, Password) 
                                               VALUES (@FirstName, @LastName, @Email, @Username, @Password)";
                        long newUserId;
                        using (MySqlCommand insertCmd = new MySqlCommand(insertUserQuery, conn, transaction))
                        {
                            insertCmd.Parameters.AddWithValue("@FirstName", firstName);
                            insertCmd.Parameters.AddWithValue("@LastName", lastName);
                            insertCmd.Parameters.AddWithValue("@Email", email);
                            insertCmd.Parameters.AddWithValue("@Username", username);
                            insertCmd.Parameters.AddWithValue("@Password", password);

                            insertCmd.ExecuteNonQuery();
                            newUserId = insertCmd.LastInsertedId;
                        }


                        // assign customer role
                        string insertRoleQuery = "INSERT INTO user_roles (UserID, RoleID) VALUES (@UserID, @RoleID)";
                        using (MySqlCommand roleCmd = new MySqlCommand(insertRoleQuery, conn, transaction))
                        {
                            roleCmd.Parameters.AddWithValue("@UserID", newUserId);
                            roleCmd.Parameters.AddWithValue("@RoleID", 1); // 1 is "Customer" 2, is "Employee", 3 is "Admin"

                            int roleRowsAffected = roleCmd.ExecuteNonQuery();
                        }
                        Session["UserID"] = newUserId;

                        // insert into customer table
                        string insertCustomerQuery = @"INSERT INTO customer (FirstName, MiddleInitial, LastName, Address, City, State, ZipCode, PhoneNumber, Email, UserID) VALUES (@FirstName, @MiddleInitial, @LastName, @Address, @City, @State, @ZipCode, @PhoneNumber, @Email, @UserID);";
                        long newCustomerId;
                        using (MySqlCommand insertCmd = new MySqlCommand(insertCustomerQuery, conn, transaction))
                        {
                            insertCmd.Parameters.AddWithValue("@FirstName", firstName);
                            insertCmd.Parameters.AddWithValue("@MiddleInitial", middleInitial);
                            insertCmd.Parameters.AddWithValue("@LastName", lastName);
                            insertCmd.Parameters.AddWithValue("@Address", address);
                            insertCmd.Parameters.AddWithValue("@City", city);
                            insertCmd.Parameters.AddWithValue("@State", state);
                            insertCmd.Parameters.AddWithValue("@ZipCode", zipCode);
                            insertCmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                            insertCmd.Parameters.AddWithValue("@Email", email);
                            insertCmd.Parameters.AddWithValue("@UserID", newUserId);
                            insertCmd.ExecuteNonQuery();

                            newCustomerId = insertCmd.LastInsertedId;
                        }

                        transaction.Commit();

                        Session["CustomerID"] = newCustomerId;
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "Registration successful! You can now log in.";
                        Response.Redirect("~/Login.aspx");

                    }

                }

            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred during registration: " + ex.Message;
            }
        }
    }
}
