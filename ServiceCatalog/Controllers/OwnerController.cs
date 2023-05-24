using Application.DTOs.Owner;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ServiceCatalogUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Owner> _validator;

        public OwnerController(IOwnerRepository ownerRepository, IMapper mapper, IValidator<Owner> validator)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet("GetById")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_ownerRepository.Get(x => x.Id.Equals(id)));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] OwnerCreateDTO owner)
        {
            if (ModelState.IsValid)
            {
                Owner mappedOwner = _mapper.Map<Owner>(owner);

                var validationResult = _validator.Validate(mappedOwner);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult);
                }
                mappedOwner = await _ownerRepository.CreateAsync(mappedOwner);

                return Ok(mappedOwner);
            }
            return BadRequest();
        }
    }
}
