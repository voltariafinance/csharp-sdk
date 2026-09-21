using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(TaskPublicActorTypeEnum.TaskPublicActorTypeEnumSerializer))]
[Serializable]
public readonly record struct TaskPublicActorTypeEnum : IStringEnum
{
    public static readonly TaskPublicActorTypeEnum Partner = new(Values.Partner);

    public static readonly TaskPublicActorTypeEnum Support = new(Values.Support);

    public TaskPublicActorTypeEnum(string value)
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
    public static TaskPublicActorTypeEnum FromCustom(string value)
    {
        return new TaskPublicActorTypeEnum(value);
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

    public static bool operator ==(TaskPublicActorTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TaskPublicActorTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TaskPublicActorTypeEnum value) => value.Value;

    public static explicit operator TaskPublicActorTypeEnum(string value) => new(value);

    internal class TaskPublicActorTypeEnumSerializer : JsonConverter<TaskPublicActorTypeEnum>
    {
        public override TaskPublicActorTypeEnum Read(
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
            return new TaskPublicActorTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TaskPublicActorTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TaskPublicActorTypeEnum ReadAsPropertyName(
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
            return new TaskPublicActorTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TaskPublicActorTypeEnum value,
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
        public const string Partner = "partner";

        public const string Support = "support";
    }
}
