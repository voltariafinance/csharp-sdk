using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Sandbox;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateClientTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {}
            """;

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
              "status": "active",
              "limits": [
                {
                  "currency": "eur",
                  "max_maturity_days": 1,
                  "limit": "limit",
                  "rate": "rate",
                  "outstanding": "outstanding",
                  "available": "available",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z"
                },
                {
                  "currency": "eur",
                  "max_maturity_days": 1,
                  "limit": "limit",
                  "rate": "rate",
                  "outstanding": "outstanding",
                  "available": "available",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z"
                }
              ],
              "data": {
                "data": {
                  "key": "value"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/sandbox/clients/client_id")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sandbox.UpdateClientAsync(
            new ClientUpdateSandbox
            {
                ClientId = "client_id",
                Status = null,
                Limit = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {}
            """;

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
              "status": "active",
              "limits": [
                {
                  "currency": "eur",
                  "max_maturity_days": 1,
                  "limit": "limit",
                  "rate": "rate",
                  "outstanding": "outstanding",
                  "available": "available",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z"
                }
              ],
              "data": {
                "key": "value"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/sandbox/clients/client_id")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sandbox.UpdateClientAsync(
            new ClientUpdateSandbox { ClientId = "client_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
