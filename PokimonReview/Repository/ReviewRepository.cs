using PokemonReviewApp.Data;
using PokimonReview.Interfaces;
using PokimonReview.Models;

namespace PokimonReview.Repository
{
    public class ReviewRepository :IReviewRepository
    {
        private readonly DataContext _context;
        public ReviewRepository(DataContext context) {  _context = context; }
        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.OrderBy(review => review.Id).ToList();
        }

    }
}
