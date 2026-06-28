using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(WebhookEventTypeEnum.WebhookEventTypeEnumSerializer))]
[Serializable]
public readonly record struct WebhookEventTypeEnum : IStringEnum
{
    public static readonly WebhookEventTypeEnum LoanUpdated = new(Values.LoanUpdated);

    public static readonly WebhookEventTypeEnum InstallmentUpdated = new(Values.InstallmentUpdated);

    public static readonly WebhookEventTypeEnum ClientUpdated = new(Values.ClientUpdated);

    public static readonly WebhookEventTypeEnum ClientLimitUpdated = new(Values.ClientLimitUpdated);

    public static readonly WebhookEventTypeEnum PartnerLimitUpdated = new(
        Values.PartnerLimitUpdated
    );

    public WebhookEventTypeEnum(string value)
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
    public static WebhookEventTypeEnum FromCustom(string value)
    {
        return new WebhookEventTypeEnum(value);
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

    public static bool operator ==(WebhookEventTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WebhookEventTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WebhookEventTypeEnum value) => value.Value;

    public static explicit operator WebhookEventTypeEnum(string value) => new(value);

    internal class WebhookEventTypeEnumSerializer : JsonConverter<WebhookEventTypeEnum>
    {
        public override WebhookEventTypeEnum Read(
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
            return new WebhookEventTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WebhookEventTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WebhookEventTypeEnum ReadAsPropertyName(
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
            return new WebhookEventTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WebhookEventTypeEnum value,
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
        public const string LoanUpdated = "loan.updated";

        public const string InstallmentUpdated = "installment.updated";

        public const string ClientUpdated = "client.updated";

        public const string ClientLimitUpdated = "client.limit.updated";

        public const string PartnerLimitUpdated = "partner.limit.updated";
    }
}
