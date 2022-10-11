using Microsoft.EntityFrameworkCore;

namespace MyWebsite.Data
{
    public class NewGoodsContext : DbContext
    {
        public NewGoodsContext(DbContextOptions<NewGoodsContext> options)
            : base(options)
        {
        }

        public DbSet<MyWebsite.Model.NewGoodsCollection> NewGoodsCollection { get; set; }
    }
}
