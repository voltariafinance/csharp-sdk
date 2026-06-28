using global::System.Text.Json;
using Voltaria.Core;

namespace Voltaria;

public partial class AccountsClient : IAccountsClient
{
    private readonly RawClient _client;

    internal AccountsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<
        WithRawResponse<Dictionary<string, CurrencyFieldSpec>>
    > ListClientAccountFieldsAsyncCore(
        ListClientAccountFieldsRequest request,
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
                        "v2/clients/{0}/accounts/fields",
                        ValueConvert.ToPathParameterString(request.ClientId)
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
                var responseData = JsonUtils.Deserialize<Dictionary<string, CurrencyFieldSpec>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, CurrencyFieldSpec>>()
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
        WithRawResponse<PaginatedResponseClientAccountResponse>
    > ListClientAccountsAsyncCore(
        ListClientAccountsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Voltaria.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("page", request.Page)
            .Add("page_size", request.PageSize)
            .Add("order_by", request.OrderBy)
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
                    Path = string.Format(
                        "v2/clients/{0}/accounts",
                        ValueConvert.ToPathParameterString(request.ClientId)
                    ),
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
                var responseData = JsonUtils.Deserialize<PaginatedResponseClientAccountResponse>(
                    responseBody
                )!;
                return new WithRawResponse<PaginatedResponseClientAccountResponse>()
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

    private async Task<WithRawResponse<ClientAccountResponse>> CreateClientAccountAsyncCore(
        PartnerClientAccountCreateRequest request,
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
                        "v2/clients/{0}/accounts",
                        ValueConvert.ToPathParameterString(request.ClientId)
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
                var responseData = JsonUtils.Deserialize<ClientAccountResponse>(responseBody)!;
                return new WithRawResponse<ClientAccountResponse>()
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

    private async Task<WithRawResponse<ClientAccountResponse>> GetClientAccountAsyncCore(
        GetClientAccountRequest request,
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
                        "v2/clients/{0}/accounts/{1}",
                        ValueConvert.ToPathParameterString(request.ClientId),
                        ValueConvert.ToPathParameterString(request.AccountId)
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
                var responseData = JsonUtils.Deserialize<ClientAccountResponse>(responseBody)!;
                return new WithRawResponse<ClientAccountResponse>()
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
    /// Return the required and optional bank account fields for each supported currency. Fetch once and cache; use it to build the create-account request.
    /// </summary>
    /// <example><code>
    /// await client.Accounts.ListClientAccountFieldsAsync(
    ///     new ListClientAccountFieldsRequest { ClientId = "client_id" }
    /// );
    /// </code></example>
    public WithRawResponseTask<Dictionary<string, CurrencyFieldSpec>> ListClientAccountFieldsAsync(
        ListClientAccountFieldsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, CurrencyFieldSpec>>(
            ListClientAccountFieldsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve all bank accounts for one of your clients.
    /// </summary>
    /// <example><code>
    /// await client.Accounts.ListClientAccountsAsync(
    ///     new ListClientAccountsRequest { ClientId = "client_id" }
    /// );
    /// </code></example>
    public WithRawResponseTask<PaginatedResponseClientAccountResponse> ListClientAccountsAsync(
        ListClientAccountsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PaginatedResponseClientAccountResponse>(
            ListClientAccountsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Create a bank account for one of your clients. The account is registered with the payment provider immediately. Use the `status` field to create it as `active` (default; demotes any existing active account in the same currency to `passive`) or `passive`.
    /// </summary>
    /// <example><code>
    /// await client.Accounts.CreateClientAccountAsync(
    ///     new PartnerClientAccountCreateRequest
    ///     {
    ///         ClientId = "client_id",
    ///         AccountHolderName = "Acme Ltd",
    ///         AccountHolderType = AccountHolderTypeEnum.Business,
    ///         Currency = CurrencyEnum.Gbp,
    ///         SortCode = "40-47-84",
    ///         AccountNumber = "12345678",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<ClientAccountResponse> CreateClientAccountAsync(
        PartnerClientAccountCreateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ClientAccountResponse>(
            CreateClientAccountAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve a specific bank account for one of your clients.
    /// </summary>
    /// <example><code>
    /// await client.Accounts.GetClientAccountAsync(
    ///     new GetClientAccountRequest { ClientId = "client_id", AccountId = "account_id" }
    /// );
    /// </code></example>
    public WithRawResponseTask<ClientAccountResponse> GetClientAccountAsync(
        GetClientAccountRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ClientAccountResponse>(
            GetClientAccountAsyncCore(request, options, cancellationToken)
        );
    }
}
