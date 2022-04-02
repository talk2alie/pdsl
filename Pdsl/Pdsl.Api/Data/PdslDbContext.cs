using Microsoft.EntityFrameworkCore;

namespace Pdsl.Api.Data
{
    public class PdslDbContext : DbContext
    {
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<PressRelease>? PressReleases { get; set; }

        public PdslDbContext()
        {

        }

        public PdslDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(optionsBuilder.IsConfigured)
            {
                return;
            }

            var connectionString = "Server=MAP-PC\\DEV110;Database=Pdsl;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(builder =>
            {
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Title)
                       .IsRequired()
                       .HasMaxLength(150);
                builder.Property(e => e.FirstName)
                       .IsRequired()
                       .HasMaxLength(256);
                builder.Property(e => e.MiddleName)
                       .HasMaxLength(256);
                builder.Property(e => e.LastName)
                       .IsRequired()
                       .HasMaxLength(256);
                builder.Property(e => e.Suffix)
                       .HasMaxLength(50);
                builder.Property(e => e.LocatorId)
                       .IsRequired()
                       .HasMaxLength(36)
                       .HasDefaultValueSql("NEWID()");
                builder.HasMany(e => e.PressReleases)
                       .WithOne(e => e.Uploader)
                       .HasForeignKey(e => e.UploaderId);
                builder.HasIndex(e => e.LocatorId)
                       .IsUnique();

                builder.HasData(new[]
                {
                    new Employee
                    {
                        Id = -111,
                        Title = "Admin",
                        FirstName = "Hafiz",
                        MiddleName = "Mohamed",
                        LastName = "Pussah",
                        LocatorId = $"{Guid.NewGuid()}"                        
                    }
                });
            });

            modelBuilder.Entity<PressRelease>(builder =>
            {
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Title)
                       .IsRequired()
                       .HasMaxLength(256);
                builder.Property(e => e.Abstract)
                       .IsRequired()
                       .HasMaxLength(256);
                builder.Property(e => e.HeroImageFilePath)
                       .IsRequired()
                       .HasMaxLength(256);
                builder.Property(e => e.DataFilePath)
                       .IsRequired()
                       .HasMaxLength(256);
                builder.Property(e => e.LocatorId)
                       .IsRequired()
                       .HasMaxLength(36)
                       .HasDefaultValueSql("NEWID()");
                builder.Property(e => e.UploaderId)
                       .IsRequired();
                builder.HasIndex(e => e.LocatorId)
                       .IsUnique();
                builder.Property(e => e.ReleaseDate)
                       .IsRequired()
                       .HasDefaultValueSql("GETUTCDATE()");
                builder.Property(e => e.UploadDate)
                       .IsRequired()
                       .HasDefaultValueSql("GETUTCDATE()");
            });
        }
    }
}
