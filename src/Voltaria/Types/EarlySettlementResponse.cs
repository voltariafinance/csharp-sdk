using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record EarlySettlementResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the loan
    /// </summary>
    [JsonPropertyName("loan_id")]
    public required string LoanId { get; set; }

    /// <summary>
    /// The date of early settlement
    /// </summary>
    [JsonPropertyName("settlement_date")]
    public required DateOnly SettlementDate { get; set; }

    /// <summary>
    /// The settlement amount at early settlement
    /// </summary>
    [JsonPropertyName("settlement_amount")]
    public required string SettlementAmount { get; set; }

    /// <summary>
    /// The internal rate of return at early settlement
    /// </summary>
    [JsonPropertyName("settlement_irr")]
    public required string SettlementIrr { get; set; }

    /// <summary>
    /// The original internal rate of return before early settlement
    /// </summary>
    [JsonPropertyName("original_irr")]
    public string? OriginalIrr { get; set; }

    /// <summary>
    /// The minimum fee applicable at early settlement
    /// </summary>
    [JsonPropertyName("minimum_fee")]
    public string? MinimumFee { get; set; }

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
