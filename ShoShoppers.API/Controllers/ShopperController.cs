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
///     Controller to add shoppers, update info about them, get them to view their info
/// </summary>
[ApiController]
[Authorize]
[Route("api/[controller]")]
[ProducesResponseType(StatusCodes.Status200OK)]
[Produces("application/json")]
public class ShopperController : ControllerBase
{
    /// <summary>
    ///     Mapping Shopper entites
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    ///     Service for Shopper logic
    /// </summary>
    private readonly IShopperService _shopperService;

    /// <summary>
    ///     Constructor for Shopper controller
    /// </summary>
    /// <param name="shopperService">Shopper service provider</param>
    /// <param name="mapper">Varialble for mapping entities DTO`s</param>
    public ShopperController(IShopperService shopperService, IMapper mapper)
    {
        _shopperService = shopperService;
        _mapper = mapper;
    }

    /// <summary>
    ///     Adding shopper to database
    /// </summary>
    /// <param name="shopperDTO">Shopper which will be added</param>
    /// <returns>An ActionResult of ShopperDto</returns>
    /// <status code="200">Succesfully added</status>
    /// <status code="400">Shopper was unsuccesfully added</status>
    /// <status code="201">Shopper which was created</status>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> AddShopperAsync([Required] ShopperDto shopperDTO)
    {
        var shopperCreated = await _shopperService.AddAsync(_mapper.Map<Shopper>(shopperDTO));

        return CreatedAtRoute("GetShopper",
            new { shopperCreated.Id, shopperCreated.Name, shopperCreated.Description, shopperCreated.Price },
            shopperCreated);
    }

    /// <summary>
    ///     Receiving all shoppers from database
    /// </summary>
    /// <param name="range">Selected pagination for Shopper entity</param>
    /// <param name="filter">Selected filter for Shopper entity</param>
    /// <param name="sort">Selected sorting for Shopper entity</param>
    /// <returns>List of filtered by options or not shoppers</returns>
    /// <status code="200">Shoppers received</status>
    /// <status code="400">There is no shoppers</status>
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetShoppersAsync(string? range = null, string? filter = null, string? sort = null)
    {
        var paginationHelper = await _shopperService.GetAsync(range, filter, sort);

        if (paginationHelper.Entities == null) return BadRequest();

        Response.Headers.Add("Access-Control-Expose-Headers", "Content-Range");
        Response.Headers.Add("Content-Range",
            $"{typeof(Shopper).Name.ToLower()} {paginationHelper.From}-{paginationHelper.To}/{paginationHelper.Count}");

        return Ok(paginationHelper.Entities);
    }

    /// <summary>
    ///     Receiving shopper by id
    /// </summary>
    /// <param name="id">Id of the shopper</param>
    /// <returns>Shopper by id</returns>
    /// <status code="200">Shopper received</status>
    /// <status code="404">There is no such shopper</status>
    [HttpGet("{id}", Name = "GetShopper")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetShopperAsync(long id)
    {
        var shopperFromRepo = await _shopperService.FindAsync(new ShopperFilter { Id = id });

        if (shopperFromRepo == null) return NotFound();

        return Ok(shopperFromRepo);
    }

    /// <summary>
    ///     Updating shopper`s name, price or description
    /// </summary>
    /// <param name="id">Shopper`s id which will be updated</param>
    /// <param name="shopperForUpdate">Updating current shopper on it`s options</param>
    /// <returns>An ActionResult</returns>
    /// <status code="200">Succesfully updated</status>
    /// <status code="500">There is no shopper by such id</status>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateShopperAsync([Required] long id, ShopperDto shopperForUpdate)
    {
        var updatedShopper = _mapper.Map<Shopper>(shopperForUpdate);
        updatedShopper.Id = id;
        await _shopperService.UpdateAsync(updatedShopper);

        return Ok(updatedShopper);
    }

    /// <summary>
    ///     Removing shopper from database by it`s id
    /// </summary>
    /// <param name="id">Shopper`s id</param>
    /// <returns>An ActionResult</returns>
    /// <status code="200">Succesfully removed</status>
    /// <status code="500">There is no shopper by such id</status>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteShopperAsync([Required] long id)
    {
        var shopperForDelete = new Shopper { Id = id };
        await _shopperService.DeleteAsync(shopperForDelete);

        return Ok(shopperForDelete);
    }
}