using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(WebhookStatusEnum.WebhookStatusEnumSerializer))]
[Serializable]
public readonly record struct WebhookStatusEnum : IStringEnum
{
    public static readonly WebhookStatusEnum Active = new(Values.Active);

    public static readonly WebhookStatusEnum Paused = new(Values.Paused);

    public static readonly WebhookStatusEnum Disabled = new(Values.Disabled);

    public WebhookStatusEnum(string value)
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
    public static WebhookStatusEnum FromCustom(string value)
    {
        return new WebhookStatusEnum(value);
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

    public static bool operator ==(WebhookStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WebhookStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WebhookStatusEnum value) => value.Value;

    public static explicit operator WebhookStatusEnum(string value) => new(value);

    internal class WebhookStatusEnumSerializer : JsonConverter<WebhookStatusEnum>
    {
        public override WebhookStatusEnum Read(
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
            return new WebhookStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WebhookStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WebhookStatusEnum ReadAsPropertyName(
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
            return new WebhookStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WebhookStatusEnum value,
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

        public const string Paused = "paused";

        public const string Disabled = "disabled";
    }
}
