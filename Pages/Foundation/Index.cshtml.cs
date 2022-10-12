using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyWebsite.Pages.Foundation
{
    public class IndexModel : PageModel
    {
        public List<DisasterInfo> listDisaster = new List<DisasterInfo>();
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

                    string query1 = $"select * from [dbo].[NewDisasters];";

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

                                listDisaster.Add(dis);
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

                    string query2 = $"select * from [dbo].[NewGoods];";

                    using (SqlCommand comm = new SqlCommand(query2, conn))
                    {
                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GoodsInfo goodies = new GoodsInfo();

                                goodies.gname = reader.GetString(0);
                                goodies.gtotal = "" + reader.GetInt32(1);
                                goodies.gtype = reader.GetString(2);
                                goodies.gdescription = reader.GetString(3);
                                goodies.gdate = reader.GetDateTime(4);

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

                    string query3 = $"select * from [dbo].[NewMoney];";

                    using (SqlCommand comm = new SqlCommand(query3, conn))
                    {
                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MoneyInfo monies = new MoneyInfo();

                                monies.mname = reader.GetString(0);
                                monies.mamount = "" + reader.GetInt32(1);
                                monies.mdate = reader.GetDateTime(2);

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
        public string did { get; set; }
        public string dlocation { get; set; }
        public DateTime dstart { get; set; }
        public DateTime dend { get; set; }
        public string ddescription { get; set; }
        public string daid { get; set; }
    }

    public class MoneyInfo
    {
        public string mname { get; set; }
        public string mamount { get; set; }
        public DateTime mdate { get; set; }
    }

    public class GoodsInfo
    {
        public string gname { get; set; }
        public string gtotal { get; set; }
        public string gtype { get; set; }
        public string gdescription { get; set; }
        public DateTime gdate { get; set; }
    }
}