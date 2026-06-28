using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record PartnerClientAccountCreateRequest
{
    [JsonIgnore]
    public required string ClientId { get; set; }

    /// <summary>
    /// Full name of the account holder.
    /// </summary>
    [JsonPropertyName("account_holder_name")]
    public required string AccountHolderName { get; set; }

    /// <summary>
    /// Optional label / nickname for the account (max 50 characters).
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label { get; set; }

    /// <summary>
    /// Account holder type. One of: `business`, `private`.
    /// </summary>
    [JsonPropertyName("account_holder_type")]
    public required AccountHolderTypeEnum AccountHolderType { get; set; }

    /// <summary>
    /// ISO 4217 currency code. Use `/accounts/fields` to get required fields per currency.
    /// </summary>
    [JsonPropertyName("currency")]
    public required CurrencyEnum Currency { get; set; }

    /// <summary>
    /// Sort code (required for GBP).
    /// </summary>
    [JsonPropertyName("sort_code")]
    public string? SortCode { get; set; }

    /// <summary>
    /// Account number (required for GBP and USD).
    /// </summary>
    [JsonPropertyName("account_number")]
    public string? AccountNumber { get; set; }

    /// <summary>
    /// IBAN (required for EUR, CZK, PLN).
    /// </summary>
    [JsonPropertyName("iban")]
    public string? Iban { get; set; }

    /// <summary>
    /// BIC / SWIFT code (optional for EUR).
    /// </summary>
    [JsonPropertyName("bic")]
    public string? Bic { get; set; }

    /// <summary>
    /// ABA routing number (required for USD).
    /// </summary>
    [JsonPropertyName("routing_number")]
    public string? RoutingNumber { get; set; }

    /// <summary>
    /// Account type (required for USD). E.g. `checking` or `savings`.
    /// </summary>
    [JsonPropertyName("account_type")]
    public string? AccountType { get; set; }

    /// <summary>
    /// Account holder address (required for USD).
    /// </summary>
    [JsonPropertyName("address")]
    public AccountAddress? Address { get; set; }

    /// <summary>
    /// Account status. `active` demotes any existing active account in the same currency to `passive`; `passive` is added as a backup. Defaults to `active`.
    /// </summary>
    [JsonPropertyName("status")]
    public PartnerClientAccountCreateRequestStatus? Status { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
