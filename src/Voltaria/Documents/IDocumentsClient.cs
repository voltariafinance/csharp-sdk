namespace Voltaria;

public partial interface IDocumentsClient
{
    /// <summary>
    /// Retrieve all documents linked to a client.
    /// </summary>
    WithRawResponseTask<PaginatedResponseDocumentResponse> ListDocumentsAsync(
        ListDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Upload a new document related to a client or loan, such as financial statements or KYC files.
    /// </summary>
    WithRawResponseTask<DocumentResponse> UploadDocumentAsync(
        DocumentCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all available document categories.
    /// </summary>
    WithRawResponseTask<AvailableDocumentCategoriesResponse> GetAvailableDocumentCategoriesAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details for a specific document using its document ID.
    /// </summary>
    WithRawResponseTask<DocumentResponse> GetDocumentByIdAsync(
        GetDocumentByIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a specific document by using its document ID.
    /// </summary>
    Task DeleteDocumentAsync(
        DeleteDocumentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
