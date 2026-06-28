using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record WaterfallResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the waterfall
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The partner ID
    /// </summary>
    [JsonPropertyName("partner_id")]
    public required string PartnerId { get; set; }

    /// <summary>
    /// The name of the waterfall
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The date of the waterfall
    /// </summary>
    [JsonPropertyName("date")]
    public required DateOnly Date { get; set; }

    /// <summary>
    /// The status of the waterfall
    /// </summary>
    [JsonPropertyName("status")]
    public required WaterfallStatusEnum Status { get; set; }

    /// <summary>
    /// The cash balance associated with the waterfall
    /// </summary>
    [JsonPropertyName("cash_balance")]
    public string? CashBalance { get; set; }

    /// <summary>
    /// The currency of the cash balance
    /// </summary>
    [JsonPropertyName("cash_balance_currency")]
    public string? CashBalanceCurrency { get; set; }

    /// <summary>
    /// The date of the cash balance
    /// </summary>
    [JsonPropertyName("cash_balance_date")]
    public DateOnly? CashBalanceDate { get; set; }

    /// <summary>
    /// The Presigned URL of the file. This is a temporary URL that allows you to download the file.
    /// </summary>
    [JsonPropertyName("file_url")]
    public string? FileUrl { get; set; }

    /// <summary>
    /// The date and time when the waterfall was created
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The date and time when the waterfall was last updated
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

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
