using PokemonReviewApp.Data;
using PokimonReview.Interfaces;
using PokimonReview.Models;

namespace PokimonReview.Repository
{
    public class CategoryRepository :ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context ) { 
        _context = context;
        }
        public ICollection<Category> GetCategory() { 
            return _context.Categories.OrderBy( x => x.Id ).ToList();
        }
    }
}
