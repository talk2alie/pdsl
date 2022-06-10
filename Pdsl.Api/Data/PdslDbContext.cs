using Microsoft.EntityFrameworkCore;
using Pdsl.Api.Licensing;

namespace Pdsl.Api.Data
{
    public class PdslDbContext : DbContext
    {
        public DbSet<Visitor> Visitors { get; set; }

        public PdslDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
            }
        }
    }
}
