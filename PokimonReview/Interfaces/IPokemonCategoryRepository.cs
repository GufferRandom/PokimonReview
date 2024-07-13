using PokemonReviewApp.Data;
using PokimonReview.Models;

namespace PokimonReview.Interfaces
{
    public interface IPokemonCategoryRepository
    {
        ICollection<PokemonCategory> GetPokemonCategories();
    }
}
