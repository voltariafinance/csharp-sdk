using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record PaymentPromiseResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the payment promise
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// When the promise was created
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// When the promise was last updated
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// The ID of the installment this promise relates to
    /// </summary>
    [JsonPropertyName("installment_id")]
    public required string InstallmentId { get; set; }

    /// <summary>
    /// The ID of the partner the installment belongs to
    /// </summary>
    [JsonPropertyName("partner_id")]
    public required string PartnerId { get; set; }

    /// <summary>
    /// The ID of the client the installment belongs to
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    /// <summary>
    /// The ID of the loan the installment belongs to
    /// </summary>
    [JsonPropertyName("loan_id")]
    public required string LoanId { get; set; }

    /// <summary>
    /// The amount the client has promised to pay
    /// </summary>
    [JsonPropertyName("amount")]
    public required string Amount { get; set; }

    /// <summary>
    /// The date the client has committed to pay by
    /// </summary>
    [JsonPropertyName("promised_date")]
    public required DateOnly PromisedDate { get; set; }

    /// <summary>
    /// The status of the promise
    /// </summary>
    [JsonPropertyName("status")]
    public required PaymentPromiseStatusEnum Status { get; set; }

    /// <summary>
    /// Optional notes captured during the collections interaction
    /// </summary>
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

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
