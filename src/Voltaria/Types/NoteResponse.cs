using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

/// <summary>
/// A note, with the name and email of whoever wrote it.
/// </summary>
[Serializable]
public record NoteResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Note ID.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// When the note was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// When the note was last updated.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// The note content.
    /// </summary>
    [JsonPropertyName("content")]
    public required string Content { get; set; }

    /// <summary>
    /// Related loan ID, if applicable.
    /// </summary>
    [JsonPropertyName("loan_id")]
    public string? LoanId { get; set; }

    /// <summary>
    /// Related installment ID, if applicable.
    /// </summary>
    [JsonPropertyName("installment_id")]
    public string? InstallmentId { get; set; }

    /// <summary>
    /// First name of the note author.
    /// </summary>
    [JsonPropertyName("author_first_name")]
    public string? AuthorFirstName { get; set; }

    /// <summary>
    /// Last name of the note author.
    /// </summary>
    [JsonPropertyName("author_last_name")]
    public string? AuthorLastName { get; set; }

    /// <summary>
    /// Email of the note author. Null if the author was deleted.
    /// </summary>
    [JsonPropertyName("author_email")]
    public string? AuthorEmail { get; set; }

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
