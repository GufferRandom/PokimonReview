using Microsoft.AspNetCore.Authorization;
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
        public HomeController(ApplicationDataContext db) { _db = db; }
        [Authorize]
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
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound(ModelState);
            }
           
            
            var get_pokemon = _db.Pokemons.Where(u => u.Id == id).FirstOrDefault();
            if (get_pokemon == null)
            {
                return NotFound();
            }
            return View(get_pokemon);

        }
        [HttpPost]
        public IActionResult Edit(Pokemon pokemon)
        {
            if(ModelState.IsValid)
            {
                _db.Pokemons.Update(pokemon);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound(ModelState);
            }
            var get_pokemon = _db.Pokemons.Where(u => u.Id == id).FirstOrDefault();
            if (get_pokemon == null)
            {
                return NotFound();
            }
            return View(get_pokemon);


        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (ModelState.IsValid)
            {
                var pokemon = _db.Pokemons.Where(u => u.Id == id).FirstOrDefault();
                _db.Pokemons.Remove(pokemon);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
     }
