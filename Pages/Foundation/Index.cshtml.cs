using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyWebsite.Pages.Foundation
{
    public class IndexModel : PageModel
    {
        public List<GoodsInfo> listGoods = new List<GoodsInfo>();
        public List<MoneyInfo> listMoney = new List<MoneyInfo>();

        public void OnGet()
        {
            try
            {
                String connString = "Server=tcp:appr6312poe.database.windows.net,1433;Initial Catalog=Foundation;Persist Security Info=False;User ID=reanetse;Password=Momentox27p!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query2 = "select * from [dbo].[Goods];";

                    using (SqlCommand comm = new SqlCommand(query2, conn))
                    {

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GoodsInfo goodies = new GoodsInfo();

                                goodies.gid = "" + reader.GetInt32(0);
                                goodies.gname = reader.GetString(1);
                                goodies.gtotal = "" + reader.GetInt32(2);
                                goodies.gtype = reader.GetString(3);
                                goodies.gdescription = reader.GetString(4);
                                goodies.gdate = reader.GetString(5);

                                listGoods.Add(goodies);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            try
            {
                String connString = "Server=tcp:appr6312poe.database.windows.net,1433;Initial Catalog=Foundation;Persist Security Info=False;User ID=reanetse;Password=Momentox27p!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query3 = "select * from [dbo].[Money]";

                    using (SqlCommand comm = new SqlCommand(query3, conn))
                    {
                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MoneyInfo monies = new MoneyInfo();

                                monies.mid = "" + reader.GetInt32(0);
                                monies.mname = reader.GetString(1);
                                monies.mamount = "" + reader.GetInt32(2);
                                monies.mdate = reader.GetString(3);

                                listMoney.Add(monies);
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

    public class DisasterInfo
    {
        public string did;
        public string dlocation;
        public DateTime dstart;
        public DateTime dend;
        public string ddescription;
        public string daid;
    }

    public class MoneyInfo
    {
        public string mid;
        public string mname;
        public string mamount;
        public string mdate;
    }

    public class GoodsInfo
    {
        public string gid;
        public string gname;
        public string gtotal;
        public string gtype;
        public string gdescription;
        public string gdate;
    }
}