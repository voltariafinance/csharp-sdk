using global::System.Text.Json;
using Voltaria.Core;

namespace Voltaria;

public partial class LoansClient : ILoansClient
{
    private readonly RawClient _client;

    internal LoansClient(RawClient client)
    {
        _client = client;
    }

    private async Task<
        WithRawResponse<PaginatedResponseLoanResponseWithClientInfo>
    > ListLoansAsyncCore(
        ListLoansRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Voltaria.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("page", request.Page)
            .Add("page_size", request.PageSize)
            .Add("client_id", request.ClientId)
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
                    Path = "v2/loans",
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
                    JsonUtils.Deserialize<PaginatedResponseLoanResponseWithClientInfo>(
                        responseBody
                    )!;
                return new WithRawResponse<PaginatedResponseLoanResponseWithClientInfo>()
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

    private async Task<WithRawResponse<LoanResponseWithInstallments>> CreateLoanAsyncCore(
        LoanCreatePayload request,
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
                    Path = "v2/loans",
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
                var responseData = JsonUtils.Deserialize<LoanResponseWithInstallments>(
                    responseBody
                )!;
                return new WithRawResponse<LoanResponseWithInstallments>()
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
                    case 409:
                        throw new ConflictError(JsonUtils.Deserialize<object>(responseBody));
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

    private async Task<WithRawResponse<LoanResponseWithInstallments>> GetLoanByIdAsyncCore(
        GetLoanByIdRequest request,
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
                        "v2/loans/{0}",
                        ValueConvert.ToPathParameterString(request.LoanId)
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
                var responseData = JsonUtils.Deserialize<LoanResponseWithInstallments>(
                    responseBody
                )!;
                return new WithRawResponse<LoanResponseWithInstallments>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>?>> DeleteLoanAsyncCore(
        DeleteLoanRequest request,
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
                        "v2/loans/{0}",
                        ValueConvert.ToPathParameterString(request.LoanId)
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
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>?>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>?>()
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
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
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

    private async Task<WithRawResponse<BulkLoanTaskResponse>> CreateBulkLoansAsyncCore(
        BulkLoanCreatePayload request,
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
                    Path = "v2/loans/bulk",
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
                var responseData = JsonUtils.Deserialize<BulkLoanTaskResponse>(responseBody)!;
                return new WithRawResponse<BulkLoanTaskResponse>()
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
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
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

    private async Task<WithRawResponse<BulkLoanTaskStatus>> GetBulkLoanStatusAsyncCore(
        GetBulkLoanStatusRequest request,
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
                        "v2/loans/bulk/{0}",
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
                var responseData = JsonUtils.Deserialize<BulkLoanTaskStatus>(responseBody)!;
                return new WithRawResponse<BulkLoanTaskStatus>()
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

    private async Task<WithRawResponse<LoanResponseWithInstallments>> SetLoanDefaultAsyncCore(
        LoanDefaultPayload request,
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
                    Path = string.Format(
                        "v2/loans/{0}/set-default",
                        ValueConvert.ToPathParameterString(request.LoanId)
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
                var responseData = JsonUtils.Deserialize<LoanResponseWithInstallments>(
                    responseBody
                )!;
                return new WithRawResponse<LoanResponseWithInstallments>()
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
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
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
    /// Retrieve all loans associated with your partner account. Supports optional filtering by client ID.
    /// </summary>
    /// <example><code>
    /// await client.Loans.ListLoansAsync(new ListLoansRequest());
    /// </code></example>
    public WithRawResponseTask<PaginatedResponseLoanResponseWithClientInfo> ListLoansAsync(
        ListLoansRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PaginatedResponseLoanResponseWithClientInfo>(
            ListLoansAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Create a new loan for an approved client with an active credit limit.
    /// </summary>
    /// <example><code>
    /// await client.Loans.CreateLoanAsync(
    ///     new LoanCreatePayload
    ///     {
    ///         ClientId = "client_ACME",
    ///         Currency = CurrencyEnum.Eur,
    ///         Amount = 1.1,
    ///         Installments = new List&lt;LoanInstallmentCreatePayload&gt;()
    ///         {
    ///             new LoanInstallmentCreatePayload
    ///             {
    ///                 ExpectedRepaymentAt = new DateOnly(2025, 12, 1),
    ///                 Amount = 1.1,
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<LoanResponseWithInstallments> CreateLoanAsync(
        LoanCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<LoanResponseWithInstallments>(
            CreateLoanAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve detailed information about a specific loan by its loan ID.
    /// </summary>
    /// <example><code>
    /// await client.Loans.GetLoanByIdAsync(new GetLoanByIdRequest { LoanId = "loan_id" });
    /// </code></example>
    public WithRawResponseTask<LoanResponseWithInstallments> GetLoanByIdAsync(
        GetLoanByIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<LoanResponseWithInstallments>(
            GetLoanByIdAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Delete a loan by ID. Only loans with 'pending' status can be deleted.
    /// </summary>
    /// <example><code>
    /// await client.Loans.DeleteLoanAsync(new DeleteLoanRequest { LoanId = "loan_id" });
    /// </code></example>
    public WithRawResponseTask<Dictionary<string, object?>?> DeleteLoanAsync(
        DeleteLoanRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>?>(
            DeleteLoanAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Create multiple loans in a single request. Processing happens asynchronously. Returns a task ID for tracking progress.
    /// </summary>
    /// <example><code>
    /// await client.Loans.CreateBulkLoansAsync(
    ///     new BulkLoanCreatePayload
    ///     {
    ///         Loans = new List&lt;BulkLoanItemPayload&gt;()
    ///         {
    ///             new BulkLoanItemPayload
    ///             {
    ///                 ClientId = "client_123",
    ///                 Currency = CurrencyEnum.Eur,
    ///                 Amount = "50000.00",
    ///                 CorrelationId = "LOAN_001",
    ///                 LoanDate = new DateOnly(2023, 5, 1),
    ///                 Installments = new List&lt;LoanInstallmentCreatePayload&gt;()
    ///                 {
    ///                     new LoanInstallmentCreatePayload
    ///                     {
    ///                         ExpectedRepaymentAt = new DateOnly(2023, 6, 1),
    ///                         Amount = "26000.00",
    ///                     },
    ///                     new LoanInstallmentCreatePayload
    ///                     {
    ///                         ExpectedRepaymentAt = new DateOnly(2023, 7, 1),
    ///                         Amount = "26000.00",
    ///                     },
    ///                 },
    ///                 Data = new Dictionary&lt;string, object?&gt;()
    ///                 {
    ///                     { "loan_type", "business" },
    ///                     { "purpose", "expansion" },
    ///                 },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<BulkLoanTaskResponse> CreateBulkLoansAsync(
        BulkLoanCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<BulkLoanTaskResponse>(
            CreateBulkLoansAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Check the status of a bulk loan creation task and retrieve results when completed.
    /// </summary>
    /// <example><code>
    /// await client.Loans.GetBulkLoanStatusAsync(new GetBulkLoanStatusRequest { TaskId = "task_id" });
    /// </code></example>
    public WithRawResponseTask<BulkLoanTaskStatus> GetBulkLoanStatusAsync(
        GetBulkLoanStatusRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<BulkLoanTaskStatus>(
            GetBulkLoanStatusAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Mark a loan as defaulted, recording the default date and the amount recovered from selling it. Defaults the loan's active and overdue installments and updates the loan status accordingly.
    /// </summary>
    /// <example><code>
    /// await client.Loans.SetLoanDefaultAsync(
    ///     new LoanDefaultPayload
    ///     {
    ///         LoanId = "loan_id",
    ///         DefaultDate = new DateOnly(2026, 6, 23),
    ///         SoldAmount = 1.1,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<LoanResponseWithInstallments> SetLoanDefaultAsync(
        LoanDefaultPayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<LoanResponseWithInstallments>(
            SetLoanDefaultAsyncCore(request, options, cancellationToken)
        );
    }
}
