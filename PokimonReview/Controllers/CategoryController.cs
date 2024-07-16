using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PokimonReview.Dto;
using PokimonReview.Interfaces;
using PokimonReview.Models;
using PokimonReview.Repository;
using System.Runtime.InteropServices;

namespace PokimonReview.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {

            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200,Type=typeof(ICollection<Category>))]
        public IActionResult GetCategories()

        {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(categories);
        }
        [HttpGet("{pokeid}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int pokeid)
        {
            if (!_categoryRepository.CategoryExists(pokeid))
            {
                return NotFound();
            }
            var categories = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(pokeid));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(categories);
        }
        [HttpGet("pokemon{categoryid}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCategory(int categoryid)
        {
            var pokemons = _mapper.Map<List<PokemonDto>>(_categoryRepository.GetPokemonByCategory(categoryid));
        if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemons);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult CreateCategory([FromBody] CategoryDto category)
        {
            if (CreateCategory == null)
            {
                return BadRequest(ModelState);
            }
         var categori = _categoryRepository.GetCategories().Where(p => p.Name.ToUpper().Trim()==category.Name.ToUpper().TrimEnd()).FirstOrDefault();
            if (categori != null)
            {
                 ModelState.AddModelError("","Category Exists");
                return StatusCode(402, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categorymap = _mapper.Map<Category>(category);
            if (!_categoryRepository.AddCategory(categorymap))
            {
                ModelState.AddModelError("", "Some error");
                return StatusCode(500,ModelState);

            }
            return Ok("Successfull created");
        }
    }
}
