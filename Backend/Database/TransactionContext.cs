using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using VATHelper.Models;

namespace VATHelper.Database;

public class TransactionContext : DbContext
{
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<TransactionPosition> TransactionPositions { get; set; }

    public string DbPath { get; }
    
    public TransactionContext()
    {  
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "transaction.db");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}