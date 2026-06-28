using global::System.Text.Json.Serialization;
using OneOf;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record PaymentPromiseCreatePayload
{
    /// <summary>
    /// The ID of the installment this promise relates to
    /// </summary>
    [JsonPropertyName("installment_id")]
    public required string InstallmentId { get; set; }

    /// <summary>
    /// The amount the client has promised to pay (must be &gt; 0)
    /// </summary>
    [JsonPropertyName("amount")]
    public required OneOf<double, string> Amount { get; set; }

    /// <summary>
    /// The date the client has committed to pay by (today or future)
    /// </summary>
    [JsonPropertyName("promised_date")]
    public required DateOnly PromisedDate { get; set; }

    /// <summary>
    /// Optional notes captured during the collections interaction
    /// </summary>
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
