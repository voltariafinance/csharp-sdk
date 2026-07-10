using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record ListCollectionActionLogsRequest
{
    [JsonIgnore]
    public string? ClientId { get; set; }

    [JsonIgnore]
    public string? LoanId { get; set; }

    [JsonIgnore]
    public string? InstallmentId { get; set; }

    [JsonIgnore]
    public CollectionActionStatusEnum? Status { get; set; }

    [JsonIgnore]
    public CollectionActionTypeEnum? ActionType { get; set; }

    [JsonIgnore]
    public int? Page { get; set; }

    [JsonIgnore]
    public int? PageSize { get; set; }

    /// <summary>
    /// Field to order the results by, e.g., 'created_at:desc,updated_at:asc'
    /// </summary>
    [JsonIgnore]
    public string? OrderBy { get; set; }

    /// <summary>
    /// Query string for filtering. Format: "field:operator:value;...". Supported fields: id, collection_action_id, action_type, status, client_id, loan_id, installment_id, scheduled_for. Supported operators: is, in, not_in, contains, not_contains, like, not_like, ilike, not_ilike, gt, gte, lt, lte, starts_with, ends_with, is_null, is_not_null.
    /// </summary>
    [JsonIgnore]
    public string? Q { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
