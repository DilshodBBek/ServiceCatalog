namespace Infrastructure.Services;

public class OwnerRepository : Repository<Owner>, IOwnerRepository
{
    public OwnerRepository(ICatalogDbContext catalogDb) : base(catalogDb)
    {
    }
}
