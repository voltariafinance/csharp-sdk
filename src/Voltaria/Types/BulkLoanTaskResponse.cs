using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record BulkLoanTaskResponse : IJsonOnDeserialized
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
    /// Number of loans to process
    /// </summary>
    [JsonPropertyName("total_loans")]
    public required int TotalLoans { get; set; }

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
