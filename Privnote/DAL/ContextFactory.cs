using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Privnote.DAL;

internal class ContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var dbHost = Environment.GetEnvironmentVariable("DATABASE_HOST");
        var dbUser = Environment.GetEnvironmentVariable("DATABASE_USER");
        var dbName = Environment.GetEnvironmentVariable("DATABASE_NAME");
        var dbPassword = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");
        var dbPort = Environment.GetEnvironmentVariable("DATABASE_PORT");

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();
        
        var connectionString = environment == "Development" 
            ? configuration.GetConnectionString("DbConnectionString") 
            : $"server={dbHost};port={dbPort};database={dbName};uid={dbUser};password={dbPassword};";
        
        var builder = new DbContextOptionsBuilder<ApplicationContext>()
            .UseNpgsql(connectionString);

        return new ApplicationContext(builder.Options);
    }
}