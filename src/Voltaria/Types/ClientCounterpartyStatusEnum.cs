using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(ClientCounterpartyStatusEnum.ClientCounterpartyStatusEnumSerializer))]
[Serializable]
public readonly record struct ClientCounterpartyStatusEnum : IStringEnum
{
    public static readonly ClientCounterpartyStatusEnum Pending = new(Values.Pending);

    public static readonly ClientCounterpartyStatusEnum Active = new(Values.Active);

    public static readonly ClientCounterpartyStatusEnum Inactive = new(Values.Inactive);

    public ClientCounterpartyStatusEnum(string value)
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
    public static ClientCounterpartyStatusEnum FromCustom(string value)
    {
        return new ClientCounterpartyStatusEnum(value);
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

    public static bool operator ==(ClientCounterpartyStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientCounterpartyStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientCounterpartyStatusEnum value) => value.Value;

    public static explicit operator ClientCounterpartyStatusEnum(string value) => new(value);

    internal class ClientCounterpartyStatusEnumSerializer
        : JsonConverter<ClientCounterpartyStatusEnum>
    {
        public override ClientCounterpartyStatusEnum Read(
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
            return new ClientCounterpartyStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientCounterpartyStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientCounterpartyStatusEnum ReadAsPropertyName(
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
            return new ClientCounterpartyStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientCounterpartyStatusEnum value,
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
