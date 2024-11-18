using MySql.Data.MySqlClient;
using System;
using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Data;
using System.Web.Configuration;
using System.Web.UI;
using System.Collections.Generic;
using System.Data.SqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using Newtonsoft.Json;
using System.Web.UI.WebControls;
using Mysqlx.Crud;
using ZstdSharp.Unsafe;
using System.Text.RegularExpressions;

//I made some changes to the code, if you can see this that means you can see all the changes I made
namespace COSCPFWA
{

    public partial class DataReportRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* if (!IsPostBack)
            {
                PopulateOrderByDropdown();
            } */
        }

        // Event handler for Generate Chart button
        /* protected void btnGenerateChart_Click(object sender, EventArgs e)
        {
            GenerateChart();
        } */

        /* private void PopulateOrderByDropdown()
        {
            orderByDropdown.Items.Add(new ListItem(erID", "CustomerID"));
        } */
        /*
        private void GenerateChart()
        {
            //Attaches the HTML form values to temporary varaibles
            string typeReport = reportType.SelectedValue;

            //Customer Vriables
            string firstName = customerFirstName.Text;
            string lastName = customerLastName.Text;
            string table = reportType.SelectedValue;
            string type = packageType.SelectedValue;
            string dateFrom = activityDateFrom.Text;
            string dateTo = activityDateTo.Text;

            //Retrieves user selection for the graph's x & y axis
            string xAxisSelected = xAxis.SelectedValue;
            string yAxisSelected = yAxis.SelectedValue;

            //This stores query results to a chart
            List<string> labels = new List<string>();
            List<int> values = new List<int>();

            string connString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            string chartQuery = "";

            if (typeReport == "Customer")
            {
                chartQuery = @"SELECT p.ServiceType, COUNT(p.PackageID) AS NumPackages
                                    FROM package as p
                                    JOIN customer as c ON p.CustomerID = c.CustomerID
                                    LEFT JOIN shippingdetails as sd ON sd.PackageID = p.PackageID
                                    LEFT JOIN package_to_locker as pl ON pl.PackageID = p.PackageID
                                    LEFT JOIN pickupdetails as pd ON pd.PackageID = p.PackageID
                                    WHERE 1=1";
            }
            else if (typeReport == "Employee")
            {
                chartQuery = @"SELECT p.ServiceType, COUNT(p.PackageID) AS NumPackages
                                    FROM package as p
                                    JOIN customer as c ON p.CustomerID = c.CustomerID
                                    LEFT JOIN shippingdetails as sd ON sd.PackageID = p.PackageID
                                    LEFT JOIN package_to_locker AS plON pl.PackageID = p.PackageID
                                    LEFT JOIN pickupdetails as pd ON pd.PackageID = p.PackageID
                                    WHERE 1=1";
            }

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                //Figure dynamic query queue
//X = Servicetype ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------                
             

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;


                    //Add parameters later
                    if (!string.IsNullOrEmpty(type))
                    {
                        chartQuery+= " AND p.ServiceType = @PackageType";
                        cmd.Parameters.AddWithValue("@PackageType", type);
                    }

                    if (!string.IsNullOrEmpty(firstName))
                    {
                        chartQuery+= " AND c.FirstName = @CustomerFirstName";
                        cmd.Parameters.AddWithValue("@CustomerFirstName", firstName);
                    }

                    if (!string.IsNullOrEmpty(lastName))
                    {
                        chartQuery+= " AND c.LastName = @CustomerLastName";
                        cmd.Parameters.AddWithValue("@CustomerLastName", lastName);
                    }

                    if (!string.IsNullOrEmpty(dateFrom) && !string.IsNullOrEmpty(dateTo))
                    {
                        chartQuery+= " AND p.CreatedAt > @FromDate";
                        chartQuery+= " AND p.CreatedAt < @ToDate";
                        cmd.Parameters.AddWithValue("@FromDate", dateFrom);
                        cmd.Parameters.AddWithValue("ToDate", dateTo);
                    }

                    chartQuery+= " GROUP BY p.ServiceType";
                    cmd.CommandText = chartQuery;
                    //System.Diagnostics.Debug.WriteLine("Final Query: " + query);

                    //Executes query
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            labels.Add(reader["ServiceType"].ToString());
                            values.Add(int.Parse(reader["NumPackages"].ToString()));
                        }
                    }
                }
            }
//Create separate chart for X=CustomerName & Y=# of packages

            // Convert chart data to JSON format for rendering in JavaScript
            var jsonData = new
            {
                labels = labels,
                values = values
            };
            chartData.Value = JsonConvert.SerializeObject(jsonData); // Set JSON data for hidden field
        } */

        protected void ViewReport_Click(object sender, EventArgs e)
        {
            //Report Type
            string typeReport = reportType.SelectedValue;
            string X_Axis = xAxis.SelectedValue;

            //Needed Customer Variables
            string firstName = customerFirstName.Text;
            string lastName = customerLastName.Text;
            string table = reportType.SelectedValue;
            string type = packageType.SelectedValue;
            string dateFrom = activityDateFrom.Text;
            string dateTo = activityDateTo.Text;
            string additionalEntries = additionalCustomer.Text.Trim();

            //Employee Variables
            string EmployeeName = employeeName.Text;
            int? Department = string.IsNullOrEmpty(departmentInput.SelectedValue) ? (int?)null : int.Parse(departmentInput.SelectedValue); //From stack overflow
            string AdditionalEmployees = additionalEmployees.Text.Trim();

            //Financial Variables
            string QuantitativeValue = valueMeasure.SelectedValue;
            string OrganizedBy = by.SelectedValue;

            //Stuff from graph function
            List<string> labels = new List<string>();
            List<int> values = new List<int>();

            //FIxed connection string
            string connString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            string chartQuery = "";
            string reportQuery = "";

            if (typeReport == "Customer")
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    try
                    {
                        conn.Open();


                        reportQuery = @"SELECT c.FirstName, c.LastName, c.CustomerID, p.PackageID, p.ServiceType, p.CreatedAt
                                                FROM package AS p
                                                 JOIN customer AS c ON p.CustomerID = c.CustomerID
                                                LEFT JOIN shippingdetails AS sd ON sd.PackageID = p.PackageID
                                                LEFT JOIN package_to_locker AS pl ON pl.PackageID = p.PackageID
                                                LEFT JOIN pickupdetails AS pd ON pd.PackageID = p.PackageID
                                                WHERE 1=1";

                        if (X_Axis == "ServiceType")
                        {
                            chartQuery = @"SELECT p.ServiceType, COUNT(p.PackageID) AS NumPackages
                                            FROM package AS p
                                            JOIN customer AS c ON p.CustomerID = c.CustomerID
                                            WHERE 1=1";
                        }
                        else if (X_Axis == "Name")
                        {
                            chartQuery = @"SELECT CONCAT(c.FirstName, ' ' , c.LastName) AS Name , COUNT(p.PackageID) AS NumPackages
                                            FROM package AS p
                                            JOIN customer AS c ON p.CustomerID = c.CustomerID
                                            WHERE 1=1";
                        }


                        using (MySqlCommand gridViewCmd = new MySqlCommand())
                        using (MySqlCommand chartCmd = new MySqlCommand())
                        {
                            gridViewCmd.Connection = conn;
                            chartCmd.Connection = conn;

                            //Try to find a way to add additional people
                            List<string> pplQuery = new List<string>();
                            //Try to find a way to add additional people

                            if (!string.IsNullOrEmpty(firstName))
                            {
                                reportQuery += " AND (c.FirstName = @CustomerFirstName";
                                chartQuery += " AND (c.FirstName = @CustomerFirstName";


                                gridViewCmd.Parameters.AddWithValue("@CustomerFirstName", firstName);
                                chartCmd.Parameters.AddWithValue("@CustomerFirstName", firstName);
                            }
                            if (!string.IsNullOrEmpty(lastName))
                            {
                                reportQuery += " AND c.LastName = @CustomerLastName)";
                                chartQuery += " AND c.LastName = @CustomerLastName)";


                                gridViewCmd.Parameters.AddWithValue("@CustomerLastName", lastName);
                                chartCmd.Parameters.AddWithValue("@CustomerLastName", lastName);

                            }


                            if (!string.IsNullOrEmpty(additionalEntries))
                            {
                                string[] customerNames = additionalEntries.Split(',');
                                for (int i = 0; i < customerNames.Length; i++)
                                {
                                    string[] nameParts = customerNames[i].Trim().Split(' ');
                                    if (nameParts.Length == 2)
                                    {
                                        string firstParam = $"@AdditionalCustomerFirst{i}";
                                        string lastParam = $"@AdditionalCustomerLast{i}";
                                        pplQuery.Add($"c.FirstName = {firstParam} AND c.LastName = {lastParam}");
                                        //pplQuery.Add($"(c.FirstName = {firstParam} AND c.LastName = {lastParam})");
                                        gridViewCmd.Parameters.AddWithValue($"@{firstParam}", nameParts[0]);
                                        gridViewCmd.Parameters.AddWithValue($"@{lastParam}", nameParts[1]);
                                        chartCmd.Parameters.AddWithValue($"@{firstParam}", nameParts[0]);
                                        chartCmd.Parameters.AddWithValue($"@{lastParam}", nameParts[1]);
                                    }
                                }
                            }

                            if (pplQuery.Count > 0)
                            {
                                string combinedNames = string.Join(" OR ", pplQuery);
                                reportQuery += $" OR ({combinedNames})";
                                chartQuery += $" OR ({combinedNames})";
                                System.Diagnostics.Debug.WriteLine($"Combined Names: {combinedNames}");

                            }



                            if (!string.IsNullOrEmpty(type))
                            {
                                reportQuery += " AND p.ServiceType = @PackageType";
                                chartQuery += " AND p.ServiceType = @PackageType";

                                gridViewCmd.Parameters.AddWithValue("@PackageType", type);
                                chartCmd.Parameters.AddWithValue("@PackageType", type);


                            }



                            if (!string.IsNullOrEmpty(dateFrom) && !string.IsNullOrEmpty(dateTo))
                            {
                                reportQuery += " AND p.CreatedAt >= @FromDate AND p.CreatedAt <= @ToDate";
                                chartQuery += " AND p.CreatedAt >= @FromDate AND p.CreatedAt <= @ToDate";


                                gridViewCmd.Parameters.AddWithValue("@FromDate", dateFrom);
                                gridViewCmd.Parameters.AddWithValue("@ToDate", dateTo);
                                chartCmd.Parameters.AddWithValue("@FromDate", dateFrom);
                                chartCmd.Parameters.AddWithValue("@ToDate", dateTo);
                            }








                            gridViewCmd.CommandText = reportQuery;
                            System.Diagnostics.Debug.WriteLine("Final Report Query: " + reportQuery);




                            //ADD CHART STUF---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                            if (X_Axis == "ServiceType")
                            {
                                chartQuery += " GROUP BY p.ServiceType";
                            }
                            else if (X_Axis == "Name")
                            {
                                chartQuery += " GROUP BY c.CustomerID";
                            }
                            //chartQuery += " GROUP BY p.ServiceType";
                            chartCmd.CommandText = chartQuery;
                            System.Diagnostics.Debug.WriteLine("Final Chart Query: " + chartQuery);

                            // Execute GridView query
                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(gridViewCmd))
                            {
                                DataTable report = new DataTable();
                                adapter.Fill(report);


                                ResultGrid.DataSource = report;
                                ResultGrid.DataBind();
                            }

                            // Executing Chart query
                            using (MySqlDataReader reader = chartCmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    labels.Add(reader[X_Axis].ToString());
                                    values.Add(reader["NumPackages"] != DBNull.Value ? Convert.ToInt32(reader["NumPackages"]) : 0);

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Failed to retrieve data: " + ex.Message + "');</script>");
                    }
                }

                // Handle case when no data is returned for chart
                if (labels.Count == 0 || values.Count == 0)
                {
                    labels.Add("No Data");
                    values.Add(0);
                }

                // Generate JSON for chart
                var jsonData = new
                {
                    labels = labels,
                    values = values
                };
                chartData.Value = JsonConvert.SerializeObject(jsonData);
            }
            //CREATE EMPLOYE REPORT -----------------------------------------------------------------------------------------------------------------------------------------------------------------
            else if (typeReport == "Employee")
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    try
                    {
                        conn.Open();


                        reportQuery = @"SELECT e.Name, e.EmployeeID, e.DepartmentNum , p.PackageID, p.ServiceType, p.CreatedAt
                                                FROM package AS p
                                                JOIN employee AS e ON p.EmployeeID = e.EmployeeID
                                                LEFT JOIN customer AS c ON p.CustomerID = c.CustomerID
                                                LEFT JOIN shippingdetails AS sd ON sd.PackageID = p.PackageID
                                                LEFT JOIN package_to_locker AS pl ON pl.PackageID = p.PackageID
                                                LEFT JOIN departments AS d ON d.DepartmentNum = e.DepartmentNum
                                                LEFT JOIN pickupdetails AS pd ON pd.PackageID = p.PackageID
                                                WHERE 1=1";

                        if (X_Axis == "ServiceType")
                        {
                            chartQuery = @"SELECT p.ServiceType, COUNT(p.PackageID) AS NumPackages
                                            FROM package AS p
                                            JOIN employee as e on p.EmployeeId = e.EmployeeID
                                            WHERE 1=1";



                        }
                        else if (X_Axis == "Name")
                        {
                            chartQuery = @"SELECT e.Name, e.DepartmentNum, COUNT(p.PackageID) AS NumPackages
                                            FROM package AS p
                                            JOIN employee as e ON p.EmployeeID = e.EmployeeID
                                            WHERE 1=1";
                        }


                        using (MySqlCommand gridViewCmd = new MySqlCommand())
                        using (MySqlCommand chartCmd = new MySqlCommand())
                        {
                            gridViewCmd.Connection = conn;
                            chartCmd.Connection = conn;

                            List<string> employeeList = new List<string>();




                            if (!string.IsNullOrEmpty(EmployeeName))
                            {
                                reportQuery += " AND e.Name = @EmployeeName";
                                chartQuery += " AND e.Name = @EmployeeName";


                                gridViewCmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                                chartCmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                            }



                            if (!string.IsNullOrEmpty(AdditionalEmployees))
                            {
                                string[] employeeNames = AdditionalEmployees.Split(',');
                                for (int i = 0; i < employeeNames.Length; i++)
                                {
                                    string employeeParam = $"@AdditionalEmployeeName{i}";
                                    employeeList.Add($"e.Name = {employeeParam}");
                                    gridViewCmd.Parameters.AddWithValue(employeeParam, employeeNames[i].Trim());
                                    chartCmd.Parameters.AddWithValue(employeeParam, employeeNames[i].Trim());
                                }
                            }

                            // Combine conditions
                            if (employeeList.Count > 0)
                            {
                                string combinedConditions = string.Join(" OR ", employeeList);
                                reportQuery += $" OR ({combinedConditions})";
                                chartQuery += $" OR ({combinedConditions})";
                            }

                            if (!string.IsNullOrEmpty(type))
                            {
                                reportQuery += " AND p.ServiceType = @PackageType";
                                chartQuery += " AND p.ServiceType = @PackageType";

                                gridViewCmd.Parameters.AddWithValue("@PackageType", type);
                                chartCmd.Parameters.AddWithValue("@PackageType", type);


                            }

                            if (Department.HasValue)
                            {
                                reportQuery += " AND e.DepartmentNum = @DepartmentNum";
                                chartQuery += " AND e.DepartmentNum = @DepartmentNum";

                                gridViewCmd.Parameters.AddWithValue("@DepartmentNum", Department);
                                chartCmd.Parameters.AddWithValue("@DepartmentNum", Department);
                            }


                            if (!string.IsNullOrEmpty(dateFrom) && !string.IsNullOrEmpty(dateTo))
                            {
                                reportQuery += " AND p.CreatedAt >= @FromDate AND p.CreatedAt <= @ToDate";
                                chartQuery += " AND p.CreatedAt >= @FromDate AND p.CreatedAt <= @ToDate";


                                gridViewCmd.Parameters.AddWithValue("@FromDate", dateFrom);
                                gridViewCmd.Parameters.AddWithValue("@ToDate", dateTo);



                                chartCmd.Parameters.AddWithValue("@FromDate", dateFrom);
                                chartCmd.Parameters.AddWithValue("@ToDate", dateTo);
                            }

                            gridViewCmd.CommandText = reportQuery;
                            System.Diagnostics.Debug.WriteLine("Final Report Query: " + reportQuery);





                            if (X_Axis == "ServiceType")
                            {
                                chartQuery += " GROUP BY p.ServiceType";
                            }
                            else if (X_Axis == "Name")
                            {
                                chartQuery += " GROUP BY e.EmployeeID";
                            }
                            //chartQuery += " GROUP BY p.ServiceType";
                            chartCmd.CommandText = chartQuery;
                            System.Diagnostics.Debug.WriteLine("Final Chart Query: " + chartQuery);

                            // Execute GridView query
                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(gridViewCmd))
                            {
                                DataTable report = new DataTable();
                                adapter.Fill(report);


                                ResultGrid.DataSource = report;
                                ResultGrid.DataBind();
                            }

                            // Executing Chart query
                            using (MySqlDataReader reader = chartCmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    labels.Add(reader[X_Axis].ToString());
                                    values.Add(Convert.ToInt32(reader["NumPackages"]));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Failed to retrieve data: " + ex.Message + "');</script>");
                    }
                }

                // Handle case when no data is returned for chart
                if (labels.Count == 0 || values.Count == 0)
                {
                    labels.Add("No Data");
                    values.Add(0);
                }

                // Generate JSON for chart
                var jsonData = new
                {
                    labels = labels,
                    values = values
                };
                chartData.Value = JsonConvert.SerializeObject(jsonData);
            }
            //FINANCIAL REPOOOOORRRRRRTTTTT
            else if (typeReport == "Financial")
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    try
                    {
                        conn.Open();



                        if (QuantitativeValue == "Revenue" && OrganizedBy == "Service")
                        {
                            chartQuery = @"SELECT p.ServiceType, SUM(p.Base_Price) AS MoneyMade
                                            FROM package AS p
                                            JOIN employee as e on p.EmployeeId = e.EmployeeID
                                            WHERE 1=1
                                            GROUP BY p.ServiceType";

                            reportQuery = @"SELECT p.ServiceType, SUM(p.Base_Price) AS MoneyMade
                                            FROM package AS p
                                            JOIN employee as e on p.EmployeeId = e.EmployeeID
                                            WHERE 1=1
                                            GROUP BY p.ServiceType";
                        }
                        else if (QuantitativeValue == "Revenue" && OrganizedBy == "Department")
                        {

                            chartQuery = @"SELECT d.DepartmentName, d.DepartmentNum, SUM(p.Base_Price) AS MoneyMade
                                            FROM package AS p
                                            JOIN employee AS e ON p.EmployeeId = e.EmployeeID
                                            LEFT JOIN departments AS d ON e.DepartmentNum = d.DepartmentNum
                                            WHERE 1=1
                                            GROUP BY d.DepartmentNum, d.DepartmentName";

                            reportQuery = @"SELECT d.DepartmentName, d.DepartmentNum, SUM(p.Base_Price) AS MoneyMade
                                            FROM package AS p
                                            JOIN employee AS e ON p.EmployeeId = e.EmployeeID
                                            LEFT JOIN departments AS d ON e.DepartmentNum = d.DepartmentNum
                                            WHERE 1=1
                                            GROUP BY d.DepartmentNum, d.DepartmentName";
                        }
                        else if (QuantitativeValue == "Revenue" && OrganizedBy == "Employee")
                        {
                            chartQuery = @"SELECT e.Name, e.DepartmentNum, SUM(Base_Price) AS MoneyMade
                                            FROM package AS p
                                            JOIN employee as e ON p.EmployeeID = e.EmployeeID
                                            WHERE 1=1
                                            GROUP BY e.EmployeeID";

                            reportQuery = @"SELECT e.Name, e.DepartmentNum, SUM(Base_Price) AS MoneyMade
                                            FROM package AS p
                                            JOIN employee as e ON p.EmployeeID = e.EmployeeID
                                            WHERE 1=1
                                            GROUP BY e.EmployeeID";
                        }


                        using (MySqlCommand gridViewCmd = new MySqlCommand())
                        using (MySqlCommand chartCmd = new MySqlCommand())
                        {
                            gridViewCmd.Connection = conn;
                            chartCmd.Connection = conn;



                            if (!string.IsNullOrEmpty(firstName))
                            {
                                reportQuery += " (AND c.FirstName = @CustomerFirstName";
                                chartQuery += " AND c.FirstName = @CustomerFirstName)";


                            }







                            gridViewCmd.CommandText = reportQuery;
                            System.Diagnostics.Debug.WriteLine("Final Report Query: " + reportQuery);




                            //ADD CHART STUF---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                            //chartQuery += " GROUP BY p.ServiceType";
                            chartCmd.CommandText = chartQuery;
                            System.Diagnostics.Debug.WriteLine("Final Chart Query: " + chartQuery);

                            // Execute GridView query
                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(gridViewCmd))
                            {
                                DataTable report = new DataTable();
                                adapter.Fill(report);


                                ResultGrid.DataSource = report;
                                ResultGrid.DataBind();
                            }

                            // Executing Chart query
                            using (MySqlDataReader reader = chartCmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    labels.Add(QuantitativeValue.ToString());
                                    values.Add(Convert.ToInt32(reader["MoneyMade"]));  //Edit later
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Failed to retrieve data: " + ex.Message + "');</script>");
                    }
                }

                // Handle case when no data is returned for chart
                if (labels.Count == 0 || values.Count == 0)
                {
                    labels.Add("No Data");
                    values.Add(0);
                }

                // Generate JSON for chart
                var jsonData = new
                {
                    labels = labels,
                    values = values
                };
                chartData.Value = JsonConvert.SerializeObject(jsonData);
            }

        }
    }
}
