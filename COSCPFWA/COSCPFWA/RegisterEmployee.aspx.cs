using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace COSCPFWA
{
    public partial class RegisterEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Get user inputs
            string name = txtName.Text;
            string departmentNum = txtDepartmentNum.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;
            string role = txtRole.Text;
            string salary = txtSalary.Text;
            string managerID = txtManagerID.Text;
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            string employeeId = txtEmployeeID.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(departmentNum) || string.IsNullOrEmpty(phoneNumber) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(role) ||
                string.IsNullOrEmpty(salary) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
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
                        string insertUserQuery = "INSERT INTO user_logins (Username, Password, Email) VALUES (@Username, @Password, @Email)";
                        long newUserId;
                        MySqlCommand userCmd = new MySqlCommand(insertUserQuery, conn, transaction);
                        userCmd.Parameters.AddWithValue("@Username", username);
                        userCmd.Parameters.AddWithValue("@Password", password);
                        userCmd.Parameters.AddWithValue("@Email", email);
                        userCmd.ExecuteNonQuery();
                        newUserId = userCmd.LastInsertedId;

                        string insertRoleQuery = "INSERT INTO user_roles (UserID, RoleID) VALUES (@UserID, 2)"; // RoleID 2 for "Employee"
                        MySqlCommand roleCmd = new MySqlCommand(insertRoleQuery, conn, transaction);
                        roleCmd.Parameters.AddWithValue("@UserID", newUserId);
                        roleCmd.ExecuteNonQuery();

                        string insertEmployeeQuery = @"
                            INSERT INTO employee (EmployeeID, DepartmentNum, Name, PhoneNumber, Email, Address, Role, Salary, ManagerID, UserID) 
                            VALUES (@EmployeeID, @DepartmentNum, @Name, @PhoneNumber, @Email, @Address, @Role, @Salary, @ManagerID, @UserID)";
                        MySqlCommand employeeCmd = new MySqlCommand(insertEmployeeQuery, conn, transaction);
                        employeeCmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                        employeeCmd.Parameters.AddWithValue("@DepartmentNum", departmentNum);
                        employeeCmd.Parameters.AddWithValue("@Name", name);
                        employeeCmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        employeeCmd.Parameters.AddWithValue("@Email", email);
                        employeeCmd.Parameters.AddWithValue("@Address", address);
                        employeeCmd.Parameters.AddWithValue("@Role", role);
                        employeeCmd.Parameters.AddWithValue("@Salary", salary);
                        employeeCmd.Parameters.AddWithValue("@ManagerID", string.IsNullOrEmpty(managerID) ? (object)DBNull.Value : managerID);
                        employeeCmd.Parameters.AddWithValue("@UserID", newUserId);
                        employeeCmd.ExecuteNonQuery();

                        transaction.Commit();

                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "Employee registered successfully!";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred: " + ex.Message;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }
    }
}