using PokemonReviewApp.Data;
using PokimonReview.Interfaces;
using PokimonReview.Models;

namespace PokimonReview.Repository
{
    public class OwnerRepository :IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
        }

        public Owner GetOwner(int ownerId)
        {
            return _context.Owners.Where(p=>p.Id == ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerOfAnPokemon(int PokeId)
        {
            return _context.PokemonOwners.Where(p => p.Owner.Id == PokeId).Select(p=>p.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.OrderBy(o => o.Id).ToList();
        }

        public ICollection<Pokemon> GetPokemonByOwner(int ownerid)
        {
            return _context.PokemonOwners.Where(p => p.Owner.Id == ownerid).Select(p=>p.Pokemon).ToList();
        }
    }
}
