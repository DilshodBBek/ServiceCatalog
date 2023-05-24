namespace Application.DTOs.Owner;

public abstract class OwnerBaseDTO
{
    public string FullName { get; set; }
    public string? TelegramUsername { get; set; }
    public string[] PhoneNumbers { get; set; }
}
