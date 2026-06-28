using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record BulkRepaymentTaskResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Task ID for tracking progress
    /// </summary>
    [JsonPropertyName("task_id")]
    public required string TaskId { get; set; }

    /// <summary>
    /// Number of repayments to process
    /// </summary>
    [JsonPropertyName("total_repayments")]
    public required int TotalRepayments { get; set; }

    /// <summary>
    /// Estimated completion time
    /// </summary>
    [JsonPropertyName("estimated_completion_time")]
    public required string EstimatedCompletionTime { get; set; }

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
