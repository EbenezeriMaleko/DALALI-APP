using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Webapp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Override OnModelCreating to specify column types for Identity tables
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configure Identity tables to use VARCHAR(255) for Id columns (for compatibility with MySQL)
        builder.Entity<IdentityRole>(entity =>
        {
            entity.Property(e => e.Id).HasColumnType("varchar(255)").IsRequired();
            entity.HasKey(e => e.Id); // Ensure the primary key is explicitly set
        });

        builder.Entity<IdentityUser>(entity =>
        {
            entity.Property(e => e.Id).HasColumnType("varchar(255)").IsRequired();
            entity.HasKey(e => e.Id); // Ensure the primary key is explicitly set
        });

        builder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.Property(e => e.LoginProvider).HasColumnType("varchar(128)");
            entity.Property(e => e.ProviderKey).HasColumnType("varchar(128)");
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey }); // Composite key
        });

        builder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnType("varchar(255)");
            entity.Property(e => e.RoleId).HasColumnType("varchar(255)");
            entity.HasKey(e => new { e.UserId, e.RoleId }); // Composite key
        });

        builder.Entity<IdentityUserToken<string>>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnType("varchar(255)");
            entity.Property(e => e.LoginProvider).HasColumnType("varchar(128)");
            entity.Property(e => e.Name).HasColumnType("varchar(128)");
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name }); // Composite key
        });

        builder.Entity<IdentityRoleClaim<string>>(entity =>
        {
            entity.Property(e => e.Id).HasColumnType("int"); // Keep as integer if it's an auto-incrementing key
        });

        builder.Entity<IdentityUserClaim<string>>(entity =>
        {
            entity.Property(e => e.Id).HasColumnType("int"); // Keep as integer if it's an auto-incrementing key
        });
    }

}
