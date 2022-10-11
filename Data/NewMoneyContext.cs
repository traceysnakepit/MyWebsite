using Microsoft.EntityFrameworkCore;

namespace MyWebsite.Data
{
    public class NewMoneyContext : DbContext
    {
        public NewMoneyContext(DbContextOptions<NewMoneyContext> options)
            : base(options)
        {
        }

        public DbSet<MyWebsite.Model.NewMoneyCollection> NewMoneyCollection { get; set; }
    }
}
