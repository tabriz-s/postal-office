using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Text;

namespace COSCPFWA.Services
{
    public class WeeklyRiskNotification
    {
        static void Main()
        {
            string connString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            string query = "SELECT employee.EmployeeID, employee.Name, employee.Email, employee.PhoneNumber, employee.IncidentCount\" +
                "FROM employee" +
                "WHERE (LastUpdated >= NOW() - INTERVAL 7 DAY) AND (IncidentCount >= 5)" +
                "ORDER BY LastUpdated DESC;";

            //Execute MySQL query and organize results
            DataTable results =
        }

        static DataTable GetQueryResults(string connString, string query)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;
        }

        static string FormatResultsAsTable(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border>");
            sb.Append("<Result>");

            foreach (DataColumn col in dt.Columns)
            {
                sb.AppendFormat("<th>{0}>/th>", col.ColumnName);
            }
            sb.AppendLine"</tr>");

            foreach (DataRow in dt.Rows)
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

        static void SendEmail(string to, string subject, string body)
        {
            using (Mailmessage mail = new Mailmessage())
            {
                mail.From = new MailAddress("rynsusername@gmail.com");
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new System.net.NetworkCredential("smtp gmail", "smtp passowrd") //Remember where you put it
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }


    }






}