using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(ClientTypeEnum.ClientTypeEnumSerializer))]
[Serializable]
public readonly record struct ClientTypeEnum : IStringEnum
{
    public static readonly ClientTypeEnum Corporate = new(Values.Corporate);

    public static readonly ClientTypeEnum Individual = new(Values.Individual);

    public ClientTypeEnum(string value)
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
    public static ClientTypeEnum FromCustom(string value)
    {
        return new ClientTypeEnum(value);
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

    public static bool operator ==(ClientTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientTypeEnum value) => value.Value;

    public static explicit operator ClientTypeEnum(string value) => new(value);

    internal class ClientTypeEnumSerializer : JsonConverter<ClientTypeEnum>
    {
        public override ClientTypeEnum Read(
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
            return new ClientTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientTypeEnum ReadAsPropertyName(
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
            return new ClientTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientTypeEnum value,
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
        public const string Corporate = "corporate";

        public const string Individual = "individual";
    }
}
