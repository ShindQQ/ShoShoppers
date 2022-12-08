using System.Text.Json.Serialization;

namespace ShoShoppers.Bll.Models.NpModels;

/// <summary>
///     Class which represents methodProperties of np api
/// </summary>
public sealed class NpRequestMethodPropertiesDto
{
    /// <summary>
    ///     Ref of region which is serialized in AreaRef
    /// </summary>
    [JsonPropertyName("AreaRef")]
    public string? RegionRef { get; set; }

    /// <summary>
    ///     Ref of city
    /// </summary>
    [JsonPropertyName("CityRef")]
    public string? CityRef { get; set; }

    /// <summary>
    ///     Ref of type of warehouse
    /// </summary>
    [JsonPropertyName("TypeOfWarehouseRef")]
    public string? TypeOfWarehouseRef { get; set; }

    /// <summary>
    ///     Ref of type of warehouse
    /// </summary>
    [JsonPropertyName("FindByString")]
    public string? FindByString { get; set; }

    /// <summary>
    ///     Limit of item`s count
    /// </summary>
    [JsonPropertyName("Limit")]
    public const string Limit = "100000";

    /// <summary>
    ///     Parameterized constructor
    /// </summary>
    /// <param name="regionRef">Ref of region</param>
    /// <param name="cityRef">Ref of city</param>
    /// <param name="typeOfWarehouseRef">Ref of type of warehouse</param>
    public NpRequestMethodPropertiesDto(string? regionRef, string? cityRef, string? typeOfWarehouseRef, string? findByString)
    {
        RegionRef = regionRef;
        CityRef = cityRef;
        TypeOfWarehouseRef = typeOfWarehouseRef;
        FindByString = findByString;
    }

    /// <summary>
    ///     Empty constructor
    /// </summary>
    public NpRequestMethodPropertiesDto()
    {
    }
}
