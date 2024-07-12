using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokimonReview.Interfaces;
using PokimonReview.Models;

namespace PokimonReview.Repository
{
    public class PokemonRepository :IPokemonRepository
    {
        private readonly DataContext _context;
        public PokemonRepository(DataContext context) {
            _context = context;
        }
        public ICollection<Pokemon> GetPokemons() {

            return _context.Pokemon.OrderBy(p => p.Id).ToList();
               }
    }
}
