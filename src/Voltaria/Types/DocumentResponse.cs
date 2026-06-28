using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record DocumentResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the document
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The category of the document (kyc, financial, etc.)
    /// </summary>
    [JsonPropertyName("category")]
    public required string Category { get; set; }

    /// <summary>
    /// The name of the uploaded file
    /// </summary>
    [JsonPropertyName("file_name")]
    public required string FileName { get; set; }

    /// <summary>
    /// The content type of the file
    /// </summary>
    [JsonPropertyName("file_type")]
    public required string FileType { get; set; }

    /// <summary>
    /// The associated client ID
    /// </summary>
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    /// <summary>
    /// The Presigned URL of the file. This is a temporary URL that allows you to download the file.
    /// </summary>
    [JsonPropertyName("file_url")]
    public string? FileUrl { get; set; }

    /// <summary>
    /// The ID of the associated loan, if applicable
    /// </summary>
    [JsonPropertyName("loan_id")]
    public string? LoanId { get; set; }

    /// <summary>
    /// The ID of the associated installment, if applicable
    /// </summary>
    [JsonPropertyName("installment_id")]
    public string? InstallmentId { get; set; }

    /// <summary>
    /// Slash-delimited folder path used to organise the document, e.g. 'Legal/Contracts'. Null means the document is unfiled (at the root).
    /// </summary>
    [JsonPropertyName("folder_path")]
    public string? FolderPath { get; set; }

    /// <summary>
    /// Optional document date (e.g. the date an investment document was issued)
    /// </summary>
    [JsonPropertyName("document_date")]
    public DateOnly? DocumentDate { get; set; }

    /// <summary>
    /// Optional expiry date of the document
    /// </summary>
    [JsonPropertyName("expiry_date")]
    public DateOnly? ExpiryDate { get; set; }

    /// <summary>
    /// The date and time when the document was created
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
