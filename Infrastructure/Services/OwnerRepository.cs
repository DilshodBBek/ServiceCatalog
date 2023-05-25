namespace Infrastructure.Services;

public class OwnerRepository : Repository<Owner>, IOwnerRepository
{
    public OwnerRepository(ICatalogDbContext catalogDb) : base(catalogDb)
    {
    }
    public override Task<Owner> CreateAsync(Owner entity)
    {

        return base.CreateAsync(entity);
    }
}
