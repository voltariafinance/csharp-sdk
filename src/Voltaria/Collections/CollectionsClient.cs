using global::System.Text.Json;
using Voltaria.Core;

namespace Voltaria;

public partial class CollectionsClient : ICollectionsClient
{
    private readonly RawClient _client;

    internal CollectionsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<
        WithRawResponse<PaginatedResponseCollectionActionResponse>
    > ListCollectionActionsAsyncCore(
        ListCollectionActionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Voltaria.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("page", request.Page)
            .Add("page_size", request.PageSize)
            .Add("order_by", request.OrderBy)
            .Add("q", request.Q)
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
                    Path = "v2/collection-actions",
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
                var responseData = JsonUtils.Deserialize<PaginatedResponseCollectionActionResponse>(
                    responseBody
                )!;
                return new WithRawResponse<PaginatedResponseCollectionActionResponse>()
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
        WithRawResponse<PaginatedResponseCollectionActionLogResponse>
    > ListCollectionActionLogsAsyncCore(
        ListCollectionActionLogsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Voltaria.Core.QueryStringBuilder.Builder(capacity: 9)
            .Add("client_id", request.ClientId)
            .Add("loan_id", request.LoanId)
            .Add("installment_id", request.InstallmentId)
            .Add("status", request.Status)
            .Add("action_type", request.ActionType)
            .Add("page", request.Page)
            .Add("page_size", request.PageSize)
            .Add("order_by", request.OrderBy)
            .Add("q", request.Q)
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
                    Path = "v2/collection-actions/logs",
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
                    JsonUtils.Deserialize<PaginatedResponseCollectionActionLogResponse>(
                        responseBody
                    )!;
                return new WithRawResponse<PaginatedResponseCollectionActionLogResponse>()
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
        WithRawResponse<CollectionActionLogResponse>
    > UpdateCollectionActionLogAsyncCore(
        CollectionActionLogUpdatePayload request,
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
                    Method = HttpMethodExtensions.Patch,
                    Path = string.Format(
                        "v2/collection-actions/logs/{0}",
                        ValueConvert.ToPathParameterString(request.LogId)
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
                var responseData = JsonUtils.Deserialize<CollectionActionLogResponse>(
                    responseBody
                )!;
                return new WithRawResponse<CollectionActionLogResponse>()
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

    /// <summary>
    /// Retrieve all collection actions configured for your partner account.
    /// </summary>
    /// <example><code>
    /// await client.Collections.ListCollectionActionsAsync(new ListCollectionActionsRequest());
    /// </code></example>
    public WithRawResponseTask<PaginatedResponseCollectionActionResponse> ListCollectionActionsAsync(
        ListCollectionActionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PaginatedResponseCollectionActionResponse>(
            ListCollectionActionsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve collection action logs for your partner account. Supports filtering by client, loan, installment, status, or action type.
    /// </summary>
    /// <example><code>
    /// await client.Collections.ListCollectionActionLogsAsync(new ListCollectionActionLogsRequest());
    /// </code></example>
    public WithRawResponseTask<PaginatedResponseCollectionActionLogResponse> ListCollectionActionLogsAsync(
        ListCollectionActionLogsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PaginatedResponseCollectionActionLogResponse>(
            ListCollectionActionLogsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Update the status and notes of a collection action log.
    /// </summary>
    /// <example><code>
    /// await client.Collections.UpdateCollectionActionLogAsync(
    ///     new CollectionActionLogUpdatePayload
    ///     {
    ///         LogId = "log_id",
    ///         Status = CollectionActionLogUpdatePayloadStatus.Completed,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CollectionActionLogResponse> UpdateCollectionActionLogAsync(
        CollectionActionLogUpdatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CollectionActionLogResponse>(
            UpdateCollectionActionLogAsyncCore(request, options, cancellationToken)
        );
    }
}
