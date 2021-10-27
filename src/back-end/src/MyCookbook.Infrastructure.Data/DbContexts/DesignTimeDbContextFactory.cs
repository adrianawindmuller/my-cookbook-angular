using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace MyCookbook.Infrastructure.Data.DbContexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyCookBookDbContext>
    {
        public MyCookBookDbContext CreateDbContext(string[] args)
        {
            string basePath = Directory.GetCurrentDirectory();
            string environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables()
                .Build();
            var connectionString = builder.GetConnectionString("MyCookBookConnection");

            var optionsBuilder = new DbContextOptionsBuilder<MyCookBookDbContext>();
            Console.WriteLine($"DesignTimeDbContextFactory.Create(string): Connection string: {connectionString}");
            optionsBuilder.UseSqlite(connectionString);
            var options = optionsBuilder.Options;
            return new MyCookBookDbContext(options);
        }
    }
}