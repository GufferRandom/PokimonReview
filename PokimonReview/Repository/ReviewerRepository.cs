using PokemonReviewApp.Data;
using PokimonReview.Interfaces;
using PokimonReview.Models;

namespace PokimonReview.Repository
{
    public class ReviewerRepository :IReviewerRepository
    {
        private readonly DataContext _context;
        public ReviewerRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Reviewer> GetReviewers()
        {
            return _context.Reviewers.OrderBy(x => x.Id).ToList();
        }
    }
}
