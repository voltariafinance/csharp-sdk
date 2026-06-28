using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record BulkLoanCreatePayload
{
    /// <summary>
    /// List of loans to create (max 1000)
    /// </summary>
    [JsonPropertyName("loans")]
    public IEnumerable<BulkLoanItemPayload> Loans { get; set; } = new List<BulkLoanItemPayload>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
