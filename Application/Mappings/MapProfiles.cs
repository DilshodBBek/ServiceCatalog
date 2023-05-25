using Application.DTOs.Address;
using Application.DTOs.Owner;
using Application.DTOs.Permission;
using Application.DTOs.Role;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.IdentityEntities;

namespace Application.Mappings;

public class MapProfiles : Profile
{
    public MapProfiles()
    {
        CreateMap<AddressCreateDTO, Address>().ReverseMap();
        CreateMap<AddressUpdateDTO, Address>().ReverseMap();
        CreateMap<AddressGetDTO, Address>().ReverseMap();

        CreateMap<Owner,OwnerCreateDTO > ().ReverseMap()
            .ForMember(x => x.Roles, t => t.Ignore());

        //.ForMember(x => x.Roles, t => t.Ignore());
        CreateMap<OwnerUpdateDTO, Owner>().ReverseMap()
            .ForMember(x => x.OwnerId, dto => dto.MapFrom(r => r.Id));
        CreateMap<OwnerGetDTO, Owner>().ReverseMap()
        .ForMember(x => x.OwnerId, dto => dto.MapFrom(r => r.Id));

        CreateMap<Role, RoleCreateDTO>().ReverseMap()
            .ForMember(x=>x.Permissions, t=>t.Ignore())
            .ForMember(x => x.OwnerRoles, t => t.Ignore());
        CreateMap<RoleUpdateDTO, Role>().ReverseMap()
         .ForMember(x => x.RoleId, dto => dto.MapFrom(r => r.Id));

        CreateMap<Role, RoleGetDTO>().ReverseMap()
            .ForMember(x => x.OwnerRoles, dto => dto.Ignore());

        CreateMap<PermissionCreateDTO, Permission>().ReverseMap();
        CreateMap<PermissionUpdateDTO, Permission>().ReverseMap()
             .ForMember(x => x.PermissionId, dto => dto.MapFrom(r => r.Id));
        CreateMap<PermissionGetDTO, Permission>().ReverseMap()
             .ForMember(x => x.PermissionId, dto => dto.MapFrom(r => r.Id)); 
    }
}
