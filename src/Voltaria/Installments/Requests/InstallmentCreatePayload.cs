using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record InstallmentCreatePayload
{
    /// <summary>
    /// The loan ID to add the installments to
    /// </summary>
    [JsonPropertyName("loan_id")]
    public required string LoanId { get; set; }

    /// <summary>
    /// List of installments to add to the loan
    /// </summary>
    [JsonPropertyName("installments")]
    public IEnumerable<LoanInstallmentCreatePayload> Installments { get; set; } =
        new List<LoanInstallmentCreatePayload>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
