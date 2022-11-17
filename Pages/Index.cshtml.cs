using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Data.SqlClient;

namespace MyWebsite.Pages
{
    public class IndexModel : PageModel
    {
        public LogInfo login = new LogInfo();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            login.lemail = Request.Form["logemail"];
            login.lpassword = Request.Form["logpassword"];

            try
            {
                string connString = "Server=tcp:appr6312poe.database.windows.net,1433;Initial Catalog=Foundation;Persist Security Info=False;User ID=reanetse;Password=Momentox27p!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query8 = "SELECT * FROM [dbo].[Users] WHERE [Email] = '" + login.lemail + "' AND Password = '" + login.lpassword + "'";
                }
            }
            catch (Exception ex)
            {
            }
            Response.Redirect("/Foundation/Disasters");
        }
    }

    public class LogInfo
    {
        public string lemail;
        public string lpassword;
    }
}
