using global::System.Text.Json.Serialization;
using OneOf;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record InstallmentEditPayload
{
    [JsonIgnore]
    public required string InstallmentId { get; set; }

    /// <summary>
    /// The new amount for the installment
    /// </summary>
    [JsonPropertyName("amount")]
    public required OneOf<double, string> Amount { get; set; }

    /// <summary>
    /// The new expected repayment date
    /// </summary>
    [JsonPropertyName("expected_repayment_at")]
    public required DateOnly ExpectedRepaymentAt { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
