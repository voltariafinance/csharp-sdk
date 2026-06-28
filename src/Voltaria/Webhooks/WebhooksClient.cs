using global::System.Text.Json;
using Voltaria.Core;

namespace Voltaria;

public partial class WebhooksClient : IWebhooksClient
{
    private readonly RawClient _client;

    internal WebhooksClient(RawClient client)
    {
        _client = client;
    }

    private async Task<
        WithRawResponse<PaginatedResponseWebhookSubscriptionResponse>
    > ListWebhookSubscriptionsAsyncCore(
        ListWebhookSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Voltaria.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("page", request.Page)
            .Add("page_size", request.PageSize)
            .Add("event_type", request.EventType)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Voltaria.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v2/webhooks/subscriptions",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData =
                    JsonUtils.Deserialize<PaginatedResponseWebhookSubscriptionResponse>(
                        responseBody
                    )!;
                return new WithRawResponse<PaginatedResponseWebhookSubscriptionResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new VoltariaApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 422:
                        throw new UnprocessableEntityError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new VoltariaApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<WebhookSubscriptionResponse>
    > CreateWebhookSubscriptionAsyncCore(
        WebhookCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new Voltaria.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v2/webhooks/subscriptions",
                    Body = request,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<WebhookSubscriptionResponse>(
                    responseBody
                )!;
                return new WithRawResponse<WebhookSubscriptionResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new VoltariaApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 422:
                        throw new UnprocessableEntityError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new VoltariaApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<WebhookSubscriptionResponse>
    > GetWebhookSubscriptionAsyncCore(
        GetWebhookSubscriptionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new Voltaria.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/webhooks/subscriptions/{0}",
                        ValueConvert.ToPathParameterString(request.WebhookId)
                    ),
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<WebhookSubscriptionResponse>(
                    responseBody
                )!;
                return new WithRawResponse<WebhookSubscriptionResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new VoltariaApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 422:
                        throw new UnprocessableEntityError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new VoltariaApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<WebhookSubscriptionResponse>
    > UpdateWebhookSubscriptionAsyncCore(
        WebhookUpdatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new Voltaria.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "v2/webhooks/subscriptions/{0}",
                        ValueConvert.ToPathParameterString(request.WebhookId)
                    ),
                    Body = request,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<WebhookSubscriptionResponse>(
                    responseBody
                )!;
                return new WithRawResponse<WebhookSubscriptionResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new VoltariaApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 422:
                        throw new UnprocessableEntityError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new VoltariaApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<Dictionary<string, object?>>
    > DeleteWebhookSubscriptionAsyncCore(
        DeleteWebhookSubscriptionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new Voltaria.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "v2/webhooks/subscriptions/{0}",
                        ValueConvert.ToPathParameterString(request.WebhookId)
                    ),
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new VoltariaApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 422:
                        throw new UnprocessableEntityError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new VoltariaApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<PaginatedResponseWebhookLogResponse>
    > ListWebhookLogsAsyncCore(
        ListWebhookLogsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Voltaria.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("webhook_id", request.WebhookId)
            .Add("page", request.Page)
            .Add("page_size", request.PageSize)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Voltaria.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v2/webhooks/logs",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PaginatedResponseWebhookLogResponse>(
                    responseBody
                )!;
                return new WithRawResponse<PaginatedResponseWebhookLogResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new VoltariaApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 422:
                        throw new UnprocessableEntityError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new VoltariaApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// List all webhook subscriptions for your partner account.
    /// </summary>
    /// <example><code>
    /// await client.Webhooks.ListWebhookSubscriptionsAsync(new ListWebhookSubscriptionsRequest());
    /// </code></example>
    public WithRawResponseTask<PaginatedResponseWebhookSubscriptionResponse> ListWebhookSubscriptionsAsync(
        ListWebhookSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PaginatedResponseWebhookSubscriptionResponse>(
            ListWebhookSubscriptionsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Create a new webhook subscription for a specific event type.
    /// </summary>
    /// <example><code>
    /// await client.Webhooks.CreateWebhookSubscriptionAsync(
    ///     new WebhookCreatePayload
    ///     {
    ///         Url = "https://example.com/webhooks",
    ///         Description = "Loan update event",
    ///         EventType = WebhookEventTypeEnum.LoanUpdated,
    ///         Secret = "whsec_f3o9p8h7g6j5k4l3m2n1o0p9i8u7y6t5",
    ///         Retry = false,
    ///         Status = WebhookStatusEnum.Active,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<WebhookSubscriptionResponse> CreateWebhookSubscriptionAsync(
        WebhookCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<WebhookSubscriptionResponse>(
            CreateWebhookSubscriptionAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve details for a specific webhook subscription with its webhook ID.
    /// </summary>
    /// <example><code>
    /// await client.Webhooks.GetWebhookSubscriptionAsync(
    ///     new GetWebhookSubscriptionRequest { WebhookId = "webhook_id" }
    /// );
    /// </code></example>
    public WithRawResponseTask<WebhookSubscriptionResponse> GetWebhookSubscriptionAsync(
        GetWebhookSubscriptionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<WebhookSubscriptionResponse>(
            GetWebhookSubscriptionAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Update a webhook subscription with its specific webhook ID.
    /// </summary>
    /// <example><code>
    /// await client.Webhooks.UpdateWebhookSubscriptionAsync(
    ///     new WebhookUpdatePayload
    ///     {
    ///         WebhookId = "webhook_id",
    ///         Url = "https://example.com/webhooks/v2",
    ///         Description = "Updated webhook endpoint",
    ///         EventType = WebhookEventTypeEnum.InstallmentUpdated,
    ///         Status = WebhookStatusEnum.Paused,
    ///         Retry = true,
    ///         Secret = "whsec_updated_secret_here",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<WebhookSubscriptionResponse> UpdateWebhookSubscriptionAsync(
        WebhookUpdatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<WebhookSubscriptionResponse>(
            UpdateWebhookSubscriptionAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Delete a specific webhook subscription.
    /// </summary>
    /// <example><code>
    /// await client.Webhooks.DeleteWebhookSubscriptionAsync(
    ///     new DeleteWebhookSubscriptionRequest { WebhookId = "webhook_id" }
    /// );
    /// </code></example>
    public WithRawResponseTask<Dictionary<string, object?>> DeleteWebhookSubscriptionAsync(
        DeleteWebhookSubscriptionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            DeleteWebhookSubscriptionAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve all webhook logs linked to your partner account.
    /// </summary>
    /// <example><code>
    /// await client.Webhooks.ListWebhookLogsAsync(new ListWebhookLogsRequest());
    /// </code></example>
    public WithRawResponseTask<PaginatedResponseWebhookLogResponse> ListWebhookLogsAsync(
        ListWebhookLogsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PaginatedResponseWebhookLogResponse>(
            ListWebhookLogsAsyncCore(request, options, cancellationToken)
        );
    }
}
