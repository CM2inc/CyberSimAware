using Microsoft.EntityFrameworkCore;

namespace CyberSimAware.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Sim> Sims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "Ransomware" },
                new Category { CategoryID = 2, Name = "Phishing" },
                new Category { CategoryID = 3, Name = "Social Engineering" }
            );

            modelBuilder.Entity<Sim>().HasData(
                //Ransomware Category Lifecycle Sims
                new Sim
                {
                    SimID = 1, 
                    CategoryID = 1,
                    Code = "1",
                    Name = "CryptoPunk #1190",
                    Abstract = ""
                },
                new Sim
                {
                    SimID = 2,
                    CategoryID = 1,
                    Code = "2",
                    Name = "CryptoPunk #5217",
                    Abstract = ""
                },
                new Sim
                {
                    SimID = 3,
                    CategoryID = 1,
                    Code = "3",
                    Name = "CryptoPunk #7804",
                    Abstract = ""
                },
                //Phising Category 
                new Sim
                {
                    SimID = 4,
                    CategoryID = 2,
                    Code = "550",
                    Name = "#550",
                    Abstract = ""
                },
                new Sim
                {
                    SimID = 5,
                    CategoryID = 2,
                    Code = "3439",
                    Name = "#3439",
                    Abstract = ""
                },
                new Sim
                {
                    SimID = 6,
                    CategoryID = 2,
                    Code = "2488",
                    Name = "#2488",
                    Abstract = ""
                },
                //Social Engineering
                new Sim
                {
                    SimID = 7,
                    CategoryID = 3,
                    Code = "5549",
                    Name = "CloneX #5549",
                    Abstract = ""
                },
                new Sim
                {
                    SimID = 8,
                    CategoryID = 3,
                    Code = "1677",
                    Name = "CloneX #1677",
                    Abstract = ""
                },
                new Sim
                {
                    SimID = 9,
                    CategoryID = 3,
                    Code = "14433",
                    Name = "CloneX #14433",
                    Abstract = ""
                }
            );
        }
    }
}