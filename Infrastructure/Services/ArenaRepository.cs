namespace Infrastructure.Services;

public class ArenaRepository : Repository<Arena>, IArenaRepository
{
    public ArenaRepository(ICatalogDbContext catalogDb) : base(catalogDb)
    {
    }
}
