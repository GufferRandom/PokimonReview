using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PokemonReview.Models;

namespace PokemonReview.Data
{
    public class ApplicationDataContext : IdentityDbContext
    {

        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {
        }
        public DbSet<Pokemon> Pokemons { get; set; }
         

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(p => new { p.LoginProvider, p.ProviderKey });
            modelBuilder.Entity<Pokemon>().HasData
                (
                new Pokemon { Id = 1, Name = "Pikachu", Review = "Pickahu is the best pokemon, because it is electric", Reviewer = "Ash" },
                new Pokemon { Id = 2, Name = "Squirtle", Review = "Squirtle is the best a killing rocks", Reviewer = "James Bond" }
                );
        }
    
    }
}
