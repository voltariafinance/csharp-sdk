namespace Voltaria;

public partial interface IWebhooksClient
{
    /// <summary>
    /// List all webhook subscriptions for your partner account.
    /// </summary>
    WithRawResponseTask<PaginatedResponseWebhookSubscriptionResponse> ListWebhookSubscriptionsAsync(
        ListWebhookSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new webhook subscription for a specific event type.
    /// </summary>
    WithRawResponseTask<WebhookSubscriptionResponse> CreateWebhookSubscriptionAsync(
        WebhookCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details for a specific webhook subscription with its webhook ID.
    /// </summary>
    WithRawResponseTask<WebhookSubscriptionResponse> GetWebhookSubscriptionAsync(
        GetWebhookSubscriptionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a webhook subscription with its specific webhook ID.
    /// </summary>
    WithRawResponseTask<WebhookSubscriptionResponse> UpdateWebhookSubscriptionAsync(
        WebhookUpdatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a specific webhook subscription.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> DeleteWebhookSubscriptionAsync(
        DeleteWebhookSubscriptionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all webhook logs linked to your partner account.
    /// </summary>
    WithRawResponseTask<PaginatedResponseWebhookLogResponse> ListWebhookLogsAsync(
        ListWebhookLogsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
