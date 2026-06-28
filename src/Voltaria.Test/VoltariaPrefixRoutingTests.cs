using NUnit.Framework;
using Voltaria;

namespace Voltaria.Test;

[TestFixture]
public class VoltariaPrefixRoutingTests
{
    [Test]
    public void LivePrefix_RoutesToProduction()
    {
        var client = new VoltariaClient("live_abc123");
        Assert.That(client.BaseUrl, Is.EqualTo(VoltariaApiEnvironment.Production));
    }

    [Test]
    public void SandboxPrefix_RoutesToSandbox()
    {
        var client = new VoltariaClient("sandbox_abc123");
        Assert.That(client.BaseUrl, Is.EqualTo(VoltariaApiEnvironment.Sandbox));
    }

    [Test]
    public void UnknownPrefix_Throws()
    {
        Assert.Throws<InvalidApiKeyException>(() => new VoltariaClient("nope_abc123"));
    }

    [Test]
    public void EmptyKey_Throws()
    {
        Assert.Throws<InvalidApiKeyException>(() => new VoltariaClient(""));
    }

    [Test]
    public void NullKey_Throws()
    {
        Assert.Throws<InvalidApiKeyException>(() => new VoltariaClient(null!));
    }

    [Test]
    public void ExplicitBaseUrl_OverridesPrefix()
    {
        const string custom = "https://api.local.test";
        var client = new VoltariaClient(
            "live_abc123",
            new VoltariaOptions { BaseUrl = custom }
        );
        Assert.That(client.BaseUrl, Is.EqualTo(custom));
    }

    [Test]
    public void ExplicitEnvironment_OverridesPrefix()
    {
        // Key prefix says live (production), but explicit Sandbox env wins.
        var client = new VoltariaClient(
            "live_abc123",
            new VoltariaOptions { Environment = VoltariaEnvironment.Sandbox }
        );
        Assert.That(client.BaseUrl, Is.EqualTo(VoltariaApiEnvironment.Sandbox));
    }

    [Test]
    public void ExplicitEnvironment_TakesPrecedenceOverBaseUrl()
    {
        var client = new VoltariaClient(
            "live_abc123",
            new VoltariaOptions
            {
                Environment = VoltariaEnvironment.Production,
                BaseUrl = "https://ignored.example",
            }
        );
        Assert.That(client.BaseUrl, Is.EqualTo(VoltariaApiEnvironment.Production));
    }

    [Test]
    public void ExplicitOverride_AllowsUnknownPrefixWithoutThrowing()
    {
        // An override must let an otherwise-invalid key through.
        Assert.DoesNotThrow(() =>
            new VoltariaClient(
                "weird_key",
                new VoltariaOptions { Environment = VoltariaEnvironment.Sandbox }
            )
        );
    }

    [Test]
    public void ResolveBaseUrl_MatchesReferenceBehaviour()
    {
        Assert.That(
            VoltariaClient.ResolveBaseUrl("live_x"),
            Is.EqualTo(VoltariaApiEnvironment.Production)
        );
        Assert.That(
            VoltariaClient.ResolveBaseUrl("sandbox_x"),
            Is.EqualTo(VoltariaApiEnvironment.Sandbox)
        );
    }
}
