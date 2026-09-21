using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Tasks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTaskStatusHistoryTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "items": [
                {
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "old_status": "active",
                  "new_status": "active",
                  "actor_type": "partner"
                },
                {
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "old_status": "active",
                  "new_status": "active",
                  "actor_type": "partner"
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
                    .WithPath("/v2/tasks/task_id/status-history")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Tasks.ListTaskStatusHistoryAsync(
            new ListTaskStatusHistoryRequest { TaskId = "task_id" }
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
                  "created_at": "2026-09-14T12:00:00.000Z",
                  "old_status": "active",
                  "new_status": "active",
                  "actor_type": "partner"
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
                    .WithPath("/v2/tasks/task_id/status-history")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Tasks.ListTaskStatusHistoryAsync(
            new ListTaskStatusHistoryRequest { TaskId = "task_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
