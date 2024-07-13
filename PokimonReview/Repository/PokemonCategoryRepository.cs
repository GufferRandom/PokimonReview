using PokemonReviewApp.Data;
using PokimonReview.Interfaces;
using PokimonReview.Models;

namespace PokimonReview.Repository
{
    public class PokemonCategoryRepository :IPokemonCategoryRepository
    {
        private readonly DataContext _context; 
        public PokemonCategoryRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<PokemonCategory> GetPokemonCategories()
        {
            return _context.PokemonCategories.OrderBy(p => p.PokemonId).ToList();
        }
    }
}
