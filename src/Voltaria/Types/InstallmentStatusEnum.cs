using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(InstallmentStatusEnum.InstallmentStatusEnumSerializer))]
[Serializable]
public readonly record struct InstallmentStatusEnum : IStringEnum
{
    public static readonly InstallmentStatusEnum Active = new(Values.Active);

    public static readonly InstallmentStatusEnum Overdue = new(Values.Overdue);

    public static readonly InstallmentStatusEnum Default = new(Values.Default);

    public static readonly InstallmentStatusEnum Sold = new(Values.Sold);

    public static readonly InstallmentStatusEnum Restructured = new(Values.Restructured);

    public static readonly InstallmentStatusEnum Repaid = new(Values.Repaid);

    public static readonly InstallmentStatusEnum Pending = new(Values.Pending);

    public static readonly InstallmentStatusEnum Deleted = new(Values.Deleted);

    public static readonly InstallmentStatusEnum Inactive = new(Values.Inactive);

    public InstallmentStatusEnum(string value)
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
    public static InstallmentStatusEnum FromCustom(string value)
    {
        return new InstallmentStatusEnum(value);
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

    public static bool operator ==(InstallmentStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InstallmentStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InstallmentStatusEnum value) => value.Value;

    public static explicit operator InstallmentStatusEnum(string value) => new(value);

    internal class InstallmentStatusEnumSerializer : JsonConverter<InstallmentStatusEnum>
    {
        public override InstallmentStatusEnum Read(
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
            return new InstallmentStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            InstallmentStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override InstallmentStatusEnum ReadAsPropertyName(
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
            return new InstallmentStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            InstallmentStatusEnum value,
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

        public const string Overdue = "overdue";

        public const string Default = "default";

        public const string Sold = "sold";

        public const string Restructured = "restructured";

        public const string Repaid = "repaid";

        public const string Pending = "pending";

        public const string Deleted = "deleted";

        public const string Inactive = "inactive";
    }
}
