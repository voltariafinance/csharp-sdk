using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Tasks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTasksTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "items": [
                {
                  "id": "id",
                  "title": "title",
                  "description": "description",
                  "status": "active",
                  "priority": "low",
                  "assignee_id": "assignee_id",
                  "due_at": "2024-01-15T09:30:00.000Z",
                  "completed_at": "2024-01-15T09:30:00.000Z",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z",
                  "partner_id": "partner_id",
                  "client_id": "client_id",
                  "loan_id": "loan_id",
                  "installment_id": "installment_id",
                  "waterfall_id": "waterfall_id"
                },
                {
                  "id": "id",
                  "title": "title",
                  "description": "description",
                  "status": "active",
                  "priority": "low",
                  "assignee_id": "assignee_id",
                  "due_at": "2024-01-15T09:30:00.000Z",
                  "completed_at": "2024-01-15T09:30:00.000Z",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z",
                  "partner_id": "partner_id",
                  "client_id": "client_id",
                  "loan_id": "loan_id",
                  "installment_id": "installment_id",
                  "waterfall_id": "waterfall_id"
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
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v2/tasks").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Tasks.ListTasksAsync(new ListTasksRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "items": [
                {
                  "id": "task_1234567890abcdef",
                  "title": "Send updated bank statement",
                  "description": "description",
                  "status": "active",
                  "priority": "low",
                  "assignee_id": "assignee_id",
                  "due_at": "2024-01-15T09:30:00.000Z",
                  "completed_at": "2024-01-15T09:30:00.000Z",
                  "created_at": "2026-09-14T12:00:00.000Z",
                  "updated_at": "2026-09-14T12:00:00.000Z",
                  "partner_id": "partner_id",
                  "client_id": "client_id",
                  "loan_id": "loan_id",
                  "installment_id": "installment_id",
                  "waterfall_id": "waterfall_id"
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
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v2/tasks").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Tasks.ListTasksAsync(new ListTasksRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }
}
