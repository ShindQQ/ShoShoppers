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
///     Controller to add pins, update info about them, get them to view their info
/// </summary>
[ApiController]
[Authorize]
[Route("api/[controller]")]
[ProducesResponseType(StatusCodes.Status200OK)]
public class PinController : ControllerBase
{
    /// <summary>
    ///     Mapping Pins entites
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    ///     Service for Pins logic
    /// </summary>
    private readonly IPinService _pinService;

    /// <summary>
    ///     Constructor for Pin controller
    /// </summary>
    /// <param name="pinService">Email service provider</param>
    /// <param name="mapper">Varialble for mapping entities DTO`s</param>
    public PinController(IPinService pinService, IMapper mapper)
    {
        _pinService = pinService;
        _mapper = mapper;
    }

    /// <summary>
    ///     Adding pin to database
    /// </summary>
    /// <param name="pinDTO">Pin which will be added</param>
    /// <returns>An ActionResult of PinDto</returns>
    /// <status code="200">Succesfully added</status>
    /// <status code="400">Pin was unsuccesfully added</status>
    /// <status code="201">Pin which was created</status>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> AddPinAsync(PinDto pinDTO)
    {
        var pinCreated = await _pinService.AddAsync(_mapper.Map<Pin>(pinDTO));

        return CreatedAtRoute("GetPin",
            new { pinCreated.Id, pinCreated.Name, pinCreated.Description, pinCreated.Price }, pinCreated);
    }

    /// <summary>
    ///     Receiving all pins from database
    /// </summary>
    /// <param name="range">Selected pagination for Pin entity</param>
    /// <param name="filter">Selected filter for Pin entity</param>
    /// <param name="sort">Selected sorting for Pin entity</param>
    /// <returns>List of filtered by options or not pins</returns>
    /// <status code="200">Pins received</status>
    /// <status code="400">There is no pins</status>
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetPinsAsync(string? range = null, string? filter = null, string? sort = null)
    {
        var paginationHelper = await _pinService.GetAsync(range, filter, sort);

        if (paginationHelper.Entities == null) return BadRequest();

        Response.Headers.Add("Access-Control-Expose-Headers", "Content-Range");
        Response.Headers.Add("Content-Range",
            $"{typeof(Pin).Name.ToLower()} {paginationHelper.From}-{paginationHelper.To}/{paginationHelper.Count}");

        return Ok(paginationHelper.Entities);
    }

    /// <summary>
    ///     Receiving pin by id
    /// </summary>  
    /// <param name="id">Id of the pin</param>
    /// <returns>Pin by id</returns>
    /// <status code="200">Pin received</status>
    /// <status code="404">There is no such pin</status>
    [HttpGet("{id}", Name = "GetPin")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPinAsync(long id)
    {
        var pinFromRepo = await _pinService.FindAsync(new PinFilter { Id = id });

        if (pinFromRepo == null) return NotFound();

        return Ok(pinFromRepo);
    }

    /// <summary>
    ///     Updating pin`s name, price or description
    /// </summary>
    /// <param name="id">Pin`s id which will be updated</param>
    /// <param name="pinForUpdate">Updating current pin on it`s options</param>
    /// <returns>An ActionResult</returns>
    /// <status code="200">Succesfully updated</status>
    /// <status code="500">There is no pin by such id</status>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdatePinAsync([Required] long id, PinDto pinForUpdate)
    {
        var updatedPin = _mapper.Map<Pin>(pinForUpdate);
        updatedPin.Id = id;
        await _pinService.UpdateAsync(updatedPin);

        return Ok(updatedPin);
    }

    /// <summary>
    ///     Removing pin from database by it`s id
    /// </summary>
    /// <param name="id">Pin`s id</param>
    /// <returns>An ActionResult</returns>
    /// <status code="200">Succesfully removed</status>
    /// <status code="500">There is no pin by such id</status>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeletePinAsync([Required] long id)
    {
        var pinForDelete = new Pin { Id = id };
        await _pinService.DeleteAsync(pinForDelete);

        return Ok(pinForDelete);
    }
}