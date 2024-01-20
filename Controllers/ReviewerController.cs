using AutoMapper;
using dotnet_pokemon_review.Dto;
using dotnet_pokemon_review.Middleware;
using dotnet_pokemon_review.Models;
using dotnet_pokemon_review.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_pokemon_review.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomResponseFormat]
    public class ReviewerController : ControllerBase
    {
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMapper _mapper;
        public ReviewerController(IReviewerRepository reviewerRepository, IMapper mapper)
        {
            _reviewerRepository = reviewerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<List<ReviewerDto>>))]
        public IActionResult GetReviewers()
        {
            var reviewers = _mapper.Map<List<ReviewerDto>>(_reviewerRepository.GetReviewers());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(reviewers);
        }

        [HttpGet("{reviewerId:int}")]
        [ProducesResponseType(200, Type = typeof(ReviewerDto))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewer([FromRoute] int reviewerId)
        {
            if (!_reviewerRepository.ReviewerExists(reviewerId))
            {
                return NotFound();
            }

            var reviewer = _mapper.Map<ReviewerDto>(_reviewerRepository.GetReviewer(reviewerId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(reviewer);
        }

        [HttpGet("{reviewerId:int}/reviews")]
        public IActionResult GetReviewsByReviewer([FromRoute] int reviewerId)
        {
            if (!_reviewerRepository.ReviewerExists(reviewerId))
            {
                return NotFound();
            }

            var reviews = _mapper.Map<List<ReviewDto>>(_reviewerRepository.GetReviewsByReviewer(reviewerId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(reviews);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateReviewer([FromBody] ReviewerDto createReviewer)
        {
            if (createReviewer == null)
            {
                return BadRequest(ModelState);
            }

            var reviewer = _reviewerRepository.GetReviewers()
                .Where(r => r.FirstName.Trim().ToUpper() == createReviewer.FirstName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (reviewer != null)
            {
                ModelState.AddModelError("", "Reviewer already exists");
                return StatusCode(422, ModelState);
            }

            var reviewerMap = _mapper.Map<Reviewer>(createReviewer);

            if (!_reviewerRepository.CreateReviewer(reviewerMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully saved");
        }

        [HttpPut("{reviewerId:int}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateReviewer([FromRoute] int reviewerId, ReviewerDto updateReviewer)
        {
            if (updateReviewer == null)
            {
                return BadRequest(ModelState);
            }

            if (reviewerId != updateReviewer.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_reviewerRepository.ReviewerExists(reviewerId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var reviewerMap = _mapper.Map<Reviewer>(updateReviewer);

            if (!_reviewerRepository.UpdateReviewer(reviewerMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}