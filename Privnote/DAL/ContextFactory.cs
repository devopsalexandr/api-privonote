using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Privnote.DAL;

internal class ContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<ApplicationContext>()
            .UseNpgsql("");

        return new ApplicationContext(builder.Options);
    }
}