using global::System.Text.Json;
using Voltaria.Core;

namespace Voltaria;

public partial class InstallmentsClient : IInstallmentsClient
{
    private readonly RawClient _client;

    internal InstallmentsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<
        WithRawResponse<PaginatedResponseInstallmentResponseWithClientInfo>
    > ListInstallmentsAsyncCore(
        ListInstallmentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Voltaria.Core.QueryStringBuilder.Builder(capacity: 6)
            .Add("page", request.Page)
            .Add("page_size", request.PageSize)
            .Add("client_id", request.ClientId)
            .Add("loan_id", request.LoanId)
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
                    Path = "v2/installments",
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
                    JsonUtils.Deserialize<PaginatedResponseInstallmentResponseWithClientInfo>(
                        responseBody
                    )!;
                return new WithRawResponse<PaginatedResponseInstallmentResponseWithClientInfo>()
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

    private async Task<WithRawResponse<IEnumerable<InstallmentResponse>>> AddInstallmentAsyncCore(
        InstallmentCreatePayload request,
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
                    Path = "v2/installments",
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
                var responseData = JsonUtils.Deserialize<IEnumerable<InstallmentResponse>>(
                    responseBody
                )!;
                return new WithRawResponse<IEnumerable<InstallmentResponse>>()
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

    private async Task<
        WithRawResponse<PaginatedResponsePaymentPromiseResponse>
    > ListPaymentPromisesAsyncCore(
        ListPaymentPromisesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Voltaria.Core.QueryStringBuilder.Builder(capacity: 6)
            .Add("page", request.Page)
            .Add("page_size", request.PageSize)
            .Add("order_by", request.OrderBy)
            .Add("q", request.Q)
            .Add("loan_id", request.LoanId)
            .Add("client_id", request.ClientId)
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
                    Path = "v2/installments/payment-promises",
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
                var responseData = JsonUtils.Deserialize<PaginatedResponsePaymentPromiseResponse>(
                    responseBody
                )!;
                return new WithRawResponse<PaginatedResponsePaymentPromiseResponse>()
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

    private async Task<WithRawResponse<PaymentPromiseResponse>> CreatePaymentPromiseAsyncCore(
        PaymentPromiseCreatePayload request,
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
                    Path = "v2/installments/payment-promises",
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
                var responseData = JsonUtils.Deserialize<PaymentPromiseResponse>(responseBody)!;
                return new WithRawResponse<PaymentPromiseResponse>()
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

    private async Task<WithRawResponse<InstallmentResponse>> GetInstallmentByIdAsyncCore(
        GetInstallmentByIdRequest request,
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
                        "v2/installments/{0}",
                        ValueConvert.ToPathParameterString(request.InstallmentId)
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
                var responseData = JsonUtils.Deserialize<InstallmentResponse>(responseBody)!;
                return new WithRawResponse<InstallmentResponse>()
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

    private async Task<WithRawResponse<InstallmentResponse>> EditInstallmentAsyncCore(
        InstallmentEditPayload request,
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
                        "v2/installments/{0}",
                        ValueConvert.ToPathParameterString(request.InstallmentId)
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
                var responseData = JsonUtils.Deserialize<InstallmentResponse>(responseBody)!;
                return new WithRawResponse<InstallmentResponse>()
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> DeleteInstallmentAsyncCore(
        DeleteInstallmentRequest request,
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
                        "v2/installments/{0}",
                        ValueConvert.ToPathParameterString(request.InstallmentId)
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
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
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
    /// Retrieve a list of all loan installments under your partner account. Supports optional filtering by loan or client.
    /// </summary>
    /// <example><code>
    /// await client.Installments.ListInstallmentsAsync(new ListInstallmentsRequest());
    /// </code></example>
    public WithRawResponseTask<PaginatedResponseInstallmentResponseWithClientInfo> ListInstallmentsAsync(
        ListInstallmentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PaginatedResponseInstallmentResponseWithClientInfo>(
            ListInstallmentsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Add new installments to a loan with its specific loan ID. This endpoint is available to select partners and will trigger the recalculation of the IRR and interest amounts for all installments of the loan.
    /// </summary>
    /// <example><code>
    /// await client.Installments.AddInstallmentAsync(
    ///     new InstallmentCreatePayload
    ///     {
    ///         LoanId = "loan_12345",
    ///         Installments = new List&lt;LoanInstallmentCreatePayload&gt;()
    ///         {
    ///             new LoanInstallmentCreatePayload
    ///             {
    ///                 ExpectedRepaymentAt = new DateOnly(2025, 12, 1),
    ///                 Amount = "1000.00",
    ///             },
    ///             new LoanInstallmentCreatePayload
    ///             {
    ///                 ExpectedRepaymentAt = new DateOnly(2026, 1, 1),
    ///                 Amount = "1000.00",
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<IEnumerable<InstallmentResponse>> AddInstallmentAsync(
        InstallmentCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<InstallmentResponse>>(
            AddInstallmentAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve a list of payment promises recorded for installments under your partner account. Supports optional filtering by loan or client.
    /// </summary>
    /// <example><code>
    /// await client.Installments.ListPaymentPromisesAsync(new ListPaymentPromisesRequest());
    /// </code></example>
    public WithRawResponseTask<PaginatedResponsePaymentPromiseResponse> ListPaymentPromisesAsync(
        ListPaymentPromisesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PaginatedResponsePaymentPromiseResponse>(
            ListPaymentPromisesAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Record a payment promise made by a client for one of their installments. The promised date must be today or in the future.
    /// </summary>
    /// <example><code>
    /// await client.Installments.CreatePaymentPromiseAsync(
    ///     new PaymentPromiseCreatePayload
    ///     {
    ///         InstallmentId = "inst_12345",
    ///         Amount = 1.1,
    ///         PromisedDate = new DateOnly(2026, 5, 15),
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<PaymentPromiseResponse> CreatePaymentPromiseAsync(
        PaymentPromiseCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PaymentPromiseResponse>(
            CreatePaymentPromiseAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve detailed information for a specific installment using its installment ID.
    /// </summary>
    /// <example><code>
    /// await client.Installments.GetInstallmentByIdAsync(
    ///     new GetInstallmentByIdRequest { InstallmentId = "installment_id" }
    /// );
    /// </code></example>
    public WithRawResponseTask<InstallmentResponse> GetInstallmentByIdAsync(
        GetInstallmentByIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<InstallmentResponse>(
            GetInstallmentByIdAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Update an installment's amount and expected repayment date with its specific installment ID. This endpoint is available to select partners and will trigger the recalculation of the IRR and interest amounts for all installments of the loan.
    /// </summary>
    /// <example><code>
    /// await client.Installments.EditInstallmentAsync(
    ///     new InstallmentEditPayload
    ///     {
    ///         InstallmentId = "installment_id",
    ///         Amount = 1.1,
    ///         ExpectedRepaymentAt = new DateOnly(2025, 12, 1),
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<InstallmentResponse> EditInstallmentAsync(
        InstallmentEditPayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<InstallmentResponse>(
            EditInstallmentAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Delete an installment with its specific installment ID. This endpoint is available to select partners and will trigger the recalculation of the IRR and interest amounts for all installments of the loan.
    /// </summary>
    /// <example><code>
    /// await client.Installments.DeleteInstallmentAsync(
    ///     new DeleteInstallmentRequest { InstallmentId = "installment_id" }
    /// );
    /// </code></example>
    public WithRawResponseTask<Dictionary<string, object?>> DeleteInstallmentAsync(
        DeleteInstallmentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            DeleteInstallmentAsyncCore(request, options, cancellationToken)
        );
    }
}
