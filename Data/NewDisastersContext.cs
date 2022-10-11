using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebsite.Model;

namespace MyWebsite.Data
{
    public class NewDisastersContext : DbContext
    {
        public NewDisastersContext (DbContextOptions<NewDisastersContext> options)
            : base(options)
        {
        }

        public DbSet<MyWebsite.Model.NewDisastersCollection> NewDisastersCollection { get; set; }
    }
}
