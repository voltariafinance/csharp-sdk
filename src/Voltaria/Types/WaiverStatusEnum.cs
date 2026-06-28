using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(WaiverStatusEnum.WaiverStatusEnumSerializer))]
[Serializable]
public readonly record struct WaiverStatusEnum : IStringEnum
{
    public static readonly WaiverStatusEnum Pending = new(Values.Pending);

    public static readonly WaiverStatusEnum Active = new(Values.Active);

    public static readonly WaiverStatusEnum Paid = new(Values.Paid);

    public static readonly WaiverStatusEnum Rejected = new(Values.Rejected);

    public WaiverStatusEnum(string value)
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
    public static WaiverStatusEnum FromCustom(string value)
    {
        return new WaiverStatusEnum(value);
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

    public static bool operator ==(WaiverStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WaiverStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WaiverStatusEnum value) => value.Value;

    public static explicit operator WaiverStatusEnum(string value) => new(value);

    internal class WaiverStatusEnumSerializer : JsonConverter<WaiverStatusEnum>
    {
        public override WaiverStatusEnum Read(
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
            return new WaiverStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WaiverStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WaiverStatusEnum ReadAsPropertyName(
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
            return new WaiverStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WaiverStatusEnum value,
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

        public const string Paid = "paid";

        public const string Rejected = "rejected";
    }
}
