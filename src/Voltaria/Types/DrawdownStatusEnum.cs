using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(DrawdownStatusEnum.DrawdownStatusEnumSerializer))]
[Serializable]
public readonly record struct DrawdownStatusEnum : IStringEnum
{
    public static readonly DrawdownStatusEnum Requested = new(Values.Requested);

    public static readonly DrawdownStatusEnum Active = new(Values.Active);

    public static readonly DrawdownStatusEnum Cancelled = new(Values.Cancelled);

    public DrawdownStatusEnum(string value)
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
    public static DrawdownStatusEnum FromCustom(string value)
    {
        return new DrawdownStatusEnum(value);
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

    public static bool operator ==(DrawdownStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DrawdownStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DrawdownStatusEnum value) => value.Value;

    public static explicit operator DrawdownStatusEnum(string value) => new(value);

    internal class DrawdownStatusEnumSerializer : JsonConverter<DrawdownStatusEnum>
    {
        public override DrawdownStatusEnum Read(
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
            return new DrawdownStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DrawdownStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DrawdownStatusEnum ReadAsPropertyName(
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
            return new DrawdownStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DrawdownStatusEnum value,
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
        public const string Requested = "requested";

        public const string Active = "active";

        public const string Cancelled = "cancelled";
    }
}
