using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record WebhookCreatePayload
{
    /// <summary>
    /// The URL to send webhooks to
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; set; }

    /// <summary>
    /// Optional description of this webhook endpoint
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Event type to subscribe toPossible values: loan_updated, installment_updated, client_updated, client_limit_updated, partner_limit_updated
    /// </summary>
    [JsonPropertyName("event_type")]
    public required WebhookEventTypeEnum EventType { get; set; }

    /// <summary>
    /// Secret for signing webhook payloads
    /// </summary>
    [JsonPropertyName("secret")]
    public required string Secret { get; set; }

    /// <summary>
    /// Whether to retry failed webhooks
    /// </summary>
    [JsonPropertyName("retry")]
    public bool? Retry { get; set; }

    /// <summary>
    /// Status of the webhook subscription. Defaults to 'active'.Possible values: active, paused, disabled
    /// </summary>
    [JsonPropertyName("status")]
    public WebhookStatusEnum? Status { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
