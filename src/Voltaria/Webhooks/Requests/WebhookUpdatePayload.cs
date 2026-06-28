using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record WebhookUpdatePayload
{
    [JsonIgnore]
    public required string WebhookId { get; set; }

    /// <summary>
    /// The URL to send webhooks to
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Description of this webhook endpoint
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Event type to subscribe toPossible values: loan_updated, installment_updated, client_updated, client_limit_updated, partner_limit_updated
    /// </summary>
    [JsonPropertyName("event_type")]
    public WebhookEventTypeEnum? EventType { get; set; }

    /// <summary>
    /// Status of the webhook subscriptionPossible values: active, paused, disabled
    /// </summary>
    [JsonPropertyName("status")]
    public WebhookStatusEnum? Status { get; set; }

    /// <summary>
    /// Whether to retry failed webhooks
    /// </summary>
    [JsonPropertyName("retry")]
    public bool? Retry { get; set; }

    /// <summary>
    /// Secret for signing webhook payloads
    /// </summary>
    [JsonPropertyName("secret")]
    public string? Secret { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
