using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Repayments;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetBulkRepaymentStatusTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "task_id": "task_id",
              "status": "status",
              "current": 1,
              "total": 1,
              "result": {
                "success_count": 1,
                "failure_count": 1,
                "total_processed": 1,
                "processing_time_seconds": 1.1,
                "results": [
                  {
                    "index": 1,
                    "success": true,
                    "repayment_log_id": "repayment_log_id",
                    "error": "error",
                    "installment_id": "installment_id",
                    "loan_id": "loan_id",
                    "amount": "amount"
                  },
                  {
                    "index": 1,
                    "success": true,
                    "repayment_log_id": "repayment_log_id",
                    "error": "error",
                    "installment_id": "installment_id",
                    "loan_id": "loan_id",
                    "amount": "amount"
                  }
                ]
              },
              "error": "error"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/repayments/bulk/task_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Repayments.GetBulkRepaymentStatusAsync(
            new GetBulkRepaymentStatusRequest { TaskId = "task_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "task_id": "task_id",
              "status": "status",
              "current": 1,
              "total": 1,
              "result": {
                "success_count": 1,
                "failure_count": 1,
                "total_processed": 1,
                "processing_time_seconds": 1.1,
                "results": [
                  {
                    "index": 1,
                    "success": true
                  }
                ]
              },
              "error": "error"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/repayments/bulk/task_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Repayments.GetBulkRepaymentStatusAsync(
            new GetBulkRepaymentStatusRequest { TaskId = "task_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
