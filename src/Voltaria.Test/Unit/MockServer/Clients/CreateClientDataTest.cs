using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Clients;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateClientDataTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "client_id": "client_id",
              "data": {
                "data": {
                  "key": "value"
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "created_at": "2024-01-15T09:30:00.000Z",
              "client_id": "client_id",
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
                    .WithPath("/v2/clients/data")
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

        var response = await Client.Clients.CreateClientDataAsync(
            new ClientDataCreatePayload
            {
                ClientId = "client_id",
                Data = new Dictionary<string, object?>()
                {
                    {
                        "data",
                        new Dictionary<object, object?>() { { "key", "value" } }
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "client_id": "client_123",
              "data": {
                "key1": "value1",
                "key2": "value2"
              }
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "created_at": "2024-01-15T09:30:00.000Z",
              "client_id": "client_id",
              "data": {
                "key": "value"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/clients/data")
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

        var response = await Client.Clients.CreateClientDataAsync(
            new ClientDataCreatePayload
            {
                ClientId = "client_123",
                Data = new Dictionary<string, object?>()
                {
                    { "key1", "value1" },
                    { "key2", "value2" },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
