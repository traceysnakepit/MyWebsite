using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            disasterInfo.dlocation = Request.Form["dislocation"];
            disasterInfo.dstart = Request.Form["disstart"];
            disasterInfo.dend = Request.Form["disend"];
            disasterInfo.ddescription = Request.Form["disdescription"];
            disasterInfo.daid = Request.Form["daids"];

            try
            {
                string connString = "Server=tcp:appr6312poe.database.windows.net,1433;Initial Catalog=Foundation;Persist Security Info=False;User ID=reanetse;Password=Momentox27p!;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using(SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                        
                    string query4 = "insert into [dbo].[Disasters] values (@dislocation, @disstart, @disend, @disdescription, @daids);";
                
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
            catch(Exception ex)
            {

            }
            successMessage = "Disaster details captured.";
        }
    }
}
