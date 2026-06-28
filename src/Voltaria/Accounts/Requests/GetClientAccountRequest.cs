using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record GetClientAccountRequest
{
    [JsonIgnore]
    public required string ClientId { get; set; }

    [JsonIgnore]
    public required string AccountId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
