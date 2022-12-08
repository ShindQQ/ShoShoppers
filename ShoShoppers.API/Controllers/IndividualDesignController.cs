using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoShoppers.Bll.Filters;
using ShoShoppers.Bll.Models;
using ShoShoppers.Bll.Services.Interfaces;
using ShoShoppers.Dal.Entities.ItemsForSale;
using System.ComponentModel.DataAnnotations;

namespace ShoShoppers.Api.Controllers;

/// <summary>
///     Controller to add individual designs, update info about them, get them to view their info
/// </summary>
[ApiController]
[Authorize]
[Route("api/[controller]")]
[ProducesResponseType(StatusCodes.Status200OK)]
[Produces("application/json")]
public class IndividualDesignController : ControllerBase
{
    /// <summary>
    ///     Service for IndividualDesign logic
    /// </summary>
    private readonly IIndividualDesignService _individualDesignService;

    /// <summary>
    ///     Mapping IndividualDesign entites
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    ///     Constructor for IndividualDesign controller
    /// </summary>
    /// <param name="individualDesignService">IndividualDesign service provider</param>
    /// <param name="mapper">Varialble for mapping entities DTO`s</param>
    public IndividualDesignController(IIndividualDesignService individualDesignService, IMapper mapper)
    {
        _individualDesignService = individualDesignService;
        _mapper = mapper;
    }

    /// <summary>
    ///     Adding individual design to database
    /// </summary>
    /// <param name="individualDesignDTO">Individual design which will be added</param>
    /// <returns>An ActionResult of IndividualDesignDTO</returns>
    /// <status code="200">Succesfully added</status>
    /// <status code="400">Individual design was unsuccesfully added</status>
    /// <status code="201">Individual design which was created</status>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> AddIndividualDesignAsync([Required] IndividualDesignDto individualDesignDTO)
    {
        var individualDesignCreated =
            await _individualDesignService.AddAsync(_mapper.Map<IndividualDesign>(individualDesignDTO));

        return CreatedAtRoute("GetIndividualDesign",
            new
            {
                individualDesignCreated.Id,
                individualDesignCreated.Name,
                individualDesignCreated.Description,
                individualDesignCreated.Price
            }, individualDesignCreated);
    }

    /// <summary>
    ///     Receiving all individual designs from database
    /// </summary>
    /// <param name="range">Selected pagination for IndividualDesign entity</param>
    /// <param name="filter">Selected filter for IndividualDesign entity</param>
    /// <param name="sort">Selected sorting for IndividualDesign entity</param>
    /// <returns>List of filtered by options or not individual designs</returns>
    /// <status code="200">Individual designs received</status>
    /// <status code="400">There is no individual designs</status>
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetIndividualDesignsAsync(string? range = null, string? filter = null,
        string? sort = null)
    {
        var paginationHelper = await _individualDesignService.GetAsync(range, filter, sort);

        if (paginationHelper.Entities == null) return BadRequest();

        Response.Headers.Add("Access-Control-Expose-Headers", "Content-Range");
        Response.Headers.Add("Content-Range",
            $"{typeof(IndividualDesign).Name.ToLower()} {paginationHelper.From}-{paginationHelper.To}/{paginationHelper.Count}");

        return Ok(paginationHelper.Entities);
    }

    /// <summary>
    ///     Receiving individual design by id
    /// </summary>
    /// <param name="id">Id of the individual design</param>
    /// <returns>Individual design by id</returns>
    /// <status code="200">Individual design received</status>
    /// <status code="204">There is no such individual design</status>
    [HttpGet("{id}", Name = "GetIndividualDesign")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetIndividualDesignAsync(long id)
    {
        var individualDesignFromRepo = await _individualDesignService.FindAsync(new IndividualDesignFilter { Id = id });

        return Ok(individualDesignFromRepo);
    }

    /// <summary>
    ///     Updating individual design`s name, price or description
    /// </summary>
    /// <param name="id">Individual design`s id which will be updated</param>
    /// <param name="individualDesignForUpdate">Updating current individual design on it`s options</param>
    /// <returns>An ActionResult</returns>
    /// <status code="200">Succesfully updated</status>
    /// <status code="500">There is no individual design by such id</status>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateIndividualDesignAsync([Required] long id,
        IndividualDesignDto individualDesignForUpdate)
    {
        var updatedIndividualDesign = _mapper.Map<IndividualDesign>(individualDesignForUpdate);
        updatedIndividualDesign.Id = id;
        await _individualDesignService.UpdateAsync(updatedIndividualDesign);

        return Ok(updatedIndividualDesign);
    }

    /// <summary>
    ///     Removing individual design from database by it`s id
    /// </summary>
    /// <param name="id">Individual design`s id</param>
    /// <returns>An ActionResult</returns>
    /// <status code="200">Succesfully removed</status>
    /// <status code="500">There is no individual design by such id</status>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteIndividualDesignAsync([Required] long id)
    {
        var individualDesignForDelete = new IndividualDesign { Id = id };
        await _individualDesignService.DeleteAsync(individualDesignForDelete);

        return Ok(individualDesignForDelete);
    }
}