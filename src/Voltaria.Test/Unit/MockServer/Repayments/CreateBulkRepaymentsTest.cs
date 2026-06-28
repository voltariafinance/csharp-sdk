using global::System.Globalization;
using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Repayments;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateBulkRepaymentsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "repayments": [
                {
                  "amount": 1.1
                },
                {
                  "amount": 1.1
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "task_id": "task_id",
              "total_repayments": 1,
              "estimated_completion_time": "estimated_completion_time"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/repayments/bulk")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Repayments.CreateBulkRepaymentsAsync(
            new BulkRepaymentCreatePayload
            {
                Repayments = new List<BulkRepaymentItemPayload>()
                {
                    new BulkRepaymentItemPayload
                    {
                        Amount = 1.1,
                        RepaymentDate = null,
                        Data = null,
                        IsEarlySettlement = null,
                        InstallmentId = null,
                        LoanId = null,
                        CorrelationId = null,
                    },
                    new BulkRepaymentItemPayload
                    {
                        Amount = 1.1,
                        RepaymentDate = null,
                        Data = null,
                        IsEarlySettlement = null,
                        InstallmentId = null,
                        LoanId = null,
                        CorrelationId = null,
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "repayments": [
                {
                  "amount": "1000.00",
                  "repayment_date": "2023-10-01T12:00:00.000Z",
                  "data": {
                    "reference": "TXN-001",
                    "type": "transfer"
                  },
                  "installment_id": "installment_123"
                },
                {
                  "amount": "500.50",
                  "data": {
                    "notes": "Payment received in office",
                    "type": "cash"
                  },
                  "loan_id": "loan_456"
                },
                {
                  "amount": "750.00",
                  "repayment_date": "2023-09-30T15:30:00.000Z",
                  "correlation_id": "LOAN-789"
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "task_id": "task_id",
              "total_repayments": 1,
              "estimated_completion_time": "estimated_completion_time"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/repayments/bulk")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Repayments.CreateBulkRepaymentsAsync(
            new BulkRepaymentCreatePayload
            {
                Repayments = new List<BulkRepaymentItemPayload>()
                {
                    new BulkRepaymentItemPayload
                    {
                        Amount = "1000.00",
                        RepaymentDate = DateTime.Parse(
                            "2023-10-01T12:00:00.000Z",
                            null,
                            DateTimeStyles.AdjustToUniversal
                        ),
                        Data = new Dictionary<string, object?>()
                        {
                            { "reference", "TXN-001" },
                            { "type", "transfer" },
                        },
                        InstallmentId = "installment_123",
                    },
                    new BulkRepaymentItemPayload
                    {
                        Amount = "500.50",
                        Data = new Dictionary<string, object?>()
                        {
                            { "notes", "Payment received in office" },
                            { "type", "cash" },
                        },
                        LoanId = "loan_456",
                    },
                    new BulkRepaymentItemPayload
                    {
                        Amount = "750.00",
                        RepaymentDate = DateTime.Parse(
                            "2023-09-30T15:30:00.000Z",
                            null,
                            DateTimeStyles.AdjustToUniversal
                        ),
                        CorrelationId = "LOAN-789",
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
