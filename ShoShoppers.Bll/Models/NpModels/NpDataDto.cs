using System.Text.Json.Serialization;

namespace ShoShoppers.Bll.Models.NpModels;

/// <summary>
///     Class which represents data array for "Нова пошта" api get request
/// </summary>
public sealed class NpDataDto
{
    /// <summary>
    ///     Data collection for name of fields and data of it
    /// </summary>
    [JsonPropertyName("data")]
    public List<NpResultDto>? Data { get; set; }
}