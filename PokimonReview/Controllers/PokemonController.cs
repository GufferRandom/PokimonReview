using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokimonReview.Dto;
using PokimonReview.Interfaces;
using PokimonReview.Models;
using PokimonReview.Repository;

namespace PokimonReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonrepository;
        private readonly IMapper _mapper;
        public PokemonController(IPokemonRepository pokemonRepository,IMapper mapper)
        {

            _pokemonrepository = pokemonRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Pokemon>))] 
        public IActionResult GetPokeomns() {
            var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonrepository.GetPokemons());
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            return Ok(pokemons);
          }

        [HttpGet("{pokeid}")]
        [ProducesResponseType(200,Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokeid)
        {
            if(!_pokemonrepository.PokemonExists(pokeid))
            {
                return NotFound();
            }
            var pokemon = _mapper.Map<PokemonDto>(_pokemonrepository.GetPokemon(pokeid));
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemon);

        }
        [HttpGet("{pokeid}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokeid)
        {
            if(!_pokemonrepository.PokemonExists(pokeid))
            {
                return NotFound();
            }
            var ratings = _pokemonrepository.GetPokemonRating(pokeid);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(ratings);
        }
    }
}
