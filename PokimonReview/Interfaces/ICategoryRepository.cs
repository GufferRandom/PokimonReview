using PokimonReview.Models;

namespace PokimonReview.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategory();
    }
}
