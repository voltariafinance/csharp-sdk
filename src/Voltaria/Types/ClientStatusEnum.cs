using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(ClientStatusEnum.ClientStatusEnumSerializer))]
[Serializable]
public readonly record struct ClientStatusEnum : IStringEnum
{
    public static readonly ClientStatusEnum Active = new(Values.Active);

    public static readonly ClientStatusEnum Rejected = new(Values.Rejected);

    public static readonly ClientStatusEnum Deactivated = new(Values.Deactivated);

    public static readonly ClientStatusEnum Pending = new(Values.Pending);

    public static readonly ClientStatusEnum PendingOnboarding = new(Values.PendingOnboarding);

    public static readonly ClientStatusEnum PreApproved = new(Values.PreApproved);

    public static readonly ClientStatusEnum Deleted = new(Values.Deleted);

    public static readonly ClientStatusEnum Inactive = new(Values.Inactive);

    public ClientStatusEnum(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static ClientStatusEnum FromCustom(string value)
    {
        return new ClientStatusEnum(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(ClientStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientStatusEnum value) => value.Value;

    public static explicit operator ClientStatusEnum(string value) => new(value);

    internal class ClientStatusEnumSerializer : JsonConverter<ClientStatusEnum>
    {
        public override ClientStatusEnum Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new ClientStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientStatusEnum ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new ClientStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Active = "active";

        public const string Rejected = "rejected";

        public const string Deactivated = "deactivated";

        public const string Pending = "pending";

        public const string PendingOnboarding = "pending_onboarding";

        public const string PreApproved = "pre_approved";

        public const string Deleted = "deleted";

        public const string Inactive = "inactive";
    }
}
