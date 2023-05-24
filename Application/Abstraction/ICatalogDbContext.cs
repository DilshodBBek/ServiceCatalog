using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstraction;

public interface ICatalogDbContext
{
    DbSet<T> Set<T>() where T : class;
    public DbSet<Stadium> Stadiums { get; set; }
    public DbSet<Arena> Arenas { get; set; }
    public DbSet<Time> Time { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Address> Addresses { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken=default);

}
