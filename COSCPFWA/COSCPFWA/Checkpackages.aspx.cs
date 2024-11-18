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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["RoleName"] != null && Session["RoleName"].ToString() == "Employee")
                {
                    if (Session["EmployeeID"] != null)
                    {
                        LoadPackagesForEmployee(Session["EmployeeID"].ToString());
                    }
                    else
                    {
                        Response.Redirect("~/Error.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Unauthorized.aspx");
                }
            }
        }
        private void LoadPackagesForEmployee(string employeeId)
        {
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"]?.ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "SELECT PackageID, EmployeeID, CurrentStatus, Contents, ServiceType, CreatedAt, DATE_ADD(CreatedAt, INTERVAL FLOOR(1 + (RAND() * 15)) DAY) AS ExpectedDeliveryDate FROM package WHERE EmployeeID = @EmployeeID";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@EmployeeID", employeeId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                PackagesGridView.DataSource = dt;
                PackagesGridView.DataBind();
            }
        }

        protected void PackagesGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            PackagesGridView.EditIndex = e.NewEditIndex;
            ReloadPackages(); // Refresh GridView
        }

        protected void PackagesGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int packageID = Convert.ToInt32(PackagesGridView.DataKeys[e.RowIndex].Value.ToString());
            string employeeID = ((Label)PackagesGridView.Rows[e.RowIndex].FindControl("LabelEmployeeID")).Text;
            var contentsTextBox = (TextBox)PackagesGridView.Rows[e.RowIndex].FindControl("ContentsTextBox");
            if (contentsTextBox == null) throw new Exception("ContentsTextBox not found.");
            string contents = contentsTextBox.Text;
            string serviceType = ((TextBox)PackagesGridView.Rows[e.RowIndex].FindControl("ServiceTypeTextBox")).Text;
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"]?.ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "UPDATE package SET EmployeeID=@EmployeeID, Contents=@Contents, ServiceType=@ServiceType WHERE PackageID=@PackageID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PackageID", packageID);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                cmd.Parameters.AddWithValue("@Contents", contents);
                cmd.Parameters.AddWithValue("@ServiceType", serviceType);

                System.Diagnostics.Debug.WriteLine("Query: " + cmd.CommandText);
                foreach (MySqlParameter param in cmd.Parameters)
                {
                    System.Diagnostics.Debug.WriteLine($"{param.ParameterName}: {param.Value}");
                }

                System.Diagnostics.Debug.WriteLine($"PackageID: {PackagesGridView.DataKeys[e.RowIndex].Value}");

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                PackagesGridView.EditIndex = -1;
                ReloadPackages(); // Refresh GridView
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

                ReloadPackages(); // Refresh GridView
            }
        }

        protected void PackagesGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            PackagesGridView.EditIndex = -1;
            ReloadPackages(); // Refresh GridView
        }

        private void ReloadPackages()
        {
            if (Session["EmployeeID"] != null)
            {
                LoadPackagesForEmployee(Session["EmployeeID"].ToString());
            }
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
