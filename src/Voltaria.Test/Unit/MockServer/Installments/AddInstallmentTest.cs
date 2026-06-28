using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Installments;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AddInstallmentTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "loan_id": "loan_id",
              "installments": [
                {
                  "expected_repayment_at": "2023-01-15",
                  "amount": 1.1
                },
                {
                  "expected_repayment_at": "2023-01-15",
                  "amount": 1.1
                }
              ]
            }
            """;

        const string mockResponse = """
            [
              {
                "id": "id",
                "created_at": "2024-01-15T09:30:00.000Z",
                "updated_at": "2024-01-15T09:30:00.000Z",
                "partner_id": "partner_id",
                "client_id": "client_id",
                "currency": "eur",
                "status": "active",
                "loan_id": "loan_id",
                "amount": "amount",
                "expected_repayment_at": "2024-01-15T09:30:00.000Z",
                "installment_number": 1,
                "installments": 1,
                "principal": "principal",
                "interest": "interest",
                "repayment_amount": "repayment_amount",
                "repayment_at": "2024-01-15T09:30:00.000Z"
              },
              {
                "id": "id",
                "created_at": "2024-01-15T09:30:00.000Z",
                "updated_at": "2024-01-15T09:30:00.000Z",
                "partner_id": "partner_id",
                "client_id": "client_id",
                "currency": "eur",
                "status": "active",
                "loan_id": "loan_id",
                "amount": "amount",
                "expected_repayment_at": "2024-01-15T09:30:00.000Z",
                "installment_number": 1,
                "installments": 1,
                "principal": "principal",
                "interest": "interest",
                "repayment_amount": "repayment_amount",
                "repayment_at": "2024-01-15T09:30:00.000Z"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/installments")
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

        var response = await Client.Installments.AddInstallmentAsync(
            new InstallmentCreatePayload
            {
                LoanId = "loan_id",
                Installments = new List<LoanInstallmentCreatePayload>()
                {
                    new LoanInstallmentCreatePayload
                    {
                        ExpectedRepaymentAt = new DateOnly(2023, 1, 15),
                        Amount = 1.1,
                    },
                    new LoanInstallmentCreatePayload
                    {
                        ExpectedRepaymentAt = new DateOnly(2023, 1, 15),
                        Amount = 1.1,
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
              "loan_id": "loan_12345",
              "installments": [
                {
                  "expected_repayment_at": "2025-12-01",
                  "amount": "1000.00"
                },
                {
                  "expected_repayment_at": "2026-01-01",
                  "amount": "1000.00"
                }
              ]
            }
            """;

        const string mockResponse = """
            [
              {
                "id": "installment_12345",
                "created_at": "2025-01-01T00:00:00.000Z",
                "updated_at": "2025-01-01T00:00:00.000Z",
                "partner_id": "partner_12345",
                "client_id": "client_12345",
                "currency": "eur",
                "status": "active",
                "loan_id": "loan_12345",
                "amount": "1000.00",
                "expected_repayment_at": "2025-01-01T00:00:00.000Z",
                "installment_number": 1,
                "installments": 6,
                "principal": "800.00",
                "interest": "200.00",
                "repayment_amount": "repayment_amount",
                "repayment_at": "2024-01-15T09:30:00.000Z"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/installments")
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

        var response = await Client.Installments.AddInstallmentAsync(
            new InstallmentCreatePayload
            {
                LoanId = "loan_12345",
                Installments = new List<LoanInstallmentCreatePayload>()
                {
                    new LoanInstallmentCreatePayload
                    {
                        ExpectedRepaymentAt = new DateOnly(2025, 12, 1),
                        Amount = "1000.00",
                    },
                    new LoanInstallmentCreatePayload
                    {
                        ExpectedRepaymentAt = new DateOnly(2026, 1, 1),
                        Amount = "1000.00",
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
