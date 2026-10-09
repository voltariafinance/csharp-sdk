using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record LoanUpdateSandbox
{
    [JsonIgnore]
    public required string LoanId { get; set; }

    /// <summary>
    /// The status of the loan. One of the following: `pending, overdue, active, default, sold, restructured, repaid, pre_approved, rejected, inactive`. Use the delete loan endpoint to delete a loan.
    /// </summary>
    [JsonPropertyName("status")]
    public LoanStatusEnum? Status { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
