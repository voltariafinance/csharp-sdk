using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Webhooks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateWebhookSubscriptionTest : BaseMockServerTest
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
                    .WithPath("/v2/webhooks/subscriptions/webhook_id")
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

        var response = await Client.Webhooks.UpdateWebhookSubscriptionAsync(
            new WebhookUpdatePayload
            {
                WebhookId = "webhook_id",
                Url = null,
                Description = null,
                EventType = null,
                Status = null,
                Retry = null,
                Secret = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "url": "https://example.com/webhooks/v2",
              "description": "Updated webhook endpoint",
              "event_type": "installment.updated",
              "status": "paused",
              "retry": true,
              "secret": "whsec_updated_secret_here"
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
                    .WithPath("/v2/webhooks/subscriptions/webhook_id")
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

        var response = await Client.Webhooks.UpdateWebhookSubscriptionAsync(
            new WebhookUpdatePayload
            {
                WebhookId = "webhook_id",
                Url = "https://example.com/webhooks/v2",
                Description = "Updated webhook endpoint",
                EventType = WebhookEventTypeEnum.InstallmentUpdated,
                Status = WebhookStatusEnum.Paused,
                Retry = true,
                Secret = "whsec_updated_secret_here",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
