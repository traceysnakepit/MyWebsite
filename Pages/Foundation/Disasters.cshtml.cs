using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyWebsite.Pages.Foundation
{
    public class DisastersModel : PageModel
    {
        public DisasterInfo disasterInfo = new DisasterInfo();
        public List<DisasterInfo> allDisasters = new List<DisasterInfo>();

        public string successMessage = "";

        public void OnGet()
        {
            try
            {
                String connString = "Server=tcp:appr6312poe.database.windows.net,1433;Initial Catalog=Foundation;Persist Security Info=False;User ID=reanetse;Password=Momentox27p!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query1 = "select * from [dbo].[NewDisasters];";

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

        public void OnPost()
        {
            disasterInfo.dlocation = Request.Form["newlocation"];
            disasterInfo.dstart = Convert.ToDateTime(Request.Form["newstart"]);
            disasterInfo.dend = Convert.ToDateTime(Request.Form["newend"]);
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
                Console.WriteLine("Exception: " + ex.ToString());
            }
            successMessage = "Disaster details captured.";
        }
    }
}
