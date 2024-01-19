using AutoMapper;
using dotnet_pokemon_review.Dto;
using dotnet_pokemon_review.Interfaces;
using dotnet_pokemon_review.Middleware;
using dotnet_pokemon_review.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_pokemon_review.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomResponseFormat]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepository ownerRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OwnerDto>))]
        public IActionResult GetOwners()
        {
            var owners = _ownerRepository.GetOwners();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(owners);
        }

        [HttpGet("{ownerId:int}")]
        [ProducesResponseType(200, Type = typeof(OwnerDto))]
        [ProducesResponseType(400)]
        public IActionResult GetOwner([FromRoute] int ownerId)
        {
            if (!_ownerRepository.OwnerExists(ownerId))
            {
                return NotFound();
            }

            var owner = _mapper.Map<OwnerDto>(_ownerRepository.GetOwner(ownerId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(owner);
        }

        [HttpGet("{ownerId:int}/pokemon")]
        [ProducesResponseType(200, Type = typeof(PokemonDto))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByOwner([FromRoute] int ownerId)
        {
            if (!_ownerRepository.OwnerExists(ownerId))
            {
                return NotFound();
            }

            var pokemons = _mapper.Map<List<PokemonDto>>(_ownerRepository.GetPokemonByOwner(ownerId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(pokemons);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOwner([FromQuery] int countryId, [FromBody] OwnerDto createOwner)
        {
            if (createOwner == null)
            {
                return BadRequest(ModelState);
            }

            var owner = _ownerRepository.GetOwners()
                .Where(o => o.Name.Trim().ToUpper() == createOwner.Name.TrimEnd().ToUpper()).FirstOrDefault();

            if (owner != null)
            {
                ModelState.AddModelError("", "Owner Already Exists");
                return StatusCode(422, ModelState);
            }

            var ownerMap = _mapper.Map<Owner>(createOwner);
            ownerMap.Country = _countryRepository.GetCountry(countryId)!;

            if (!_ownerRepository.CreateOwner(ownerMap))
            {
                ModelState.AddModelError("", "Something went wrong while Saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Saved");
        }
    }
}