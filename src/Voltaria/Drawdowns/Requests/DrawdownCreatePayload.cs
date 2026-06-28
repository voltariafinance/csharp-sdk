using global::System.Text.Json.Serialization;
using OneOf;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record DrawdownCreatePayload
{
    /// <summary>
    /// The amount for the drawdown.
    /// </summary>
    [JsonPropertyName("amount")]
    public required OneOf<double, string> Amount { get; set; }

    /// <summary>
    /// The date for the drawdown. If not provided, defaults to the current date and time.
    /// </summary>
    [JsonPropertyName("drawdown_date")]
    public DateTime? DrawdownDate { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
