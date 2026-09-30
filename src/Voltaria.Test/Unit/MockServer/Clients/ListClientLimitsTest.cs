using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Clients;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListClientLimitsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "items": [
                {
                  "id": "id",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "currency": "eur",
                  "limit": "limit"
                },
                {
                  "id": "id",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "currency": "eur",
                  "limit": "limit"
                }
              ],
              "page": 1,
              "page_size": 1,
              "items_in_page": 1,
              "total_items": 1,
              "total_pages": 1,
              "has_next": true,
              "has_previous": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/clients/client_id/limits")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Clients.ListClientLimitsAsync(
            new ListClientLimitsRequest { ClientId = "client_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "items": [
                {
                  "id": "limit_a1B2c3D4e5",
                  "created_at": "2026-09-11T10:00:00.000Z",
                  "currency": "eur",
                  "limit": "200000.00"
                }
              ],
              "page": 1,
              "page_size": 1,
              "items_in_page": 1,
              "total_items": 1,
              "total_pages": 1,
              "has_next": true,
              "has_previous": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/clients/client_id/limits")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Clients.ListClientLimitsAsync(
            new ListClientLimitsRequest { ClientId = "client_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
