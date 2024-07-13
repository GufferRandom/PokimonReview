using PokimonReview.Models;

namespace PokimonReview.Interfaces
{
    public interface IPokemonOwnerRepository
    {
        ICollection<PokemonOwner> GetPokemonOwners();
    }
}
