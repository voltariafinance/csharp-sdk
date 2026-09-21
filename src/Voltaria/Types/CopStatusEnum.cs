using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(CopStatusEnum.CopStatusEnumSerializer))]
[Serializable]
public readonly record struct CopStatusEnum : IStringEnum
{
    public static readonly CopStatusEnum Matched = new(Values.Matched);

    public static readonly CopStatusEnum CloseMatch = new(Values.CloseMatch);

    public static readonly CopStatusEnum NotMatched = new(Values.NotMatched);

    public static readonly CopStatusEnum AccountNotFound = new(Values.AccountNotFound);

    public static readonly CopStatusEnum Unavailable = new(Values.Unavailable);

    public CopStatusEnum(string value)
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
    public static CopStatusEnum FromCustom(string value)
    {
        return new CopStatusEnum(value);
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

    public static bool operator ==(CopStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CopStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CopStatusEnum value) => value.Value;

    public static explicit operator CopStatusEnum(string value) => new(value);

    internal class CopStatusEnumSerializer : JsonConverter<CopStatusEnum>
    {
        public override CopStatusEnum Read(
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
            return new CopStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CopStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CopStatusEnum ReadAsPropertyName(
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
            return new CopStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CopStatusEnum value,
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
        public const string Matched = "matched";

        public const string CloseMatch = "close_match";

        public const string NotMatched = "not_matched";

        public const string AccountNotFound = "account_not_found";

        public const string Unavailable = "unavailable";
    }
}
