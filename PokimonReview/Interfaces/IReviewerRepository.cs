using PokimonReview.Models;

namespace PokimonReview.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
    }
}
