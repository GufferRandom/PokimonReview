using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokimonReview.Dto;
using PokimonReview.Interfaces;
using PokimonReview.Models;

namespace PokimonReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        public ReviewController(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Review>))]
        public IActionResult GetReviews()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var reviews = _mapper.Map<ICollection<ReviewDto>>(_reviewRepository.GetReviews());

            return Ok(reviews);
        }
        [HttpGet("reviewget/{reviewid}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        public IActionResult GetReview(int reviewid)

        {
            if (!_reviewRepository.ReviewExists(reviewid))
            {
                return NotFound();
            }
            
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var review = _mapper.Map<ReviewDto>(_reviewRepository.GetReview(reviewid));

                return Ok(review);
            
        }
        [HttpGet("reviewofpokemon/{pokeid}")]
        [ProducesResponseType(200, Type = typeof(ICollection<Review>))]
        public IActionResult GetReviewsOfPokemon(int pokeid)
        {
          
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var reviews = _mapper.Map<ICollection<ReviewDto>>(_reviewRepository.GetRevviewsOfPokemon(pokeid));

            return Ok(reviews);
        }


    }
}
