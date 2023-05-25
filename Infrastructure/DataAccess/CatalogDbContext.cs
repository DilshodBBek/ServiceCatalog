using Domain.Entities.IdentityEntities;
using Infrastructure.DataAccess.Interceptor;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess;

public class CatalogDbContext : DbContext, ICatalogDbContext
{
    private readonly AuditableEntitySaveChangesInterceptor _interceptor;
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options,
        AuditableEntitySaveChangesInterceptor interceptor)
        : base(options)
    {
        _interceptor = interceptor;
    }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Arena> Arenas { get; set; }
    public DbSet<Owner> Owners { get; set; }    
    public DbSet<Stadium> Stadiums { get; set; }
    public DbSet<Time> Time { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_interceptor);
    }


}
