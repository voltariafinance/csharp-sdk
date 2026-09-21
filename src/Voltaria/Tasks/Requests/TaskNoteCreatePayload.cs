using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record TaskNoteCreatePayload
{
    [JsonIgnore]
    public required string TaskId { get; set; }

    /// <summary>
    /// The note content.
    /// </summary>
    [JsonPropertyName("content")]
    public required string Content { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
