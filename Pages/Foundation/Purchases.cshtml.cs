using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyWebsite.Pages.Foundation
{
    public class PurchasesModel : PageModel
    {
        public List<NewPurchases> purchasedGoods = new List<NewPurchases>();
        public List<Difference> getDiff = new List<Difference>();
        public List<Sum> getSum = new List<Sum>();

        public NewPurchases newPurchasedGoods = new NewPurchases();
        public Difference newDiff = new Difference();
        public Sum newSum = new Sum();

        public string successMessage = "";

        public void OnGet()
        {
            try
            {
                String connString = "Server=tcp:appr6312poe.database.windows.net,1433;Initial Catalog=Foundation;Persist Security Info=False;User ID=reanetse;Password=Momentox27p!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query2 = "select * from [dbo].[PurchasedGoods];";

                    string query5 = "select (select sum(Amount) from [dbo].[Money]) - (select sum(Price) from [dbo].[PurchasedGoods]) as difference;";

                    string query6 = "select (select sum(TotalItems) from [dbo].[Goods]) + (select sum(TotalGoods) from [dbo].[PurchasedGoods]) as sum;";

                    using (SqlCommand comm = new SqlCommand(query2, conn))
                    {

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                NewPurchases purc = new NewPurchases();

                                purc.pid = "" + reader.GetInt32(0);
                                purc.ptype = reader.GetString(1);
                                purc.ptotal = "" + reader.GetInt32(2);
                                purc.pprice = "" + reader.GetInt32(3);

                                purchasedGoods.Add(purc);
                            }
                        }
                    }

                    using (SqlCommand comms = new SqlCommand(query5, conn))
                    {
                        using (SqlDataReader reader1 = comms.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                Difference thediff = new Difference();

                                thediff.maindiff = "" + reader1.GetInt32(0);

                                getDiff.Add(thediff);
                            }
                        }
                    }

                    using (SqlCommand comma = new SqlCommand(query6, conn))
                    {
                        using (SqlDataReader reader2 = comma.ExecuteReader())
                        {
                            while (reader2.Read())
                            {
                                Sum thesum = new Sum();

                                thesum.mainsum = "" + reader2.GetInt32(0);

                                getSum.Add(thesum);
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
            newPurchasedGoods.ptype = Request.Form["goodstype"];
            newPurchasedGoods.ptotal = Request.Form["goodstotal"];
            newPurchasedGoods.pprice = Request.Form["goodscost"];

            try
            {
                string connString = "Server=tcp:appr6312poe.database.windows.net,1433;Initial Catalog=Foundation;Persist Security Info=False;User ID=reanetse;Password=Momentox27p!;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query4 = "insert into [dbo].[PurchasedGoods] values (@goodstype, @goodstotal, @goodscost);";

                    using (SqlCommand comm = new SqlCommand(query4, conn))
                    {
                        comm.Parameters.AddWithValue("@goodstype", newPurchasedGoods.ptype);
                        comm.Parameters.AddWithValue("@goodstotal", newPurchasedGoods.ptotal);
                        comm.Parameters.AddWithValue("@goodscost", newPurchasedGoods.pprice);

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
