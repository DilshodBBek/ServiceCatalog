using Application.DTOs.Permission;
using Application.Interfaces;
using Application.ResponseModel;
using Domain.Entities.IdentityEntities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace ServiceCatalogUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ApiControllerBase<Permission>
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionController(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        [HttpGet("[action]")]
        //[Authorize(Roles = "GetAllPermission")]
        public async Task<ActionResult<ResponseCore<IQueryable<PermissionGetDTO>>>> GetAll()
        {
            //string[] strings = { "GetAllPermission", "GetAllRole", "GetAllOwner", "GetByIdRole", "GetByIdOwner",
            //"UpdateRole", "CreateRole","DeleteRole",
            //"UpdateOwner", "CreateOwner", "DeleteOwner"};
            //foreach (string s in strings)
            //{

            //    await _permissionRepository.CreateAsync(new Permission() { PermissionName = s });
            //}
            IEnumerable<Permission> permissions = await _permissionRepository.GetAsync(x => true);

            IEnumerable<PermissionGetDTO> mappedPermissions = _mapper.Map<IEnumerable<PermissionGetDTO>>(permissions);

            return Ok(new ResponseCore<IEnumerable<PermissionGetDTO>>(mappedPermissions));
        }
    }
}
