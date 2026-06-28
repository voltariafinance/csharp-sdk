using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Repayments;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateRepaymentTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "amount": 1.1
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "created_at": "2024-01-15T09:30:00.000Z",
              "client_id": "client_id",
              "loan_id": "loan_id",
              "installment_id": "installment_id",
              "amount": "amount",
              "repayment_date": "2024-01-15T09:30:00.000Z",
              "type": "type",
              "data": {
                "data": {
                  "key": "value"
                }
              },
              "is_early_settlement": true,
              "principal_amount": "principal_amount",
              "interest_amount": "interest_amount",
              "late_fee_amount": "late_fee_amount"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/repayments")
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

        var response = await Client.Repayments.CreateRepaymentAsync(
            new RepaymentCreatePayload
            {
                Amount = 1.1,
                RepaymentDate = null,
                Data = null,
                IsEarlySettlement = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "amount": 1.1
            }
            """;

        const string mockResponse = """
            {
              "id": "repayment_log_123",
              "created_at": "2023-10-01T12:00:00.000Z",
              "client_id": "client_123",
              "loan_id": "loan_456",
              "installment_id": "installment_789",
              "amount": "1000.00",
              "repayment_date": "2024-01-15T09:30:00.000Z",
              "type": "type",
              "data": {
                "key": "value"
              },
              "is_early_settlement": true,
              "principal_amount": "principal_amount",
              "interest_amount": "interest_amount",
              "late_fee_amount": "late_fee_amount"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/repayments")
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

        var response = await Client.Repayments.CreateRepaymentAsync(
            new RepaymentCreatePayload { Amount = 1.1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
