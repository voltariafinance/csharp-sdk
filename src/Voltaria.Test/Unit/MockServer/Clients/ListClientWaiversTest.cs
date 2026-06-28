using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Clients;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListClientWaiversTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "items": [
                {
                  "id": "id",
                  "client_id": "client_id",
                  "loan_id": "loan_id",
                  "limit_request_id": "limit_request_id",
                  "status": "pending",
                  "waiver_date": "2023-01-15",
                  "currency": "eur",
                  "amount": "amount",
                  "notes": "notes",
                  "created_at": "2024-01-15T09:30:00.000Z"
                },
                {
                  "id": "id",
                  "client_id": "client_id",
                  "loan_id": "loan_id",
                  "limit_request_id": "limit_request_id",
                  "status": "pending",
                  "waiver_date": "2023-01-15",
                  "currency": "eur",
                  "amount": "amount",
                  "notes": "notes",
                  "created_at": "2024-01-15T09:30:00.000Z"
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
                    .WithPath("/v2/clients/client_id/waivers")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Clients.ListClientWaiversAsync(
            new ListClientWaiversRequest { ClientId = "client_id" }
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
                  "id": "waiver_1234567890abcdef",
                  "client_id": "client_1234567890abcdef",
                  "loan_id": "loan_id",
                  "limit_request_id": "limit_request_id",
                  "status": "pending",
                  "waiver_date": "2024-01-15",
                  "currency": "eur",
                  "amount": "amount",
                  "notes": "notes",
                  "created_at": "2024-01-15T12:00:00.000Z"
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
                    .WithPath("/v2/clients/client_id/waivers")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Clients.ListClientWaiversAsync(
            new ListClientWaiversRequest { ClientId = "client_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
