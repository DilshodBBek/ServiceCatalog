namespace Infrastructure.Services;

public class TimeRepository : Repository<Time>, ITimeRepository
{
    public TimeRepository(ICatalogDbContext catalogDb) : base(catalogDb)
    {
    }
}
