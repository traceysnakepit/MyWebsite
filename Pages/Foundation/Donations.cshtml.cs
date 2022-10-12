using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;

namespace MyWebsite.Pages.Foundation
{
    public class DonationsModel : PageModel
    {
        public GoodsInfo goodsInfo = new GoodsInfo();
        public MoneyInfo moneyInfo = new MoneyInfo();

        public string successMessage = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            string mnewname = Request.Form["monname"];
            string mnewamount = Request.Form["monamount"];
            string mnewdate = Request.Form["mondate"];

            moneyInfo.mname = mnewname;
            moneyInfo.mamount = mnewamount;
            moneyInfo.mdate = Convert.ToDateTime(mnewdate);

            string gnewname = Request.Form["goodname"];
            string gnewtotal = Request.Form["goodtotal"];
            string gnewtype = Request.Form["goodtype"];
            string gnewdes = Request.Form["gooddescription"];
            string gnewdate = Request.Form["gooddate"];

            goodsInfo.gname = gnewname;
            goodsInfo.gtotal = gnewtotal;
            goodsInfo.gtype = gnewtype;
            goodsInfo.gdescription = gnewdes;
            goodsInfo.gdate = Convert.ToDateTime(gnewdate);

            try
            {
                string connString = "Server=tcp:appr6312poe.database.windows.net,1433;Initial Catalog=Foundation;Persist Security Info=False;User ID=reanetse;Password=Momentox27p!;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query7 = $"insert into [dbo].[NewMoney] (DonorName, DonatedAmount, DateDonated)  values ('{mnewname}', '{mnewamount}', '{mnewdate}');";

                    using (SqlCommand comm = new SqlCommand(query7, conn))
                    {
                        comm.Parameters.AddWithValue(mnewname, moneyInfo.mname);
                        comm.Parameters.AddWithValue(mnewamount, moneyInfo.mamount);
                        comm.Parameters.AddWithValue(mnewdate, moneyInfo.mdate);

                        comm.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {

            }

            try
            {
                string connString = "Server=tcp:appr6312poe.database.windows.net,1433;Initial Catalog=Foundation;Persist Security Info=False;User ID=reanetse;Password=Momentox27p!;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query6 = $"insert into [dbo].[NewGoods] (DonorName, TotalItems, ItemType, Details, DateDonated) values ('{gnewname}', '{gnewtotal}', '{gnewtype}', '{gnewdes}', '{gnewdate}');";

                    using (SqlCommand comm = new SqlCommand(query6, conn))
                    {
                        comm.Parameters.AddWithValue(gnewname, goodsInfo.gname);
                        comm.Parameters.AddWithValue(gnewtotal, goodsInfo.gtotal);
                        comm.Parameters.AddWithValue(gnewtype, goodsInfo.gtype);
                        comm.Parameters.AddWithValue(gnewdes, goodsInfo.gdescription);
                        comm.Parameters.AddWithValue(gnewdate, goodsInfo.gdate);

                        comm.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {

            }
            successMessage = "Donation made.";
        }
    }
}
