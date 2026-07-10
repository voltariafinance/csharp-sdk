using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(
    typeof(CollectionActionLogUpdatePayloadStatus.CollectionActionLogUpdatePayloadStatusSerializer)
)]
[Serializable]
public readonly record struct CollectionActionLogUpdatePayloadStatus : IStringEnum
{
    public static readonly CollectionActionLogUpdatePayloadStatus Completed = new(Values.Completed);

    public static readonly CollectionActionLogUpdatePayloadStatus Failed = new(Values.Failed);

    public CollectionActionLogUpdatePayloadStatus(string value)
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
    public static CollectionActionLogUpdatePayloadStatus FromCustom(string value)
    {
        return new CollectionActionLogUpdatePayloadStatus(value);
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

    public static bool operator ==(CollectionActionLogUpdatePayloadStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CollectionActionLogUpdatePayloadStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CollectionActionLogUpdatePayloadStatus value) =>
        value.Value;

    public static explicit operator CollectionActionLogUpdatePayloadStatus(string value) =>
        new(value);

    internal class CollectionActionLogUpdatePayloadStatusSerializer
        : JsonConverter<CollectionActionLogUpdatePayloadStatus>
    {
        public override CollectionActionLogUpdatePayloadStatus Read(
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
            return new CollectionActionLogUpdatePayloadStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CollectionActionLogUpdatePayloadStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CollectionActionLogUpdatePayloadStatus ReadAsPropertyName(
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
            return new CollectionActionLogUpdatePayloadStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CollectionActionLogUpdatePayloadStatus value,
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
        public const string Completed = "completed";

        public const string Failed = "failed";
    }
}
