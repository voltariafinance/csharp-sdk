using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Tasks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTaskNotesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "items": [
                {
                  "id": "id",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z",
                  "content": "content",
                  "loan_id": "loan_id",
                  "installment_id": "installment_id",
                  "author_first_name": "author_first_name",
                  "author_last_name": "author_last_name",
                  "author_email": "author_email"
                },
                {
                  "id": "id",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z",
                  "content": "content",
                  "loan_id": "loan_id",
                  "installment_id": "installment_id",
                  "author_first_name": "author_first_name",
                  "author_last_name": "author_last_name",
                  "author_email": "author_email"
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
                    .WithPath("/v2/tasks/task_id/notes")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Tasks.ListTaskNotesAsync(
            new ListTaskNotesRequest { TaskId = "task_id" }
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
                  "id": "note_1234567890abcdef",
                  "created_at": "2026-05-11T12:00:00.000Z",
                  "updated_at": "2026-05-11T12:00:00.000Z",
                  "content": "Spoke with client about upcoming repayment.",
                  "loan_id": "loan_id",
                  "installment_id": "installment_id",
                  "author_first_name": "author_first_name",
                  "author_last_name": "author_last_name",
                  "author_email": "author_email"
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
                    .WithPath("/v2/tasks/task_id/notes")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Tasks.ListTaskNotesAsync(
            new ListTaskNotesRequest { TaskId = "task_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
