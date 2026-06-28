using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Clients;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListLimitRequestsTest : BaseMockServerTest
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
                  "status": "pending",
                  "requested_limit": "requested_limit",
                  "reason": "reason",
                  "response": "response",
                  "waiver_id": "waiver_id",
                  "created_at": "2024-01-15T09:30:00.000Z"
                },
                {
                  "id": "id",
                  "client_id": "client_id",
                  "status": "pending",
                  "requested_limit": "requested_limit",
                  "reason": "reason",
                  "response": "response",
                  "waiver_id": "waiver_id",
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
                    .WithPath("/v2/clients/limit-requests")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Clients.ListLimitRequestsAsync(new ListLimitRequestsRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "items": [
                {
                  "id": "lr_1234567890abcdef",
                  "client_id": "client_1234567890abcdef",
                  "status": "pending",
                  "requested_limit": "requested_limit",
                  "reason": "Need more credit for business expansion",
                  "response": "response",
                  "waiver_id": "waiver_id",
                  "created_at": "2023-10-01T12:00:00.000Z"
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
                    .WithPath("/v2/clients/limit-requests")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Clients.ListLimitRequestsAsync(new ListLimitRequestsRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }
}
