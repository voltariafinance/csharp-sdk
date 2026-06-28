using global::System.Text.Json;
using Voltaria.Core;

namespace Voltaria;

public partial class RepaymentsClient : IRepaymentsClient
{
    private readonly RawClient _client;

    internal RepaymentsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<
        WithRawResponse<PaginatedResponseRepaymentResponseWithClientInfo>
    > ListRepaymentLogsAsyncCore(
        ListRepaymentLogsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Voltaria.Core.QueryStringBuilder.Builder(capacity: 7)
            .Add("client_id", request.ClientId)
            .Add("loan_id", request.LoanId)
            .Add("installment_id", request.InstallmentId)
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
                    Path = "v2/repayments",
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
                    JsonUtils.Deserialize<PaginatedResponseRepaymentResponseWithClientInfo>(
                        responseBody
                    )!;
                return new WithRawResponse<PaginatedResponseRepaymentResponseWithClientInfo>()
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

    private async Task<WithRawResponse<RepaymentResponse>> CreateRepaymentAsyncCore(
        RepaymentCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Voltaria.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("installment_id", request.InstallmentId)
            .Add("loan_id", request.LoanId)
            .Add("correlation_id", request.CorrelationId)
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
                    Method = HttpMethod.Post,
                    Path = "v2/repayments",
                    Body = request,
                    QueryString = _queryString,
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
                var responseData = JsonUtils.Deserialize<RepaymentResponse>(responseBody)!;
                return new WithRawResponse<RepaymentResponse>()
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

    private async Task<WithRawResponse<BulkRepaymentTaskResponse>> CreateBulkRepaymentsAsyncCore(
        BulkRepaymentCreatePayload request,
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
                    Path = "v2/repayments/bulk",
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
                var responseData = JsonUtils.Deserialize<BulkRepaymentTaskResponse>(responseBody)!;
                return new WithRawResponse<BulkRepaymentTaskResponse>()
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

    private async Task<WithRawResponse<BulkRepaymentTaskStatus>> GetBulkRepaymentStatusAsyncCore(
        GetBulkRepaymentStatusRequest request,
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
                        "v2/repayments/bulk/{0}",
                        ValueConvert.ToPathParameterString(request.TaskId)
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
                var responseData = JsonUtils.Deserialize<BulkRepaymentTaskStatus>(responseBody)!;
                return new WithRawResponse<BulkRepaymentTaskStatus>()
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
    /// Retrieve all repayments made under your partner account. Supports filtering by client, loan, or installments.
    /// </summary>
    /// <example><code>
    /// await client.Repayments.ListRepaymentLogsAsync(new ListRepaymentLogsRequest());
    /// </code></example>
    public WithRawResponseTask<PaginatedResponseRepaymentResponseWithClientInfo> ListRepaymentLogsAsync(
        ListRepaymentLogsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PaginatedResponseRepaymentResponseWithClientInfo>(
            ListRepaymentLogsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Create a new repayment log for an installment. Requires the installment ID, loan ID or loan correlation ID.
    /// </summary>
    /// <example><code>
    /// await client.Repayments.CreateRepaymentAsync(new RepaymentCreatePayload { Amount = 1.1 });
    /// </code></example>
    public WithRawResponseTask<RepaymentResponse> CreateRepaymentAsync(
        RepaymentCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<RepaymentResponse>(
            CreateRepaymentAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Initiate processing of up to 10000 repayment logs. Returns task_id for tracking progress.
    /// </summary>
    /// <example><code>
    /// await client.Repayments.CreateBulkRepaymentsAsync(
    ///     new BulkRepaymentCreatePayload
    ///     {
    ///         Repayments = new List&lt;BulkRepaymentItemPayload&gt;()
    ///         {
    ///             new BulkRepaymentItemPayload
    ///             {
    ///                 Amount = "1000.00",
    ///                 RepaymentDate = new DateTime(2023, 10, 01, 12, 00, 00, 000),
    ///                 Data = new Dictionary&lt;string, object?&gt;()
    ///                 {
    ///                     { "reference", "TXN-001" },
    ///                     { "type", "transfer" },
    ///                 },
    ///                 InstallmentId = "installment_123",
    ///             },
    ///             new BulkRepaymentItemPayload
    ///             {
    ///                 Amount = "500.50",
    ///                 Data = new Dictionary&lt;string, object?&gt;()
    ///                 {
    ///                     { "notes", "Payment received in office" },
    ///                     { "type", "cash" },
    ///                 },
    ///                 LoanId = "loan_456",
    ///             },
    ///             new BulkRepaymentItemPayload
    ///             {
    ///                 Amount = "750.00",
    ///                 RepaymentDate = new DateTime(2023, 09, 30, 15, 30, 00, 000),
    ///                 CorrelationId = "LOAN-789",
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<BulkRepaymentTaskResponse> CreateBulkRepaymentsAsync(
        BulkRepaymentCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<BulkRepaymentTaskResponse>(
            CreateBulkRepaymentsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Check the progress and results of a bulk repayment processing task.
    /// </summary>
    /// <example><code>
    /// await client.Repayments.GetBulkRepaymentStatusAsync(
    ///     new GetBulkRepaymentStatusRequest { TaskId = "task_id" }
    /// );
    /// </code></example>
    public WithRawResponseTask<BulkRepaymentTaskStatus> GetBulkRepaymentStatusAsync(
        GetBulkRepaymentStatusRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<BulkRepaymentTaskStatus>(
            GetBulkRepaymentStatusAsyncCore(request, options, cancellationToken)
        );
    }
}
