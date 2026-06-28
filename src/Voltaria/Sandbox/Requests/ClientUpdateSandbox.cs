using global::System.Text.Json.Serialization;
using OneOf;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record ClientUpdateSandbox
{
    [JsonIgnore]
    public required string ClientId { get; set; }

    /// <summary>
    /// The status of the client. One of the following: `active, rejected, deactivated, pending, pending_onboarding, pre_approved, deleted, inactive`
    /// </summary>
    [JsonPropertyName("status")]
    public ClientStatusEnum? Status { get; set; }

    /// <summary>
    /// The limit to set for the client. This will override the existing limit.
    /// </summary>
    [JsonPropertyName("limit")]
    public OneOf<double, string>? Limit { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
