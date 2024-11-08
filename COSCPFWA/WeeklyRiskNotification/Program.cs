using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Text;
using System.Configuration;

namespace COSCPFWA.Services
{
    public class WeeklyRiskNotification
    {
        static void Main()
        {
            //Sets up variables to hold database connection string & query
            //Don't use configuration only needed for html
            try
            {
            string connString = "Server=uhbaseddatabasers.mysql.database.azure.com;Port=3306;Database=test_schema;Uid=UH4;Pwd=COSC3380!;SslMode=Required;";
                
            string query = "SELECT employee.EmployeeID, employee.Name, employee.Email, employee.PhoneNumber, employee.IncidentCount FROM employee WHERE (LastUpdated >= NOW() - INTERVAL 7 DAY) AND (IncidentCount >= 5) ORDER BY LastUpdated DESC;";

            Console.WriteLine("Starting database query...");

            //This executes a MySQL query and then organize results into a table
            DataTable results = GetQueryResults(connString, query);

            if (results == null || results.Rows.Count == 0)
            {
                Console.WriteLine("No results found from the query.");
            }
            else
            {
                Console.WriteLine("Query executed successfully with data.");
            }

            string emailBody = FormatResultsAsTable(results);
            Console.WriteLine("Email body successfully");

                //Sends email
             SendEmail("rynsusername@gmail.com", "Weekly Report", emailBody);
                Console.WriteLine("Email sent successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static DataTable GetQueryResults(string connString, string query)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    Console.WriteLine("Database connection opened");
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    Console.WriteLine("Data filled into table");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetQueryResults: {ex.Message}");
            }
            return dt;
        }

        static string FormatResultsAsTable(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border>");

            sb.Append("<tr>");
            foreach (DataColumn col in dt.Columns)
            {
                sb.AppendFormat("<th>{0}</th>", col.ColumnName);
            }
            sb.AppendLine("</tr>");

            foreach (DataRow row in dt.Rows)
            {
                sb.Append("<tr>");
                foreach (var item in row.ItemArray)
                {
                    sb.AppendFormat("<td>{0}</td>", item);
                }
                sb.AppendLine("</tr>");
            }
            sb.AppendLine("</table>");
            return sb.ToString();
        }

        /* static void SendEmail(string to, string subject, string body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("rparaula@cougarnet.uh.edu");
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com", 587))
                {
                    smtp.Credentials = new System.Net.NetworkCredential("rparaula@cougarnet.uh.edu", "MyPassword123"); //Remember where you put it
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        } */
        static void SendEmail(string to, string subject, string body)
        {
            try
            {
                Console.WriteLine("Setting up email message...");

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("araulaphillipryan@gmail.com");
                    mail.To.Add(to);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    Console.WriteLine("Configuring SMTP client...");

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential("araulaphillipryan@gmail.com", "eqzr lukj ygex bzdh");
                        smtp.EnableSsl = true;
                        smtp.Timeout = 10000; // 10 seconds timeout

                        Console.WriteLine("Attempting to send email...");
                        smtp.Send(mail);
                        Console.WriteLine("Email sent successfully.");
                    }
                }
            }
            catch (SmtpException smtpEx)
            {
                Console.WriteLine($"SMTP Error: {smtpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
            }
        }
    }

}
