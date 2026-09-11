using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Loans;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CalculateSettlementTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "loan_id": "loan_id",
              "settlement_date": "2023-01-15",
              "settlement_amount": "settlement_amount",
              "settlement_irr": "settlement_irr",
              "original_irr": "original_irr",
              "minimum_fee": "minimum_fee"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/loans/loan_id/calculate-settlement")
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

        var response = await Client.Loans.CalculateSettlementAsync(
            new EarlySettlementPayload { LoanId = "loan_id", SettlementDate = null }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "loan_id": "loan_12345",
              "settlement_date": "2026-09-07",
              "settlement_amount": "49000.00",
              "settlement_irr": "0.05",
              "original_irr": "original_irr",
              "minimum_fee": "minimum_fee"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/loans/loan_id/calculate-settlement")
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

        var response = await Client.Loans.CalculateSettlementAsync(
            new EarlySettlementPayload { LoanId = "loan_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
