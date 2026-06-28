using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Webhooks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListWebhookLogsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "items": [
                {
                  "id": "id",
                  "webhook_id": "webhook_id",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z",
                  "event_type": "loan.updated",
                  "webhook_url": "webhook_url",
                  "success": true,
                  "status_code": 1,
                  "error_message": "error_message",
                  "request_duration_ms": 1,
                  "request_body": {
                    "request_body": {
                      "key": "value"
                    }
                  }
                },
                {
                  "id": "id",
                  "webhook_id": "webhook_id",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z",
                  "event_type": "loan.updated",
                  "webhook_url": "webhook_url",
                  "success": true,
                  "status_code": 1,
                  "error_message": "error_message",
                  "request_duration_ms": 1,
                  "request_body": {
                    "request_body": {
                      "key": "value"
                    }
                  }
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
                WireMock.RequestBuilders.Request.Create().WithPath("/v2/webhooks/logs").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Webhooks.ListWebhookLogsAsync(new ListWebhookLogsRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "items": [
                {
                  "id": "wlog_abc123",
                  "webhook_id": "webhook_xyz789",
                  "created_at": "2025-04-14T15:30:00.000Z",
                  "updated_at": "2025-04-14T15:30:05.000Z",
                  "event_type": "loan.updated",
                  "webhook_url": "https://example.com/webhook",
                  "success": true,
                  "status_code": 200,
                  "error_message": "error_message",
                  "request_duration_ms": 153,
                  "request_body": {
                    "data": {
                      "id": "loan_12345",
                      "new_status": "active",
                      "old_status": "pending",
                      "updated_at": "2023-05-01T10:00:00Z"
                    },
                    "event_type": "loan.updated",
                    "id": "evt_1744810323_partner_0",
                    "subscription_id": "webhook_5uNMts5hRr",
                    "triggered_at": "2025-04-16T13:32:03.680615+00:00Z"
                  }
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
                WireMock.RequestBuilders.Request.Create().WithPath("/v2/webhooks/logs").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Webhooks.ListWebhookLogsAsync(new ListWebhookLogsRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }
}
