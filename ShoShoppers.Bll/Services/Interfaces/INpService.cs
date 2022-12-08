using ShoShoppers.Bll.Models.NpModels;
using ShoShoppers.Bll.Options;

namespace ShoShoppers.Bll.Services.Interfaces;

/// <summary>
///     Interface to work with np api
/// </summary>
public interface INpService
{
    /// <summary>
    ///     Getting list of Ukraine regions 
    /// </summary>
    /// <param name="npOptions">Configuration options</param>
    /// <returns>Returns list of regions</returns>
    ValueTask<IEnumerable<NpResultDto>?> GetRegionsAsync(NpRequestMethodPropertiesDto npRequestMethodProperties);

    /// <summary>
    ///     Getting list of cities by region ref 
    /// </summary>
    /// <param name="npOptions">Configuration options</param>
    /// <param name="npRequestMethodProperties">Class with ref on region</param>
    /// <returns>List of cities</returns>
    ValueTask<IEnumerable<NpResultDto>?> GetCitiesByRegionAsync(NpRequestMethodPropertiesDto npRequestMethodProperties);

    /// <summary>
    ///     Getting list of streets by city ref 
    /// </summary>
    /// <param name="npOptions">Configuration options</param>
    /// <param name="npRequestMethodProperties">Class with ref on city</param>
    /// <returns>List of streets in city</returns>
    ValueTask<IEnumerable<NpResultDto>?> GetStreetsByCityAsync(NpRequestMethodPropertiesDto npRequestMethodProperties);

    /// <summary>
    ///     Getting list of post officies by city and it`s type
    /// </summary>
    /// <param name="npOptions">Configuration options</param>
    /// <param name="npRequestMethodProperties">Class with ref on type of warehouse and city</param>
    /// <returns>List of cities in region</returns>
    ValueTask<IEnumerable<NpResultDto>?> GetPostOfficiesAsync(NpRequestMethodPropertiesDto npRequestMethodProperties);
}
