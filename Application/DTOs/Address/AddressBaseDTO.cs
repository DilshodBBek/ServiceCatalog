namespace Application.DTOs.Address;

public abstract class AddressBaseDTO
{
    public string? City { get; set; } = "Toshkent";
    public string Region { get; set; }
    public string? Description { get; set; }
    public Uri Location { get; set; }

    public Guid StadiumId { get; set; }

}
