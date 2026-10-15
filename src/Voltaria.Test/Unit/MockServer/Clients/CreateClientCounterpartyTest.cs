using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Clients;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateClientCounterpartyTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "name": "x"
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "country": "country",
              "company_number": "company_number",
              "status": "pending",
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z",
              "client_id": "client_id",
              "notes": "notes"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/clients/client_id/counterparties")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Clients.CreateClientCounterpartyAsync(
            new ClientCounterpartyCreatePayload
            {
                ClientId = "client_id",
                Name = "x",
                Country = null,
                CompanyNumber = null,
                Notes = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "name": "Acme Installations Ltd"
            }
            """;

        const string mockResponse = """
            {
              "id": "client_counterparty_2Hq8XzLp4A",
              "name": "Acme Installations Ltd",
              "country": "country",
              "company_number": "company_number",
              "status": "pending",
              "created_at": "2026-10-13T10:00:00.000Z",
              "updated_at": "2026-10-13T10:00:00.000Z",
              "client_id": "client_1234567890abcdef",
              "notes": "notes"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/clients/client_id/counterparties")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Clients.CreateClientCounterpartyAsync(
            new ClientCounterpartyCreatePayload
            {
                ClientId = "client_id",
                Name = "Acme Installations Ltd",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
