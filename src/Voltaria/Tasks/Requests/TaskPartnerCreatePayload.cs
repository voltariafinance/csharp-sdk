using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record TaskPartnerCreatePayload
{
    /// <summary>
    /// Short title of the task.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    /// <summary>
    /// Optional longer description of what needs to be done.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Task priority. One of the following: low, medium, high, urgent
    /// </summary>
    [JsonPropertyName("priority")]
    public TaskPriorityEnum? Priority { get; set; }

    /// <summary>
    /// Optional due date for the task.
    /// </summary>
    [JsonPropertyName("due_at")]
    public DateTime? DueAt { get; set; }

    /// <summary>
    /// Client this task relates to. Must belong to your partner account.
    /// </summary>
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    /// <summary>
    /// Loan this task relates to. Must belong to your partner account.
    /// </summary>
    [JsonPropertyName("loan_id")]
    public string? LoanId { get; set; }

    /// <summary>
    /// Installment this task relates to. Must belong to your partner account.
    /// </summary>
    [JsonPropertyName("installment_id")]
    public string? InstallmentId { get; set; }

    /// <summary>
    /// Waterfall this task relates to. Must belong to your partner account.
    /// </summary>
    [JsonPropertyName("waterfall_id")]
    public string? WaterfallId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
