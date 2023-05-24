using Application.DTOs.Owner;

namespace Application.DTOs.Stadium;

public class StadiumGetDTO : StadiumBaseDTO
{
    public Guid StadiumId { get; set; }
    public OwnerBaseDTO Owner { get; set; }
    public string? City { get; set; } = "Toshkent";
    public string Region { get; set; }
    public string? Description { get; set; }
    public Uri Location { get; set; }
    public string StadiumName { get; set; }
}
