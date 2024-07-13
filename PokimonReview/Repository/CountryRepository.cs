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
        public ICollection<Country> GetCountries() {
            return _context.Countries.OrderBy(c => c.Id).ToList();
        }
    


} 


}
