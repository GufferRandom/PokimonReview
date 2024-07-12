using PokimonReview.Models;

namespace PokimonReview.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons(); 
    }
}
