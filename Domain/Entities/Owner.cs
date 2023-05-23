using Domain.Common;
using Domain.Entities.IdentityEntities;

namespace Domain.Entities;

public class Owner : BaseAuditableEntity
{
    public string FullName { get; set; }
    public string? TelegramUsername { get; set; }
    public string[] PhoneNumbers { get; set; }
    public string Username { get; set; }

    public string Password { get; set; }

    public virtual ICollection<Role>? Roles { get; set; }

}
