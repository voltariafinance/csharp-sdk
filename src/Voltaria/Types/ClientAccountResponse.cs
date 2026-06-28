using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record ClientAccountResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique account identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Name of the account holder.
    /// </summary>
    [JsonPropertyName("account_holder_name")]
    public required string AccountHolderName { get; set; }

    /// <summary>
    /// Optional label / nickname for the account.
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label { get; set; }

    /// <summary>
    /// Account holder type. One of: `business`, `private`.
    /// </summary>
    [JsonPropertyName("account_holder_type")]
    public required AccountHolderTypeEnum AccountHolderType { get; set; }

    /// <summary>
    /// ISO 4217 currency code.
    /// </summary>
    [JsonPropertyName("currency")]
    public required CurrencyEnum Currency { get; set; }

    /// <summary>
    /// Sort code (GBP accounts).
    /// </summary>
    [JsonPropertyName("sort_code")]
    public string? SortCode { get; set; }

    /// <summary>
    /// Account number (GBP / USD accounts).
    /// </summary>
    [JsonPropertyName("account_number")]
    public string? AccountNumber { get; set; }

    /// <summary>
    /// IBAN (EUR / CZK / PLN accounts).
    /// </summary>
    [JsonPropertyName("iban")]
    public string? Iban { get; set; }

    /// <summary>
    /// BIC / SWIFT code (EUR accounts).
    /// </summary>
    [JsonPropertyName("bic")]
    public string? Bic { get; set; }

    /// <summary>
    /// Routing number (USD accounts).
    /// </summary>
    [JsonPropertyName("routing_number")]
    public string? RoutingNumber { get; set; }

    /// <summary>
    /// Account type (USD accounts). E.g. `checking` or `savings`.
    /// </summary>
    [JsonPropertyName("account_type")]
    public string? AccountType { get; set; }

    /// <summary>
    /// Account holder address (USD accounts).
    /// </summary>
    [JsonPropertyName("address")]
    public AccountAddress? Address { get; set; }

    /// <summary>
    /// Account status. One of: `pending`, `active`, `passive`.
    /// </summary>
    [JsonPropertyName("status")]
    public required AccountStatusEnum Status { get; set; }

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
