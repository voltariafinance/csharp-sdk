using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(CollectionActionTypeEnum.CollectionActionTypeEnumSerializer))]
[Serializable]
public readonly record struct CollectionActionTypeEnum : IStringEnum
{
    public static readonly CollectionActionTypeEnum Email = new(Values.Email);

    public static readonly CollectionActionTypeEnum Sms = new(Values.Sms);

    public static readonly CollectionActionTypeEnum PhoneCall = new(Values.PhoneCall);

    public static readonly CollectionActionTypeEnum PushNotification = new(Values.PushNotification);

    public CollectionActionTypeEnum(string value)
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
    public static CollectionActionTypeEnum FromCustom(string value)
    {
        return new CollectionActionTypeEnum(value);
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

    public static bool operator ==(CollectionActionTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CollectionActionTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CollectionActionTypeEnum value) => value.Value;

    public static explicit operator CollectionActionTypeEnum(string value) => new(value);

    internal class CollectionActionTypeEnumSerializer : JsonConverter<CollectionActionTypeEnum>
    {
        public override CollectionActionTypeEnum Read(
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
            return new CollectionActionTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CollectionActionTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CollectionActionTypeEnum ReadAsPropertyName(
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
            return new CollectionActionTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CollectionActionTypeEnum value,
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
        public const string Email = "email";

        public const string Sms = "sms";

        public const string PhoneCall = "phone_call";

        public const string PushNotification = "push_notification";
    }
}
