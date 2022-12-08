using Microsoft.AspNetCore.Mvc;
using ShoShoppers.Bll.Models.NpModels;
using ShoShoppers.Bll.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ShoShoppers.API.Controllers;

/// <summary>
///     Controller to get regions, cities, post officies 
/// </summary>
[ApiController]
[Route("api/[controller]")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[Produces("application/json")]
public class NpController : ControllerBase
{
    /// <summary>
    ///     Service for "Нова пошта" logic
    /// </summary>
    private readonly INpService _npService;

    /// <summary>
    ///     Constructor Np contoller
    /// </summary>
    /// <param name="npService">Np service provider</param>
    public NpController(INpService npService)
    {
        _npService = npService;
    }

    /// <summary>
    ///     Getting all Ukraine regions from np api
    /// </summary>
    /// <param name="npRequestMethodProperties">Empty method properties or with find by string</param>
    /// <returns>List of Ukraine regions</returns>
    [HttpPost]
    public async Task<IActionResult> GetRegionsAsync([Required] NpRequestMethodPropertiesDto npRequestMethodProperties)
    {
        var regions = await _npService.GetRegionsAsync(npRequestMethodProperties);

        if (regions == null) return BadRequest();

        return Ok(regions);
    }

    /// <summary>
    ///     Getting all cities by region
    /// </summary>
    /// <param name="npRequestMethodProperties">Class containing ref of region</param>
    /// <returns>List of cities in region</returns>
    [HttpPost("getCitiesByRegion")]
    public async Task<IActionResult> GetCitiesByRegionAsync([Required] NpRequestMethodPropertiesDto npRequestMethodProperties)
    {
        var cities = await _npService.GetCitiesByRegionAsync(npRequestMethodProperties);

        if (cities == null) return BadRequest();

        return Ok(cities);
    }

    /// <summary>
    ///     Getting all streets by city
    /// </summary>
    /// <param name="npRequestMethodProperties">Class containing ref of city</param>
    /// <returns>List of streets in city</returns>s
    [HttpPost("getStreetsByCity")]
    public async Task<IActionResult> GetStreetsByCityAsync([Required] NpRequestMethodPropertiesDto npRequestMethodProperties)
    {
        var streets = await _npService.GetStreetsByCityAsync(npRequestMethodProperties);

        if (streets == null) return BadRequest();

        return Ok(streets);
    }

    /// <summary>
    ///     Getting all post officies by city and type
    /// </summary>
    /// <param name="npRequestMethodProperties">Class containing ref of type of warehouse and ref of city</param>
    /// <returns>List of cities in region</returns>
    [HttpPost("getPostOffices")]
    public async Task<IActionResult> GetPostOfficiesAsync([Required] NpRequestMethodPropertiesDto npRequestMethodProperties)
    {
        var postOfficies = await _npService.GetPostOfficiesAsync(npRequestMethodProperties);

        if (postOfficies == null) return BadRequest();

        return Ok(postOfficies);
    }
}
