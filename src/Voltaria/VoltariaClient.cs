namespace Voltaria;

/// <summary>
/// The well-known Voltaria API environments.
/// </summary>
public enum VoltariaEnvironment
{
    /// <summary>
    /// Production environment (<c>https://api.voltaria.io</c>).
    /// </summary>
    Production,

    /// <summary>
    /// Sandbox environment (<c>https://api.sandbox.voltaria.io</c>).
    /// </summary>
    Sandbox,
}

/// <summary>
/// Thrown when the supplied API key does not carry a recognised environment
/// prefix (<c>live_</c> or <c>sandbox_</c>) and no explicit environment or base
/// URL was provided to override prefix routing.
/// </summary>
[Serializable]
public class InvalidApiKeyException : Exception
{
    public InvalidApiKeyException()
        : base("The API key is missing a recognised environment prefix ('live_' or 'sandbox_').") { }

    public InvalidApiKeyException(string message)
        : base(message) { }

    public InvalidApiKeyException(string message, Exception innerException)
        : base(message, innerException) { }
}

/// <summary>
/// Options that control how <see cref="Voltaria"/> resolves the API base URL
/// before delegating to the generated <see cref="VoltariaApiClient"/>.
/// </summary>
/// <remarks>
/// An explicitly supplied <see cref="Environment"/> or <see cref="BaseUrl"/>
/// always overrides routing derived from the API-key prefix.
/// </remarks>
[Serializable]
public class VoltariaOptions
{
    /// <summary>
    /// An explicit environment. When set, prefix routing is bypassed and this
    /// environment's base URL is used.
    /// </summary>
    public VoltariaEnvironment? Environment { get; set; }

    /// <summary>
    /// An explicit base URL. When set (and <see cref="Environment"/> is not),
    /// prefix routing is bypassed and this URL is used verbatim.
    /// </summary>
    public string? BaseUrl { get; set; }

    /// <summary>
    /// Underlying generated client options (HTTP client, retries, timeout,
    /// additional headers, ...). Its <c>BaseUrl</c> is ignored in favour of the
    /// resolved value; use <see cref="BaseUrl"/> above to override.
    /// </summary>
    public ClientOptions? ClientOptions { get; set; }
}

/// <summary>
/// Prefix-routing entry point for the Voltaria SDK.
///
/// The API base URL is derived automatically from the API-key prefix:
/// <list type="bullet">
///   <item><description><c>live_</c> &#8594; production (<c>https://api.voltaria.io</c>)</description></item>
///   <item><description><c>sandbox_</c> &#8594; sandbox (<c>https://api.sandbox.voltaria.io</c>)</description></item>
/// </list>
/// An unknown or empty prefix throws <see cref="InvalidApiKeyException"/>.
/// An explicitly supplied environment or base URL always overrides prefix routing.
/// </summary>
public class VoltariaClient : VoltariaApiClient
{
    /// <summary>
    /// The base URL that was resolved for this client (after applying any
    /// explicit overrides or prefix routing).
    /// </summary>
    public string BaseUrl { get; }

    /// <summary>
    /// Creates a client, resolving the base URL from <paramref name="apiKey"/>'s
    /// prefix unless <paramref name="options"/> supplies an explicit override.
    /// </summary>
    /// <param name="apiKey">The bearer API key (e.g. <c>live_...</c> or <c>sandbox_...</c>).</param>
    /// <param name="options">Optional overrides and underlying client options.</param>
    /// <exception cref="InvalidApiKeyException">
    /// Thrown when no override is supplied and the key prefix is unrecognised.
    /// </exception>
    public VoltariaClient(string apiKey, VoltariaOptions? options = null)
        : this(apiKey, ResolveBaseUrl(apiKey, options), options?.ClientOptions) { }

    private VoltariaClient(string apiKey, string baseUrl, ClientOptions? clientOptions)
        : base(apiKey, WithBaseUrl(clientOptions, baseUrl))
    {
        BaseUrl = baseUrl;
    }

    /// <summary>
    /// Maps a <see cref="VoltariaEnvironment"/> to its base URL.
    /// </summary>
    public static string GetBaseUrl(VoltariaEnvironment environment) =>
        environment switch
        {
            VoltariaEnvironment.Production => VoltariaApiEnvironment.Production,
            VoltariaEnvironment.Sandbox => VoltariaApiEnvironment.Sandbox,
            _ => throw new ArgumentOutOfRangeException(nameof(environment), environment, null),
        };

    /// <summary>
    /// Resolves the effective base URL following the documented precedence:
    /// explicit environment &#8594; explicit base URL &#8594; API-key prefix.
    /// </summary>
    /// <exception cref="InvalidApiKeyException">
    /// Thrown when no override is supplied and the key prefix is unrecognised.
    /// </exception>
    public static string ResolveBaseUrl(string apiKey, VoltariaOptions? options = null)
    {
        if (options?.Environment is { } environment)
        {
            return GetBaseUrl(environment);
        }

        if (options?.BaseUrl is { } baseUrl)
        {
            return baseUrl;
        }

        if (apiKey is null)
        {
            throw new InvalidApiKeyException();
        }

        if (apiKey.StartsWith("live_", StringComparison.Ordinal))
        {
            return VoltariaApiEnvironment.Production;
        }

        if (apiKey.StartsWith("sandbox_", StringComparison.Ordinal))
        {
            return VoltariaApiEnvironment.Sandbox;
        }

        throw new InvalidApiKeyException();
    }

    private static ClientOptions WithBaseUrl(ClientOptions? clientOptions, string baseUrl)
    {
        if (clientOptions is null)
        {
            return new ClientOptions { BaseUrl = baseUrl };
        }

        // ClientOptions.BaseUrl is init-only on modern targets, so re-create it
        // carrying over the caller's settings while overriding the base URL.
        return new ClientOptions
        {
            BaseUrl = baseUrl,
            HttpClient = clientOptions.HttpClient,
            MaxRetries = clientOptions.MaxRetries,
            Timeout = clientOptions.Timeout,
            AdditionalHeaders = clientOptions.AdditionalHeaders,
        };
    }
}
