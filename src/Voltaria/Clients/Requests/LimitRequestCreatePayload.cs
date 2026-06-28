using global::System.Text.Json.Serialization;
using OneOf;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record LimitRequestCreatePayload
{
    /// <summary>
    /// The ID of the client for which the limit request is being created
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    /// <summary>
    /// The requested credit limit amount
    /// </summary>
    [JsonPropertyName("requested_limit")]
    public required OneOf<double, string> RequestedLimit { get; set; }

    /// <summary>
    /// The reason for the limit request
    /// </summary>
    [JsonPropertyName("reason")]
    public required string Reason { get; set; }

    /// <summary>
    /// Whether a special waiver is requested alongside this limit request
    /// </summary>
    [JsonPropertyName("waiver_request")]
    public bool? WaiverRequest { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
