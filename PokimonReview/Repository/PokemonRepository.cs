using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokimonReview.Interfaces;
using PokimonReview.Models;
using System.Runtime.CompilerServices;

namespace PokimonReview.Repository
{
    public class PokemonRepository :IPokemonRepository
    {
        private readonly DataContext _context;
        public PokemonRepository(DataContext context) {
            _context = context;
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string Name)
        {
            return _context.Pokemon.Where(p => p.Name == Name).FirstOrDefault();
        }
        public decimal GetPokemonRating(int pokeid)
        {
            var ratings = _context.Reviews.Where(p => p.Id==pokeid);
            if(ratings.Count()<=0)
            {
                return 0;
            }
            return ((decimal)ratings.Sum(p => p.Rating)/ratings.Count());
        }

        public ICollection<Pokemon> GetPokemons() {

            return _context.Pokemon.OrderBy(p => p.Id).ToList();
               }
        public bool PokemonExists(int id)
        {
            return _context.Pokemon.Any(p => p.Id == id);
        }
    }
}
