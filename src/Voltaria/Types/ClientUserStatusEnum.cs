using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(ClientUserStatusEnum.ClientUserStatusEnumSerializer))]
[Serializable]
public readonly record struct ClientUserStatusEnum : IStringEnum
{
    public static readonly ClientUserStatusEnum Pending = new(Values.Pending);

    public static readonly ClientUserStatusEnum Active = new(Values.Active);

    public static readonly ClientUserStatusEnum Inactive = new(Values.Inactive);

    public ClientUserStatusEnum(string value)
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
    public static ClientUserStatusEnum FromCustom(string value)
    {
        return new ClientUserStatusEnum(value);
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

    public static bool operator ==(ClientUserStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientUserStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientUserStatusEnum value) => value.Value;

    public static explicit operator ClientUserStatusEnum(string value) => new(value);

    internal class ClientUserStatusEnumSerializer : JsonConverter<ClientUserStatusEnum>
    {
        public override ClientUserStatusEnum Read(
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
            return new ClientUserStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientUserStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientUserStatusEnum ReadAsPropertyName(
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
            return new ClientUserStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientUserStatusEnum value,
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
        public const string Pending = "pending";

        public const string Active = "active";

        public const string Inactive = "inactive";
    }
}
