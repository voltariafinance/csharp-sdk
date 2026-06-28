using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record BulkRepaymentItemResult : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Index of the repayment in the original request
    /// </summary>
    [JsonPropertyName("index")]
    public required int Index { get; set; }

    /// <summary>
    /// Whether the repayment was processed successfully
    /// </summary>
    [JsonPropertyName("success")]
    public required bool Success { get; set; }

    /// <summary>
    /// ID of the created repayment log if successful
    /// </summary>
    [JsonPropertyName("repayment_log_id")]
    public string? RepaymentLogId { get; set; }

    /// <summary>
    /// Error message if processing failed
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    /// <summary>
    /// ID of the associated installment
    /// </summary>
    [JsonPropertyName("installment_id")]
    public string? InstallmentId { get; set; }

    /// <summary>
    /// ID of the associated loan
    /// </summary>
    [JsonPropertyName("loan_id")]
    public string? LoanId { get; set; }

    /// <summary>
    /// Amount of the repayment
    /// </summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

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
