using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record PaginatedResponseLimitRequestResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("items")]
    public IEnumerable<LimitRequestResponse> Items { get; set; } = new List<LimitRequestResponse>();

    /// <summary>
    /// Current page number
    /// </summary>
    [JsonPropertyName("page")]
    public int? Page { get; set; }

    /// <summary>
    /// Number of items per page
    /// </summary>
    [JsonPropertyName("page_size")]
    public int? PageSize { get; set; }

    /// <summary>
    /// Number of items in the current page
    /// </summary>
    [JsonPropertyName("items_in_page")]
    public int? ItemsInPage { get; set; }

    /// <summary>
    /// Total number of items across all pages
    /// </summary>
    [JsonPropertyName("total_items")]
    public int? TotalItems { get; set; }

    /// <summary>
    /// Total number of pages available
    /// </summary>
    [JsonPropertyName("total_pages")]
    public int? TotalPages { get; set; }

    /// <summary>
    /// Indicates if there is a next page
    /// </summary>
    [JsonPropertyName("has_next")]
    public bool? HasNext { get; set; }

    /// <summary>
    /// Indicates if there is a previous page
    /// </summary>
    [JsonPropertyName("has_previous")]
    public bool? HasPrevious { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
