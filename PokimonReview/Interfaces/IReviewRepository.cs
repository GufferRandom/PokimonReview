using PokimonReview.Models;

namespace PokimonReview.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        ICollection<Review> GetRevviewsOfPokemon(int pokeid);
        bool ReviewExists(int reviewid);
        Review GetReview(int id);
       

    }
}
