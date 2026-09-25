using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

/// <summary>
/// A task shared with your partner account.
/// </summary>
[Serializable]
public record TaskPartnerResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the task.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Short title of the task.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    /// <summary>
    /// Longer description of what needs to be done.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The status of the task. One of the following: active, in_progress, blocked, review_needed, done, cancelled
    /// </summary>
    [JsonPropertyName("status")]
    public required TaskStatusEnum Status { get; set; }

    /// <summary>
    /// Task priority. One of the following: low, medium, high, urgent
    /// </summary>
    [JsonPropertyName("priority")]
    public TaskPriorityEnum? Priority { get; set; }

    /// <summary>
    /// The user on your team this task is assigned to. Null when nobody on your team has it — either it is unassigned, or Voltaria is handling it.
    /// </summary>
    [JsonPropertyName("assignee_id")]
    public string? AssigneeId { get; set; }

    /// <summary>
    /// When the task is due.
    /// </summary>
    [JsonPropertyName("due_at")]
    public DateTime? DueAt { get; set; }

    /// <summary>
    /// When the task was completed.
    /// </summary>
    [JsonPropertyName("completed_at")]
    public DateTime? CompletedAt { get; set; }

    /// <summary>
    /// When the task was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// When the task was last updated.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Your partner account the task belongs to.
    /// </summary>
    [JsonPropertyName("partner_id")]
    public string? PartnerId { get; set; }

    /// <summary>
    /// Client this task relates to.
    /// </summary>
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    /// <summary>
    /// Loan this task relates to.
    /// </summary>
    [JsonPropertyName("loan_id")]
    public string? LoanId { get; set; }

    /// <summary>
    /// Installment this task relates to.
    /// </summary>
    [JsonPropertyName("installment_id")]
    public string? InstallmentId { get; set; }

    /// <summary>
    /// Waterfall this task relates to.
    /// </summary>
    [JsonPropertyName("waterfall_id")]
    public string? WaterfallId { get; set; }

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
