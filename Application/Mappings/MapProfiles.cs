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

        CreateMap<OwnerCreateDTO, Owner>().ReverseMap();
        //.ForMember(x => x.Roles, t => t.Ignore());
        CreateMap<OwnerUpdateDTO, Owner>().ReverseMap()
            .ForMember(x => x.OwnerId, dto => dto.MapFrom(r => r.Id));
        CreateMap<OwnerGetDTO, Owner>().ReverseMap()
        .ForMember(x => x.OwnerId, dto => dto.MapFrom(r => r.Id));

        CreateMap<RoleCreateDTO, Role>().ReverseMap();
        CreateMap<RoleUpdateDTO, Role>().ReverseMap()
         .ForMember(x => x.RoleId, dto => dto.MapFrom(r => r.Id));

        CreateMap<RoleGetDTO, Role>().ReverseMap()
            .ForMember(x => x.RoleId, dto => dto.MapFrom(r => r.Id));

        CreateMap<PermissionCreateDTO, Permission>().ReverseMap();
        CreateMap<PermissionUpdateDTO, Permission>().ReverseMap();
        CreateMap<PermissionGetDTO, Permission>().ReverseMap();
    }
}
