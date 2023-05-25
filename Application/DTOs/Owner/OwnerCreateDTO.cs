namespace Application.DTOs.Owner;

public class OwnerCreateDTO: OwnerBaseDTO
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }

   
}
