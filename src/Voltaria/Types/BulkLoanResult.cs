using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record BulkLoanResult : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Number of successfully created loans
    /// </summary>
    [JsonPropertyName("success_count")]
    public required int SuccessCount { get; set; }

    /// <summary>
    /// Number of failed loans
    /// </summary>
    [JsonPropertyName("failure_count")]
    public required int FailureCount { get; set; }

    /// <summary>
    /// Total number of loans processed
    /// </summary>
    [JsonPropertyName("total_processed")]
    public required int TotalProcessed { get; set; }

    /// <summary>
    /// Time taken to process all loans
    /// </summary>
    [JsonPropertyName("processing_time_seconds")]
    public required double ProcessingTimeSeconds { get; set; }

    /// <summary>
    /// Detailed results for each loan
    /// </summary>
    [JsonPropertyName("results")]
    public IEnumerable<BulkLoanItemResult> Results { get; set; } = new List<BulkLoanItemResult>();

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
