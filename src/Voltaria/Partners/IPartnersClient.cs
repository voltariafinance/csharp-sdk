namespace Voltaria;

public partial interface IPartnersClient
{
    /// <summary>
    /// Use this endpoint to check the available funding capacity in your dedicated lending account before initiating a new loan or submitting a drawdown request.
    /// </summary>
    WithRawResponseTask<IEnumerable<AvailableFunding>> GetAvailableFundingAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Upload supplementary partner information, such as bank account balance, accounting figures, or other relevant details.
    /// </summary>
    WithRawResponseTask<PartnerDataResponse> CreatePartnerDataAsync(
        PartnerDataCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Use this endpoint to get the list of waterfalls for your dedicated lending account.
    /// </summary>
    WithRawResponseTask<PaginatedResponseWaterfallResponse> ListPartnerWaterfallsAsync(
        ListPartnerWaterfallsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
