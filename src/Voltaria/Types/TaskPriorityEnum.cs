using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(TaskPriorityEnum.TaskPriorityEnumSerializer))]
[Serializable]
public readonly record struct TaskPriorityEnum : IStringEnum
{
    public static readonly TaskPriorityEnum Low = new(Values.Low);

    public static readonly TaskPriorityEnum Medium = new(Values.Medium);

    public static readonly TaskPriorityEnum High = new(Values.High);

    public static readonly TaskPriorityEnum Urgent = new(Values.Urgent);

    public TaskPriorityEnum(string value)
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
    public static TaskPriorityEnum FromCustom(string value)
    {
        return new TaskPriorityEnum(value);
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

    public static bool operator ==(TaskPriorityEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TaskPriorityEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TaskPriorityEnum value) => value.Value;

    public static explicit operator TaskPriorityEnum(string value) => new(value);

    internal class TaskPriorityEnumSerializer : JsonConverter<TaskPriorityEnum>
    {
        public override TaskPriorityEnum Read(
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
            return new TaskPriorityEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TaskPriorityEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TaskPriorityEnum ReadAsPropertyName(
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
            return new TaskPriorityEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TaskPriorityEnum value,
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
        public const string Low = "low";

        public const string Medium = "medium";

        public const string High = "high";

        public const string Urgent = "urgent";
    }
}
