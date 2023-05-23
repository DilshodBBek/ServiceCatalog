using Domain.Common;

namespace Domain.Entities;

public class Time:BaseAuditableEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid ArenaId { get; set; }
    public Arena Arena { get; set; }
}
