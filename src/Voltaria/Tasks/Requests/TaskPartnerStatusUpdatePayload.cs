using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record TaskPartnerStatusUpdatePayload
{
    [JsonIgnore]
    public required string TaskId { get; set; }

    /// <summary>
    /// The new status of the task. One of the following: active, in_progress, blocked, done. You can move a task to any of these at any time, so one closed by mistake can be reopened. Every change is kept in the task's status history.
    /// </summary>
    [JsonPropertyName("status")]
    public required TaskPartnerStatusUpdatePayloadStatus Status { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
