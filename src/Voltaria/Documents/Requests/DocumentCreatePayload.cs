using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record DocumentCreatePayload
{
    [JsonIgnore]
    public string? ClientId { get; set; }

    [JsonIgnore]
    public string? LoanId { get; set; }

    [JsonIgnore]
    public string? InstallmentId { get; set; }

    [JsonIgnore]
    public string? WaterfallId { get; set; }

    /// <summary>
    /// The category of the document. Available options can be fetched from the available categories endpoint. '.../documents/available-categories'.
    /// </summary>
    public required string Category { get; set; }

    /// <summary>
    /// The name of the file
    /// </summary>
    public required string FileName { get; set; }

    public required FileParameter File { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
