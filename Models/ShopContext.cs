using Microsoft.EntityFrameworkCore;

namespace GuitarShop.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Nft> Nfts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "Crypto Punks" },
                new Category { CategoryID = 2, Name = "Bored Apes" },
                new Category { CategoryID = 3, Name = "CloneX" }
            );

            modelBuilder.Entity<Nft>().HasData(
                new Nft
                {
                    NftID = 1, 
                    CategoryID = 1,
                    Code = "1190",
                    Name = "CryptoPunk #1190",
                    Price = (decimal)400.00
                },
                new Nft
                {
                    NftID = 2,
                    CategoryID = 1,
                    Code = "5217",
                    Name = "CryptoPunk #5217",
                    Price = (decimal)2250.00
                },
                new Nft
                {
                    NftID = 3,
                    CategoryID = 1,
                    Code = "635",
                    Name = "CryptoPunk #7804",
                    Price = (decimal)4200.00
                },
                new Nft
                {
                    NftID = 4,
                    CategoryID = 2,
                    Code = "550",
                    Name = "#550",
                    Price = (decimal)185.00
                },
                new Nft
                {
                    NftID = 5,
                    CategoryID = 2,
                    Code = "3439",
                    Name = "#3439",
                    Price = (decimal)1499.00
                },
                new Nft
                {
                    NftID = 6,
                    CategoryID = 2,
                    Code = "2488",
                    Name = "#2488",
                    Price = (decimal)189.69
                },
                new Nft
                {
                    NftID = 7,
                    CategoryID = 3,
                    Code = "5549",
                    Name = "CloneX #5549",
                    Price = (decimal)33.33
                },
                new Nft
                {
                    NftID = 8,
                    CategoryID = 3,
                    Code = "1677",
                    Name = "CloneX #1677",
                    Price = (decimal)49.00
                },
                new Nft
                {
                    NftID = 9,
                    CategoryID = 3,
                    Code = "14433",
                    Name = "CloneX #14433",
                    Price = (decimal)138
                }
            );
        }
    }
}