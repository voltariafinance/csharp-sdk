using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(ChecklistTypeEnum.ChecklistTypeEnumSerializer))]
[Serializable]
public readonly record struct ChecklistTypeEnum : IStringEnum
{
    public static readonly ChecklistTypeEnum Client = new(Values.Client);

    public static readonly ChecklistTypeEnum Loan = new(Values.Loan);

    public ChecklistTypeEnum(string value)
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
    public static ChecklistTypeEnum FromCustom(string value)
    {
        return new ChecklistTypeEnum(value);
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

    public static bool operator ==(ChecklistTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ChecklistTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ChecklistTypeEnum value) => value.Value;

    public static explicit operator ChecklistTypeEnum(string value) => new(value);

    internal class ChecklistTypeEnumSerializer : JsonConverter<ChecklistTypeEnum>
    {
        public override ChecklistTypeEnum Read(
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
            return new ChecklistTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ChecklistTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ChecklistTypeEnum ReadAsPropertyName(
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
            return new ChecklistTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ChecklistTypeEnum value,
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
        public const string Client = "client";

        public const string Loan = "loan";
    }
}
