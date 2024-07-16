using PokemonReviewApp.Data;
using PokimonReview.Interfaces;
using PokimonReview.Models;

namespace PokimonReview.Repository
{
    public class ReviewRepository :IReviewRepository
    {
        private readonly DataContext _context;
        public ReviewRepository(DataContext context) {  _context = context; }

        public Review GetReview(int id)
        {
            return _context.Reviews.Where(p => p.Id == id).FirstOrDefault();
        }


        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.OrderBy(review => review.Id).ToList();
        }

        public ICollection<Review> GetRevviewsOfPokemon(int pokeid)
        {
            return _context.Reviews.Where(p=>p.Pokemon.Id == pokeid).ToList();
        }

        public bool ReviewExists(int reviewid)
        {
            return _context.Reviews.Any(p=>p.Id==reviewid);
        }
    }
}
