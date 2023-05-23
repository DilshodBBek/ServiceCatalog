using Domain.Common;

namespace Domain.Entities
{
    public class Stadium:BaseAuditableEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
