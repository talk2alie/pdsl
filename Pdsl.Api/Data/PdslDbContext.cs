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

        public PdslDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=MAP-PC\\Dev110;Database=PDSL;Trusted_Connection=True;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitor>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Id)
                 .IsRequired()
                 .HasConversion(
                    value => value.ToString(),
                    value => new Guid(value)
                  )
                 .HasMaxLength(255);

                e.Property(x => x.Name)
                 .IsRequired()
                 .HasConversion(
                    value => value.Text,
                    value => new Name(value))
                 .HasMaxLength(255);

                e.Property(x => x.Organization)
                 .IsRequired()
                 .HasConversion(
                    value => value.Name,
                    value => new Organization(value))
                 .HasMaxLength(255);

                e.Property(x => x.Email)
                 .IsRequired()
                 .HasConversion(
                    value => value.Text,
                    value => new Email(value))
                 .HasMaxLength(255);

                e.Property(x => x.Secret)
                 .IsRequired()
                 .HasConversion(
                    value => value.Text,
                    value => new Secret(value))
                 .HasMaxLength(255);

                e.Property(x => x.IsVerified)
                 .HasConversion(
                    value => value ? "True" : "False",
                    value => value == "True" ? true : false
                )
                 .HasMaxLength(5);

                e.Property(x => x.CreationUtcDateTime)
                 .HasDefaultValueSql("GETUTCDATE()");

                e.Property(x => x.LastUpdatedUtcDateTime)
                 .HasDefaultValueSql("GETUTCDATE()");

                e.OwnsMany(x => x.Visits)
                 .ToTable(nameof(Visitor.Visits))
                 .Property(x => x.UtcDateTime)
                 .IsRequired()
                 .HasMaxLength(55)
                 .HasDefaultValueSql("GETUTCDATE()");

                e.OwnsMany(x => x.Visits)
                 .Property(x => x.Activity)
                 .IsRequired()
                 .HasMaxLength(55)
                 .HasConversion(
                    value => value.ToString(),
                    value => (Activity)Enum.Parse(typeof(Activity), value)
                 );
            });
        }
    }
}
