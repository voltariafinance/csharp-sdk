using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Tasks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateTaskStatusTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "status": "active"
            }
            """;

        const string mockResponse = """
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/tasks/task_id/status")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Tasks.UpdateTaskStatusAsync(
            new TaskPartnerStatusUpdatePayload
            {
                TaskId = "task_id",
                Status = TaskPartnerStatusUpdatePayloadStatus.Active,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "status": "active"
            }
            """;

        const string mockResponse = """
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/tasks/task_id/status")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Tasks.UpdateTaskStatusAsync(
            new TaskPartnerStatusUpdatePayload
            {
                TaskId = "task_id",
                Status = TaskPartnerStatusUpdatePayloadStatus.Active,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
