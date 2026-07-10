using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record CollectionActionLogResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the collection action log
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The ID of the collection action this log belongs to
    /// </summary>
    [JsonPropertyName("collection_action_id")]
    public required string CollectionActionId { get; set; }

    /// <summary>
    /// The channel used for this action
    /// </summary>
    [JsonPropertyName("action_type")]
    public required CollectionActionTypeEnum ActionType { get; set; }

    /// <summary>
    /// The name of the action at the time it was triggered
    /// </summary>
    [JsonPropertyName("action_name")]
    public required string ActionName { get; set; }

    /// <summary>
    /// The current status of the action
    /// </summary>
    [JsonPropertyName("status")]
    public required CollectionActionStatusEnum Status { get; set; }

    /// <summary>
    /// The ID of the client this action targets
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    /// <summary>
    /// The ID of the loan this action targets
    /// </summary>
    [JsonPropertyName("loan_id")]
    public required string LoanId { get; set; }

    /// <summary>
    /// The ID of the installment this action targets
    /// </summary>
    [JsonPropertyName("installment_id")]
    public required string InstallmentId { get; set; }

    /// <summary>
    /// Whether this action needs manual follow-up
    /// </summary>
    [JsonPropertyName("flag")]
    public required bool Flag { get; set; }

    /// <summary>
    /// Notes about this action
    /// </summary>
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    /// <summary>
    /// When this action is/was scheduled to run
    /// </summary>
    [JsonPropertyName("scheduled_for")]
    public required DateTime ScheduledFor { get; set; }

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
