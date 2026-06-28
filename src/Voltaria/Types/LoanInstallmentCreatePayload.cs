using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record LoanInstallmentCreatePayload : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The expected repayment date for this installment
    /// </summary>
    [JsonPropertyName("expected_repayment_at")]
    public required DateOnly ExpectedRepaymentAt { get; set; }

    /// <summary>
    /// The amount due for this installment
    /// </summary>
    [JsonPropertyName("amount")]
    public required OneOf<double, string> Amount { get; set; }

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
