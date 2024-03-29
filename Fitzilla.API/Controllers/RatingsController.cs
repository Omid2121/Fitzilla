﻿using AutoMapper;
using Fitzilla.BLL.DTOs;
using Fitzilla.DAL.IRepository;
using Fitzilla.DAL.Models;
using Fitzilla.Models.Constants;
using Fitzilla.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fitzilla.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin, Consumer")]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class RatingsController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    [HttpGet("exerciseTemplate/{exerciseTemplateId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetRatingsByExerciseTemplateId(Guid exerciseTemplateId)
    {
        var ratings = await _unitOfWork.Ratings.GetAll(r => r.Id.Equals(exerciseTemplateId));
        if (ratings == null || ratings.Count == 0) return NotFound("No ratings found for the specified exercise template.");
        
        var results = _mapper.Map<IList<RatingDTO>>(ratings);

        return Ok(results);
    }

    [HttpGet("exerciseTemplate/{exerciseTemplateId}/paged")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPagedRatings(RequestParams requestParams, Guid exerciseTemplateId)
    {
        var ratings = await _unitOfWork.Ratings.GetPagedList(requestParams, r => r.Id.Equals(exerciseTemplateId));
        if (ratings == null || ratings.Count == 0) return NotFound("No ratings found for the specified exercise template.");
        
        var results = _mapper.Map<IList<RatingDTO>>(ratings);

        return Ok(results);
    }

    [HttpGet("{ratingId}", Name = "GetRatingById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRatingById(Guid ratingId)
    {
        if (ratingId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        var rating = await _unitOfWork.Ratings.Get(r => r.Id.Equals(ratingId), ["Creator", "ExerciseTemplate"]);
        if (rating == null) return NotFound("No rating found for the specified id.");

        var result = _mapper.Map<RatingDTO>(rating);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateRating([FromBody] CreateRatingDTO createRatingDTO)
    {
        if (createRatingDTO == null) return BadRequest("Submitted data is invalid.");

        var rating = _mapper.Map<Rating>(createRatingDTO);
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (rating.CreatorId != currentUserId) return Forbid("You are not authorized to create this rating.");

        var exerciseTemplate = await _unitOfWork.ExerciseTemplates.Get(e => e.Id.Equals(createRatingDTO.ExerciseTemplateId));
        if (exerciseTemplate == null) return NotFound("No exercise template found for the specified rating.");

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

        var userRoles = User.FindAll(ClaimTypes.Role);
        bool isAdmin = userRoles.Any(ur => ur.Value == Role.Admin);
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!isAdmin && updateRatingDTO.CreatorId != currentUserId) return Forbid("You are not authorized to update this rating.");

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

        var userRoles = User.FindAll(ClaimTypes.Role);
        bool isAdmin = userRoles.Any(ur => ur.Value == Role.Admin);
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!isAdmin && rating.CreatorId != currentUserId) return Forbid("You are not authorized to delete this rating.");

        await _unitOfWork.Ratings.Delete(ratingId);
        await _unitOfWork.Save();

        return NoContent();
    }
}
