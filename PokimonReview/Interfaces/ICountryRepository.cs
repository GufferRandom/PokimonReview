using PokimonReview.Models;

namespace PokimonReview.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();    
    }
}
