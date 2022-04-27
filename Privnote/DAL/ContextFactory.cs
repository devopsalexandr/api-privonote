using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Privnote.DAL;

internal class ContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<ApplicationContext>()
            .UseNpgsql("server=localhost;port=54322;database=privnote;uid=privnote;password=password;");

        return new ApplicationContext(builder.Options);
    }
}