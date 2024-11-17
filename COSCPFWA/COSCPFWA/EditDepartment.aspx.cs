using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COSCPFWA
{
    public partial class EditDepartment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllDepartments();
            }
        }

        protected void LoadAllDepartmentsButton_Click(object sender, EventArgs e)
        {
            LoadAllDepartments();
        }

        private void LoadAllDepartments()
        {
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"]?.ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "SELECT * FROM department";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DepartmentGridView.DataSource = dt;
                DepartmentGridView.DataBind();
            }
        }

        protected void DepartmentGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DepartmentGridView.EditIndex = e.NewEditIndex;
            LoadAllDepartments(); 
        }

        protected void DepartmentGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string departmentNum = DepartmentGridView.DataKeys[e.RowIndex].Value.ToString();
            GridViewRow row = DepartmentGridView.Rows[e.RowIndex];
            string departmentName = ((TextBox)row.Cells[1].Controls[0]).Text;
            string managerID = ((TextBox)row.Cells[2].Controls[0]).Text;
            string managerStart = ((TextBox)row.Cells[3].Controls[0]).Text;
            string numOfEmployees = ((TextBox)row.Cells[4].Controls[0]).Text;
            string postOfficeID = ((TextBox)row.Cells[5].Controls[0]).Text;

            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"]?.ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "UPDATE department SET DepartmentName=@DepartmentName, ManagerID=@ManagerID, ManagerStart=@ManagerStart, NumOfEmployees=@NumOfEmployees, PostOfficeID=@PostOfficeID WHERE DepartmentNum=@DepartmentNum";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DepartmentName", departmentName);
                cmd.Parameters.AddWithValue("@ManagerID", managerID);
                cmd.Parameters.AddWithValue("@ManagerStart", managerStart);
                cmd.Parameters.AddWithValue("@NumOfEmployees", numOfEmployees);
                cmd.Parameters.AddWithValue("@PostOfficeID", postOfficeID);
                cmd.Parameters.AddWithValue("@DepartmentNum", departmentNum);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                DepartmentGridView.EditIndex = -1;
                LoadAllDepartments();
            }
        }

        protected void DepartmentGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string departmentNum = DepartmentGridView.DataKeys[e.RowIndex].Value.ToString();
            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"]?.ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "DELETE FROM department WHERE DepartmentNum = @DepartmentNum";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DepartmentNum", departmentNum);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                LoadAllDepartments(); 
            }
        }

        protected void DepartmentGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DepartmentGridView.EditIndex = -1;
            LoadAllDepartments(); 
        }
    }
}
