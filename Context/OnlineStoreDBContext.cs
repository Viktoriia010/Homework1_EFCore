using Microsoft.EntityFrameworkCore;
using OnlineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Context;

public class OnlineStoreDBContext:DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=DESKTOP-BI99DMD\\SQLEXPRESS;Database=online_store;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
