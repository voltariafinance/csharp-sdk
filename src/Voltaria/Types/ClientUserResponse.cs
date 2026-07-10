using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record ClientUserResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique client user identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// ID of the partner this user belongs to.
    /// </summary>
    [JsonPropertyName("partner_id")]
    public required string PartnerId { get; set; }

    /// <summary>
    /// ID of the client this user belongs to.
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    /// <summary>
    /// Email address of the portal user.
    /// </summary>
    [JsonPropertyName("email")]
    public required string Email { get; set; }

    /// <summary>
    /// ID of the role assigned to the user.
    /// </summary>
    [JsonPropertyName("role_id")]
    public required string RoleId { get; set; }

    /// <summary>
    /// Role assigned to the user.
    /// </summary>
    [JsonPropertyName("role")]
    public RoleResponse? Role { get; set; }

    /// <summary>
    /// Account status. One of: `pending`, `active`, `inactive`.
    /// </summary>
    [JsonPropertyName("status")]
    public required ClientUserStatusEnum Status { get; set; }

    /// <summary>
    /// Whether the user has verified their email address.
    /// </summary>
    [JsonPropertyName("is_email_verified")]
    public required bool IsEmailVerified { get; set; }

    /// <summary>
    /// KYC verification status of the user.
    /// </summary>
    [JsonPropertyName("kyc_status")]
    public required KycStatusEnum KycStatus { get; set; }

    /// <summary>
    /// First name of the user.
    /// </summary>
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    /// <summary>
    /// Last name of the user.
    /// </summary>
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    /// <summary>
    /// Phone number of the user.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// Whether two-factor authentication is enabled for this user.
    /// </summary>
    [JsonPropertyName("is_2fa_enabled")]
    public bool? Is2FaEnabled { get; set; }

    /// <summary>
    /// Whether two-factor authentication is required for this user.
    /// </summary>
    [JsonPropertyName("is_2fa_required")]
    public bool? Is2FaRequired { get; set; }

    /// <summary>
    /// Timestamp when the user was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// Timestamp when the user was last updated.
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
