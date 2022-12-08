using Microsoft.Extensions.Options;
using ShoShoppers.Bll.Models.Error;
using ShoShoppers.Bll.Models.NpModels;
using ShoShoppers.Bll.Options;
using ShoShoppers.Bll.Services.Interfaces;
using System.Net.Http.Json;

namespace ShoShoppers.Bll.Services;

/// <summary>
///     Class to work with np api
/// </summary>
public sealed class NpService : INpService
{
    /// <summary>
    ///     Uri for np api
    /// </summary>
    private const string npUri = "https://api.novaposhta.ua/v2.0/json/";

    /// <summary>
    ///     Name of model for np api
    /// </summary>
    private const string modelName = "Address";

    /// <summary>
    ///     Class which represents np apikey and api uri
    /// </summary>
    private readonly NpInfoOptions _options;

    /// <summary>
    ///     HttpClient with di IHttpFactory
    /// </summary>
    private readonly HttpClient _httpClient;

    /// <summary>
    ///     Constructor for new postmail services
    /// </summary>
    /// <param name="options">Configuration class</param>
    public NpService(IOptions<NpInfoOptions> options, HttpClient httpClient)
    {
        _options = options.Value;
        _httpClient = httpClient;
    }

    /// <summary>
    ///     Getting list of Ukraine regions 
    /// </summary>
    /// <param name="npOptions">Configuration options</param>
    /// <returns>Returns list of regions</returns>
    public async ValueTask<IEnumerable<NpResultDto>?> GetRegionsAsync(NpRequestMethodPropertiesDto npRequestMethodProperties)
    {
        return (await GetResponseFromNpAPIAsync(new NpRequestBodyDto(_options.ApiKey, modelName, "getAreas",
            npRequestMethodProperties)))?.Data;
    }

    /// <summary>
    ///     Getting list of cities by region ref 
    /// </summary>
    /// <param name="npOptions">Configuration options</param>
    /// <param name="npRequestMethodProperties">Class with ref on region</param>
    /// <returns>List of cities</returns>
    public async ValueTask<IEnumerable<NpResultDto>?> GetCitiesByRegionAsync(NpRequestMethodPropertiesDto npRequestMethodProperties)
    {
        return (await GetResponseFromNpAPIAsync(new NpRequestBodyDto(_options.ApiKey, modelName, "getCities",
            npRequestMethodProperties)))?.Data;
    }

    /// <summary>
    ///     Getting list of streets by city ref 
    /// </summary>
    /// <param name="npOptions">Configuration options</param>
    /// <param name="npRequestMethodProperties">Class with ref on city</param>
    /// <returns>List of cities</returns>
    public async ValueTask<IEnumerable<NpResultDto>?> GetStreetsByCityAsync(NpRequestMethodPropertiesDto npRequestMethodProperties)
    {
        return (await GetResponseFromNpAPIAsync(new NpRequestBodyDto(_options.ApiKey, modelName, "getStreet",
            npRequestMethodProperties)))?.Data;
    }

    /// <summary>
    ///     Getting list of post officies by city and it`s type
    /// </summary>
    /// <param name="npOptions">Configuration options</param>
    /// <param name="npRequestMethodProperties">Class with ref on type of warehouse and city</param>
    /// <returns>List of cities in region</returns>
    public async ValueTask<IEnumerable<NpResultDto>?> GetPostOfficiesAsync(NpRequestMethodPropertiesDto npRequestMethodProperties)
    {
        return (await GetResponseFromNpAPIAsync(new NpRequestBodyDto(_options.ApiKey, modelName, "getWarehouses",
            npRequestMethodProperties)))?.Data;
    }

    /// <summary>
    ///     Getting response from np api
    /// </summary>
    /// <param name="npRequestBodyDto">Body of request</param>
    /// <returns>NpDataDto object</returns>
    /// <exception cref="HttpStatusCodeException">Custom exception class which contains status code and message</exception>
    private async ValueTask<NpDataDto?> GetResponseFromNpAPIAsync(NpRequestBodyDto npRequestBodyDto)
    {
        var response = await _httpClient.PostAsJsonAsync(npUri, npRequestBodyDto);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpStatusCodeException(response.StatusCode, "Happened some troubles with sending request to np API.");
        }

        return await response.Content.ReadFromJsonAsync<NpDataDto>();
    }
}
