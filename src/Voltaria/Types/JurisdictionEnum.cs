using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(JurisdictionEnum.JurisdictionEnumSerializer))]
[Serializable]
public readonly record struct JurisdictionEnum : IStringEnum
{
    public static readonly JurisdictionEnum Eu = new(Values.Eu);

    public static readonly JurisdictionEnum Uk = new(Values.Uk);

    public static readonly JurisdictionEnum Us = new(Values.Us);

    public JurisdictionEnum(string value)
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
    public static JurisdictionEnum FromCustom(string value)
    {
        return new JurisdictionEnum(value);
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

    public static bool operator ==(JurisdictionEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(JurisdictionEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(JurisdictionEnum value) => value.Value;

    public static explicit operator JurisdictionEnum(string value) => new(value);

    internal class JurisdictionEnumSerializer : JsonConverter<JurisdictionEnum>
    {
        public override JurisdictionEnum Read(
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
            return new JurisdictionEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            JurisdictionEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override JurisdictionEnum ReadAsPropertyName(
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
            return new JurisdictionEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            JurisdictionEnum value,
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
        public const string Eu = "eu";

        public const string Uk = "uk";

        public const string Us = "us";
    }
}
