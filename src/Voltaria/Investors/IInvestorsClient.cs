namespace Voltaria;

public partial interface IInvestorsClient
{
    /// <summary>
    /// Retrieve all clients with at least one loan funded by this investor.
    /// </summary>
    WithRawResponseTask<PaginatedResponseClientInvestorResponse> InvestorListClientsAsync(
        InvestorListClientsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a specific client that has a loan funded by this investor.
    /// </summary>
    WithRawResponseTask<ClientInvestorResponse> InvestorGetClientAsync(
        InvestorGetClientRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all loans funded by the current investor.
    /// </summary>
    WithRawResponseTask<PaginatedResponseLoanInvestorResponse> InvestorListLoansAsync(
        InvestorListLoansRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a specific loan funded by the current investor, with its installments.
    /// </summary>
    WithRawResponseTask<LoanResponseWithInstallments> InvestorGetLoanAsync(
        InvestorGetLoanRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all installments for loans funded by the current investor.
    /// </summary>
    WithRawResponseTask<PaginatedResponseInstallmentResponseWithClientInfo> InvestorListInstallmentsAsync(
        InvestorListInstallmentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a specific installment for a loan funded by the current investor.
    /// </summary>
    WithRawResponseTask<InstallmentResponse> InvestorGetInstallmentAsync(
        InvestorGetInstallmentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all repayment logs for loans funded by the current investor.
    /// </summary>
    WithRawResponseTask<PaginatedResponseRepaymentResponseWithClientInfo> InvestorListRepaymentsAsync(
        InvestorListRepaymentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
