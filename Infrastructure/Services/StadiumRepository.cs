namespace Infrastructure.Services;

public class StadiumRepository : Repository<Stadium>, IStadiumRepository
{
    public StadiumRepository(ICatalogDbContext catalogDb) : base(catalogDb)
    {
    }
}
