namespace Infrastructure.Services;

public class AddressRepository : Repository<Address>, IAddressRepository
{
    public AddressRepository(ICatalogDbContext catalogDb) : base(catalogDb)
    {
    }
}
