using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PokemonReview.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roles;
        public RolesController(RoleManager<IdentityRole> rolemanager)
        {

            _roles = rolemanager;
        }

        public IActionResult Index()
        {
            var roles = _roles.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {

            var roles = new IdentityRole
            {

                Name = role.Name,
                NormalizedName = role.Name.ToUpper()
            };
            var results = await _roles.CreateAsync(roles);
            if (results.Succeeded)
            {
                return RedirectToAction("Index"); 
            }
            return View();
        }
        
    }
    }

