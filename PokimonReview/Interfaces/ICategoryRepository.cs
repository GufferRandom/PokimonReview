using PokimonReview.Models;

namespace PokimonReview.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonByCategory(int pokeid);

        bool CategoryExists(int id);
        bool AddCategory(Category category);
        bool SaveChange();
    }
}
