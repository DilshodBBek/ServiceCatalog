using Application.DTOs.Owner;
using Application.Interfaces;
using Application.ResponseModel;
using Domain.Entities;
using Domain.Entities.IdentityEntities;
using Microsoft.AspNetCore.Mvc;
using ServiceCatalogUI.Filters;

namespace ServiceCatalogUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ApiControllerBase<Owner>
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IRoleRepository _roleRepository;

        public OwnerController(IOwnerRepository ownerRepository, IRoleRepository roleRepository)
        {
            _ownerRepository = ownerRepository;
            _roleRepository = roleRepository;
        }

        [HttpGet("[action]")]
        //[Authorize(Roles = "GetAllOwner")]
        public async Task<ActionResult<ResponseCore<IQueryable<OwnerGetDTO>>>> GetAll()
        {
            Task<IQueryable<Owner>> owners = _ownerRepository.GetAsync(x => true);

            IQueryable<OwnerGetDTO> mappedOwners = _mapper.Map<IQueryable<OwnerGetDTO>>(owners);

            return Ok(new ResponseCore<IQueryable<OwnerGetDTO>>(mappedOwners));
        }

        [HttpGet("[action]")]
        //[Authorize(Roles = "GetByIdOwner")]
        public async Task<ActionResult<ResponseCore<OwnerGetDTO>>> GetById(Guid id)
        {
            Owner? obj = await _ownerRepository.GetByIdAsync(id);
            if (obj == null)
            {
                return NotFound(new ResponseCore<Owner?>(false, id + " not found!"));
            }
            OwnerGetDTO mappedOwner = _mapper.Map<OwnerGetDTO>(obj);
            return Ok(new ResponseCore<OwnerGetDTO?>(mappedOwner));
        }

        [HttpPut("[action]")]
        [ActionModelValidation]
        //[Authorize(Roles = "UpdateOwner")]
        public async Task<ActionResult<ResponseCore<OwnerGetDTO>>> Update([FromBody] OwnerUpdateDTO owner)
        {
            Owner? mappedOwner = _mapper.Map<Owner>(owner);
            var validationResult = _validator.Validate(mappedOwner);
            if (!validationResult.IsValid)
            {
                return BadRequest(new ResponseCore<Owner>(false, validationResult.Errors));
            }
            mappedOwner.Roles = new List<Role>();
            foreach (Guid item in owner.Roles)
            {
                Role? role = await _roleRepository.GetByIdAsync(item);
                if (role != null)
                    mappedOwner.Roles.Add(role);
                else return BadRequest(new ResponseCore<Owner>(false, item + " Id not found"));
            }
            mappedOwner = await _ownerRepository.UpdateAsync(mappedOwner);
            if (mappedOwner != null)
                return Ok(new ResponseCore<OwnerGetDTO>(_mapper.Map<OwnerGetDTO>(mappedOwner)));
            return BadRequest(new ResponseCore<Owner>(false, owner + " not found"));

        }

        [HttpPost("[action]")]
        [ActionModelValidation]
        //[Authorize(Roles = "CreateOwner")]
        public async Task<ActionResult<ResponseCore<OwnerGetDTO>>> Create([FromBody] OwnerCreateDTO owner)
        {
            Owner mappedOwner = _mapper.Map<Owner>(owner);
            var validationResult = _validator.Validate(mappedOwner);
            if (!validationResult.IsValid)
            {
                return BadRequest(new ResponseCore<object>(false, validationResult.Errors));
            }
            mappedOwner.Roles = new List<Role>();
            foreach (Guid item in owner.Roles)
            {
                Role? role = await _roleRepository.GetByIdAsync(item);
                if (role != null)
                    mappedOwner.Roles.Add(role);
                else return BadRequest(new ResponseCore<string>(false, item + " Id not found"));
            }
            mappedOwner = await _ownerRepository.CreateAsync(mappedOwner);
            var res = _mapper.Map<OwnerGetDTO>(mappedOwner);
            return Ok(new ResponseCore<OwnerGetDTO>(res));

        }

        [HttpDelete("[action]")]
        //[Authorize(Roles = "DeleteOwner")]
        public async Task<ActionResult<ResponseCore<bool>>> Delete(Guid id)
        {
            return await _ownerRepository.DeleteAsync(id) ?
                Ok(new ResponseCore<bool>(true))
              : BadRequest(new ResponseCore<bool>(false, "Delete failed!"));

        }
    }
}
