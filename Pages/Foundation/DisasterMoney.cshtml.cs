using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;

namespace MyWebsite.Pages.Foundation
{
    public class DisasterMoneyModel : PageModel
    {
        public GoodsDisaster gDisaster = new GoodsDisaster();
        public MoneyDisaster mDisaster = new MoneyDisaster();

        public string successMessage = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            mDisaster.mdlocation = Request.Form["donmondisaster"];
            mDisaster.mdamount = Request.Form["donmonamount"];

            gDisaster.gdlocation = Request.Form["locationgooddon"];
            gDisaster.gdtype = Request.Form["typegooddon"];
            gDisaster.gdtotal = Request.Form["totalgooddon"];

            try
            {
                string connString = "Server=tcp:appr6312poe.database.windows.net,1433;Initial Catalog=Foundation;Persist Security Info=False;User ID=reanetse;Password=Momentox27p!;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query7 = "insert into [dbo].[DisasterGoods] values (@locationgooddon, @typegooddon, @totalgooddon);";

                    using (SqlCommand comm = new SqlCommand(query7, conn))
                    {
                        comm.Parameters.AddWithValue("@locationgooddon", gDisaster.gdlocation);
                        comm.Parameters.AddWithValue("@typegooddon", gDisaster.gdtype);
                        comm.Parameters.AddWithValue("@totalgooddon", gDisaster.gdtotal);

                        comm.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            try
            {
                string connString = "Server=tcp:appr6312poe.database.windows.net,1433;Initial Catalog=Foundation;Persist Security Info=False;User ID=reanetse;Password=Momentox27p!;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query6 = "insert into [dbo].[DisasterMoney] values (@donmondisaster, @donmonamount);";

                    using (SqlCommand comm = new SqlCommand(query6, conn))
                    {
                        comm.Parameters.AddWithValue("@donmondisaster", mDisaster.mdlocation);
                        comm.Parameters.AddWithValue("@donmonamount", mDisaster.mdamount);

                        comm.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            successMessage = "Donation made.";
        }
    }
}
