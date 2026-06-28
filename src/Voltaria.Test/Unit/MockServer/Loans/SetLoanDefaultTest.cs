using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Loans;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SetLoanDefaultTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "default_date": "2023-01-15",
              "sold_amount": 1.1
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z",
              "partner_id": "partner_id",
              "client_id": "client_id",
              "currency": "eur",
              "amount": "amount",
              "status": "pending",
              "irr": "irr",
              "loan_date": "2023-01-15",
              "currency_rate": "currency_rate",
              "correlation_id": "correlation_id",
              "payment_status": "pending",
              "payment_reference": "payment_reference",
              "early_settlement_date": "2023-01-15",
              "early_settlement_amount": "early_settlement_amount",
              "data": {
                "data": {
                  "key": "value"
                }
              },
              "installments": [
                {
                  "id": "id",
                  "amount": "amount",
                  "installment_number": 1,
                  "expected_repayment_at": "2024-01-15T09:30:00.000Z",
                  "status": "pending",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z"
                },
                {
                  "id": "id",
                  "amount": "amount",
                  "installment_number": 1,
                  "expected_repayment_at": "2024-01-15T09:30:00.000Z",
                  "status": "pending",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/loans/loan_id/set-default")
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

        var response = await Client.Loans.SetLoanDefaultAsync(
            new LoanDefaultPayload
            {
                LoanId = "loan_id",
                DefaultDate = new DateOnly(2023, 1, 15),
                SoldAmount = 1.1,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "default_date": "2026-06-23",
              "sold_amount": 1.1
            }
            """;

        const string mockResponse = """
            {
              "id": "loan_12345",
              "created_at": "2023-05-01T10:00:00.000Z",
              "updated_at": "2023-05-01T10:00:00.000Z",
              "partner_id": "partner_1",
              "client_id": "client_ACME",
              "currency": "eur",
              "amount": "50000.00",
              "status": "pending",
              "irr": "irr",
              "loan_date": "2023-01-15",
              "currency_rate": "1.00",
              "correlation_id": "correlation_id",
              "payment_status": "pending",
              "payment_reference": "payment_reference",
              "early_settlement_date": "2023-01-15",
              "early_settlement_amount": "early_settlement_amount",
              "data": {
                "key": "value"
              },
              "installments": [
                {
                  "id": "installment_67890",
                  "amount": "51000.00",
                  "installment_number": 1,
                  "expected_repayment_at": "2023-06-01T00:00:00.000Z",
                  "status": "pending",
                  "created_at": "2023-05-01T10:00:00.000Z",
                  "updated_at": "2023-05-01T10:00:00.000Z"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/loans/loan_id/set-default")
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

        var response = await Client.Loans.SetLoanDefaultAsync(
            new LoanDefaultPayload
            {
                LoanId = "loan_id",
                DefaultDate = new DateOnly(2026, 6, 23),
                SoldAmount = 1.1,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
