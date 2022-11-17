using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyWebsite.Pages.Foundation
{
    public class TotalDonationsModel : PageModel
    {
        public List<GoodsInfo> listGoods = new List<GoodsInfo>();
        public List<MoneyInfo> listMoney = new List<MoneyInfo>();
        public List<MoneyDisaster> moneyDisaster = new List<MoneyDisaster>();
        public List<GoodsDisaster> goodsDisasters = new List<GoodsDisaster>();

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
                                goodies.gdate = reader.GetDateTime(5);

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
                                monies.mdate = reader.GetDateTime(3);

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

            try
            {
                String connString = "Server=tcp:appr6312poe.database.windows.net,1433;Initial Catalog=Foundation;Persist Security Info=False;User ID=reanetse;Password=Momentox27p!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query3 = "select * from [dbo].[DisasterMoney]";

                    using (SqlCommand comm = new SqlCommand(query3, conn))
                    {
                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MoneyDisaster monies = new MoneyDisaster();

                                monies.mdid = "" + reader.GetInt32(0);
                                monies.mdlocation = reader.GetString(1);
                                monies.mdamount = "" + reader.GetInt32(2);

                                moneyDisaster.Add(monies);
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

                    string query3 = "select * from [dbo].[DisasterGoods]";

                    using (SqlCommand comm = new SqlCommand(query3, conn))
                    {
                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GoodsDisaster monies = new GoodsDisaster();

                                monies.gdid = "" + reader.GetInt32(0);
                                monies.gdlocation = reader.GetString(1);
                                monies.gdtype = reader.GetString(2);
                                monies.gdtotal = "" + reader.GetInt32(3);

                                goodsDisasters.Add(monies);
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
