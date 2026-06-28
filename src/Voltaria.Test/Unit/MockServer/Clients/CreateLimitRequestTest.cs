using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Clients;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateLimitRequestTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "client_id": "client_id",
              "requested_limit": 1.1,
              "reason": "reason"
            }
            """;

        const string mockResponse = """
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/clients/limit-requests")
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

        var response = await Client.Clients.CreateLimitRequestAsync(
            new LimitRequestCreatePayload
            {
                ClientId = "client_id",
                RequestedLimit = 1.1,
                Reason = "reason",
                WaiverRequest = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "client_id": "client_1234567890abcdef",
              "requested_limit": 1.1,
              "reason": "Need more credit for business expansion"
            }
            """;

        const string mockResponse = """
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/clients/limit-requests")
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

        var response = await Client.Clients.CreateLimitRequestAsync(
            new LimitRequestCreatePayload
            {
                ClientId = "client_1234567890abcdef",
                RequestedLimit = 1.1,
                Reason = "Need more credit for business expansion",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
