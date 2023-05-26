using Domain.Common;

namespace Domain.Entities;

public class Arena : BaseAuditableEntity
{
    public string Name { get; set; }

    public Guid StadiumId { get; set; }
    public Stadium Stadium { get; set; }
}
