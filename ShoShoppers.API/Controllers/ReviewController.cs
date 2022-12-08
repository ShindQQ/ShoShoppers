using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoShoppers.Bll.Filters;
using ShoShoppers.Bll.Models;
using ShoShoppers.Bll.Services.Interfaces;
using ShoShoppers.Dal.Entities;
using System.ComponentModel.DataAnnotations;

namespace ShoShoppers.Api.Controllers;

/// <summary>
///     Controller to add, get reviews
/// </summary>
[ApiController]
[Authorize]
[Route("api/[controller]")]
[ProducesResponseType(StatusCodes.Status200OK)]
[Produces("application/json")]
public class ReviewController : ControllerBase
{
    /// <summary>
    ///     Mapping Review entites
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    ///     Service for Review logic
    /// </summary>
    private readonly IReviewService _reviewService;

    /// <summary>
    ///     Constructor for Review controller
    /// </summary>
    /// <param name="reviewService">Review service provider</param>
    /// <param name="mapper">Varialble for mapping entities DTO`s</param>
    public ReviewController(IReviewService reviewService, IMapper mapper)
    {
        _reviewService = reviewService;
        _mapper = mapper;
    }

    /// <summary>
    ///     Adding review to database
    /// </summary>
    /// <param name="reviewDTO">Review which will be added</param>
    /// <returns>An ActionResult of ReviewDto</returns>
    /// <status code="200">Succesfully added</status>
    /// <status code="400">Review was unsuccesfully added</status>
    /// <status code="201">Review which was created</status>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> AddReviewAsync([Required] ReviewDto reviewDTO)
    {
        var createdReview = await _reviewService.AddAsync(_mapper.Map<Review>(reviewDTO));

        return CreatedAtRoute("GetReview", new { createdReview.Id }, createdReview);
    }

    /// <summary>
    ///     Receiving all reviews from database
    /// </summary>
    /// <param name="range">Selected pagination for Review entity</param>
    /// <param name="filter">Selected filter for Review entity</param>
    /// <param name="sort">Selected sorting for Review entity</param>
    /// <returns>List of filtered by options or not reviews</returns>
    /// <status code="200">Reviews received</status>
    /// <status code="400">There is no reviews</status>
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetReviewsAsync(string? range = null, string? filter = null, string? sort = null)
    {
        var paginationHelper = await _reviewService.GetAsync(range, filter, sort);

        if (paginationHelper.Entities == null) return BadRequest();

        Response.Headers.Add("Access-Control-Expose-Headers", "Content-Range");
        Response.Headers.Add("Content-Range",
            $"{typeof(Review).Name.ToLower()} {paginationHelper.From}-{paginationHelper.To}/{paginationHelper.Count}");

        return Ok(paginationHelper.Entities);
    }

    /// <summary>
    ///     Receiving review by id
    /// </summary>
    /// <param name="id">Id of the review</param>
    /// <returns>Review by filter options</returns>
    /// <status code="200">Review received</status>
    /// <status code="404">There is no such review</status>
    [HttpGet("{id}", Name = "GetReview")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetReviewAsync(long id)
    {
        var reviewFromRepo = await _reviewService.FindAsync(new ReviewFilter { Id = id });

        if (reviewFromRepo == null) return NotFound();

        return Ok(reviewFromRepo);
    }

    /// <summary>
    ///     Updating review`s name, price or description
    /// </summary>
    /// <param name="id">Review`s id which will be updated</param>
    /// <param name="reviewForUpdate">Updating current review on it`s options</param>
    /// <returns>An ActionResult</returns>
    /// <status code="200">Succesfully updated</status>
    /// <status code="500">There is no review by such id</status>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateReviewAsync([Required] long id, ReviewDto reviewForUpdate)
    {
        var updatedReview = _mapper.Map<Review>(reviewForUpdate);
        updatedReview.Id = id;
        await _reviewService.UpdateAsync(updatedReview);

        return Ok(updatedReview);
    }

    /// <summary>
    ///     Removing review from database by it`s id
    /// </summary>
    /// <param name="id">Reviews`s id</param>
    /// <returns>An ActionResult</returns>
    /// <status code="200">Succesfully removed</status>
    /// <status code="500">There is no review by such id</status>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteReviewAsync([Required] long id)
    {
        var reviewForDelete = new Review { Id = id };
        await _reviewService.DeleteAsync(reviewForDelete);

        return Ok(reviewForDelete);
    }
}