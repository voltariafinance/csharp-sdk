using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record LimitRequestResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the limit request
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The ID of the client associated with the limit request
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    /// <summary>
    /// The status of the limit request. One of the following: pending, approved, rejected
    /// </summary>
    [JsonPropertyName("status")]
    public required LimitRequestStatusEnum Status { get; set; }

    /// <summary>
    /// The requested limit amount
    /// </summary>
    [JsonPropertyName("requested_limit")]
    public required string RequestedLimit { get; set; }

    /// <summary>
    /// The reason for the limit request
    /// </summary>
    [JsonPropertyName("reason")]
    public required string Reason { get; set; }

    /// <summary>
    /// The response to the limit request
    /// </summary>
    [JsonPropertyName("response")]
    public string? Response { get; set; }

    /// <summary>
    /// The ID of the waiver associated with this limit request
    /// </summary>
    [JsonPropertyName("waiver_id")]
    public string? WaiverId { get; set; }

    /// <summary>
    /// The timestamp when the limit request was created
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

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
