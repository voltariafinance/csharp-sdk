using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(WaterfallStatusEnum.WaterfallStatusEnumSerializer))]
[Serializable]
public readonly record struct WaterfallStatusEnum : IStringEnum
{
    public static readonly WaterfallStatusEnum Pending = new(Values.Pending);

    public static readonly WaterfallStatusEnum Paid = new(Values.Paid);

    public WaterfallStatusEnum(string value)
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
    public static WaterfallStatusEnum FromCustom(string value)
    {
        return new WaterfallStatusEnum(value);
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

    public static bool operator ==(WaterfallStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WaterfallStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WaterfallStatusEnum value) => value.Value;

    public static explicit operator WaterfallStatusEnum(string value) => new(value);

    internal class WaterfallStatusEnumSerializer : JsonConverter<WaterfallStatusEnum>
    {
        public override WaterfallStatusEnum Read(
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
            return new WaterfallStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WaterfallStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WaterfallStatusEnum ReadAsPropertyName(
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
            return new WaterfallStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WaterfallStatusEnum value,
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

        public const string Paid = "paid";
    }
}
