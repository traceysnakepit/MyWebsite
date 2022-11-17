using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyWebsite.Pages.Foundation
{
    public class ActiveDisastersModel : PageModel
    {
        public DisasterInfo disasterInfo = new DisasterInfo();
        public List<DisasterInfo> allDisasters = new List<DisasterInfo>();

        public static DateTime Now { get; }

        public string successMessage = "";

        public void OnGet()
        {
            try
            {
                String connString = "Server=tcp:appr6312poe.database.windows.net,1433;Initial Catalog=Foundation;Persist Security Info=False;User ID=reanetse;Password=Momentox27p!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query1 = "select * from [dbo].[NewDisasters] where 'EndDate' < 'CURRENT_DATE';";

                    using (SqlCommand comm = new SqlCommand(query1, conn))
                    {
                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DisasterInfo dis = new DisasterInfo();

                                dis.did = "" + reader.GetInt32(0);
                                dis.dlocation = reader.GetString(1);
                                dis.dstart = reader.GetDateTime(2);
                                dis.dend = reader.GetDateTime(3);
                                dis.ddescription = reader.GetString(4);
                                dis.daid = reader.GetString(5);

                                allDisasters.Add(dis);
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
    }
}
