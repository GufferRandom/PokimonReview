using PokimonReview.Models;

namespace PokimonReview.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
    }
}
