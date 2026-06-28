using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(KycStatusEnum.KycStatusEnumSerializer))]
[Serializable]
public readonly record struct KycStatusEnum : IStringEnum
{
    public static readonly KycStatusEnum NotStarted = new(Values.NotStarted);

    public static readonly KycStatusEnum Triggered = new(Values.Triggered);

    public static readonly KycStatusEnum Verified = new(Values.Verified);

    public static readonly KycStatusEnum Rejected = new(Values.Rejected);

    public KycStatusEnum(string value)
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
    public static KycStatusEnum FromCustom(string value)
    {
        return new KycStatusEnum(value);
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

    public static bool operator ==(KycStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(KycStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(KycStatusEnum value) => value.Value;

    public static explicit operator KycStatusEnum(string value) => new(value);

    internal class KycStatusEnumSerializer : JsonConverter<KycStatusEnum>
    {
        public override KycStatusEnum Read(
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
            return new KycStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            KycStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override KycStatusEnum ReadAsPropertyName(
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
            return new KycStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            KycStatusEnum value,
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
        public const string NotStarted = "not_started";

        public const string Triggered = "triggered";

        public const string Verified = "verified";

        public const string Rejected = "rejected";
    }
}
