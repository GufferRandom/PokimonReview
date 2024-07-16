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

        public Reviewer GetReviewer(int id)
        {
            return _context.Reviewers.Where(p=>p.Id==id).FirstOrDefault();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _context.Reviewers.OrderBy(x => x.Id).ToList();
        }

        public ICollection<Review> GetReviews(int reviewerid)
        {
            return _context.Reviews.Where(p=>p.Reviewer.Id == reviewerid).ToList();
        }

        public bool ReviewerExists(int id)
        {
            return _context.Reviewers.Any(p=>p.Id==id);
        }
    }
}
