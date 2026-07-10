using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Collections;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListCollectionActionLogsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "items": [
                {
                  "id": "id",
                  "collection_action_id": "collection_action_id",
                  "action_type": "email",
                  "action_name": "action_name",
                  "status": "pending",
                  "client_id": "client_id",
                  "loan_id": "loan_id",
                  "installment_id": "installment_id",
                  "flag": true,
                  "notes": "notes",
                  "scheduled_for": "2024-01-15T09:30:00.000Z"
                },
                {
                  "id": "id",
                  "collection_action_id": "collection_action_id",
                  "action_type": "email",
                  "action_name": "action_name",
                  "status": "pending",
                  "client_id": "client_id",
                  "loan_id": "loan_id",
                  "installment_id": "installment_id",
                  "flag": true,
                  "notes": "notes",
                  "scheduled_for": "2024-01-15T09:30:00.000Z"
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
                    .WithPath("/v2/collection-actions/logs")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Collections.ListCollectionActionLogsAsync(
            new ListCollectionActionLogsRequest()
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
                  "id": "collection_action_log_123",
                  "collection_action_id": "collection_action_123",
                  "action_type": "email",
                  "action_name": "Overdue reminder call",
                  "status": "pending",
                  "client_id": "client_123",
                  "loan_id": "loan_456",
                  "installment_id": "installment_789",
                  "flag": false,
                  "notes": "notes",
                  "scheduled_for": "2026-07-10T09:00:00.000Z"
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
                    .WithPath("/v2/collection-actions/logs")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Collections.ListCollectionActionLogsAsync(
            new ListCollectionActionLogsRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
