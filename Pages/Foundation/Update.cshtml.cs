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

                    string query1 = $"select * from [dbo].[NewDisasters] where DisasterID' = @id";

                    using (SqlCommand comm = new SqlCommand(query1, conn))
                    {
                        comm.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            if (reader.Read())
                            {/*
                                disasterInfo.dlocation = reader.GetString(0);
                                disasterInfo.dstart = reader.GetString(1);
                                disasterInfo.dend = reader.GetString(2);
                                disasterInfo.ddescription = reader.GetString(3);
                                disasterInfo.daid = reader.GetString(4);*/
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void OnPost()
        {
            /* disasterInfo.dlocation = Request.Form["dislocation"];
             disasterInfo.dstart = Request.Form["disstart"];
             disasterInfo.dend = Request.Form["disend"];
             disasterInfo.ddescription = Request.Form["disdescription"];
             disasterInfo.daid = Request.Form["daids"];*/

            try
            {
                string connString = "Server=tcp:appr6312poe.database.windows.net,1433;Initial Catalog=Foundation;Persist Security Info=False;User ID=reanetse;Password=Momentox27p!;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query4 = "update [dbo].[Disasters] set Location = @dislocation, StartDate = @disstart, EndDate = @disend, Description = @disdescription, RequiredAid = @daids where DisasterID = @id;";

                    using (SqlCommand comm = new SqlCommand(query4, conn))
                    {
                        comm.Parameters.AddWithValue("@dislocation", disasterInfo.dlocation);
                        comm.Parameters.AddWithValue("@disstart", disasterInfo.dstart);
                        comm.Parameters.AddWithValue("@disend", disasterInfo.dend);
                        comm.Parameters.AddWithValue("@disdescription", disasterInfo.ddescription);
                        comm.Parameters.AddWithValue("@disaids", disasterInfo.daid);

                        comm.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {

            }

            Response.Redirect("/Foundation/Index");
        }
    }
}
