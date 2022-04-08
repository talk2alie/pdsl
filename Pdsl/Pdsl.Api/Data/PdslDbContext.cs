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
            if (optionsBuilder.IsConfigured)
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
                       .HasMaxLength(150);
                builder.Property(e => e.Abstract)
                       .IsRequired()
                       .HasMaxLength(500);
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

                builder.HasData(new[]
                {
                    new PressRelease
                    {
                        Id = 1,
                        Title = "2 Years Ago",
                        Abstract = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.",
                        DataFilePath = "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf",
                        HeroImageFilePath = "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg",
                        LocatorId = "beb6fc9d-4b8c-4738-8f1c-038bcec82e0c",
                        ReleaseDate = DateTime.UtcNow.AddYears(-2),
                        UploadDate = DateTime.UtcNow.AddYears(-2),
                        UploaderId = -111
                    },
                    new PressRelease
                    {
                        Id = 2,
                        Title = "3 Years Ago",
                        Abstract = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.",
                        DataFilePath = "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf",
                        HeroImageFilePath = "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg",
                        LocatorId = "beb6fc9d-4b8c-4738-8f1c-038bcec82e0b",
                        ReleaseDate = DateTime.UtcNow.AddYears(-3),
                        UploadDate = DateTime.UtcNow.AddYears(-3),
                        UploaderId = -111
                    },
                    new PressRelease
                    {
                        Id = 3,
                        Title = "9 Months Ago",
                        Abstract = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.",
                        DataFilePath = "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf",
                        HeroImageFilePath = "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg",
                        LocatorId = "deb6fc9d-4b8c-4738-8f1c-038bcec82e09",
                        ReleaseDate = DateTime.UtcNow.AddMonths(-9),
                        UploadDate = DateTime.UtcNow.AddMonths(-9),
                        UploaderId = -111
                    },
                    new PressRelease
                    {
                        Id = 4,
                        Title = "8 Months Ago",
                        Abstract = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.",
                        DataFilePath = "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf",
                        HeroImageFilePath = "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg",
                        LocatorId = "ceb6fc9d-4b8c-4738-8f1c-038bcec82e09",
                        ReleaseDate = DateTime.UtcNow.AddMonths(-8),
                        UploadDate = DateTime.UtcNow.AddMonths(-8),
                        UploaderId = -111
                    },
                    new PressRelease
                    {
                        Id = 5,
                        Title = "8 Months Ago",
                        Abstract = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.",
                        DataFilePath = "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf",
                        HeroImageFilePath = "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg",
                        LocatorId = "bec6fc9d-4b8c-4728-8f1c-038bcec82e09",
                        ReleaseDate = DateTime.UtcNow.AddMonths(-8).AddDays(-10),
                        UploadDate = DateTime.UtcNow.AddMonths(-8),
                        UploaderId = -111
                    },
                    new PressRelease
                    {
                        Id = 6,
                        Title = "8 Months",
                        Abstract = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.",
                        DataFilePath = "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf",
                        HeroImageFilePath = "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg",
                        LocatorId = "beb6fc9d-4b8c-4738-8f1c-038b3ec82e09",
                        ReleaseDate = DateTime.UtcNow.AddMonths(-8).AddDays(-5),
                        UploadDate = DateTime.UtcNow.AddMonths(-8),
                        UploaderId = -111
                    },
                    new PressRelease
                    {
                        Id = 7,
                        Title = "2 Months Ago",
                        Abstract = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.",
                        DataFilePath = "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf",
                        HeroImageFilePath = "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg",
                        LocatorId = "beb6fc9d-4b8c-4738-8f1c-038bcec82e19",
                        ReleaseDate = DateTime.UtcNow.AddMonths(-2),
                        UploadDate = DateTime.UtcNow.AddMonths(-2),
                        UploaderId = -111
                    },
                    new PressRelease
                    {
                        Id = 8,
                        Title = "1 Month Ago",
                        Abstract = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.",
                        DataFilePath = "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf",
                        HeroImageFilePath = "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg",
                        LocatorId = "beb6fc9d-3b8c-4738-8f1c-038bcec82e09",
                        ReleaseDate = DateTime.UtcNow.AddMonths(-1).AddDays(1),
                        UploadDate = DateTime.UtcNow.AddMonths(-1),
                        UploaderId = -111
                    },
                    new PressRelease
                    {
                        Id = 9,
                        Title = "10 Days Ago",
                        Abstract = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.",
                        DataFilePath = "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf",
                        HeroImageFilePath = "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg",
                        LocatorId = "beb6f99d-4b8c-4738-8f1c-038bcec82e09",
                        ReleaseDate = DateTime.UtcNow.AddDays(-10),
                        UploadDate = DateTime.UtcNow.AddDays(-10),
                        UploaderId = -111
                    },
                    new PressRelease
                    {
                        Id = 10,
                        Title = "10 Days Ago Another",
                        Abstract = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.",
                        DataFilePath = "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf",
                        HeroImageFilePath = "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg",
                        LocatorId = "bee6fc9d-4b8c-4738-8f1c-038bcec82e09",
                        ReleaseDate = DateTime.UtcNow.AddDays(-10),
                        UploadDate = DateTime.UtcNow.AddDays(-10),
                        UploaderId = -111
                    },
                    new PressRelease
                    {
                        Id = 11,
                        Title = "8 Days Ago",
                        Abstract = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.",
                        DataFilePath = "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf",
                        HeroImageFilePath = "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg",
                        LocatorId = "beb6fc9d-4b8c-4738-8f1c-038bcec82e09",
                        ReleaseDate = DateTime.UtcNow.AddDays(-8),
                        UploadDate = DateTime.UtcNow.AddDays(-8),
                        UploaderId = -111
                    },
                    new PressRelease
                    {
                        Id = 12,
                        Title = "6 Days Ago",
                        Abstract = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.",
                        DataFilePath = "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf",
                        HeroImageFilePath = "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg",
                        LocatorId = "beb6fc9d-4b8c-4728-8f1c-038bcec82e09",
                        ReleaseDate = DateTime.UtcNow.AddDays(-6),
                        UploadDate = DateTime.UtcNow.AddDays(-6),
                        UploaderId = -111
                    },
                    new PressRelease
                    {
                        Id = 13,
                        Title = "14 Days Ago",
                        Abstract = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.",
                        DataFilePath = "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf",
                        HeroImageFilePath = "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg",
                        LocatorId = "beb6fc9d-4b8c-4738-811c-038bcec82e09",
                        ReleaseDate = DateTime.UtcNow.AddDays(-14),
                        UploadDate = DateTime.UtcNow.AddDays(-14),
                        UploaderId = -111
                    },
                    new PressRelease
                    {
                        Id = 14,
                        Title = "Today",
                        Abstract = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.",
                        DataFilePath = "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf",
                        HeroImageFilePath = "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg",
                        LocatorId = "beb6fc9d-4b8c-4738-8f1c-038b2ec82e09",
                        ReleaseDate = DateTime.UtcNow,
                        UploadDate = DateTime.UtcNow,
                        UploaderId = -111
                    },
                    new PressRelease
                    {
                        Id = 15,
                        Title = "2 Days Ago",
                        Abstract = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.",
                        DataFilePath = "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf",
                        HeroImageFilePath = "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg",
                        LocatorId = "beb6fc9d-4b5c-4738-8f1c-038bcec82e09",
                        ReleaseDate = DateTime.UtcNow.AddDays(-2),
                        UploadDate = DateTime.UtcNow.AddDays(-2),
                        UploaderId = -111
                    }
                });
            });
        }
    }
}
