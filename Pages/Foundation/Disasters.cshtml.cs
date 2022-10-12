using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;

namespace MyWebsite.Pages.Foundation
{
    public class DisastersModel : PageModel
    {
        public DisasterInfo disasterInfo = new DisasterInfo();

        public string successMessage = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            string newloc = Request.Form["dislocation"];
            string newstart = Request.Form["disstart"];
            string newend = Request.Form["disend"];
            string newdes = Request.Form["disdescription"];
            string newaid = Request.Form["disaids"];

            disasterInfo.dlocation = newloc;
            disasterInfo.dstart = Convert.ToDateTime(newstart);
            disasterInfo.dend = Convert.ToDateTime(newend);
            disasterInfo.ddescription = newdes;
            disasterInfo.daid = newaid;

            try
            {
                string connString = "Server=tcp:appr6312poe.database.windows.net,1433;Initial Catalog=Foundation;Persist Security Info=False;User ID=reanetse;Password=Momentox27p!;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query = $"insert into [dbo].[NewDisasters] (Location, StartDate, EndDate, Details, RequiredAid) values ('{newloc}', '{newstart}', '{newend}', '{newdes}', '{newaid}');";

                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        comm.Parameters.AddWithValue(newloc, disasterInfo.dlocation);
                        comm.Parameters.AddWithValue(newstart, disasterInfo.dstart);
                        comm.Parameters.AddWithValue(newend, disasterInfo.dend);
                        comm.Parameters.AddWithValue(newdes, disasterInfo.ddescription);
                        comm.Parameters.AddWithValue(newaid, disasterInfo.daid);

                        comm.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {

            }
            successMessage = "Disaster details captured.";
        }
    }
}
