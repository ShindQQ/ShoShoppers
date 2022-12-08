using System.Text.Json.Serialization;

namespace ShoShoppers.Bll.Models.NpModels;

/// <summary>
///     Class which represents description of description and ref in data array for "Нова пошта" api get request
/// </summary>
public sealed class NpResultDto
{
    /// <summary>
    ///     Name of region, city or post office
    /// </summary>
    [JsonPropertyName("Description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    ///     Ref of region, city or post office
    /// </summary>
    [JsonPropertyName("Ref")]
    public string Ref { get; set; } = string.Empty;
}

