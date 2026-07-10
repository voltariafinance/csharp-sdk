namespace Voltaria;

public partial interface ICollectionsClient
{
    /// <summary>
    /// Retrieve all collection actions configured for your partner account.
    /// </summary>
    WithRawResponseTask<PaginatedResponseCollectionActionResponse> ListCollectionActionsAsync(
        ListCollectionActionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve collection action logs for your partner account. Supports filtering by client, loan, installment, status, or action type.
    /// </summary>
    WithRawResponseTask<PaginatedResponseCollectionActionLogResponse> ListCollectionActionLogsAsync(
        ListCollectionActionLogsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the status and notes of a collection action log.
    /// </summary>
    WithRawResponseTask<CollectionActionLogResponse> UpdateCollectionActionLogAsync(
        CollectionActionLogUpdatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
