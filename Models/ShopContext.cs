﻿using Microsoft.EntityFrameworkCore;

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
                    Price = (decimal)516796.00
                },
                new Sim
                {
                    SimID = 2,
                    CategoryID = 1,
                    Code = "2",
                    Name = "CryptoPunk #5217",
                    Price = (decimal)2906977.50
                },
                new Sim
                {
                    SimID = 3,
                    CategoryID = 1,
                    Code = "3",
                    Name = "CryptoPunk #7804",
                    Price = (decimal)5426358.00
                },
                //Phising Category 
                new Sim
                {
                    SimID = 4,
                    CategoryID = 2,
                    Code = "550",
                    Name = "#550",
                    Price = (decimal)239018.15
                },
                new Sim
                {
                    SimID = 5,
                    CategoryID = 2,
                    Code = "3439",
                    Name = "#3439",
                    Price = (decimal)1936693.01
                },
                new Sim
                {
                    SimID = 6,
                    CategoryID = 2,
                    Code = "2488",
                    Name = "#2488",
                    Price = (decimal)245077.58
                },
                //Social Engineering
                new Sim
                {
                    SimID = 7,
                    CategoryID = 3,
                    Code = "5549",
                    Name = "CloneX #5549",
                    Price = (decimal)43062.03
                },
                new Sim
                {
                    SimID = 8,
                    CategoryID = 3,
                    Code = "1677",
                    Name = "CloneX #1677",
                    Price = (decimal)63307.51
                },
                new Sim
                {
                    SimID = 9,
                    CategoryID = 3,
                    Code = "14433",
                    Name = "CloneX #14433",
                    Price = (decimal)178294.62
                }
            );
        }
    }
}