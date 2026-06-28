using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record BulkRepaymentResult : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Number of successfully processed repayments
    /// </summary>
    [JsonPropertyName("success_count")]
    public required int SuccessCount { get; set; }

    /// <summary>
    /// Number of failed repayments
    /// </summary>
    [JsonPropertyName("failure_count")]
    public required int FailureCount { get; set; }

    /// <summary>
    /// Total number of repayments processed
    /// </summary>
    [JsonPropertyName("total_processed")]
    public required int TotalProcessed { get; set; }

    /// <summary>
    /// Time taken to process all repayments
    /// </summary>
    [JsonPropertyName("processing_time_seconds")]
    public required double ProcessingTimeSeconds { get; set; }

    /// <summary>
    /// Detailed results for each repayment
    /// </summary>
    [JsonPropertyName("results")]
    public IEnumerable<BulkRepaymentItemResult> Results { get; set; } =
        new List<BulkRepaymentItemResult>();

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
