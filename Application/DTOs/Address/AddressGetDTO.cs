namespace Application.DTOs.Address
{
    public class AddressGetDTO : AddressBaseDTO
    {
        public Guid AddressId { get; set; }
        public string StadiumName { get; set; }
    }
}
