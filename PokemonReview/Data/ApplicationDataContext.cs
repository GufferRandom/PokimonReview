using Microsoft.EntityFrameworkCore;
using PokemonReview.Models;

namespace PokemonReview.Data
{
    public class ApplicationDataContext : DbContext
    {

        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {
        }
        public DbSet<Pokemon> Pokemons { get; set; }
         

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>().HasData
                (
                new Pokemon { Id = 1, Name = "Pikachu", Review = "Pickahu is the best pokemon, because it is electric", Reviewer = "Ash" },
                new Pokemon { Id = 2, Name = "Squirtle", Review = "Squirtle is the best a killing rocks", Reviewer = "James Bond" }
                );
        }
    
    }
}
