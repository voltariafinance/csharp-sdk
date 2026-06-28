namespace Voltaria;

public partial interface IDrawdownsClient
{
    /// <summary>
    /// Retrieve a list of drawdowns.
    /// </summary>
    WithRawResponseTask<PaginatedResponseDrawdownResponse> ListDrawdownsAsync(
        ListDrawdownsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new drawdown request.
    /// </summary>
    WithRawResponseTask<DrawdownResponse> CreateDrawdownRequestAsync(
        DrawdownCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all checklist items for a specific drawdown
    /// </summary>
    WithRawResponseTask<PaginatedResponseDrawdownChecklistResponse> ListDrawdownChecklistsAsync(
        ListDrawdownChecklistsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
