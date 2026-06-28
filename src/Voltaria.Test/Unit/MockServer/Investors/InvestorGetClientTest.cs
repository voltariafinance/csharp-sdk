using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Investors;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class InvestorGetClientTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "id": "id",
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z",
              "correlation_id": "correlation_id",
              "name": "name",
              "type": "corporate",
              "jurisdiction": "eu",
              "company_number": "company_number",
              "status": "active"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/investors/clients/client_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Investors.InvestorGetClientAsync(
            new InvestorGetClientRequest { ClientId = "client_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "id": "client_As2fD1gaX2",
              "created_at": "2025-01-01T00:00:00.000Z",
              "updated_at": "2025-01-01T00:00:00.000Z",
              "correlation_id": "correlation_id",
              "name": "ACME Corp",
              "type": "corporate",
              "jurisdiction": "eu",
              "company_number": "company_number",
              "status": "active"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/investors/clients/client_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Investors.InvestorGetClientAsync(
            new InvestorGetClientRequest { ClientId = "client_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
