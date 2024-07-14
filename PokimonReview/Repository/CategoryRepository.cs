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
        public ICollection<Category> GetCategories()
        {
            return _context.Categories.OrderBy(x => x.Id).ToList();
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(x => x.Id == id);
        }
        public Category GetCategory(int id)
        {
           return _context.Categories.Where(p=>p.Id==id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int pokeid)
        {
            return _context.PokemonCategories.Where(p=>p.CategoryId== pokeid).Select(p=>p.Pokemon).ToList();
        }
    }
}
