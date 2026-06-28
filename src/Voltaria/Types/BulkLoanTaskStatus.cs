using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record BulkLoanTaskStatus : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Task ID
    /// </summary>
    [JsonPropertyName("task_id")]
    public required string TaskId { get; set; }

    /// <summary>
    /// Task status (PENDING, PROGRESS, SUCCESS, FAILURE)
    /// </summary>
    [JsonPropertyName("status")]
    public required string Status { get; set; }

    /// <summary>
    /// Current loan being processed
    /// </summary>
    [JsonPropertyName("current")]
    public int? Current { get; set; }

    /// <summary>
    /// Total loans to process
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// Final result if completed
    /// </summary>
    [JsonPropertyName("result")]
    public BulkLoanResult? Result { get; set; }

    /// <summary>
    /// Error message if task failed
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }

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
