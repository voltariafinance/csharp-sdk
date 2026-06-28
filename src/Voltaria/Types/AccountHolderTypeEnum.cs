using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(AccountHolderTypeEnum.AccountHolderTypeEnumSerializer))]
[Serializable]
public readonly record struct AccountHolderTypeEnum : IStringEnum
{
    public static readonly AccountHolderTypeEnum Private = new(Values.Private);

    public static readonly AccountHolderTypeEnum Business = new(Values.Business);

    public AccountHolderTypeEnum(string value)
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
    public static AccountHolderTypeEnum FromCustom(string value)
    {
        return new AccountHolderTypeEnum(value);
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

    public static bool operator ==(AccountHolderTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AccountHolderTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AccountHolderTypeEnum value) => value.Value;

    public static explicit operator AccountHolderTypeEnum(string value) => new(value);

    internal class AccountHolderTypeEnumSerializer : JsonConverter<AccountHolderTypeEnum>
    {
        public override AccountHolderTypeEnum Read(
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
            return new AccountHolderTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AccountHolderTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AccountHolderTypeEnum ReadAsPropertyName(
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
            return new AccountHolderTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AccountHolderTypeEnum value,
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
        public const string Private = "private";

        public const string Business = "business";
    }
}
