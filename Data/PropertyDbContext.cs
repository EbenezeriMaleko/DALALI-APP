using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Webapp.Models;

namespace Webapp.Data;

public class PropertyDbContext : DbContext
{
    
    public PropertyDbContext(DbContextOptions<PropertyDbContext> options)
        : base(options)
    {
    }
    public DbSet<Property> AgentTable{ get; set; }

     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
    }
    
}
