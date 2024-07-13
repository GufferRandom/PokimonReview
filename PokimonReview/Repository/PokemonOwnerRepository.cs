using PokemonReviewApp.Data;
using PokimonReview.Interfaces;
using PokimonReview.Models;

namespace PokimonReview.Repository
{
    public class PokemonOwnerRepository :IPokemonOwnerRepository
    {
        private readonly DataContext _context;
        public PokemonOwnerRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<PokemonOwner> GetPokemonOwners()
        {
            return _context.PokemonOwners.OrderBy(p => p.PokemonId).ToList();
        }
    }
}
