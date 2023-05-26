using Application.DTOs.Permission;
using Application.DTOs.Role;
using AutoMapper;
using Domain.Entities.IdentityEntities;

namespace Application.Mappings;

public class MapProfiles : Profile
{
    public MapProfiles()
    {
        Permission();
        Role();

        //CreateMap<AddressCreateDTO, Address>().ReverseMap();
        //CreateMap<AddressUpdateDTO, Address>().ReverseMap();
        //CreateMap<AddressGetDTO, Address>().ReverseMap();

        //CreateMap<Owner,OwnerCreateDTO > ().ReverseMap()
        //    .ForMember(x => x.Roles, t => t.Ignore());

        ////.ForMember(x => x.Roles, t => t.Ignore());
        //CreateMap<OwnerUpdateDTO, Owner>().ReverseMap()
        //    .ForMember(x => x.OwnerId, dto => dto.MapFrom(r => r.Id));
        //CreateMap<OwnerGetDTO, Owner>().ReverseMap()
        //.ForMember(x => x.OwnerId, dto => dto.MapFrom(r => r.Id));

        //CreateMap<Role, RoleCreateDTO>().ReverseMap()
        //    .ForMember(x=>x.Permissions, t=>t.Ignore())
        //    .ForMember(x => x.OwnerRoles, t => t.Ignore());

    }

    private void Permission()
    {
        CreateMap<Permission, PermissionGetDTO>()
          .ForMember(x => x.PermissionName, t => t.MapFrom(f => f.PermissionName))
          .ForMember(x => x.PermissionId, t => t.MapFrom(s => s.Id));
    }

    void Role()
    {
        CreateMap<RoleUpdateDTO, Role>()
            .ForMember(x => x.Name, t => t.MapFrom(s => s.Name))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RoleId))
            .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.Permissions.Select(id => new Permission { Id = id }).ToList()));


        CreateMap<Role, RoleGetDTO>()
           .ForMember(x => x.Name, t => t.MapFrom(s => s.Name))
           .ForMember(x => x.RoleId, t => t.MapFrom(d => d.Id))
           .ForMember(x => x.Permissions, t => t.MapFrom(x => x.Permissions.Select(s => s.Id).ToList()));

        CreateMap<RoleCreateDTO, Role>()
            .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.Permissions.Select(id => new Permission() { Id = id }).ToList()))
            .ForMember(d => d.Name, o => o.MapFrom(src => src.Name));

    }
}
