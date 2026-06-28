using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record WebhookTestSandbox
{
    /// <summary>
    /// The ID of the webhook subscription. Only this webhook will be triggered if provided.
    /// </summary>
    [JsonPropertyName("webhook_id")]
    public string? WebhookId { get; set; }

    /// <summary>
    /// Event type to trigger for the test. All subscriptions for this event type will be triggered if webhook_id is not provided.Possible values: loan_updated, installment_updated, client_updated, client_limit_updated, partner_limit_updated
    /// </summary>
    [JsonPropertyName("event_type")]
    public required WebhookEventTypeEnum EventType { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
