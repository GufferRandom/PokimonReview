using PokimonReview.Models;

namespace PokimonReview.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();    
        Country GetCountry(int id);
        Country GetCountryByOwner(int id);
        ICollection<Owner> GetOwnersByCountry(int id);
        bool CountryExists(int id);
        bool AddCountry(Country country);

    }
}
