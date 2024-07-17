using PokimonReview.Models;

namespace PokimonReview.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);
        ICollection<Pokemon> GetPokemonByOwner(int ownerId);
        ICollection<Owner> GetOwnerOfAnPokemon(int pokeId);
        bool AddOwner(Owner owner);
    }
}
