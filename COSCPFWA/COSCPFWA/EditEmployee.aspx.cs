using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COSCPFWA
{
    public partial class EditEmployee : System.Web.UI.Page
    {
        protected void CheckEmployeeButton_Click(object sender, EventArgs e)
        {
            string employeeID = EmployeeIDTextBox.Text;
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"]?.ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "SELECT * FROM employee WHERE EmployeeID = @EmployeeID";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                DataTable dt = new DataTable();
                da.Fill(dt);
                EmployeeGridView.DataSource = dt;
                EmployeeGridView.DataBind();
            }
        }

        protected void EmployeeGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            EmployeeGridView.EditIndex = e.NewEditIndex;
            CheckEmployeeButton_Click(sender, e);
        }

        protected void EmployeeGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string employeeID = EmployeeGridView.DataKeys[e.RowIndex].Value.ToString();
            GridViewRow row = EmployeeGridView.Rows[e.RowIndex];
            string email = ((TextBox)row.Cells[1].Controls[0]).Text;
            string address = ((TextBox)row.Cells[2].Controls[0]).Text;
            string role = ((TextBox)row.Cells[3].Controls[0]).Text;
            string salary = ((TextBox)row.Cells[4].Controls[0]).Text;
            string hoursWorked = ((TextBox)row.Cells[5].Controls[0]).Text;
            string incidentCount = ((TextBox)row.Cells[6].Controls[0]).Text;
            string packagesDelivered = ((TextBox)row.Cells[7].Controls[0]).Text;
            string hourlyDeliveryRate = ((TextBox)row.Cells[8].Controls[0]).Text;
            string managerID = ((TextBox)row.Cells[9].Controls[0]).Text;

            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"]?.ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    string query = "UPDATE employee SET Email=@Email, Address=@Address, Role=@Role, Salary=@Salary, HoursWorked=@HoursWorked, IncidentCount=@IncidentCount, PackagesDelivered=@PackagesDelivered, HourlyDeliveryRate=@HourlyDeliveryRate, ManagerID=@ManagerID WHERE EmployeeID=@EmployeeID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@Salary", salary);
                    cmd.Parameters.AddWithValue("@HoursWorked", hoursWorked);
                    cmd.Parameters.AddWithValue("@IncidentCount", incidentCount);
                    cmd.Parameters.AddWithValue("@PackagesDelivered", packagesDelivered);
                    cmd.Parameters.AddWithValue("@HourlyDeliveryRate", hourlyDeliveryRate);
                    cmd.Parameters.AddWithValue("@ManagerID", managerID);
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    EmployeeGridView.EditIndex = -1;
                    CheckEmployeeButton_Click(sender, e);
                    ErrorMessageLabel.Visible = false; //Use the notification template for error message
                }
            }
            catch (MySqlException ex)
            {
                SalaryTrigger(ex);
            }
        }

        protected void EmployeeGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string employeeID = EmployeeGridView.DataKeys[e.RowIndex].Value.ToString();
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"]?.ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    string query = "DELETE FROM employee WHERE EmployeeID = @EmployeeID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    CheckEmployeeButton_Click(sender, e);
                }
            }
            catch (MySqlException ex)
            {
                SalaryTrigger(ex);
            }
        }

        protected void EmployeeGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            EmployeeGridView.EditIndex = -1;
            CheckEmployeeButton_Click(sender, e);
        }

        private void SalaryTrigger(MySqlException ex)
        {
            if (ex.Number == 1644)
            {
                ErrorMessageLabel.Text =  ex.Message;
            }
            else
            {
                ErrorMessageLabel.Text = "Damn we did not prepare for this" + ex.Message;
            }
            ErrorMessageLabel.Visible = true;
        }
    }
}
