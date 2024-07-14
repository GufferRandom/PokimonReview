using PokimonReview.Models;

namespace PokimonReview.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string Name);
        decimal GetPokemonRating(int pokeid);
        bool PokemonExists(int id);

    }
}
