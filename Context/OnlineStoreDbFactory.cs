using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OnlineStore.Configurator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Context;

public class OnlineStoreDbFactory
     : IDesignTimeDbContextFactory<OnlineStoreDBContext>
{
    public OnlineStoreDBContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<OnlineStoreDBContext>();

        DbContextConfigurator.Configure(optionsBuilder);

        return new OnlineStoreDBContext(optionsBuilder.Options);
    }
}
