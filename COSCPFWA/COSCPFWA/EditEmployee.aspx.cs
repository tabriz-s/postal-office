using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace COSCPFWA
{
    public partial class EditEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            //debugging flag
            Response.Write("<script>alert('Debugging');</script>");

            string connString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            string employeeID = Request.Form["employeeID"];
            string salary = Request.Form["salary"];

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE employee SET Salary = @Salary WHERE EmployeeID = @EmployeeID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Salary", salary);
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                        //executed command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Response.Write("<script>alert('Done.');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('No matching EmployeeID found.');</script>");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    //catch block error
                    Response.Write("<script>alert('MySQL Error: " + ex.Message.Replace("'", "\\'") + "');</script>");
                }
                catch (Exception ex)
                {
                    //general error
                    Response.Write("<script>alert('An error occurred: " + ex.Message.Replace("'", "\\'") + "');</script>");
                }
            }
        }
    }
}
