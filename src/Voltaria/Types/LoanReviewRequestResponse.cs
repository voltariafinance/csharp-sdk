using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record LoanReviewRequestResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the loan review request
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The ID of the loan associated with the review request
    /// </summary>
    [JsonPropertyName("loan_id")]
    public required string LoanId { get; set; }

    /// <summary>
    /// The ID of the client associated with the review request
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    /// <summary>
    /// The status of the review request. One of the following: pending, approved, rejected
    /// </summary>
    [JsonPropertyName("status")]
    public required LoanReviewRequestStatusEnum Status { get; set; }

    /// <summary>
    /// The requester's note for the review request
    /// </summary>
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    /// <summary>
    /// The reviewer's note explaining the approval or rejection
    /// </summary>
    [JsonPropertyName("response")]
    public string? Response { get; set; }

    /// <summary>
    /// The timestamp when the review request was approved or rejected
    /// </summary>
    [JsonPropertyName("reviewed_at")]
    public DateTime? ReviewedAt { get; set; }

    /// <summary>
    /// The timestamp when the review request was created
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The timestamp when the review request was last updated
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

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
