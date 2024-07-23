using Microsoft.AspNetCore.Mvc;
using PokemonReview.Data;
using PokemonReview.Models;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace PokemonReview.Controllers
{
    public class HomeController : Controller

    {
        private readonly ApplicationDataContext _db;
        public HomeController(ApplicationDataContext db) {  _db = db; }
        public IActionResult Index()
        {
            var list_pokemons = _db.Pokemons.ToList();
      
            return View(list_pokemons); 
        }
        
    }
}
