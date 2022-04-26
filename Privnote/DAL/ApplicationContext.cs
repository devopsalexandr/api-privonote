using Microsoft.EntityFrameworkCore;
using Privnote.DAL.Entities;

namespace Privnote.DAL;

public class ApplicationContext : DbContext
{
    public DbSet<Note> Notes { get; set; }
    
    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
            
        AfterOnModelCreating(builder);
    }
    
    protected virtual void AfterOnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Note>().ToTable("notes");
    }
}