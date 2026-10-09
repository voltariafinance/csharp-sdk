using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(LoanRepaymentMethodEnum.LoanRepaymentMethodEnumSerializer))]
[Serializable]
public readonly record struct LoanRepaymentMethodEnum : IStringEnum
{
    public static readonly LoanRepaymentMethodEnum Pmt = new(Values.Pmt);

    public static readonly LoanRepaymentMethodEnum ConstantPrincipal = new(
        Values.ConstantPrincipal
    );

    public LoanRepaymentMethodEnum(string value)
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
    public static LoanRepaymentMethodEnum FromCustom(string value)
    {
        return new LoanRepaymentMethodEnum(value);
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

    public static bool operator ==(LoanRepaymentMethodEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LoanRepaymentMethodEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LoanRepaymentMethodEnum value) => value.Value;

    public static explicit operator LoanRepaymentMethodEnum(string value) => new(value);

    internal class LoanRepaymentMethodEnumSerializer : JsonConverter<LoanRepaymentMethodEnum>
    {
        public override LoanRepaymentMethodEnum Read(
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
            return new LoanRepaymentMethodEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LoanRepaymentMethodEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LoanRepaymentMethodEnum ReadAsPropertyName(
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
            return new LoanRepaymentMethodEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LoanRepaymentMethodEnum value,
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
        public const string Pmt = "pmt";

        public const string ConstantPrincipal = "constant_principal";
    }
}
