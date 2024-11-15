using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COSCPFWA
{
    public partial class CheckPackages : System.Web.UI.Page
    {
        protected void CheckPackagesButton_Click(object sender, EventArgs e)
        {
            string employeeID = EmployeeIDTextBox.Text;
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"]?.ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "SELECT * FROM package WHERE EmployeeID = @EmployeeID";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                DataTable dt = new DataTable();
                da.Fill(dt);
                PackagesGridView.DataSource = dt;
                PackagesGridView.DataBind();
            }
        }

        protected void PackagesGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            PackagesGridView.EditIndex = e.NewEditIndex;
            CheckPackagesButton_Click(sender, e); // Refresh GridView
        }

        protected void PackagesGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int packageID = Convert.ToInt32(PackagesGridView.DataKeys[e.RowIndex].Value.ToString());
            string employeeID = ((TextBox)PackagesGridView.Rows[e.RowIndex].FindControl("EmployeeIDTextBox")).Text;
            string contents = ((TextBox)PackagesGridView.Rows[e.RowIndex].FindControl("ContentsTextBox")).Text;
            string weight_lbs = ((TextBox)PackagesGridView.Rows[e.RowIndex].FindControl("Weight_lbsTextBox")).Text;
            string serviceType = ((TextBox)PackagesGridView.Rows[e.RowIndex].FindControl("ServiceTypeTextBox")).Text;
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"]?.ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "UPDATE package SET EmployeeID=@EmployeeID, Contents=@Contents, Weight_lbs=@Weight_lbs, ServiceType=@ServiceType WHERE PackageID=@PackageID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PackageID", packageID);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                cmd.Parameters.AddWithValue("@Contents", contents);
                cmd.Parameters.AddWithValue("@Weight_lbs", weight_lbs);
                cmd.Parameters.AddWithValue("@ServiceType", serviceType);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                PackagesGridView.EditIndex = -1;
                CheckPackagesButton_Click(sender, e); // Refresh GridView
            }
        }

        protected void PackagesGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int packageID = Convert.ToInt32(PackagesGridView.DataKeys[e.RowIndex].Value.ToString());
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"]?.ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "DELETE FROM package WHERE PackageID = @PackageID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PackageID", packageID);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                CheckPackagesButton_Click(sender, e); // Refresh GridView
            }
        }

        protected void PackagesGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            PackagesGridView.EditIndex = -1;
            CheckPackagesButton_Click(sender, e); // Refresh GridView
        }

        private void AddClientConfirmation()
        {
            foreach (GridViewRow row in PackagesGridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    foreach (TableCell cell in row.Cells)
                    {
                        foreach (Control control in cell.Controls)
                        {
                            if (control is Button button)
                            {
                                if (button.CommandName == "Delete")
                                {
                                    button.OnClientClick = "return confirmDelete();";
                                }
                                else if (button.CommandName == "Edit")
                                {
                                    button.OnClientClick = "return confirmEdit();";
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
