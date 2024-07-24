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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Pokemon pokemon)
        {
            if (pokemon == null)
            {
                StatusCode(404, "there is nothing in it please enter");
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                _db.Pokemons.Add(pokemon);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();  
        }
        
    }
}
