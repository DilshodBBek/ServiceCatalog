namespace Application.DTOs.Stadium;

public class StadiumCreateDTO : StadiumBaseDTO
{
    public Domain.Entities.Address Addresses { get; set; }
}
