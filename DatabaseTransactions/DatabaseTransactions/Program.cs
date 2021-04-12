using System;
using EFGetStarted;


Console.WriteLine("Started!");

using FishingLogDbContext dbContext = new();
{
    dbContext.Accounts.Add(new (){Name = "TestName1", Balance = 1000});
    dbContext.SaveChanges();
}
