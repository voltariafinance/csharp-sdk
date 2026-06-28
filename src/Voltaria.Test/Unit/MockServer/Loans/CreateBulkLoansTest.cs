using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Loans;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateBulkLoansTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "loans": [
                {
                  "client_id": "client_id",
                  "currency": "eur",
                  "amount": 1.1,
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
                },
                {
                  "client_id": "client_id",
                  "currency": "eur",
                  "amount": 1.1,
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
              ]
            }
            """;

        const string mockResponse = """
            {
              "task_id": "task_id",
              "total_loans": 1,
              "estimated_completion_time": "estimated_completion_time"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/loans/bulk")
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

        var response = await Client.Loans.CreateBulkLoansAsync(
            new BulkLoanCreatePayload
            {
                Loans = new List<BulkLoanItemPayload>()
                {
                    new BulkLoanItemPayload
                    {
                        ClientId = "client_id",
                        Currency = CurrencyEnum.Eur,
                        Amount = 1.1,
                        CorrelationId = null,
                        LoanDate = null,
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
                        Data = null,
                    },
                    new BulkLoanItemPayload
                    {
                        ClientId = "client_id",
                        Currency = CurrencyEnum.Eur,
                        Amount = 1.1,
                        CorrelationId = null,
                        LoanDate = null,
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
                        Data = null,
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
              "loans": [
                {
                  "client_id": "client_123",
                  "currency": "eur",
                  "amount": "50000.00",
                  "correlation_id": "LOAN_001",
                  "loan_date": "2023-05-01",
                  "installments": [
                    {
                      "expected_repayment_at": "2023-06-01",
                      "amount": "26000.00"
                    },
                    {
                      "expected_repayment_at": "2023-07-01",
                      "amount": "26000.00"
                    }
                  ],
                  "data": {
                    "loan_type": "business",
                    "purpose": "expansion"
                  }
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "task_id": "task_id",
              "total_loans": 1,
              "estimated_completion_time": "estimated_completion_time"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/loans/bulk")
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

        var response = await Client.Loans.CreateBulkLoansAsync(
            new BulkLoanCreatePayload
            {
                Loans = new List<BulkLoanItemPayload>()
                {
                    new BulkLoanItemPayload
                    {
                        ClientId = "client_123",
                        Currency = CurrencyEnum.Eur,
                        Amount = "50000.00",
                        CorrelationId = "LOAN_001",
                        LoanDate = new DateOnly(2023, 5, 1),
                        Installments = new List<LoanInstallmentCreatePayload>()
                        {
                            new LoanInstallmentCreatePayload
                            {
                                ExpectedRepaymentAt = new DateOnly(2023, 6, 1),
                                Amount = "26000.00",
                            },
                            new LoanInstallmentCreatePayload
                            {
                                ExpectedRepaymentAt = new DateOnly(2023, 7, 1),
                                Amount = "26000.00",
                            },
                        },
                        Data = new Dictionary<string, object?>()
                        {
                            { "loan_type", "business" },
                            { "purpose", "expansion" },
                        },
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
