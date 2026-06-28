using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record WebhookSubscriptionResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the webhook subscription
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The URL to send webhooks to
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; set; }

    /// <summary>
    /// Description of this webhook endpoint
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Event type subscribed toPossible values: loan_updated, installment_updated, client_updated, client_limit_updated, partner_limit_updated
    /// </summary>
    [JsonPropertyName("event_type")]
    public required WebhookEventTypeEnum EventType { get; set; }

    /// <summary>
    /// Status of the webhook subscriptionPossible values: active, paused, disabled
    /// </summary>
    [JsonPropertyName("status")]
    public required WebhookStatusEnum Status { get; set; }

    /// <summary>
    /// Whether to retry failed webhooks
    /// </summary>
    [JsonPropertyName("retry")]
    public required bool Retry { get; set; }

    /// <summary>
    /// Secret for signing webhook payloads
    /// </summary>
    [JsonPropertyName("secret")]
    public required string Secret { get; set; }

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
