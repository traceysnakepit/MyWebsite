using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            moneyInfo.mname = Request.Form["monname"];
            moneyInfo.mamount = Request.Form["monamount"];
            moneyInfo.mdate = Request.Form["mondate"];

            goodsInfo.gname = Request.Form["goodname"];
            goodsInfo.gtotal = Request.Form["goodtotal"];
            goodsInfo.gtype = Request.Form["goodtype"];
            goodsInfo.gdescription = Request.Form["gooddescription"];
            goodsInfo.gdate = Request.Form["gooddate"];

            try
            {
                string connString = "Server=tcp:appr6312poe.database.windows.net,1433;Initial Catalog=Foundation;Persist Security Info=False;User ID=reanetse;Password=Momentox27p!;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query7 = "insert into [dbo].[Money]  values (@monname, @monamount, @mondate);";

                    using (SqlCommand comm = new SqlCommand(query7, conn))
                    {
                        comm.Parameters.AddWithValue("@monname", moneyInfo.mname);
                        comm.Parameters.AddWithValue("@monamount", moneyInfo.mamount);
                        comm.Parameters.AddWithValue("@mondate", moneyInfo.mdate);

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

                    string query6 = "insert into [dbo].[Goods]  values (@goodname, @goodtotal, @goodtype, @gooddescription, @gooddate);";

                    using (SqlCommand comm = new SqlCommand(query6, conn))
                    {
                        comm.Parameters.AddWithValue("@goodname", goodsInfo.gname);
                        comm.Parameters.AddWithValue("@goodtotal", goodsInfo.gtotal);
                        comm.Parameters.AddWithValue("@goodtype", goodsInfo.gtype);
                        comm.Parameters.AddWithValue("@gooddescription", goodsInfo.gdescription);
                        comm.Parameters.AddWithValue("@gooddate", goodsInfo.gdate);

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
