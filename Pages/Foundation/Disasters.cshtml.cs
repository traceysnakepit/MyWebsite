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
            disasterInfo.dlocation = Request.Form["newlocation"];
            disasterInfo.dstart = Request.Form["newstart"];
            disasterInfo.dend = Request.Form["newend"];
            disasterInfo.ddescription = Request.Form["newdetails"];
            disasterInfo.daid = Request.Form["newhelp"];

            try
            {
                string connString = "Server=tcp:appr6312poe.database.windows.net,1433;Initial Catalog=Foundation;Persist Security Info=False;User ID=reanetse;Password=Momentox27p!;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query4 = "insert into [dbo].[NewDisasters] values (@newlocation, @newstart, @newend, @newdetails, @newhelp);";

                    using (SqlCommand comm = new SqlCommand(query4, conn))
                    {
                        comm.Parameters.AddWithValue("@newlocation", disasterInfo.dlocation);
                        comm.Parameters.AddWithValue("@newstart", disasterInfo.dstart);
                        comm.Parameters.AddWithValue("@newend", disasterInfo.dend);
                        comm.Parameters.AddWithValue("@newdetails", disasterInfo.ddescription);
                        comm.Parameters.AddWithValue("@newhelp", disasterInfo.daid);

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
