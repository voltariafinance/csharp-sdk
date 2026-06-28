namespace Voltaria;

public partial interface IInstallmentsClient
{
    /// <summary>
    /// Retrieve a list of all loan installments under your partner account. Supports optional filtering by loan or client.
    /// </summary>
    WithRawResponseTask<PaginatedResponseInstallmentResponseWithClientInfo> ListInstallmentsAsync(
        ListInstallmentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Add new installments to a loan with its specific loan ID. This endpoint is available to select partners and will trigger the recalculation of the IRR and interest amounts for all installments of the loan.
    /// </summary>
    WithRawResponseTask<IEnumerable<InstallmentResponse>> AddInstallmentAsync(
        InstallmentCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of payment promises recorded for installments under your partner account. Supports optional filtering by loan or client.
    /// </summary>
    WithRawResponseTask<PaginatedResponsePaymentPromiseResponse> ListPaymentPromisesAsync(
        ListPaymentPromisesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Record a payment promise made by a client for one of their installments. The promised date must be today or in the future.
    /// </summary>
    WithRawResponseTask<PaymentPromiseResponse> CreatePaymentPromiseAsync(
        PaymentPromiseCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve detailed information for a specific installment using its installment ID.
    /// </summary>
    WithRawResponseTask<InstallmentResponse> GetInstallmentByIdAsync(
        GetInstallmentByIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an installment's amount and expected repayment date with its specific installment ID. This endpoint is available to select partners and will trigger the recalculation of the IRR and interest amounts for all installments of the loan.
    /// </summary>
    WithRawResponseTask<InstallmentResponse> EditInstallmentAsync(
        InstallmentEditPayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an installment with its specific installment ID. This endpoint is available to select partners and will trigger the recalculation of the IRR and interest amounts for all installments of the loan.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> DeleteInstallmentAsync(
        DeleteInstallmentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
