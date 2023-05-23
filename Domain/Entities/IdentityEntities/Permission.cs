using Domain.Common;

namespace Domain.Entities.IdentityEntities;

public class Permission:BaseAuditableEntity
{
    public int PermissionId { get; set; }

    public string? PermissionName { get; set; }

    public virtual ICollection<Role>? Roles { get; set; }
}
