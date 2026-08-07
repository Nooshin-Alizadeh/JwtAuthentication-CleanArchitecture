using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace JwtAuthentication.Infrastructure.Persistence
{
    // Design-time factory to allow EF tools to create ApplicationDbContext_G
    public class ApplicationDbContextGFactory : IDesignTimeDbContextFactory<ApplicationDbContext_G>
    {
        public ApplicationDbContext_G CreateDbContext(string[] args)
        {
            // Try to locate the API project's appsettings.json (startup project) which usually lives next to this project
            var infrastructureDir = Directory.GetCurrentDirectory();
            var apiProjectPath = Path.GetFullPath(Path.Combine(infrastructureDir, "..", "JwtAuthentication.Api"));

            var builder = new ConfigurationBuilder();
            if (Directory.Exists(apiProjectPath))
            {
                builder.SetBasePath(apiProjectPath)
                       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
            }
            else
            {
                // Fallback to current directory
                builder.SetBasePath(infrastructureDir)
                       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
            }

            var configuration = builder.AddEnvironmentVariables().Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext_G>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                // As a last resort, use a localdb fallback so tooling can still run
                connectionString = "Server=(localdb)\\mssqllocaldb;Database=JwtAuthentication_Db;Trusted_Connection=True;MultipleActiveResultSets=true";
            }

            optionsBuilder.UseSqlServer(connectionString);

            return new ApplicationDbContext_G(optionsBuilder.Options);
        }
    }
}
