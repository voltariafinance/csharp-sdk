using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record ListClientPortalUsersRequest
{
    [JsonIgnore]
    public required string ClientId { get; set; }

    [JsonIgnore]
    public int? Page { get; set; }

    [JsonIgnore]
    public int? PageSize { get; set; }

    [JsonIgnore]
    public string? OrderBy { get; set; }

    /// <summary>
    /// Query string for filtering. Format: "field:operator:value;...". Supported fields: id, email, status, first_name, last_name. Supported operators: is, in, not_in, contains, not_contains, like, not_like, ilike, not_ilike, gt, gte, lt, lte, starts_with, ends_with, is_null, is_not_null.
    /// </summary>
    [JsonIgnore]
    public string? Q { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
