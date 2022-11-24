using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyWebsite.Pages.Foundation
{
    public class TotalDonationsModel : PageModel
    {
        public GoodsDisaster gDisaster = new GoodsDisaster();
        public MoneyDisaster mDisaster = new MoneyDisaster();

        public List<MoneyDisaster> allMoney = new List<MoneyDisaster>();
        public List<GoodsDisaster> allGoods = new List<GoodsDisaster>();

        public void OnGet()
        {
            try
            {
                String connString = "Server=tcp:appr6312poe.database.windows.net,1433;Initial Catalog=Foundation;Persist Security Info=False;User ID=reanetse;Password=Momentox27p!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query1 = "select * from [dbo].[DisasterMoney];";

                    using (SqlCommand comm = new SqlCommand(query1, conn))
                    {
                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MoneyDisaster dis = new MoneyDisaster();

                                dis.mdid = "" + reader.GetInt32(0);
                                dis.mdlocation = reader.GetString(1);
                                dis.mdamount = "" + reader.GetInt32(2);

                                allMoney.Add(dis);
                            }
                        }
                    }
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query1 = "select * from [dbo].[DisasterGoods];";

                    using (SqlCommand comm = new SqlCommand(query1, conn))
                    {
                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GoodsDisaster dis = new GoodsDisaster();

                                dis.gdid = "" + reader.GetInt32(0);
                                dis.gdlocation = reader.GetString(1);
                                dis.gdtype = reader.GetString(2);
                                dis.gdtotal = "" + reader.GetInt32(3);

                                allGoods.Add(dis);
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
