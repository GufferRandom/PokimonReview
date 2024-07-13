using PokimonReview.Models;

namespace PokimonReview.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
    }
}
