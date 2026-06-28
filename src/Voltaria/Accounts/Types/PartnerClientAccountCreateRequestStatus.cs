using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(
    typeof(PartnerClientAccountCreateRequestStatus.PartnerClientAccountCreateRequestStatusSerializer)
)]
[Serializable]
public readonly record struct PartnerClientAccountCreateRequestStatus : IStringEnum
{
    public static readonly PartnerClientAccountCreateRequestStatus Active = new(Values.Active);

    public static readonly PartnerClientAccountCreateRequestStatus Passive = new(Values.Passive);

    public PartnerClientAccountCreateRequestStatus(string value)
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
    public static PartnerClientAccountCreateRequestStatus FromCustom(string value)
    {
        return new PartnerClientAccountCreateRequestStatus(value);
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

    public static bool operator ==(PartnerClientAccountCreateRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PartnerClientAccountCreateRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PartnerClientAccountCreateRequestStatus value) =>
        value.Value;

    public static explicit operator PartnerClientAccountCreateRequestStatus(string value) =>
        new(value);

    internal class PartnerClientAccountCreateRequestStatusSerializer
        : JsonConverter<PartnerClientAccountCreateRequestStatus>
    {
        public override PartnerClientAccountCreateRequestStatus Read(
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
            return new PartnerClientAccountCreateRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PartnerClientAccountCreateRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PartnerClientAccountCreateRequestStatus ReadAsPropertyName(
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
            return new PartnerClientAccountCreateRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PartnerClientAccountCreateRequestStatus value,
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

        public const string Passive = "passive";
    }
}
