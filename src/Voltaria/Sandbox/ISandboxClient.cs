namespace Voltaria;

public partial interface ISandboxClient
{
    /// <summary>
    /// Update an existing client's status or credit limit using their client ID.
    /// </summary>
    WithRawResponseTask<ClientResponse> UpdateClientAsync(
        ClientUpdateSandbox request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the status of a specific loan using its unique loan ID.
    /// </summary>
    WithRawResponseTask<LoanResponseWithInstallments> UpdateLoanAsync(
        LoanUpdateSandbox request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Test a webhook subscription by ID or trigger all by event type.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> WebhookTestAsync(
        WebhookTestSandbox request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
