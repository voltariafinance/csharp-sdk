using global::System.Net.Http;

namespace Voltaria.Core;

internal static class HttpMethodExtensions
{
    public static readonly HttpMethod Patch = new("PATCH");
}
