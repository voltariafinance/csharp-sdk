using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record LoanInstallmentResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the installment
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The amount of the installment
    /// </summary>
    [JsonPropertyName("amount")]
    public required string Amount { get; set; }

    /// <summary>
    /// The installment number in sequence
    /// </summary>
    [JsonPropertyName("installment_number")]
    public required int InstallmentNumber { get; set; }

    /// <summary>
    /// The expected repayment date of the installment
    /// </summary>
    [JsonPropertyName("expected_repayment_at")]
    public required DateTime ExpectedRepaymentAt { get; set; }

    /// <summary>
    /// The status of the installment
    /// </summary>
    [JsonPropertyName("status")]
    public required LoanStatusEnum Status { get; set; }

    /// <summary>
    /// The creation date of the installment
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The last update date of the installment
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

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
