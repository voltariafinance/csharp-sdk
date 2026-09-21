using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record ListTaskStatusHistoryRequest
{
    [JsonIgnore]
    public required string TaskId { get; set; }

    [JsonIgnore]
    public int? Page { get; set; }

    [JsonIgnore]
    public int? PageSize { get; set; }

    /// <summary>
    /// Field to order the results by, e.g., 'created_at:asc'. Defaults to 'created_at:desc'.
    /// </summary>
    [JsonIgnore]
    public string? OrderBy { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
