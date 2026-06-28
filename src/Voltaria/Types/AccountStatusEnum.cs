using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[JsonConverter(typeof(AccountStatusEnum.AccountStatusEnumSerializer))]
[Serializable]
public readonly record struct AccountStatusEnum : IStringEnum
{
    public static readonly AccountStatusEnum Active = new(Values.Active);

    public static readonly AccountStatusEnum Passive = new(Values.Passive);

    public static readonly AccountStatusEnum Pending = new(Values.Pending);

    public AccountStatusEnum(string value)
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
    public static AccountStatusEnum FromCustom(string value)
    {
        return new AccountStatusEnum(value);
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

    public static bool operator ==(AccountStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AccountStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AccountStatusEnum value) => value.Value;

    public static explicit operator AccountStatusEnum(string value) => new(value);

    internal class AccountStatusEnumSerializer : JsonConverter<AccountStatusEnum>
    {
        public override AccountStatusEnum Read(
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
            return new AccountStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AccountStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AccountStatusEnum ReadAsPropertyName(
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
            return new AccountStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AccountStatusEnum value,
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

        public const string Pending = "pending";
    }
}
