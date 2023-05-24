using Domain.Entities.IdentityEntities;

namespace Infrastructure.Services;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(ICatalogDbContext catalogDb) : base(catalogDb)
    {
    }
}
