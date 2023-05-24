using Application.DTOs.Permission;

namespace Application.DTOs.Role;

public class RoleBaseDTO
{
    public string Name { get; set; }

    public List<PermissionGetDTO> Permissions { get; set; }
}
