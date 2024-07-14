using PokemonReviewApp.Data;
using PokimonReview.Interfaces;
using PokimonReview.Models;

namespace PokimonReview.Repository
{
    public class CountryRepository:ICountryRepository
    {
        private readonly DataContext _context;
        public CountryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CountryExists(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }

        public ICollection<Country> GetCountries() {
            return _context.Countries.OrderBy(c => c.Id).ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Where(p => p.Id == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int id)
        {
            return _context.Owners.Where(p => p.Id == id).Select(p=>p.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersByCountry(int id)
        {
            return _context.Owners.Where(p => p.Country.Id == id).ToList();
        }
    } 


}
