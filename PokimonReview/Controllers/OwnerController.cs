
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokimonReview.Dto;
using PokimonReview.Interfaces;
using PokimonReview.Models;

namespace PokimonReview.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;
        public OwnerController(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200,Type=typeof(ICollection<Owner>))]
        public IActionResult GetOwners()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var owners =_mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());
            return Ok(owners);
        }
        [HttpGet("owner/{ownerid}")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult GetOwner(int ownerid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var owner = _mapper.Map<OwnerDto>(_ownerRepository.GetOwner(ownerid));
            return Ok(owner);
        }
        [HttpGet("owner/pokemon/{ownerid}")]
        [ProducesResponseType(200, Type = typeof(ICollection<Pokemon>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByOwner(int ownerid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var pokemons = _mapper.Map<List<PokemonDto>>(_ownerRepository.GetPokemonByOwner(ownerid));
            return Ok(pokemons);
        }
        [HttpGet("owner/pok/{pokeid}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        [ProducesResponseType(400)]
        public IActionResult GetOwnerOfAnPokemon(int pokeid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var pokemons = _mapper.Map<List<Owner>>(_ownerRepository.GetOwnerOfAnPokemon(pokeid));
            return Ok(pokemons);
        }

    }
}
