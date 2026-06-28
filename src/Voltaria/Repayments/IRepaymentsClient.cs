namespace Voltaria;

public partial interface IRepaymentsClient
{
    /// <summary>
    /// Retrieve all repayments made under your partner account. Supports filtering by client, loan, or installments.
    /// </summary>
    WithRawResponseTask<PaginatedResponseRepaymentResponseWithClientInfo> ListRepaymentLogsAsync(
        ListRepaymentLogsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new repayment log for an installment. Requires the installment ID, loan ID or loan correlation ID.
    /// </summary>
    WithRawResponseTask<RepaymentResponse> CreateRepaymentAsync(
        RepaymentCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Initiate processing of up to 10000 repayment logs. Returns task_id for tracking progress.
    /// </summary>
    WithRawResponseTask<BulkRepaymentTaskResponse> CreateBulkRepaymentsAsync(
        BulkRepaymentCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Check the progress and results of a bulk repayment processing task.
    /// </summary>
    WithRawResponseTask<BulkRepaymentTaskStatus> GetBulkRepaymentStatusAsync(
        GetBulkRepaymentStatusRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
