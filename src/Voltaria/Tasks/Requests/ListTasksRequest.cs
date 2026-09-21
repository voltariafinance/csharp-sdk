using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record ListTasksRequest
{
    /// <summary>
    /// Filter by task status.
    /// </summary>
    [JsonIgnore]
    public TaskStatusEnum? Status { get; set; }

    /// <summary>
    /// Filter by client.
    /// </summary>
    [JsonIgnore]
    public string? ClientId { get; set; }

    /// <summary>
    /// Filter by loan.
    /// </summary>
    [JsonIgnore]
    public string? LoanId { get; set; }

    /// <summary>
    /// Filter by installment.
    /// </summary>
    [JsonIgnore]
    public string? InstallmentId { get; set; }

    /// <summary>
    /// Filter by waterfall.
    /// </summary>
    [JsonIgnore]
    public string? WaterfallId { get; set; }

    [JsonIgnore]
    public int? Page { get; set; }

    [JsonIgnore]
    public int? PageSize { get; set; }

    /// <summary>
    /// Field to order the results by, e.g., 'due_at:asc,created_at:desc'.
    /// </summary>
    [JsonIgnore]
    public string? OrderBy { get; set; }

    /// <summary>
    /// Query string for filtering. Format: "field:operator:value;...". Supported fields: id, status, priority, due_at, created_at, client_id, loan_id, installment_id, waterfall_id. Supported operators: is, in, not_in, contains, not_contains, like, not_like, ilike, not_ilike, gt, gte, lt, lte, starts_with, ends_with, is_null, is_not_null.
    /// </summary>
    [JsonIgnore]
    public string? Q { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
