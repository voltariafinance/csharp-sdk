namespace Voltaria;

public partial interface IClientsClient
{
    /// <summary>
    /// Retrieve a list of all clients associated with your partner account.
    /// </summary>
    WithRawResponseTask<PaginatedResponseClientResponse> ListClientsAsync(
        ListClientsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new client under your partner account. The client will remain in a pending state until reviewed by Winyield.
    /// </summary>
    WithRawResponseTask<ClientResponse> CreateClientAsync(
        ClientCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Upload supplementary client information, such as bank account balance, accounting figures, or other relevant details.
    /// </summary>
    WithRawResponseTask<ClientDataResponse> CreateClientDataAsync(
        ClientDataCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of all limit requests associated with your partner account.
    /// </summary>
    WithRawResponseTask<PaginatedResponseLimitRequestResponse> ListLimitRequestsAsync(
        ListLimitRequestsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a limit review request for a client. The request will remain in a pending state until reviewed by Winyield.
    /// </summary>
    WithRawResponseTask<LimitRequestResponse> CreateLimitRequestAsync(
        LimitRequestCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a specific limit request by its ID.
    /// </summary>
    WithRawResponseTask<LimitRequestResponse> GetLimitRequestAsync(
        GetLimitRequestRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all clients that have self-registered via the portal and are awaiting partner approval.
    /// </summary>
    WithRawResponseTask<PaginatedResponseClientResponse> ListOnboardingClientsAsync(
        ListOnboardingClientsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Accept a self-onboarded client. The client status moves to 'pending' and the owner's portal account is activated so they can begin submitting documents.
    /// </summary>
    WithRawResponseTask<ClientResponse> ApproveOnboardingAsync(
        ApproveOnboardingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Reject a self-onboarded client. The client record is kept with 'rejected' status for audit history and is not deleted.
    /// </summary>
    WithRawResponseTask<ClientResponse> RejectOnboardingAsync(
        RejectOnboardingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Invite a new user to a client's portal account. The invited user will receive an email with a one-time link to set their password. Partner can assign any role: 'owner', 'admin', or 'viewer'.
    /// </summary>
    WithRawResponseTask<ClientUserResponse> AddClientPortalUserAsync(
        ClientUserInviteRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all waivers associated with a specific client.
    /// </summary>
    WithRawResponseTask<PaginatedResponseWaiverResponse> ListClientWaiversAsync(
        ListClientWaiversRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve detailed information for a specific client using their client ID.
    /// </summary>
    WithRawResponseTask<ClientResponse> GetClientByIdAsync(
        GetClientByIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a client by ID. Only clients with 'pending' status can be deleted. All client's loans must also be in 'pending' status.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>?> DeleteClientAsync(
        DeleteClientRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the checklist summaries for one of your clients, including the AI description and item completion counts.
    /// </summary>
    WithRawResponseTask<PaginatedResponseChecklistSummaryPartnerResponse> ListClientChecklistSummariesAsync(
        ListClientChecklistSummariesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
