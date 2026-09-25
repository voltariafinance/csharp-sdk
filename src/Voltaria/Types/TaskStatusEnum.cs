using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(TaskStatusEnum.TaskStatusEnumSerializer))]
[Serializable]
public readonly record struct TaskStatusEnum : IStringEnum
{
    public static readonly TaskStatusEnum Active = new(Values.Active);

    public static readonly TaskStatusEnum InProgress = new(Values.InProgress);

    public static readonly TaskStatusEnum Blocked = new(Values.Blocked);

    public static readonly TaskStatusEnum ReviewNeeded = new(Values.ReviewNeeded);

    public static readonly TaskStatusEnum Done = new(Values.Done);

    public static readonly TaskStatusEnum Cancelled = new(Values.Cancelled);

    public TaskStatusEnum(string value)
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
    public static TaskStatusEnum FromCustom(string value)
    {
        return new TaskStatusEnum(value);
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

    public static bool operator ==(TaskStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TaskStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TaskStatusEnum value) => value.Value;

    public static explicit operator TaskStatusEnum(string value) => new(value);

    internal class TaskStatusEnumSerializer : JsonConverter<TaskStatusEnum>
    {
        public override TaskStatusEnum Read(
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
            return new TaskStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TaskStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TaskStatusEnum ReadAsPropertyName(
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
            return new TaskStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TaskStatusEnum value,
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

        public const string InProgress = "in_progress";

        public const string Blocked = "blocked";

        public const string ReviewNeeded = "review_needed";

        public const string Done = "done";

        public const string Cancelled = "cancelled";
    }
}
