using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    public class FishingLogDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options
                .UseSqlServer(@"Data Source=localhost;Initial Catalog=FishingLog;Integrated Security=True;")
                .LogTo(Console.WriteLine);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasIndex(a => a.Name).IsUnique();
        }
    }

    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Range(0, 10000)]
        public int Balance { get; set; }
    }
}