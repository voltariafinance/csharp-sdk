using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Webhooks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateWebhookSubscriptionTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "url": "url",
              "event_type": "loan.updated",
              "secret": "secret"
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "url": "url",
              "description": "description",
              "event_type": "loan.updated",
              "status": "active",
              "retry": true,
              "secret": "secret",
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/webhooks/subscriptions")
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

        var response = await Client.Webhooks.CreateWebhookSubscriptionAsync(
            new WebhookCreatePayload
            {
                Url = "url",
                Description = null,
                EventType = WebhookEventTypeEnum.LoanUpdated,
                Secret = "secret",
                Retry = null,
                Status = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "url": "https://example.com/webhooks",
              "description": "Loan update event",
              "event_type": "loan.updated",
              "secret": "whsec_f3o9p8h7g6j5k4l3m2n1o0p9i8u7y6t5",
              "retry": false,
              "status": "active"
            }
            """;

        const string mockResponse = """
            {
              "id": "webhook_123abc",
              "url": "https://example.com/webhooks",
              "description": "Payment notification endpoint",
              "event_type": "loan.updated",
              "status": "active",
              "retry": false,
              "secret": "whsec_f3o9p8h7g6j5k4l3m2n1o0p9i8u7y6t5",
              "created_at": "2025-04-14T12:00:00.000Z",
              "updated_at": "2025-04-14T12:00:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/webhooks/subscriptions")
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

        var response = await Client.Webhooks.CreateWebhookSubscriptionAsync(
            new WebhookCreatePayload
            {
                Url = "https://example.com/webhooks",
                Description = "Loan update event",
                EventType = WebhookEventTypeEnum.LoanUpdated,
                Secret = "whsec_f3o9p8h7g6j5k4l3m2n1o0p9i8u7y6t5",
                Retry = false,
                Status = WebhookStatusEnum.Active,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
