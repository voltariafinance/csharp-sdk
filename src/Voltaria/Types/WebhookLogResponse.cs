using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record WebhookLogResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the webhook log
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The ID of the webhook subscription
    /// </summary>
    [JsonPropertyName("webhook_id")]
    public required string WebhookId { get; set; }

    /// <summary>
    /// Creation timestamp
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// Last update timestamp
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// The type of event
    /// </summary>
    [JsonPropertyName("event_type")]
    public required WebhookEventTypeEnum EventType { get; set; }

    /// <summary>
    /// The URL of the webhook subscription
    /// </summary>
    [JsonPropertyName("webhook_url")]
    public required string WebhookUrl { get; set; }

    /// <summary>
    /// Whether the webhook was delivered successfully
    /// </summary>
    [JsonPropertyName("success")]
    public required bool Success { get; set; }

    /// <summary>
    /// The HTTP status code returned by the server
    /// </summary>
    [JsonPropertyName("status_code")]
    public int? StatusCode { get; set; }

    /// <summary>
    /// Error message if the webhook failed
    /// </summary>
    [JsonPropertyName("error_message")]
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// The time taken to deliver the webhook in milliseconds
    /// </summary>
    [JsonPropertyName("request_duration_ms")]
    public int? RequestDurationMs { get; set; }

    /// <summary>
    /// The request body sent to the webhook URL
    /// </summary>
    [JsonPropertyName("request_body")]
    public OneOf<Dictionary<string, object?>, IEnumerable<object>>? RequestBody { get; set; }

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
