using Microsoft.AspNetCore.Mvc;
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
        public PokemonController(IPokemonRepository pokemonRepository)
        {

            _pokemonrepository = pokemonRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Pokemon>))] 
        public IActionResult GetPokeomns() {
            var pokemons = _pokemonrepository.GetPokemons();
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            return Ok(pokemons);
          }
    }
}
