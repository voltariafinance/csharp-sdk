using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Loans;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListLoanReviewRequestsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "items": [
                {
                  "id": "id",
                  "loan_id": "loan_id",
                  "client_id": "client_id",
                  "status": "pending",
                  "notes": "notes",
                  "response": "response",
                  "reviewed_at": "2024-01-15T09:30:00.000Z",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z"
                },
                {
                  "id": "id",
                  "loan_id": "loan_id",
                  "client_id": "client_id",
                  "status": "pending",
                  "notes": "notes",
                  "response": "response",
                  "reviewed_at": "2024-01-15T09:30:00.000Z",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z"
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
                    .WithPath("/v2/loans/review-requests")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Loans.ListLoanReviewRequestsAsync(
            new ListLoanReviewRequestsRequest()
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
                  "id": "loan_review_1234567890abcdef",
                  "loan_id": "loan_1234567890abcdef",
                  "client_id": "client_1234567890abcdef",
                  "status": "pending",
                  "notes": "notes",
                  "response": "response",
                  "reviewed_at": "2024-01-15T09:30:00.000Z",
                  "created_at": "2026-06-29T12:00:00.000Z",
                  "updated_at": "2026-06-29T12:00:00.000Z"
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
                    .WithPath("/v2/loans/review-requests")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Loans.ListLoanReviewRequestsAsync(
            new ListLoanReviewRequestsRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
