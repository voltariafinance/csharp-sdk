using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record LoanReviewRequestCreatePayload
{
    /// <summary>
    /// The ID of the loan to be reviewed. Must be a not-yet-disbursed (pending or pre-approved) loan belonging to the current partner
    /// </summary>
    [JsonPropertyName("loan_id")]
    public required string LoanId { get; set; }

    /// <summary>
    /// Optional note from the requester explaining the review request
    /// </summary>
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
