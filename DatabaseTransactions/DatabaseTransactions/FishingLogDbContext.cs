using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    public class FishingLogDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=localhost;Initial Catalog=FishingLog;Integrated Security=True;");
    }

    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
    }
}