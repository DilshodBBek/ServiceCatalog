using Domain.Common;

namespace Domain.Entities;

public class Address : BaseAuditableEntity
{
    public string? City { get; set; } = "Toshkent";
    public string Region { get; set; }
    public string? Description { get; set; }
    public Uri Location { get; set; }

    public Guid StadiumId { get; set; }
    public Stadium Stadium { get; set; }
}
