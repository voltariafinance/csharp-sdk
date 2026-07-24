namespace Voltaria;

public partial interface IRecoveriesClient
{
    /// <summary>
    /// Retrieve recoveries recorded against your loans. Supports filtering by client or loan.
    /// </summary>
    WithRawResponseTask<PaginatedResponseRecoveryResponse> ListRecoveriesAsync(
        ListRecoveriesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Record a new recovery against one of your loans.
    /// </summary>
    WithRawResponseTask<RecoveryResponse> CreateRecoveryAsync(
        RecoveryCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
