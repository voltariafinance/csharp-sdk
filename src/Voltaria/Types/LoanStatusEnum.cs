using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(LoanStatusEnum.LoanStatusEnumSerializer))]
[Serializable]
public readonly record struct LoanStatusEnum : IStringEnum
{
    public static readonly LoanStatusEnum Pending = new(Values.Pending);

    public static readonly LoanStatusEnum Overdue = new(Values.Overdue);

    public static readonly LoanStatusEnum Active = new(Values.Active);

    public static readonly LoanStatusEnum Default = new(Values.Default);

    public static readonly LoanStatusEnum Sold = new(Values.Sold);

    public static readonly LoanStatusEnum Restructured = new(Values.Restructured);

    public static readonly LoanStatusEnum Repaid = new(Values.Repaid);

    public static readonly LoanStatusEnum PreApproved = new(Values.PreApproved);

    public static readonly LoanStatusEnum Rejected = new(Values.Rejected);

    public static readonly LoanStatusEnum Deleted = new(Values.Deleted);

    public static readonly LoanStatusEnum Inactive = new(Values.Inactive);

    public LoanStatusEnum(string value)
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
    public static LoanStatusEnum FromCustom(string value)
    {
        return new LoanStatusEnum(value);
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

    public static bool operator ==(LoanStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LoanStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LoanStatusEnum value) => value.Value;

    public static explicit operator LoanStatusEnum(string value) => new(value);

    internal class LoanStatusEnumSerializer : JsonConverter<LoanStatusEnum>
    {
        public override LoanStatusEnum Read(
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
            return new LoanStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LoanStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LoanStatusEnum ReadAsPropertyName(
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
            return new LoanStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LoanStatusEnum value,
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

        public const string Overdue = "overdue";

        public const string Active = "active";

        public const string Default = "default";

        public const string Sold = "sold";

        public const string Restructured = "restructured";

        public const string Repaid = "repaid";

        public const string PreApproved = "pre_approved";

        public const string Rejected = "rejected";

        public const string Deleted = "deleted";

        public const string Inactive = "inactive";
    }
}
