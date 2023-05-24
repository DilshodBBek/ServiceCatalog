using Domain.Entities.IdentityEntities;

namespace Infrastructure.Services;

public class PermissionRepository : Repository<Permission>, IPermissionRepository
{
    public PermissionRepository(ICatalogDbContext catalogDb) : base(catalogDb)
    {
    }
}
