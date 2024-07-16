using PokimonReview.Models;

namespace PokimonReview.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int id);
        ICollection<Review> GetReviews(int reviewerid);
    bool ReviewerExists(int id);
    }
}
