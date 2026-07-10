namespace Voltaria;

public partial interface ILoansClient
{
    /// <summary>
    /// List loan review requests for your partner account, optionally filtered by loan ID or client ID.
    /// </summary>
    WithRawResponseTask<PaginatedResponseLoanReviewRequestResponse> ListLoanReviewRequestsAsync(
        ListLoanReviewRequestsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Ask Voltaria to review a not-yet-disbursed (pending or pre-approved) loan before disbursement.
    /// </summary>
    WithRawResponseTask<LoanReviewRequestResponse> CreateLoanReviewRequestAsync(
        LoanReviewRequestCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a specific loan review request by its ID.
    /// </summary>
    WithRawResponseTask<LoanReviewRequestResponse> GetLoanReviewRequestAsync(
        GetLoanReviewRequestRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all loans associated with your partner account. Supports optional filtering by client ID.
    /// </summary>
    WithRawResponseTask<PaginatedResponseLoanResponseWithClientInfo> ListLoansAsync(
        ListLoansRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new loan for an approved client with an active credit limit.
    /// </summary>
    WithRawResponseTask<LoanResponseWithInstallments> CreateLoanAsync(
        LoanCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve detailed information about a specific loan by its loan ID.
    /// </summary>
    WithRawResponseTask<LoanResponseWithInstallments> GetLoanByIdAsync(
        GetLoanByIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a loan by ID. Only loans with 'pending' status can be deleted.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>?> DeleteLoanAsync(
        DeleteLoanRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create multiple loans in a single request. Processing happens asynchronously. Returns a task ID for tracking progress.
    /// </summary>
    WithRawResponseTask<BulkLoanTaskResponse> CreateBulkLoansAsync(
        BulkLoanCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Check the status of a bulk loan creation task and retrieve results when completed.
    /// </summary>
    WithRawResponseTask<BulkLoanTaskStatus> GetBulkLoanStatusAsync(
        GetBulkLoanStatusRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Mark a loan as defaulted, recording the default date and the amount recovered from selling it. Defaults the loan's active and overdue installments and updates the loan status accordingly.
    /// </summary>
    WithRawResponseTask<LoanResponseWithInstallments> SetLoanDefaultAsync(
        LoanDefaultPayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
