using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Loans;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetLoanReviewRequestTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/loans/review-requests/request_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Loans.GetLoanReviewRequestAsync(
            new GetLoanReviewRequestRequest { RequestId = "request_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/loans/review-requests/request_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Loans.GetLoanReviewRequestAsync(
            new GetLoanReviewRequestRequest { RequestId = "request_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
