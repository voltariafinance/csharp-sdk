using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(CollectionActionStatusEnum.CollectionActionStatusEnumSerializer))]
[Serializable]
public readonly record struct CollectionActionStatusEnum : IStringEnum
{
    public static readonly CollectionActionStatusEnum Pending = new(Values.Pending);

    public static readonly CollectionActionStatusEnum Completed = new(Values.Completed);

    public static readonly CollectionActionStatusEnum Failed = new(Values.Failed);

    public static readonly CollectionActionStatusEnum Skipped = new(Values.Skipped);

    public CollectionActionStatusEnum(string value)
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
    public static CollectionActionStatusEnum FromCustom(string value)
    {
        return new CollectionActionStatusEnum(value);
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

    public static bool operator ==(CollectionActionStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CollectionActionStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CollectionActionStatusEnum value) => value.Value;

    public static explicit operator CollectionActionStatusEnum(string value) => new(value);

    internal class CollectionActionStatusEnumSerializer : JsonConverter<CollectionActionStatusEnum>
    {
        public override CollectionActionStatusEnum Read(
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
            return new CollectionActionStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CollectionActionStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CollectionActionStatusEnum ReadAsPropertyName(
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
            return new CollectionActionStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CollectionActionStatusEnum value,
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
        public const string Pending = "pending";

        public const string Completed = "completed";

        public const string Failed = "failed";

        public const string Skipped = "skipped";
    }
}
