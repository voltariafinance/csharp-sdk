namespace Voltaria;

public partial interface IAccountsClient
{
    /// <summary>
    /// Return the required and optional bank account fields for each supported currency. Fetch once and cache; use it to build the create-account request.
    /// </summary>
    WithRawResponseTask<Dictionary<string, CurrencyFieldSpec>> ListClientAccountFieldsAsync(
        ListClientAccountFieldsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all bank accounts for one of your clients.
    /// </summary>
    WithRawResponseTask<PaginatedResponseClientAccountResponse> ListClientAccountsAsync(
        ListClientAccountsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a bank account for one of your clients. The account is registered with the payment provider immediately. Use the `status` field to create it as `active` (default; demotes any existing active account in the same currency to `passive`) or `passive`.
    /// </summary>
    WithRawResponseTask<ClientAccountResponse> CreateClientAccountAsync(
        PartnerClientAccountCreateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a specific bank account for one of your clients.
    /// </summary>
    WithRawResponseTask<ClientAccountResponse> GetClientAccountAsync(
        GetClientAccountRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
