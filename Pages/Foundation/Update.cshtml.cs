using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;

namespace MyWebsite.Pages.Foundation
{
    public class UpdateModel : PageModel
    {
        public DisasterInfo disasterInfo = new DisasterInfo();

        public string successMessage = "";

        public void OnGet()
        {
            string id = Request.Query["id"];

            try
            {
                String connString = "Server=tcp:appr6312poe.database.windows.net,1433;Initial Catalog=Foundation;Persist Security Info=False;User ID=reanetse;Password=Momentox27p!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query1 = "select * from [dbo].[NewDisasters] where DisasterID = @id";

                    using (SqlCommand comm = new SqlCommand(query1, conn))
                    {
                        comm.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                disasterInfo.did = "" + reader.GetInt32(0);
                                disasterInfo.dlocation = reader.GetString(1);
                                disasterInfo.dstart = reader.GetDateTime(2);
                                disasterInfo.dend = reader.GetDateTime(3);
                                disasterInfo.ddescription = reader.GetString(4);
                                disasterInfo.daid = reader.GetString(5);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }

        public void OnPost()
        {
            disasterInfo.dend = Convert.ToDateTime(Request.Form["disend"]);

            try
            {
                string connString = "Server=tcp:appr6312poe.database.windows.net,1433;Initial Catalog=Foundation;Persist Security Info=False;User ID=reanetse;Password=Momentox27p!;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query4 = "update [dbo].[NewDisasters] set EndDate = @disend where DisasterID = @id;";

                    using (SqlCommand comm = new SqlCommand(query4, conn))
                    {
                        comm.Parameters.AddWithValue("@disend", disasterInfo.dend);

                        comm.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            successMessage = "Date updated.";
        }
    }
}
