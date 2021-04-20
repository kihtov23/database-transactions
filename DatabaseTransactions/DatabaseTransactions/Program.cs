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

    UpdateJustWithSaveChanges1();
    //UpdateJustWithSaveChanges2();

    //SimpleRowUpdate1();
    //SimpleRowUpdate2();

    // BreakConstraint();

    // TransferMoney();

    // MakeBadTransaction();
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


void TransferMoney()
{
    var fromAccount = dbContext.Accounts.First(a => a.Name == "Ivan");
    fromAccount.Balance = fromAccount.Balance - 200;

    var toAccount = dbContext.Accounts.First(a => a.Name == "Olha");
    toAccount.Balance = toAccount.Balance + 200;
    dbContext.SaveChanges();
}

void MakeBadTransaction()
{
    var fromAccount = dbContext.Accounts.First(a => a.Name == "ivan");
    fromAccount.Name = "Ivan";

    var toAccount = dbContext.Accounts.First(a => a.Name == "Olha");
    toAccount.Name = "Ivan";
    dbContext.SaveChanges();
}

void BreakConstraint()
{
    var a = dbContext.Accounts.First(a => a.Id == 1);
    a.Name = "Test1";

    var b = dbContext.Accounts.First(t => t.Id == 2);
    b.Name = "Test1";
    dbContext.SaveChanges();
}

void SimpleRowUpdate1()
{
    using var transaction = dbContext.Database.BeginTransaction(IsolationLevel.ReadUncommitted);
    var a = dbContext.Accounts.First(a => a.Name == "Oleg");
    a.Name = "Test1";
    dbContext.SaveChanges();
    transaction.Commit();
}

void SimpleRowUpdate2()
{
    using var transaction = dbContext.Database.BeginTransaction(IsolationLevel.ReadUncommitted);
    var a = dbContext.Accounts.First(a => a.Name == "Test1");
    a.Name = "Test2";
    dbContext.SaveChanges();
    transaction.Commit();
}

void UpdateJustWithSaveChanges1()
{
    var a = dbContext.Accounts.First(a => a.Name == "Oleg");
    a.Name = "Test1";
    dbContext.SaveChanges();
}

void UpdateJustWithSaveChanges2()
{
    var a = dbContext.Accounts.First(a => a.Name == "Oleg");
    a.Name = "Test1";
    dbContext.SaveChanges();
}

