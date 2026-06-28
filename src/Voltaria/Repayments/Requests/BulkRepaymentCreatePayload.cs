using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record BulkRepaymentCreatePayload
{
    /// <summary>
    /// List of repayments to create (max 10000)
    /// </summary>
    [JsonPropertyName("repayments")]
    public IEnumerable<BulkRepaymentItemPayload> Repayments { get; set; } =
        new List<BulkRepaymentItemPayload>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
