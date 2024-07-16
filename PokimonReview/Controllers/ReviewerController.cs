using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokimonReview.Dto;
using PokimonReview.Interfaces;
using PokimonReview.Models;
using PokimonReview.Repository;

namespace PokimonReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : Controller
    {
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMapper _mapper;
        public ReviewerController(IReviewerRepository reviewerRepository, IMapper mapper)
        {
            _reviewerRepository = reviewerRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Reviewer>))]
        public IActionResult GetReviewers()
        {
            if(!ModelState.IsValid) { 
            return BadRequest(ModelState);
            }
            var reviewers=_mapper.Map<List<ReviewerDto>>(_reviewerRepository.GetReviewers());
            return Ok(reviewers);
        }
        [HttpGet("reviewer/{reviewerid}")]
        [ProducesResponseType(200, Type = typeof(Reviewer))]
        public IActionResult GetReviewer(int reviewerid)
        {
            if (!_reviewerRepository.ReviewerExists(reviewerid))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var reviewers = _mapper.Map<ReviewerDto>(_reviewerRepository.GetReviewer(reviewerid));
            return Ok(reviewers);
        }
        [HttpGet("/review/{reviewerid}")]
        [ProducesResponseType(200, Type = typeof(ICollection<Review>))]
        public IActionResult GetReviewes(int reviewerid)
        {
            if (!_reviewerRepository.ReviewerExists(reviewerid))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var reviewers = _mapper.Map<List<Review>>(_reviewerRepository.GetReviews(reviewerid));
            return Ok(reviewers);
        }
    }
}
