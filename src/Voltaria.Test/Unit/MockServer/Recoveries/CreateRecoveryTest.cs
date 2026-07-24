using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Recoveries;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateRecoveryTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "loan_id": "loan_id",
              "amount": 1.1,
              "currency": "eur",
              "recovery_date": "2023-01-15"
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z",
              "partner_id": "partner_id",
              "client_id": "client_id",
              "loan_id": "loan_id",
              "amount": "amount",
              "currency": "eur",
              "recovery_date": "2023-01-15",
              "notes": "notes"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/recoveries")
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

        var response = await Client.Recoveries.CreateRecoveryAsync(
            new RecoveryCreatePayload
            {
                LoanId = "loan_id",
                Amount = 1.1,
                Currency = CurrencyEnum.Eur,
                RecoveryDate = new DateOnly(2023, 1, 15),
                Notes = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "loan_id": "loan_abc123",
              "amount": 1.1,
              "currency": "eur",
              "recovery_date": "2026-07-15"
            }
            """;

        const string mockResponse = """
            {
              "id": "recovery_abc123",
              "created_at": "2026-07-15T10:00:00.000Z",
              "updated_at": "2026-07-15T10:00:00.000Z",
              "partner_id": "partner_123",
              "client_id": "client_123",
              "loan_id": "loan_abc123",
              "amount": "1500.00",
              "currency": "eur",
              "recovery_date": "2026-07-15",
              "notes": "notes"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/recoveries")
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

        var response = await Client.Recoveries.CreateRecoveryAsync(
            new RecoveryCreatePayload
            {
                LoanId = "loan_abc123",
                Amount = 1.1,
                Currency = CurrencyEnum.Eur,
                RecoveryDate = new DateOnly(2026, 7, 15),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
