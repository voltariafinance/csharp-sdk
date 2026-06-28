using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(CurrencyEnum.CurrencyEnumSerializer))]
[Serializable]
public readonly record struct CurrencyEnum : IStringEnum
{
    public static readonly CurrencyEnum Eur = new(Values.Eur);

    public static readonly CurrencyEnum Gbp = new(Values.Gbp);

    public static readonly CurrencyEnum Usd = new(Values.Usd);

    public static readonly CurrencyEnum Czk = new(Values.Czk);

    public static readonly CurrencyEnum Pln = new(Values.Pln);

    public static readonly CurrencyEnum Isk = new(Values.Isk);

    public CurrencyEnum(string value)
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
    public static CurrencyEnum FromCustom(string value)
    {
        return new CurrencyEnum(value);
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

    public static bool operator ==(CurrencyEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CurrencyEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CurrencyEnum value) => value.Value;

    public static explicit operator CurrencyEnum(string value) => new(value);

    internal class CurrencyEnumSerializer : JsonConverter<CurrencyEnum>
    {
        public override CurrencyEnum Read(
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
            return new CurrencyEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CurrencyEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CurrencyEnum ReadAsPropertyName(
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
            return new CurrencyEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CurrencyEnum value,
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
        public const string Eur = "eur";

        public const string Gbp = "gbp";

        public const string Usd = "usd";

        public const string Czk = "czk";

        public const string Pln = "pln";

        public const string Isk = "isk";
    }
}
