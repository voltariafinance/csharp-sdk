using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(PaymentPromiseStatusEnum.PaymentPromiseStatusEnumSerializer))]
[Serializable]
public readonly record struct PaymentPromiseStatusEnum : IStringEnum
{
    public static readonly PaymentPromiseStatusEnum Active = new(Values.Active);

    public static readonly PaymentPromiseStatusEnum Paid = new(Values.Paid);

    public static readonly PaymentPromiseStatusEnum NotPaid = new(Values.NotPaid);

    public static readonly PaymentPromiseStatusEnum Cancelled = new(Values.Cancelled);

    public PaymentPromiseStatusEnum(string value)
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
    public static PaymentPromiseStatusEnum FromCustom(string value)
    {
        return new PaymentPromiseStatusEnum(value);
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

    public static bool operator ==(PaymentPromiseStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PaymentPromiseStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PaymentPromiseStatusEnum value) => value.Value;

    public static explicit operator PaymentPromiseStatusEnum(string value) => new(value);

    internal class PaymentPromiseStatusEnumSerializer : JsonConverter<PaymentPromiseStatusEnum>
    {
        public override PaymentPromiseStatusEnum Read(
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
            return new PaymentPromiseStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PaymentPromiseStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PaymentPromiseStatusEnum ReadAsPropertyName(
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
            return new PaymentPromiseStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PaymentPromiseStatusEnum value,
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
        public const string Active = "active";

        public const string Paid = "paid";

        public const string NotPaid = "not_paid";

        public const string Cancelled = "cancelled";
    }
}
