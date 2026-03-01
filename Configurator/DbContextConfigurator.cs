using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Configurator;


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public static class DbContextConfigurator
{
    public static void Configure(DbContextOptionsBuilder options)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        options.UseSqlServer(
            configuration.GetConnectionString("DefaultConnection"));
    }
}
