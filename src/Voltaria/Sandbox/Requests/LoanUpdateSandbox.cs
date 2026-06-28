using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record LoanUpdateSandbox
{
    [JsonIgnore]
    public required string LoanId { get; set; }

    /// <summary>
    /// The status of the client. One of the following: `pending, overdue, active, default, sold, restructured, repaid, pre_approved, rejected, deleted, inactive`
    /// </summary>
    [JsonPropertyName("status")]
    public LoanStatusEnum? Status { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
