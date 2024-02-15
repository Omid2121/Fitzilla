using AutoMapper;
using Fitzilla.BLL.DTOs;
using Fitzilla.DAL.IRepository;
using Fitzilla.DAL.Models;
using Fitzilla.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fitzilla.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin, Consumer")]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class RatingsController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRatings()
    {
        var ratingss = await _unitOfWork.Ratings.GetAll();
        var results = _mapper.Map<IList<RatingDTO>>(ratingss);

        return Ok(results);
    }

    [HttpGet("paged")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPagedRatings(RequestParams requestParams)
    {
        var ratings = await _unitOfWork.Ratings.GetPagedList(requestParams);
        var results = _mapper.Map<IList<RatingDTO>>(ratings);

        return Ok(results);
    }

    [HttpGet("{ratingId}", Name = "GetRatingById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRatingById(Guid ratingId)
    {
        if (ratingId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        var rating = await _unitOfWork.Ratings.Get(
            r => r.Id.Equals(ratingId), ["Medias"]);

        var result = _mapper.Map<RatingDTO>(rating);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> CreateRating([FromBody] CreateRatingDTO createRatingDTO)
    {
        if (createRatingDTO == null) return BadRequest("Submitted data is invalid.");

        var rating = _mapper.Map<Rating>(createRatingDTO);
        rating.CreatedAt = DateTimeOffset.Now;
        await _unitOfWork.Ratings.Insert(rating);
        await _unitOfWork.Save();

        return CreatedAtRoute("GetRatingById", new { ratingId = rating.Id }, rating);
    }

    [HttpPut("{ratingId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> UpdateRating(Guid ratingId, [FromBody] UpdateRatingDTO updateRatingDTO)
    {
        if (updateRatingDTO == null) return BadRequest("Submitted data is invalid.");

        var rating = await _unitOfWork.Ratings.Get(r => r.Id.Equals(ratingId));
        if (rating == null) return BadRequest("Submitted data is invalid.");

        _mapper.Map(updateRatingDTO, rating);
        rating.ModifiedAt = DateTimeOffset.Now;
        _unitOfWork.Ratings.Update(rating);
        await _unitOfWork.Save();

        return NoContent();
    }

    [HttpDelete("{ratingId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeleteRating(Guid ratingId)
    {
        var rating = await _unitOfWork.Ratings.Get(r => r.Id.Equals(ratingId));
        if (rating == null) return BadRequest("Submitted data is invalid.");

        await _unitOfWork.Ratings.Delete(ratingId);
        await _unitOfWork.Save();

        return NoContent();
    }
}
