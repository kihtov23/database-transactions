using System;
using System.Data;
using System.Linq;
using EFGetStarted;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Started!");

using FishingLogDbContext dbContext = new();
{
    ClearTable(nameof(dbContext.Accounts));
    DataSeed();

    //SingleUpdateWithOneSaveChanges();

    //SeveralUpdatesWithOneSaveChange();

    //BreakConstraintWithOneSaveChange();

    //ExplicitTransactionWithOneSaveChange();

    //ExplicitTransactionWithMultipleSaveChanges();
}

void ClearTable(string name)
{
    dbContext.Database.ExecuteSqlRaw($"TRUNCATE TABLE {name}");
}

void DataSeed()
{
    dbContext.Accounts.Add(new() { Name = "Oleg", Balance = 1000 });
    dbContext.Accounts.Add(new() { Name = "ivan", Balance = 700 });
    dbContext.Accounts.Add(new() { Name = "Olha", Balance = 500 });
    dbContext.Accounts.Add(new() { Name = "Max", Balance = 1300 });
    dbContext.Accounts.Add(new() { Name = "Natalia", Balance = 1100 });
    dbContext.SaveChanges();
}

void SingleUpdateWithOneSaveChanges()
{
    Console.WriteLine("**********************************************");
    Console.WriteLine("*********************dbContext.Accounts.First(a => a.Id == 1)*************************");
    Console.WriteLine("**********************************************");

    var a = dbContext.Accounts.First(a => a.Id == 1);

    Console.WriteLine("**********************************************");
    Console.WriteLine("*********************a.Name = 'Test1'*************************");
    Console.WriteLine("**********************************************");

    a.Name = "Test1";

    Console.WriteLine("**********************************************");
    Console.WriteLine("*********************dbContext.SaveChanges()*************************");
    Console.WriteLine("**********************************************");

    dbContext.SaveChanges();
}

void SeveralUpdatesWithOneSaveChange()
{
    var a = dbContext.Accounts.First(a => a.Id == 1);
    a.Name = "Test1";

    var b = dbContext.Accounts.First(t => t.Id == 2);
    b.Name = "Test2";
    dbContext.SaveChanges();
}

void BreakConstraintWithOneSaveChange()
{
    var a = dbContext.Accounts.First(a => a.Id == 1);
    a.Name = "Test1";

    var b = dbContext.Accounts.First(t => t.Id == 2);
    b.Name = "Test1";
    dbContext.SaveChanges();
}

void ExplicitTransactionWithOneSaveChange()
{
    using var transaction = dbContext.Database.BeginTransaction(IsolationLevel.ReadUncommitted);
    var a = dbContext.Accounts.First(a => a.Name == "Oleg");
    a.Name = "Test1";
    dbContext.SaveChanges();
    transaction.Commit();
}

void ExplicitTransactionWithMultipleSaveChanges()
{
    using var transaction = dbContext.Database.BeginTransaction(IsolationLevel.ReadUncommitted);
    var a = dbContext.Accounts.First(a => a.Id == 1);
    a.Name = "Test1";
    dbContext.SaveChanges();

    var b = dbContext.Accounts.First(a => a.Name == "Test1");
    b.Name = "Test2";
    dbContext.SaveChanges();
    transaction.Commit();
}

